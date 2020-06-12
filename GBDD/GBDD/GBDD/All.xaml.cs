using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GBDD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class All : ContentPage
    {
        public All()
        {
            InitializeComponent();
            listView.ItemsSource = AllData.GetImageModel();
        }

        async void OnCurrent(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Fullimage
                {
                    BindingContext = e.SelectedItem as ClassPhoto
                });
            }
            //listView.SelectedItem = null;
        }

            async void OneRequestClicked(object sender, EventArgs e)
        {
            await App.Database.SaveAppealAsync(AllData.GetAppealModel());
            AllData.ClearModel();
            await Navigation.PopToRootAsync();
        }
    }
}
 