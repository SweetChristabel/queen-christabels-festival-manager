
using BepInEx;
using UnityEngine;

namespace PharaohFestivalManager
{
    [BepInPlugin(
        "com.pharaohfestivalmanager.main",
        "Pharaoh Festival Manager",
        "0.1.1"
    )]
    public class Plugin : BaseUnityPlugin
    {
        private MapLifecycleHandler _mapLifecycleHandler;
        private void Awake()
        {   

            Logger.LogInfo("Pharaoh Festival Manager loaded!");


            _mapLifecycleHandler = new MapLifecycleHandler(Logger);
            _mapLifecycleHandler.Subscribe();
        }
    }
}
