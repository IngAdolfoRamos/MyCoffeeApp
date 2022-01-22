using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCoffeeApp.ViewModels
{
    internal class CoffeeEquipmentViewModel : ViewModelBase
    {
        public CoffeeEquipmentViewModel()
        {
            //command instead of click button handler event
            IncreaseCount = new Command(OnIncrease);

        }

        public ICommand IncreaseCount { get; }

        int count = 0;
        string countDisplay = "Welcome to Coffee Equipment";
        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"You clicled {count} times";
        }
    }
}
