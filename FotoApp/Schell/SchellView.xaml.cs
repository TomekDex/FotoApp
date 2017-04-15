using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace FotoApp.Schell
{
    /// <summary>
    /// Interaction logic for SchellView.xaml
    /// </summary>
    public partial class SchellView : Window
    {
        public SchellView()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4 ||
                Keyboard.Modifiers == ModifierKeys.Control && e.SystemKey == Key.Escape)
            {
                e.Handled = true;
            }
            else
            {
                base.OnPreviewKeyDown(e);
            }
        }
       
    }
}
