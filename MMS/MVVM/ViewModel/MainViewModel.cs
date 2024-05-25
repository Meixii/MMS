using MMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand CalendarViewCommand { get; set; }
        public RelayCommand StatsViewCommand { get; set; }
        public RelayCommand EntryViewCommand { get; set; }

        public CalendarViewModel CalenVM { get; set; }
        public StatsViewModel StatsVM { get; set; }
        public EntryViewModel EntryVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            
            CalenVM = new CalendarViewModel();
            StatsVM = new StatsViewModel();
            EntryVM = new EntryViewModel();


            CalendarViewCommand = new RelayCommand(o =>
            {
                CurrentView = CalenVM;
            });

            StatsViewCommand = new RelayCommand(o =>
            {
                CurrentView = StatsVM;
            });

            EntryViewCommand = new RelayCommand(o =>
            {
                CurrentView = EntryVM;
            });
        }

    }
}
