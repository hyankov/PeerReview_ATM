namespace PeerReview.ATM.HardwareDrivers.Interfaces.Drivers
{
    using System.Drawing;

    /// <summary>
    /// Interface to the cameras
    /// </summary>
    public interface ICameraDriver
    {
        /// <summary>
        /// Takes a picture with the camera
        /// </summary>
        /// <returns>A byte array representing a <see cref="Bitmap"/></returns>
        byte[] TakePicture();
    }
}