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
            var image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBoXyezjniIUJyXeKOPTyj466Nb6eCCrXUNg&usqp=CAU";

            Coffee.Add(new Coffee { Roaster = "UNO", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "DOS", Name = "NOMBRE", Image = image });
            Coffee.Add(new Coffee { Roaster = "TRES", Name = "NOMBRE", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("TRES", new[] { Coffee[2] }));
            CoffeeGroups.Add(new Grouping<string, Coffee>("DOS", Coffee.Take(2)));

            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
