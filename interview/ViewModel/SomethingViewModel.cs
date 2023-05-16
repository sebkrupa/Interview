using interview.Helpers;
using interview.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace interview.ViewModel
{
    public class SomethingViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string _rawInput;

        public string RawInput
        {
            get { return _rawInput; }
            set 
            { 
                _rawInput = value;
                HandleTextChange(_rawInput);
                OnPropertyChanged(nameof(RawInput));
            }
        }

        public ObservableCollection<Models.Word> Words { get; set; }

        #endregion
        public SomethingViewModel()
        {
            Words = new ObservableCollection<Models.Word>();
        }

        public ICommand ReverseClickCommand { 
            get
            {
                return new ClickCommand(ReverseClick, ReverseHandleValidation);
            }
        }

        public bool ReverseHandleValidation()
        {
            return true;
        }

        public void ReverseClick()
        {
            var reversedCollection = ReverseCollection(Words.ToList());

            if (reversedCollection == null) return;

            Words.Clear();

            foreach (var word in reversedCollection)
            {
                Words.Add(word);
            }

            RawInput = string.Join(" ", Words.Select(x=>x.Literal));
        }

        private List<Word> ReverseCollection(List<Models.Word> strings)
        {
            var tempCollection = strings;
            var result = new List<Models.Word>();

            for (var i = tempCollection.Count; i > 0; i--)
            {
                result.Add(tempCollection[i - 1]);
            }

            return result;
        }

        public void HandleTextChange(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;

            Words.Clear();
            var splitted = input.Trim()
                                .Split(" ");

            foreach (var word in splitted)
            {
                Words.Add(new Models.Word(word));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
