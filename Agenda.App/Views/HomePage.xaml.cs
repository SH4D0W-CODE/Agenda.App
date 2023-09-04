using Agenda.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItem();
        }

        private async void LoadItem()
        {
            var item = await App.Context.GetItemsAsync();
            lista_tareas.ItemsSource = item;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmacion", "Esta Seguro de eliminar el elemento?", "Si", "No"))
            {
                var item = (AgendaItem)(sender as MenuItem).CommandParameter;
                var result = await App.Context.DeleteItemAsync(item);
                if (result == 1)
                {
                    LoadItem();
                }
            }
        }
    }
}