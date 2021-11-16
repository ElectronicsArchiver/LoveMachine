﻿using BepInEx;
using LoveMachine.Core;

namespace LoveMachine.AGH
{
    [BepInPlugin(CoreConfig.GUID, CoreConfig.PluginName, CoreConfig.Version)]
    internal class AGHLoveMachine : BaseUnityPlugin
    {
        private void Start()
        {
            CoreConfig.Logger = Logger;
            PluginInitializer.Initialize(
                plugin: this,
                girlMappingHeader: null,
                girlMappingOptions: null,
                actionMappingHeader: null,
                actionMappingOptions: null,
                typeof(HoukagoRinkanButtplugStrokerController),
                typeof(HoukagoRinkanButtplugVibrationController));
            Hooks.InstallHooks();
        }
    }
}
