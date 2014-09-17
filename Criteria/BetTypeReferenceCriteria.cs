// --------------------------------------------------------------------------
// <copyright file="BetTypeReferenceCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.12">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// PT Information Criteria.
    /// </summary>
    public class BetTypeReferenceCriteria : CriteriaBase
    {
        [SpParam(SqlParamName = "CustId")]
        public int CustomerId { get; set; }

        public int RoleId { get; set; }

        public override string GetSettingKey()
        {
            return "PositionTaking_RefSportTypeAndBetType";
        }

        public override bool IsValid()
        {
            return CustomerId >= 0;
        }
    }
}
