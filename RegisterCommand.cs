using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab14
{
    public class RegisterCommand : ICommand
    {
        private RegistretionModelValidator _validator = new RegistretionModelValidator();
        public event EventHandler CanExecuteChanged // przy przypisaniu event hendlera do  canexectueChange przepisujemy ten event hendler to requery suggested
        {
            add { CommandManager.RequerySuggested += value; } //
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {

            var model = parameter as RegistrationModel;
            if (model is null)
            {
                return false;
            }
            var result = _validator.Validate(model);
            model.Errors = string.Join(" ", result.Errors);
            return result.IsValid;
                //_validator.Validate(model).IsValid;
                //            !string.IsNullOrWhiteSpace(model.Email) && !string.IsNullOrWhiteSpace(model.Password) && model.Accept;
        }

        public void Execute(object parameter)
        {
            var model = parameter as RegistrationModel;
            MessageBox.Show($"Zarejestrowano usera {model.Email}",  "Rejestracja pomyślna", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
