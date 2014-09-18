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

    /// <summary>
    /// Cache to get Sport and Bet type name.
    /// </summary>
    internal static class CacheRef
    {
        public static string GetSportName(int sportId, LanguageCode lang)
        {
            return RefData.GetSportName(sportId.ToString(CultureInfo.InvariantCulture), TWLang(lang));
        }

        public static string GetBettype(int bettypeId, LanguageCode lang)
        {
            return RefData.GetBetTypeName(bettypeId.ToString(CultureInfo.InvariantCulture), TWLang(lang));
        }

        /// <summary>
        /// Language code defined by TW team.
        /// </summary>
        /// <param name="lang">The current language of our system.</param>
        /// <returns>
        /// The language code.
        /// </returns>
        private static string TWLang(LanguageCode lang)
        {
            switch (lang)
            {
                case LanguageCode.English: return "en";
                case LanguageCode.Taiwan: return "ch";
                case LanguageCode.Chinese: return "cs";
                case LanguageCode.Japanese: return "jp";
                case LanguageCode.Thailand: return "th";
                case LanguageCode.Vietnamese: return "vn";
                default: return "en";
            }
        }
    }
}
