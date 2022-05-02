using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace RomanNumerals.ViewModel
{
    // Since the Generate method itself was quite easy to solve, I decided to demonstrate my skills by adding a GUI using MVVM architecture
    // MVVM allows to create logic independant from UI
    // So that for example by using the same bindings I could theoretically change the frontend and
    // Make it a mobile app instead

    // Here we have MainWindowViewModel that implements INotifyPropertyChanged interface
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // We have 3 strings that are used for bindings and 2 commands used for buttons
        private string numberInput;
        private string romanOutput;
        private ICommand generateCommand;
        private ICommand clearCommand;
        private RomanNumeralGenerator generator;
        private string history;

        public MainWindowViewModel()
        {
            // I create RomanNumeralGenerator object here at the start of the app so that I don't have to create it every time i press a button
            generator = new RomanNumeralGenerator();
            // This is a header for the History TextBox that will save all generated roman numerals
            History = string.Format("{0,-20}{1,-15}\n", "Arabic", "Roman");
        }

        public string NumberInput
        {
            get { return this.numberInput; }
            set
            {
                this.numberInput = value;
                // We need to use OnPropertyChanged method to update the bindings
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
                    // When Clear button is pressed, ClearHistory() method is executed
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
                    // When Generate button is pressed, GenerateRomanNumerals() is executed
                    GenerateRomanNumerals();
                }));
            }
        }

        private void GenerateRomanNumerals()
        {
            // First it checks if there is a valid number
            // We already have NumberValidationTextBox method in MainWindow.xaml.cs but it is not perfect since it allows spaces and copied text
            if (!int.TryParse(NumberInput, out int inputInteger))
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
                // Adds generated number to history string that will be displayed in History TextBox
                History += string.Format("{0,-20}{1,-15}\n", inputInteger.ToString(), RomanOutput);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void ClearHistory()
        {
            // Resets the History string to just a header
            History = string.Format("{0,-20}{1,-15}\n", "Arabic", "Roman");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
