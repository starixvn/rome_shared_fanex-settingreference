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
        /// <param name="language">The language code.</param>
        /// <returns>The html string.</returns>
        public static BetTypeReferenceService RenderBetTypeReference(
            this HtmlHelper htmlHelper,
            int customerId = 0,
            int roleId = 0,
            LanguageCode language = LanguageCode.English)
        {
            BetTypeReferenceCriteria criteria = new BetTypeReferenceCriteria { CustomerId = customerId, RoleId = roleId };
            return new BetTypeReferenceService(criteria, language);
        }
    }
}
