﻿using UseCase1.Models;

namespace UseCase1.Extensions
{
    public static class CountryExtensions
    {
        public static List<Country> FilterByCommonName(this List<Country> countries, string str)
        {
            return countries.Where(x => x.Name?.Common?.Contains(str, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
        }

        public static List<Country> FilterByPopulation(this List<Country> countries, int maxPopulationInMilions)
        {
            int maxPopulation = maxPopulationInMilions * 1000000;
            return countries.Where(x => x.Population < maxPopulation).ToList();
        }
    }
}
