﻿using BepInEx.Configuration;
using BepInEx.Logging;

namespace LoveMachine.Core
{
    public class CoreConfig
    {
        public const string PluginName = "LoveMachine";
        public const string GUID = "Sauceke.LoveMachine";
        public const string Version = VersionInfo.Version;

        public static ManualLogSource Logger { get; set; }
        public static string PluginDirectoryPath { get; set; }

        public static ConfigEntry<string> WebSocketAddress { get; internal set; }
        public static ConfigEntry<bool> SaveDeviceSettings { get; internal set; }
        public static ConfigEntry<string> DeviceSettingsJson { get; internal set; }

        public static ConfigEntry<int> MaxStrokesPerMinute { get; internal set; }
        public static ConfigEntry<int> LatencyMs { get; internal set; }
        public static ConfigEntry<int> SlowStrokeZoneMin { get; internal set; }
        public static ConfigEntry<int> SlowStrokeZoneMax { get; internal set; }
        public static ConfigEntry<int> FastStrokeZoneMin { get; internal set; }
        public static ConfigEntry<int> FastStrokeZoneMax { get; internal set; }
        public static ConfigEntry<float> StrokeLengthRealism { get; internal set; }
        public static ConfigEntry<float> OrgasmDepth { get; internal set; }
        public static ConfigEntry<int> OrgasmShakingFrequency { get; internal set; }
        public static ConfigEntry<int> HardSexIntensity { get; internal set; }
        public static ConfigEntry<bool> SmoothStroking { get; internal set; }

        public static ConfigEntry<bool> SyncVibrationWithAnimation { get; internal set; }
        public static ConfigEntry<int> VibrationUpdateFrequency { get; internal set; }
        public static ConfigEntry<int> VibrationIntensityMin { get; internal set; }
        public static ConfigEntry<int> VibrationIntensityMax { get; internal set; }

        public static ConfigEntry<float> RotationSpeedRatio { get; internal set; }
        public static ConfigEntry<float> RotationDirectionChangeChance { get; internal set; }
        public static ConfigEntry<KeyboardShortcut> KillSwitch { get; internal set; }
        public static ConfigEntry<KeyboardShortcut> ResumeSwitch { get; internal set; }

        // experimental stuff for KK/KKS
        public static ConfigEntry<bool> ReduceAnimationSpeeds;
        public static ConfigEntry<bool> SuppressAnimationBlending;
        public static ConfigEntry<bool> EnableCalorDepthControl;
        public static ConfigEntry<bool> EnableHotdogDepthControl;
        public static ConfigEntry<string> HotdogServerAddress;
    }
}
