// --------------------------------------------------------------------------
// <copyright file="BetTypeRef.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.15">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference
{
    using System.Collections.Generic;

    /// <summary>
    /// RefBetType model.
    /// </summary>
    internal class BetTypeRef
    {
        public BetTypeRef()
        {
            SportTypes = new List<SportType>();
        }

        public int RefBetTypeId { get; set; }

        public string RefBetTypeName { get; set; }

        public IList<SportType> SportTypes { get; set; }
    }
}
