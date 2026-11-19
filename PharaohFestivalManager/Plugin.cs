
using BepInEx;
using UnityEngine;

namespace PharaohFestivalManager
{
    [BepInPlugin(
        "com.pharaohfestivalmanager.main",
        "Pharaoh Festival Manager",
        "0.1.0"
    )]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Pharaoh Festival Manager loaded!");
        }
    }
}
