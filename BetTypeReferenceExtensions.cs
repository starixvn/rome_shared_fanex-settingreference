// --------------------------------------------------------------------------
// <copyright file="BetTypeReferenceExtensions.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.12">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference
{
    using System.Web.Mvc;

    /// <summary>
    /// PT Information Extensions.
    /// </summary>
    public static class BetTypeReferenceExtensions
    {
        public static BetTypeReferenceService RenderBetTypeReference(
            this HtmlHelper htmlHelper,
            int customerId,
            int roleId,
            bool isShowAll,
            string siteDBGroupIp,
            int siteDBGroupId)
        {
            return RenderBetTypeReference(htmlHelper, customerId, roleId, isShowAll, siteDBGroupIp, siteDBGroupId, null);
        }

        public static BetTypeReferenceService RenderBetTypeReference(this HtmlHelper htmlHelper, bool isShowAll)
        {
            return RenderBetTypeReference(htmlHelper, 0, 0, isShowAll, string.Empty, 0, null);
        }

        public static BetTypeReferenceService RenderBetTypeReference(this HtmlHelper htmlHelper,
            bool isShowAll,
            string siteDBGroupIp,
            int siteDBGroupId,
            int[] exclusiveRefSportIds)
        {
            return RenderBetTypeReference(htmlHelper, 0, 0, isShowAll, siteDBGroupIp, siteDBGroupId, exclusiveRefSportIds);
        }

        private static BetTypeReferenceService RenderBetTypeReference(
            this HtmlHelper htmlHelper,
            int customerId,
            int roleId,
            bool isShowAll,
            string siteDBGroupIp,
            int siteDBGroupId,
            params int[] exclusiveRefSportIds)
        {
            BetTypeReferenceCriteria criteria = new BetTypeReferenceCriteria
            {
                CustomerId = customerId,
                RoleId = roleId,
                IsShowAll = isShowAll,
                SiteDBGroupId = siteDBGroupId,
                SiteDBGroupIp = siteDBGroupIp
            };

            return new BetTypeReferenceService(criteria, exclusiveRefSportIds);
        }
    }
}
