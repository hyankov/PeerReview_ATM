namespace PeerReview.ATM.HardwareDrivers.Camera_MegaPX
{
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using Interfaces;

    /// <summary>
    /// A hardware driver to the camera
    /// </summary>
    public class CameraMegaPXDriver : ICameraDriver
    {
        /// <summary>
        /// Takes a picture with the camera
        /// </summary>
        /// <returns>A byte array representing a <see cref="Bitmap"/></returns>
        public byte[] TakePicture()
        {
            Trace.TraceInformation("[HARDWARE] Taking a picture ...");

            using (var stream = new MemoryStream())
            {
                Resources.UserPhoto.Save(stream, ImageFormat.Png);
                Trace.TraceInformation("[HARDWARE] Picture taken.");

                return stream.ToArray();
            }
        }
    }
}