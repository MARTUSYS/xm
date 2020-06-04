using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GBDD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingPhotos : ContentPage
    {
        private IPhotographerPlatform platform;
        private byte[] imageData;
        public AddingPhotos(IPhotographerPlatform platform)
        {
            InitializeComponent();
            this.platform = platform;
            if (!platform.IsCameraAvailable())
            {
                takePhotoButton.IsEnabled = false;
            }
            platform.PhotoCallback = PhotoTaken;
        }

        private void takePhotoButton_Clicked(object sender, EventArgs e)
        {
            platform.TakePhoto();
        }

        private void PhotoTaken(byte[] imageData)
        {
            this.imageData = imageData;
            var source = ImageSource.FromStream(() => new MemoryStream(imageData));

            takenPhoto.Source = source;
        }

        private void SaveTakenPhoto_Clicked(object sender, EventArgs e)
        {
            platform.SaveImage(imageData);
        }
        /*
        private void Write_Clicked(object sender, EventArgs e)
        {
            platform.SaveToDB();
        }

        private void Read_Clicked(object sender, EventArgs e)
        {
            textFromDB.Text = platform.ReadFromDB;
        }
        */
    }
}