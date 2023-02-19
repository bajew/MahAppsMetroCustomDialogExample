using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MahAppsMetroCustomDialogExample
{
    public class ExampleData : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public decimal Total => Price * Amount;
        public string Email { get; set; }

        private readonly Dictionary<string, List<string>> errorsByPropertyName = new Dictionary<string, List<string>>();
        public bool HasErrors => errorsByPropertyName.Any();

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return errorsByPropertyName.ContainsKey(propertyName) ? errorsByPropertyName[propertyName] : null;
        }
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void Validate()
        {
            ClearErrors(nameof(Price));
            if (Price < 0)
            {
                AddError(nameof(Price), "Price must be positve");
            }
            ClearErrors(nameof(Amount));
            if (Amount < 0)
            {
                AddError(nameof(Amount), "Amount must be positve");
            }
            ClearErrors(nameof(Name));
            if (string.IsNullOrWhiteSpace(Name))
            {
                AddError(nameof(Name), "Name must be set");
            }
            ClearErrors(nameof(Email));
            if (string.IsNullOrWhiteSpace(Email))
            {
                AddError(nameof(Email), "Email must be set");
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (errorsByPropertyName.ContainsKey(propertyName))
            {
                errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        private void AddError(string propertyName, string errorMessage)
        {
            if (!errorsByPropertyName.ContainsKey(propertyName))
            {
                errorsByPropertyName[propertyName] = new List<string>();
            }
            if (!errorsByPropertyName[propertyName].Contains(errorMessage))
            {
                errorsByPropertyName[propertyName].Add(errorMessage);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
