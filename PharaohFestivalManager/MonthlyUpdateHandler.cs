using BepInEx.Logging;

namespace PharaohFestivalManager
{
    public class MonthlyUpdateHandler : IMonthlyUpdatable
    {
        private readonly ManualLogSource _logger;
        private readonly FestivalManager _festivalManager;

        public MonthlyUpdateHandler(ManualLogSource logger)
        {
            _logger = logger;
            _festivalManager = new FestivalManager(logger);
            TimeManager.Instance.RegisterMonthlyUpdatable(this);

            _logger.LogInfo("Monthly Update Handler registered!");
        }

        public void MontlhyUpdate()
        {
            _festivalManager.CheckGameState();
        }

    }
}