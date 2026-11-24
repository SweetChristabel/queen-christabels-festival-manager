using BepInEx.Configuration;

namespace PharaohFestivalManager
{
    public static class FestivalConfig
    {
        public static ConfigEntry<bool> ModEnabled; 
        public static ConfigEntry<bool> GrandFestivalsEnabled;
        public static ConfigEntry<float> TreasuryLimit;
        public static ConfigEntry<float> BeerLimit;

        public static void Initialize(ConfigFile config)
        {
            ModEnabled = config.Bind(
                "General",
                "ModEnabled",
                true,
                "Enable or disable the Pharaoh Festival Manager mod."
            );

            GrandFestivalsEnabled = config.Bind(
                "General",
                "GrandFestivalsEnabled",
                true,
                "Allow grand festivals to be scheduled when the conditions are met."
            );

            TreasuryLimit = config.Bind(
                "General",
                "TreasuryLimit",
                0.25f,
                new ConfigDescription(
                    "The maximum percentage of the treasury that can be spent on a festival.",
                    new AcceptableValueRange<float>(0f, 1f)
                )
            );

            BeerLimit = config.Bind(
                "General",
                "BeerLimit",
                0.50f,
                new ConfigDescription(
                    "The maximum percentage of stored beer that can be spent on a grand festival.",
                    new AcceptableValueRange<float>(0f, 1f)
                )
            );
        }
    }
}