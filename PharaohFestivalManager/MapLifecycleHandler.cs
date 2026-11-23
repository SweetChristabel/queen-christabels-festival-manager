using BepInEx;
using BepInEx.Logging;

namespace PharaohFestivalManager
{
    public class MapLifecycleHandler
    {
        private readonly ManualLogSource _logger;
        private MonthlyUpdateHandler? _monthlyUpdateHandler;

        public MapLifecycleHandler(ManualLogSource logger)
        {
            _logger = logger;
        }
        
        public void Subscribe()
        {
            ABaseLevelManager.MapDataLoadedEvent += OnMapLoaded;
            ABaseLevelManager.MapDataUnloadedEvent += OnMapUnloaded;
        }

        private void OnMapLoaded(LevelMap level)
        {
            _logger.LogInfo("Map loaded!");

            if (_monthlyUpdateHandler == null)
            {
                _monthlyUpdateHandler = new MonthlyUpdateHandler(_logger);
            }
        }

        private void OnMapUnloaded(LevelMap level)
        {
            _logger.LogInfo("Map unloaded!");
            _monthlyUpdateHandler = null;
        }
    }
}