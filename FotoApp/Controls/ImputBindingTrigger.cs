using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace FotoApp.Controls
{
    public class ImputBindingTrigger: TriggerBase<FrameworkElement>, ICommand
    {
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            "InputBinding", typeof(InputBinding), typeof(ImputBindingTrigger), new PropertyMetadata(default(InputBinding)));

        public InputBinding PropertyType
        {
            get { return (InputBinding) GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InvokeActions(parameter);
        }

        public event EventHandler CanExecuteChanged;

        protected override void OnAttached()
        {
            if (PropertyType != null)
            {
                PropertyType.Command = this;
                AssociatedObject.Loaded += delegate {
                    var window = GetWindow(AssociatedObject);
                    window.InputBindings.Add(PropertyType);
                };
            }
            base.OnAttached();
        }

        private Window GetWindow(FrameworkElement element)
        {
            if (element is Window)
            {
                return (Window) element;
            }
            var parent = element.Parent as FrameworkElement;

            return GetWindow(parent);

        }
    }
}
