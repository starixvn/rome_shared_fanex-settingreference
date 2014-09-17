// --------------------------------------------------------------------------
// <copyright file="SportTypeReference.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.15">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Ref Sport Type.
    /// </summary>
    internal class SportTypeReference
    {
        public SportTypeReference()
        {
            RefBetTypes = new List<BetTypeRef>();
        }

        public int RefSportId { get; set; }

        public string RefSportName { get; set; }

        public IList<BetTypeRef> RefBetTypes { get; set; }
    }
}
