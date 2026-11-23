using BepInEx.Logging;
using System.Collections.Generic;
using System.Linq;


namespace PharaohFestivalManager
{

    public class FestivalManager
    {
        private readonly ManualLogSource _logger;
        public FestivalManager(ManualLogSource logger)
        {
            _logger = logger;
        }

        public void CheckGameState()
        {
            int currentMonth = TimeManager.Instance.CurrentMonth;
            _logger.LogInfo($"Current month: {currentMonth}");

            DeityName? scheduledDeity =
                FestivalScheduler.GetScheduledDeity(
                    currentMonth,
                    ReligionManager.Instance.ActiveDeities
                );

            if (scheduledDeity.HasValue)
            {
                _logger.LogInfo($"Scheduled festival for: {scheduledDeity.Value}");
            }
            else
            {
                _logger.LogInfo("No festival scheduled this month.");
            }

            int treasury = GlobalAccessor.Level.Treasury;
            _logger.LogInfo($"Treasury: {treasury}");

            int storedBeer = LevelManager.Instance.GetGoodTotalStoredQuantity(
                Good.Beer,
                ignoreWorkforce: true
            );
            _logger.LogInfo($"Stored Beer: {storedBeer}");

            bool festivalSquareExists = 
                GlobalAccessor.Level
                .GetStoredBuildings<UniqueBuilding>(false)
                .Any(b => b.Type == BuildingType.FestivalSquare);
            _logger.LogInfo($"Festival Square exists: {festivalSquareExists}");
        }   


    }



}