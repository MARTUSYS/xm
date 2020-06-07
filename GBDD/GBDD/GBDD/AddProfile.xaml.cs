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
    public partial class AddProfile : ContentPage
    {
        public AddProfile()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (DBModel)BindingContext;
            if (note.Last_name != null && note.First_name != null)
            {
                if (!note.Organization)
                {
                    note.Name_of_company = null;
                    note.Additional_information = null;
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