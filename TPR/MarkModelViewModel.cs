using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TPR
{
    class MarkModelViewModel : INotifyPropertyChanged
    {
        public MarkModel model;
        public int StrategyCount
        { 
            get => model.StrategyCount;
            set
            {
                model.StrategyCount = value;
                OnPropertyChanged(nameof(MarkModel.StrategyCount));
            }
        }
        public int StateCount
        {
            get => model.StateCount;
            set
            {
                model.StateCount = value;
                OnPropertyChanged(nameof(MarkModel.StateCount));
            }
        }
        public int Steps
        {
            get => model.Steps;
            set
            {
                model.Steps = value;
                OnPropertyChanged(nameof(MarkModel.Steps));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MarkModelViewModel()
        {
            this.model = new MarkModel(1, 1, 1);
        }
    }
}
