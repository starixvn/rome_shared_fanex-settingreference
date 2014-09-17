// --------------------------------------------------------------------------
// <copyright file="BetTypeReferenceService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.12">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using Fanex.Data.Repository;
    using Fanex.PTSetting.BettypeReference.Criteria;
    using Fanex.PTSetting.BettypeReference.Enums;
    using Fanex.PTSetting.BettypeReference.Models;
    using Fanex.PTSetting.BettypeReference.Views;

    /// <summary>
    /// PT Information Service.
    /// </summary>
    public class BetTypeReferenceService : IHtmlString
    {
        private readonly BetTypeReferenceCriteria _criteria;
        private readonly DynamicRepository _dynamicRepository;
        private readonly LanguageCode _language;

        public BetTypeReferenceService(BetTypeReferenceCriteria criteria, LanguageCode language)
        {
            _language = language;
            Thread.CurrentThread.CurrentCulture = new CultureInfo((int)_language);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            _criteria = criteria;
            _dynamicRepository = new DynamicRepository();
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>
        /// An HTML-encoded string.
        /// </returns>
        public string ToHtmlString()
        {
            BetTypeReferenceView_Template tpl = new BetTypeReferenceView_Template();
            tpl.SportSection.Clear();

            var refSports = GetBetTypeReferences();
            int refSportCount = refSports == null ? 0 : refSports.Count;
            for (int i = 0; i < refSportCount; i++)
            {
                tpl.SportSection.Append(BuildSport(refSports[i], i == 0));
            }

            return tpl.ToString();    
        }

        #region TplCore render Html

        /// <summary>
        /// Builds the sport.
        /// </summary>
        /// <param name="refSport">The sport.</param>
        /// <param name="firstSport">If set to <c>true</c> [first sport].</param>
        /// <returns>The sport section html.</returns>
        private static BetTypeReferenceView_SportSection_Block BuildSport(SportTypeReference refSport, bool firstSport)
        {
            BetTypeReferenceView_SportSection_Block sportSection = new BetTypeReferenceView_SportSection_Block();
            sportSection.BetSection.Clear();

            sportSection.RefSportName = refSport.RefSportName;
            if (firstSport)
            {
                sportSection.FirstSportClass = "first-child";
                sportSection.CollapseExpandClass = "expand-icon";
                sportSection.HideClass = string.Empty;
            }
            else
            {
                sportSection.FirstSportClass = string.Empty;
                sportSection.CollapseExpandClass = "collapse-icon";
                sportSection.HideClass = "hide";
            }

            foreach (var refBettype in refSport.RefBetTypes)
            {
                BuildBetType(sportSection, refBettype);
            }

            return sportSection;
        }

        /// <summary>
        /// Builds the type of the bet.
        /// </summary>
        /// <param name="sportSection">The sport section.</param>
        /// <param name="bettype">The group.</param>
        private static void BuildBetType(BetTypeReferenceView_SportSection_Block sportSection, BetTypeRef bettype)
        {
            BetTypeReferenceView_SportSection_BetSection_Block betSection = null;

            var sporttypes = bettype.SportTypes;
            int sportCount = sporttypes == null ? 0 : sporttypes.Count;
            for (int i = 0; i < sportCount; i++)
            {
                betSection = new BetTypeReferenceView_SportSection_BetSection_Block();
                if (i == 0)
                {
                    betSection.FirstRow.NumOfBetType = sportCount.ToString(CultureInfo.InvariantCulture);
                    betSection.FirstRow.RefBetTypeName = bettype.RefBetTypeName;
                }
                else
                {
                    betSection.FirstRow.Clear();
                }

                betSection.SportName = sporttypes[i].SportName;
                betSection.BetTypeName = sporttypes[i].BetTypeName;

                sportSection.BetSection.Append(betSection);
            }
        }

        #endregion

        /// <summary>
        /// Gets the PT information.
        /// </summary>
        /// <returns>
        /// The list of Sport object.
        /// </returns>
        private IList<SportTypeReference> GetBetTypeReferences()
        {
            int refSportId;
            BetTypeRef refBettype;
            SportTypeReference refSporttype;
            IDictionary<int, SportTypeReference> refSporttypeHash = new Dictionary<int, SportTypeReference>();

            var rawdata = _dynamicRepository.Fetch<RawBetTypeReference>(_criteria)
                .GroupBy(r => new { r.SportTypeRef, r.BetTypeRef });
            foreach (var group in rawdata)
            {
                refBettype = new BetTypeRef
                {
                    RefBetTypeId = group.Key.BetTypeRef,
                    RefBetTypeName = CacheRef.GetBettype(group.Key.BetTypeRef, _language)
                };

                foreach (var item in group)
                {
                    refBettype.SportTypes.Add(new SportType 
                    {
                        SportId = item.SportType,
                        SportName = CacheRef.GetSportName(item.SportType, _language),
                        BetTypeId = item.BetType,
                        BetTypeName = CacheRef.GetBettype(item.BetType, _language)
                    });    
                }

                refSportId = group.Key.SportTypeRef;
                if (!refSporttypeHash.TryGetValue(refSportId, out refSporttype))
                {
                    refSporttype = new SportTypeReference { RefSportId = refSportId, RefSportName = CacheRef.GetSportName(refSportId, _language) };
                    refSporttypeHash.Add(refSportId, refSporttype);   
                }

                refSporttype.RefBetTypes.Add(refBettype);
            }

            return refSporttypeHash.Values.ToList();
        }
    }
}
