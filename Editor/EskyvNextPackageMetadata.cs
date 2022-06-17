#if XR_MGMT_320
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.XR.Management.Metadata;
using UnityEngine;

namespace BEER.XR.EskyvNext.Editor
{
    internal class EskyvNextMetadata : IXRPackage
    {
        private class EskyvNextPackageMetadata : IXRPackageMetadata
        {
            public string packageName => "EskyvNext Plugin";
            public string packageId => "com.beer.xr.eskyvnext";
            public string settingsType => "com.beer.xr.eskyvnext.EskyvNextBuildSettings";
            private static readonly List<IXRLoaderMetadata> s_LoaderMetadata = new List<IXRLoaderMetadata>() { new EskyvNextLoaderMetadata() };
            public List<IXRLoaderMetadata> loaderMetadata => s_LoaderMetadata;
        }

        private class EskyvNextLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName => "EskyvNext Loader";
            public string loaderType => "com.beer.xr.eskyvnext.EskyvNextLoader";

            private static readonly List<BuildTargetGroup> s_SupportedBuildTargets = new List<BuildTargetGroup>()
            {
                BuildTargetGroup.Standalone,
                BuildTargetGroup.Android,
            };
            public List<BuildTargetGroup> supportedBuildTargets => s_SupportedBuildTargets;
        }

        private static IXRPackageMetadata s_Metadata = new EskyvNextPackageMetadata();
        public IXRPackageMetadata metadata => s_Metadata;

        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            var settings = obj as EskyvNextBuildSettings;
            if (settings != null)
            {
                settings.renderMode = EskyvNextBuildSettings.RenderMode.SinglePassInstanced;
                return true;
            }

            return false;
        }
    }
}
#endif