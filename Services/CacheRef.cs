// --------------------------------------------------------------------------
// <copyright file="CacheRef.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2014.09.15">Created</change>
// </history>
// --------------------------------------------------------------------------

namespace Fanex.PTSetting.BettypeReference
{
    using System.Globalization;
    using RemotingRef;
    using System.Threading;

    /// <summary>
    /// Cache to get Sport and Bet type name.
    /// </summary>
    internal static class CacheRef
    {
        private readonly static IRemotingRefService remotingRefService = new RemotingRefService();
        private const string SportRefId = "DummySport";

        public static string GetSportName(int sportId)
        {
            var sportName = remotingRefService.GetSportName(sportId.ToString(CultureInfo.InvariantCulture), Thread.CurrentThread.CurrentCulture.Name);

            if (string.IsNullOrWhiteSpace(sportName))
            {
                sportName = remotingRefService.GetResourceDataByRefIdAndResourceId(
                    SportRefId,
                    sportId.ToString(CultureInfo.InvariantCulture),
                    Thread.CurrentThread.CurrentCulture.Name,
                    string.Empty);
            }

            return sportName;
        }

        public static string GetBettype(int bettypeId)
        {
            return remotingRefService.GetBetTypeName(bettypeId.ToString(CultureInfo.InvariantCulture), Thread.CurrentThread.CurrentCulture.Name);
        }
    }
}
