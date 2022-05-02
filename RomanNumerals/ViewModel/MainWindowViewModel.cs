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
        private string history;

        public MainWindowViewModel()
        {
            generator = new RomanNumeralGenerator();
            History = string.Format("{0,-20}{1,-15}\n", "Arabic", "Roman");
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

        public string History
        {
            get { return this.history; }
            set
            {
                this.history = value;
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
            // First it checks if there is a valid number
            if(!int.TryParse(NumberInput, out int inputInteger))
            {
                MessageBox.Show("Please input valid number!");
                return;
            }
            // Then it checks if Generator object has been created
            if(generator == null)
            {
                generator = new RomanNumeralGenerator();
            }
            // Generates roman number
            try
            {
                RomanOutput = generator.Generate(inputInteger);
                History += string.Format("{0,-20}{1,-15}\n", inputInteger.ToString(), RomanOutput);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void ClearHistory()
        {
            History = string.Format("{0,-20}{1,-15}\n", "Arabic", "Roman");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
