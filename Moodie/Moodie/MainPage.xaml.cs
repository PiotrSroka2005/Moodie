using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Moodie
{
    public partial class MainPage : ContentPage
    {
        public static Dictionary<MoodEnum, string> DayMoodIcons = new Dictionary<MoodEnum, string>()
        {
            { MoodEnum.zadowolony, "good.png"},
            { MoodEnum.dobry, "mid.png"},
            { MoodEnum.przeciętny, "meh.png"},
            { MoodEnum.słaby, "sad.png"},
            { MoodEnum.okropny, "bad.png"}
        };

        private static List<ImageButton> dayMoodImageButtons = new List<ImageButton>()
        {
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.zadowolony]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.dobry]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.przeciętny]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.słaby]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.okropny]
            },
        };

        public async void LastDayDateAndMood()
        {
            var result = await App.Database.GetLastDayMood();

            if (result != null)
            {
                yourLastDayData.Text = result.Data.ToString("MM/dd/yyyy");
                yourLastDayMood.Text = result.Mood.ToString();
            }
            else
            {
                yourLastDayData.Text = "Brak danych";
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
