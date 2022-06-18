using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.Experimental.XR;
using UnityEngine.XR;
using UnityEngine.XR.Management;

namespace BEER.XR.EskyvNext
{
    /// <summary>
    /// Loader for Mock HMD.
    /// </summary>
    public class EskyvNextLoader : XRLoaderHelper
    {
        private static List<XRDisplaySubsystemDescriptor> s_DisplaySubsystemDescriptors =
            new List<XRDisplaySubsystemDescriptor>();
        private static List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors =
            new List<XRInputSubsystemDescriptor>();

        public override bool Initialize()
        {

            var buildSettings = EskyvNextBuildSettings.Instance;
            CreateSubsystem<XRDisplaySubsystemDescriptor, XRDisplaySubsystem>(s_DisplaySubsystemDescriptors, "EskyvNext Display");
            CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(s_InputSubsystemDescriptors, "EskyvNext Head Tracking");            
            if (buildSettings != null) 
            {
                UnityEngine.Debug.Log("Blegh?");
//                EskyvNext.EskyvNextHMD.Blegh();
                //EskyvNext.EskyvNextHMD.SetRenderMode(buildSettings.renderMode);
            }

            UnityEngine.Debug.Log("Blegh?");
            return true;
        }

        public override bool Start()
        {
            StartSubsystem<XRDisplaySubsystem>();
            StartSubsystem<XRInputSubsystem>();
            return true;
        }

        public override bool Stop()
        {
            StopSubsystem<XRInputSubsystem>();
            StopSubsystem<XRDisplaySubsystem>();
            return true;
        }

        public override bool Deinitialize()
        {
            DestroySubsystem<XRInputSubsystem>();
            DestroySubsystem<XRDisplaySubsystem>();
            return true;
        }
    }
}
