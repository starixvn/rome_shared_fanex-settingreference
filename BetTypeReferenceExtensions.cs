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
        /// <summary>
        /// Render html string for PT information.
        /// </summary>
        /// <param name="htmlHelper">Html helper object.</param>
        /// <param name="customerId">User ID logged in.</param>
        /// <param name="roleId">Role Id of user logged in.</param>
        /// <param name="isShowAll">If set to <c>true</c> [is show all]:<para></para>
        /// UAT = true.<para></para>
        /// PROD = false.
        /// </param>
        /// <param name="language">The language code.</param>
        /// <returns>
        /// The html string.
        /// </returns>
        public static BetTypeReferenceService RenderBetTypeReference(
            this HtmlHelper htmlHelper,
            int customerId,
            int roleId,
            bool isShowAll,
            LanguageCode language)
        {
            BetTypeReferenceCriteria criteria = new BetTypeReferenceCriteria { CustomerId = customerId, RoleId = roleId, IsShowAll = isShowAll };
            return new BetTypeReferenceService(criteria, language);
        }

        /// <summary>
        /// Renders the bet type reference.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="isShowAll">If set to <c>true</c> [is show all]:<para></para>
        /// UAT = true.<para></para>
        /// PROD = false.
        /// </param>
        /// <returns>The html string.</returns>
        public static BetTypeReferenceService RenderBetTypeReference(this HtmlHelper htmlHelper, bool isShowAll)
        {
            BetTypeReferenceCriteria criteria = new BetTypeReferenceCriteria { IsShowAll = isShowAll };
            return new BetTypeReferenceService(criteria, LanguageCode.English);
        }
    }
}
