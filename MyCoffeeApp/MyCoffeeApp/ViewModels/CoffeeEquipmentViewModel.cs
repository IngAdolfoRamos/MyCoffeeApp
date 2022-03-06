using MvvmHelpers;
using MvvmHelpers.Commands;
using MyCoffeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    internal class CoffeeEquipmentViewModel : ViewModelBase
    {

        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            var image = "https://png.pngtree.com/png-clipart/20201107/ourmid/pngtree-creative-flat-coffee-cup-silhouette-png-image_2397039.jpg";

            Coffee.Add(new Coffee { Roaster = "UNO", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "DOS", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "TRES", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "Cuatro", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "Cinco", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "Seis", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "Siete", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "Ocho", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "Nueve", Name = "NOMBRE", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Group One", new[] { Coffee[3] }));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Group Two", Coffee.Take(3)));

            RefreshCommand = new AsyncCommand(Refresh);
        }

        Coffee previouslySelected;
        Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get => selectedCoffee;

            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "Ok");
                    previouslySelected = value;
                    value = null;
                }
                selectedCoffee = value;
                OnPropertyChanged();
            }
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);
            IsBusy = false;
        }
    }
}
