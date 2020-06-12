using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GBDD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Appeal : ContentPage
    {
        public Appeal()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = AllData.GetAppealModel();
            listView.ItemsSource = await App.Database.GetAppealAsync();
            listView.SelectedItem = null;
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            AppealModel AppealM = new AppealModel();
            AppealM.Text = Editor.Text;
            AppealM.Date = DateTime.UtcNow;
            AllData.PushAppealModel(AppealM);
            await Navigation.PushAsync(new PhotoAddLib());
        }

        async void ButtonDeleteClicked(object sender, EventArgs e)
        {
            AppealModel Model = listView.SelectedItem as AppealModel;
            if (Model != null)
            {
                await App.Database.DeleteAppealAsync(Model);
                listView.ItemsSource = await App.Database.GetAppealAsync();
            }
            listView.SelectedItem = null;
        }

        void ButtonSelectClicked(object sender, EventArgs e)
        {
            AppealModel Model = listView.SelectedItem as AppealModel;
            if (Model != null)
            {
                Editor.Text = Model.Text;
            }
        }
        /*
        protected override bool OnBackButtonPressed()
        {
            AppealModel AppealM = new AppealModel();
            AllData.PushAppealModel(AppealM);
            return true;
        }
        */
    }
}