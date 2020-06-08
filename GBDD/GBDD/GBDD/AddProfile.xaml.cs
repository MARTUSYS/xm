using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GBDD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProfile : ContentPage
    {
        public AddProfile()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (DBModel)BindingContext;
            if (note.Last_name != null && note.First_name != null && note.Email != null && note.Region != null && note.Subdivision != null)
            {
                if (!note.Organization)
                {
                    note.Name_of_company = null;
                    note.Additional_information = null;
                    note.Outgoing_number = 0;
                    note.date_of_registration_of_the_document_in_the_organization = DateTime.UtcNow;
                    note.Registered_Mail_Number = 0;
                };
                note.Date = DateTime.UtcNow;
                await App.Database.SaveNoteAsync(note);
            };
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (DBModel)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}