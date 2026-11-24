using BepInEx.Logging;
using System.Collections.Generic;
using System.Drawing.Text;
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

        private bool HasFestivalSquare()
        {
            return GlobalAccessor.Level
                .GetStoredBuildings<UniqueBuilding>(false)
                .Any(b => b.Type == BuildingType.FestivalSquare);
        } 

        private bool HasMinimumPopulation()
        {
            return PopulationManager.Instance.TotalPopulation >=
            FestivalConfig.MinimumPopulation.Value;
        }
        private bool HasPendingFestival()
        {
            return ReligionManager.Instance.NextFestival != null;
        }

        private bool CanAffordFestival(FestivalSize size, int treasury)
        {
            if (treasury <= 0)
                return false;

            int cost = ReligionManager.Instance.GetFestivalCostInDeben(size);

            return cost <= treasury * FestivalConfig.TreasuryLimit.Value;
        }

        private bool CanAffordGrandFestival(int storedBeer)
        {
            if (storedBeer <= 0)
                return false;

            int beerCost = ReligionManager.Instance.GetFestivalCostInBeer();

            return beerCost <= storedBeer * FestivalConfig.BeerLimit.Value;
        }

        private int GetTreasury()
        {
            return GlobalAccessor.Level.Treasury;
        }

        private int GetStoredBeer()
        {
            return LevelManager.Instance.GetGoodTotalStoredQuantity(
                Good.Beer,
                ignoreWorkforce:true
            );
        }

        private DeityName? GetScheduledDeity()
        {
            return FestivalScheduler.GetScheduledDeity(
                TimeManager.Instance.CurrentMonth,
                ReligionManager.Instance.ActiveDeities
            );
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

        private void PrepareFestival(DeityName deity, FestivalSize size)
        {
            bool success = ReligionManager.Instance.PrepareFestival(deity, size);
            if (success)
            {
                _logger.LogInfo($"Prepared {size} festival for {deity}.");
            }
            else
            {
                _logger.LogWarning($"Failed to prepare {size} festival for {deity}.");
            }
        }


        public void CheckGameState()
        {
            if (!FestivalConfig.ModEnabled.Value)
            return;

            DeityName? scheduledDeity = GetScheduledDeity();
            if (!scheduledDeity.HasValue)
            {
                return;
            }

            if (!HasFestivalSquare())
            {
                _logger.LogInfo("Festival skipped: No Festival Square.");
                return;
            }

            if (!HasMinimumPopulation())
            {
                _logger.LogInfo("Festival skipped: Minimum population not met.");
                return;
            }

            if (HasPendingFestival())
            {
                _logger.LogInfo("Festival skipped: Festival already scheduled.");
                return;
            }

            int treasury = GetTreasury();
            int storedBeer = GetStoredBeer();

            FestivalSize? selectedSize = SelectFestivalSize(
                treasury,
                storedBeer,
                allowGrandFestival:true
            );

            if (!selectedSize.HasValue)
            {
                _logger.LogInfo("Festival skipped: Insufficient resources.");
                return;
            }

            PrepareFestival(scheduledDeity.Value, selectedSize.Value);

        }   


    }



}