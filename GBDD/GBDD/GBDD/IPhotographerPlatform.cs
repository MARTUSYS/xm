using System;
using Xamarin.Forms;

namespace GBDD
{
    public interface IPhotographerPlatform
    {
        void TakePhoto();
        bool IsCameraAvailable();
        Action<byte[]> PhotoCallback { get; set; }
        void SaveImage(byte[] data);
        /*
        void SaveToDB();
        string ReadFromDB();
        */
    }
}
