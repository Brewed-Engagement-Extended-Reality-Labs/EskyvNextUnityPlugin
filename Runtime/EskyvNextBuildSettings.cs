using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

namespace BEER.XR.EskyvNext
{
    /// <summary>
    /// Build-time settings for MockHMD provider.
    /// </summary>
    [XRConfigurationData("EskyvNextHMD", EskyvNextBuildSettings.BuildSettingsKey)]
    public class EskyvNextBuildSettings : ScriptableObject
    {
        public const string BuildSettingsKey = "com.beer.xr.eskyvnext.settings";

        /// <summary>
        /// Stereo rendering mode.
        /// </summary>
        public enum RenderMode
        {
            /// <summary>
            /// Submit separate draw calls for each eye.
            /// </summary>
            MultiPass,

            /// <summary>
            /// Submit one draw call for both eyes.
            /// </summary>
            SinglePassInstanced,
        };

        /// <summary>
        /// Stereo rendering mode.
        /// </summary>
        public RenderMode renderMode;

        /// <summary>
        /// Runtime access to build settings.
        /// </summary>
        public static EskyvNextBuildSettings Instance
        {
            get
            {
                EskyvNextBuildSettings settings = null;
#if UNITY_EDITOR
                UnityEngine.Object obj = null;
                UnityEditor.EditorBuildSettings.TryGetConfigObject(BuildSettingsKey, out obj);
                if (obj == null || !(obj is EskyvNextBuildSettings))
                    return null;
                settings = (EskyvNextBuildSettings) obj;
#else
                settings = s_RuntimeInstance;
                if (settings == null)
                    settings = new EskyvNextBuildSettings();
#endif
                return settings;
            }
        }

#if !UNITY_EDITOR
        /// <summary>Static instance that will hold the runtime asset instance we created in our build process.</summary>
        public static EskyvNextBuildSettings s_RuntimeInstance = null;

        void OnEnable()
        {
            s_RuntimeInstance = this;
        }
#endif
    }
}