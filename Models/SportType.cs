// --------------------------------------------------------------------------
// <copyright file="SportType.cs" company="Nexcel Solutions Vietnam">
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
    /// SportType model.
    /// </summary>
    internal class SportType
    {
        public int SportId { get; set; }

        public string SportName { get; set; }

        public int BetTypeId { get; set; }

        public string BetTypeName { get; set; }
    }
}
