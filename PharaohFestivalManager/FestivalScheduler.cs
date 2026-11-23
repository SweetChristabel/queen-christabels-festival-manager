using System.Collections.Generic;

namespace PharaohFestivalManager
{
    public static class FestivalScheduler
    {
        private static readonly Dictionary<int, Dictionary<int, int>> Schedules =
            new Dictionary<int, Dictionary<int, int>>
            {   //One deity: two festivals per year
                {1, new Dictionary<int, int>
                    {
                        {1, 0}, //February
                        {7, 0}  // August
                    }
                },


                // Two deities
                { 2, new Dictionary<int, int>
                    {
                        { 1, 0 },  // February
                        { 7, 1 }   // August
                    }
                },

                // Three deities
                { 3, new Dictionary<int, int>
                    {
                        { 1, 0 },  // February
                        { 5, 1 },  // June
                        { 9, 2 }   // October
                    }
                },

                // Four deities
                { 4, new Dictionary<int, int>
                    {
                        { 1, 0 },  // February
                        { 4, 1 },  // May
                        { 7, 2 },  // August
                        { 10, 3 }  // November
                    }
                },

                // Five deities
                { 5, new Dictionary<int, int>
                    {
                        { 1, 0 },  // February
                        { 3, 1 },  // April
                        { 6, 2 },  // July
                        { 8, 3 },  // September
                        { 10, 4 }  // November
                    }
                }
            };

        public static DeityName? GetScheduledDeity(
            int currentMonth,
            IList<DeityName> activeDeities)
        {
            int deityCount = activeDeities.Count;

            if(!Schedules.TryGetValue(deityCount, out var schedule))
            {
                return null;
            }

            if (!schedule.TryGetValue(currentMonth, out int deityIndex))
            {
                return null;
            }

            return activeDeities[deityIndex];
        }
    }
}



