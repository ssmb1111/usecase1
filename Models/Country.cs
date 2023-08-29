﻿namespace UseCase1.Models
{
    public class Country
    {
        public Name? Name { get; set; }

        public string[]? Tld { get; set; }
        public string? Cca2 { get; set; }
        public string? Ccn3 { get; set; }
        public string? Cca3 { get; set; }
        public string? Cioc { get; set; }
        public bool Independent { get; set; }
        public string? Status { get; set; }
        public bool UnMember { get; set; }

        public Dictionary<string, Currency>? Currencies { get; set; }

        public Idd? Idd { get; set; }

        public string[]? Capital { get; set; }
        public string[]? AltSpellings { get; set; }
        public string? Region { get; set; }
        public string? Subregion { get; set; }
        public Dictionary<string, string>? Languages { get; set; }
        public Dictionary<string, Name>? Translations { get; set; }
        public double[]? LatLng { get; set; }
        public bool LandLocked { get; set; }
        public string[]? Borders { get; set; }
        public double Area { get; set; }
        public Dictionary<string, Demonym>? Demonyms { get; set; }
        public string? Flag { get; set; }

        public Maps? Maps { get; set; }

        public int Population { get; set; }
        public Dictionary<int, double>? Gini { get; set; }
        public string? Fifa { get; set; }
        public Car? Car { get; set; }
        public string[]? Timezones { get; set; }
        public string[]? Continents { get; set; }
        public Flags? Flags { get; set; }
        public Flags? CoatOfArms { get; set; }
        public string? StartOfWeek { get; set; }
        public CapitalInfo? CapitalInfo { get; set; }
        public PostalCode? PostalCode { get; set; }
    }
}