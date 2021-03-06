﻿using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace GBDD
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
            listView.SelectedItem = null;
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            DBModel prof = new DBModel();
            prof.date_of_registration_of_the_document_in_the_organization = DateTime.UtcNow;
            //prof.First_name = "";
            await Navigation.PushAsync(new AddProfile
            {
                BindingContext = prof
            });
        }

        async void DeleteItem (object sender, EventArgs e)
        {
            DBModel prof = listView.SelectedItem as DBModel;
            if (prof != null)
            {
                await App.Database.DeleteNoteAsync(prof);
                listView.ItemsSource = await App.Database.GetNotesAsync();
            }
            listView.SelectedItem = null;
        }

        async void RemoveItem(object sender, EventArgs e)
        {
            DBModel prof = listView.SelectedItem as DBModel;
            if (prof != null)
            {
                await Navigation.PushAsync(new AddProfile
                {
                    BindingContext = prof
                });
                listView.SelectedItem = null;
            }
        }

        async void ButtonItemCliced(object sender, EventArgs e)
        {
            DBModel prof = listView.SelectedItem as DBModel;
            if (prof != null)
            {
                AllData.PushDBModel(prof);
                await Navigation.PushAsync(new Appeal());
                
            }
        }
    }
}
