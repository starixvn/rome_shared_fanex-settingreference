// --------------------------------------------------------------------------
// <copyright file="RawBetTypeReference.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.15">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference.Models
{
    /// <summary>
    /// Raw PT information.
    /// </summary>
    public class RawBetTypeReference
    {
        public int SportType { get; set; }

        public int BetType { get; set; }

        public int SportTypeRef { get; set; }

        public int BetTypeRef { get; set; }
    }
}
