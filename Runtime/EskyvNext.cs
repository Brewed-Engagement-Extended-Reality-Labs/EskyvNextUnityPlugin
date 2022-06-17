using System.Runtime.InteropServices;

namespace BEER.XR.EskyvNext
{
    /// <summary>
    /// Runtime scripting API for Mock HMD provider.
    /// </summary>
    public static class EskyvNextHMD
    {
        private const string LibraryName = "EskyvNextUnityXRWrapper";

        /// <summary>
        /// Set the stereo rendering mode.
        /// </summary>
        /// <param name="renderMode">rendering mode</param>
        /// <returns>true if render mode successfully set</returns>
        [DllImport(LibraryName, EntryPoint = "NativeConfig_SetRenderMode")]
        public static extern bool SetRenderMode(EskyvNextBuildSettings.RenderMode renderMode);
    }
}