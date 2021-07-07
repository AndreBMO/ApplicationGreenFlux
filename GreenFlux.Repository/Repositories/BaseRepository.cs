﻿using GreenFlux.Domain.Model;
using System.Collections.Generic;

namespace GreenFlux.Infrastructure
{
    public class BaseRepository
    {
        public static readonly Dictionary<string, CountryCode> countryCodes =
            new Dictionary<string, CountryCode> 
            {
                { "AL", CountryCode.AL },
                { "AD", CountryCode.AD },
                { "AR", CountryCode.AR },
                { "AT", CountryCode.AT },
                { "AU", CountryCode.AU },
                { "AX", CountryCode.AX },
                { "BB", CountryCode.BB },
                { "BE", CountryCode.BE },
                { "BG", CountryCode.BG },
                { "BJ", CountryCode.BJ },
                { "BO", CountryCode.BO },
                { "BR", CountryCode.BR },
                { "BS", CountryCode.BS },
                { "BW", CountryCode.BW },
                { "BY", CountryCode.BY },
                { "BZ", CountryCode.BZ },
                { "CA", CountryCode.CA },
                { "CH", CountryCode.CH },
                { "CL", CountryCode.CL },
                { "CN", CountryCode.CN },
                { "CO", CountryCode.CO },
                { "CR", CountryCode.CR },
                { "CU", CountryCode.CU },
                { "CY", CountryCode.CY },
                { "CZ", CountryCode.CZ },
                { "DE", CountryCode.DE },
                { "DK", CountryCode.DK },
                { "DO", CountryCode.DO },
                { "EC", CountryCode.EC },
                { "EE", CountryCode.EE },
                { "EG", CountryCode.EG },
                { "ES", CountryCode.ES },
                { "FI", CountryCode.FI },
                { "FO", CountryCode.FO },
                { "FR", CountryCode.FR },
                { "GA", CountryCode.GA },
                { "GB", CountryCode.GB },
                { "GD", CountryCode.GD },
                { "GI", CountryCode.GI },
                { "GL", CountryCode.GL },
                { "GM", CountryCode.GM },
                { "GR", CountryCode.GR },
                { "GT", CountryCode.GT },
                { "GG", CountryCode.GG },
                { "GY", CountryCode.GY },
                { "HN", CountryCode.HN },
                { "HR", CountryCode.HR },
                { "HT", CountryCode.HT },
                { "HU", CountryCode.HU },
                { "IE", CountryCode.IE },
                { "ID", CountryCode.ID },
                { "IM", CountryCode.IM },
                { "IS", CountryCode.IS },
                { "IT", CountryCode.IT },
                { "LI", CountryCode.LI },
                { "LS", CountryCode.LS },
                { "LT", CountryCode.LT },
                { "LU", CountryCode.LU },
                { "LV", CountryCode.LV },
                { "JE", CountryCode.JE },
                { "JM", CountryCode.JM },
                { "JP", CountryCode.JP },
                { "KR", CountryCode.KR },
                { "MA", CountryCode.MA },
                { "MC", CountryCode.MC },
                { "MD", CountryCode.MD },
                { "ME", CountryCode.ME },
                { "MG", CountryCode.MG },
                { "MK", CountryCode.MK },
                { "MN", CountryCode.MN },
                { "MS", CountryCode.MS },
                { "MT", CountryCode.MT },
                { "MX", CountryCode.MX },
                { "MZ", CountryCode.MZ },
                { "NA", CountryCode.NA },
                { "NE", CountryCode.NE },
                { "NG", CountryCode.NG },
                { "NI", CountryCode.NI },
                { "NL", CountryCode.NL },
                { "NO", CountryCode.NO },
                { "NZ", CountryCode.NZ },
                { "PA", CountryCode.PA },
                { "PE", CountryCode.PE },
                { "PG", CountryCode.PG },
                { "PL", CountryCode.PL },
                { "PR", CountryCode.PR },
                { "PT", CountryCode.PT },
                { "PY", CountryCode.PY },
                { "RO", CountryCode.RO },
                { "RS", CountryCode.RS },
                { "RU", CountryCode.RU },
                { "SE", CountryCode.SE },
                { "SI", CountryCode.SI },
                { "SJ", CountryCode.SJ },
                { "SK", CountryCode.SK },
                { "SM", CountryCode.SM },
                { "SR", CountryCode.SR },
                { "SV", CountryCode.SV },
                { "TN", CountryCode.TN },
                { "TR", CountryCode.TR },
                { "UA", CountryCode.UA },
                { "US", CountryCode.US },
                { "UY", CountryCode.UY },
                { "VA", CountryCode.VA },
                { "VE", CountryCode.VE },
                { "VN", CountryCode.VN },                
                { "ZA", CountryCode.ZA },
                { "ZW", CountryCode.ZW }
            };
    }
}