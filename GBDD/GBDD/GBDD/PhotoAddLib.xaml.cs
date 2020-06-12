using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace GBDD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoAddLib : ContentPage
    {
        private bool flag;
        private ClassPhoto Node;

        ObservableCollection<ClassPhoto> imageData = new ObservableCollection<ClassPhoto>();
        public PhotoAddLib()
        {
            InitializeComponent();
            imageData = AllData.GetImageModel();
            listView.ItemsSource = imageData;
            if (imageData.Count > 0)
            {
                File_appeal.IsEnabled = true;
                Delete.IsEnabled = true;
            }
            else
            {
                File_appeal.IsEnabled = false;
                Delete.IsEnabled = false;
            }
        }

    async void PhotoClicked(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Custom,
                    CustomPhotoSize = 60,
                    CompressionQuality = 80,
                });
                if (photo != null)
                {
                    ClassPhoto m = new ClassPhoto
                    {
                        imag = ImageSource.FromFile(photo.Path)
                    };
                    imageData.Add(m);
                }
            }
            if (imageData.Count > 0)
            {
                File_appeal.IsEnabled = true;
                Delete.IsEnabled = true;
            }
        }

        async void TakePhotoClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Custom,
                CustomPhotoSize = 60,
                CompressionQuality = 80,

                Directory = "Sample",
                Name = $"{ DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss") }.jpg",
                SaveToAlbum = true
            });

            if (file == null)
                return;


            ImageSource image = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();

                return stream;
            });

            ClassPhoto m = new ClassPhoto
            {
                imag = image
            };
            imageData.Add(m);

            if (imageData.Count > 0)
            {
                File_appeal.IsEnabled = true;
                Delete.IsEnabled = true;
            }
        }

        void DeletePhotoClicked(object sender, EventArgs e)
        {
            ClassPhoto prof = listView.SelectedItem as ClassPhoto;
            if (prof != null)
            {
                imageData.Remove(prof);
            }
            listView.SelectedItem = null;
            if (imageData.Count == 0)
            {
                File_appeal.IsEnabled = false;
                Delete.IsEnabled = false;
            }
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if ((ClassPhoto)listView.SelectedItem != Node)
            {
                Node = (ClassPhoto)listView.SelectedItem;
                flag = false;
            } else
            {
                flag = true;
            }
            if (e.SelectedItem != null && flag)
            {
                await Navigation.PushAsync(new Fullimage
                {
                    BindingContext = Node as ClassPhoto
                });
            }
        }

        async void FileAppealTakePhotoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new All
            {
                BindingContext = AllData.GetIModelAll()
            });
        }
    }
}