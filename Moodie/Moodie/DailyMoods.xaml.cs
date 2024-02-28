using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moodie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyMoods : ContentPage
    {
       
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            moodsList.ItemsSource = await App.Database.GetDayMoods();           
            
        }



        public DailyMoods()
        {
            InitializeComponent();
        }

        private void GoToMainPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}