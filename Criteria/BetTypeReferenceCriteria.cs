// --------------------------------------------------------------------------
// <copyright file="BetTypeReferenceCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.12">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference
{
    using System.Collections;

    /// <summary>
    /// PT Information Criteria.
    /// </summary>
    public class BetTypeReferenceCriteria
    {
        public int CustomerId { get; set; }

        public int RoleId { get; set; }

        public bool IsShowAll { get; set; }

        public string GetSettingKey()
        {
            return "PositionTaking_RefSportTypeAndBetType";
        }

        public Hashtable GetSpParams()
        {
            return new Hashtable 
            {
                { "custid", CustomerId },
                { "roleid", RoleId },
                { "isshowall", IsShowAll }
            };
        }

        public bool IsValid()
        {
            return CustomerId >= 0;
        }
    }
}
