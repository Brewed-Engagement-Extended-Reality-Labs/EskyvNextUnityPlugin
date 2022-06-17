using System.Runtime.InteropServices;

namespace BEER.XR.EskyvNext
{
    /// <summary>
    /// Runtime scripting API for Mock HMD provider.
    /// </summary>
    public static class EskyvNextHMD
    {
        private const string LibraryName = "EskyvNext";

        /// <summary>
        /// Set the stereo rendering mode.
        /// </summary>
        /// <param name="renderMode">rendering mode</param>
        /// <returns>true if render mode successfully set</returns>
        [DllImport(LibraryName, EntryPoint = "NativeConfig_SetRenderMode")]
        public static extern bool SetRenderMode(EskyvNextBuildSettings.RenderMode renderMode);

        /// <summary>
        /// Set the resolution of the eye textures.
        /// </summary>
        [DllImport(LibraryName, EntryPoint = "NativeConfig_SetEyeResolution")]
        public static extern bool SetEyeResolution(int width, int height);

        /// <summary>
        /// Set the crop value applied when rendering the mirror view.
        /// This is useful to remove the peripheral distorted part of the image.
        /// </summary>
        /// <param name="crop">the amount to remove from the image, valid range is 0.0 to 0.5</param>
        [DllImport(LibraryName, EntryPoint = "NativeConfig_SetMirrorViewCrop")]
        public static extern bool SetMirrorViewCrop(float crop);
    }
}