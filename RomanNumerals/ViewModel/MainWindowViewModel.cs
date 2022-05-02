using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RomanNumerals.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string numberInput;
        private string romanOutput;
        private ICommand generateCommand;
        private ICommand clearCommand;
        private RomanNumeralGenerator generator;

        public MainWindowViewModel()
        {
            generator = new RomanNumeralGenerator();
        }

        public string NumberInput
        {
            get { return this.numberInput; }
            set
            {
                this.numberInput = value;
                OnPropertyChanged();
            }
        }

        public string RomanOutput
        {
            get { return this.romanOutput; }
            set
            {
                this.romanOutput = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new RelayCommand(x =>
                {
                    ClearHistory();
                }));
            }
        }

        public ICommand GenerateCommand
        {
            get
            {
                return generateCommand ?? (generateCommand = new RelayCommand(x =>
                {
                    GenerateRomanNumerals();
                }));
            }
        }

        private void GenerateRomanNumerals()
        {
            if(!int.TryParse(NumberInput, out int inputInteger))
            {
                MessageBox.Show("Please input valid number!");
                return;
            }
            if(generator == null)
            {
                generator = new RomanNumeralGenerator();
            }
            RomanOutput = generator.Generate(inputInteger);
            
        }
        private void ClearHistory() { }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
