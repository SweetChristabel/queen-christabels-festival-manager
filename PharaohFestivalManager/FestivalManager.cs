using BepInEx.Logging;
using System.Collections.Generic;
using System.Linq;


namespace PharaohFestivalManager
{

    public class FestivalManager
    {
        private readonly ManualLogSource _logger;
        private const double TreasuryLimit = 0.25;
        private const double GrandBeerLimit = 0.50;


        public FestivalManager(ManualLogSource logger)
        {
            _logger = logger;
        }

        private bool CanAffordFestival(FestivalSize size, int treasury)
        {
            if (treasury <= 0)
                return false;

            int cost = ReligionManager.Instance.GetFestivalCostInDeben(size);

            return cost <= treasury * TreasuryLimit;
        }

        private bool CanAffordGrandFestival(int storedBeer)
        {
            if (storedBeer <= 0)
                return false;

            int beerCost = ReligionManager.Instance.GetFestivalCostInBeer();

            return beerCost <= storedBeer * GrandBeerLimit;
        }

        private FestivalSize? SelectFestivalSize(
            int treasury,
            int storedBeer,
            bool allowGrandFestival)
        {
            if (allowGrandFestival &&
                CanAffordFestival(FestivalSize.Grand, treasury) &&
                CanAffordGrandFestival(storedBeer))
            {
                return FestivalSize.Grand;
            }

            if (CanAffordFestival(FestivalSize.Lavish, treasury))
                return FestivalSize.Lavish;

            if (CanAffordFestival(FestivalSize.Small, treasury))
                return FestivalSize.Small;

            return null;
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

            int treasury = GlobalAccessor.Level.Treasury;
            _logger.LogInfo($"Treasury: {treasury}");

            int storedBeer = LevelManager.Instance.GetGoodTotalStoredQuantity(
                Good.Beer,
                ignoreWorkforce: true
            );
            _logger.LogInfo($"Stored Beer: {storedBeer}");

            if (scheduledDeity.HasValue)
            {
                FestivalSize? selectedSize = SelectFestivalSize(
                    treasury,
                    storedBeer,
                    allowGrandFestival: true
                );

                if (selectedSize.HasValue)
                    _logger.LogInfo($"Selected festival size: {selectedSize.Value}");
                else
                    _logger.LogInfo("No affordable festival size.");
            }


            bool festivalSquareExists = 
                GlobalAccessor.Level
                .GetStoredBuildings<UniqueBuilding>(false)
                .Any(b => b.Type == BuildingType.FestivalSquare);
        }   


    }



}