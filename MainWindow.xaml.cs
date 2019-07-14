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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_TestKeyDown
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("TextBox_KeyDown:" + Convert.ToInt32(e.Key));
            //if (e.Key == Key.A) e.Handled = false;
            //e.Handled = true;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("TextBox_TextChanged:");
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("TextBox_KeyUp:" + e.Key.ToString());
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("TextBox_PreviewKeyDown:" + Convert.ToInt32(e.Key));
            this.TextBox_PreviewKeyDown_FSC(sender, e);
            //e.Handled = true;
        }

        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("TextBox_PreviewKeyUp:" + e.Key.ToString());
        }

        public void TextBox_PreviewKeyDown_FSC(object sender, KeyEventArgs e)
        {
            //not allow Ctrl+C
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.C)
            { e.Handled = true; }
            //not allow Ctrl+X
            else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.X)
            { e.Handled = true; }
            //not allow Ctrl+V
            else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.V)
            { e.Handled = true; }
            //Allow Letter A-Z,a-z
            else if (Convert.ToInt32(e.Key) >= Convert.ToInt32(Key.A)
                && Convert.ToInt32(e.Key) <= Convert.ToInt32(Key.Z))
            { }
            //Allow Space,_,-
            else if (e.Key == Key.Space
                || e.Key == Key.OemMinus
                || e.Key == Key.Subtract)
            { }
            //Allow Edit Key
            else if (e.Key == Key.Back
                || e.Key == Key.Delete
                || e.Key == Key.Right
                || e.Key == Key.Left
                || e.Key == Key.Enter
                || e.Key == Key.Home
                || e.Key == Key.End)
            { }
            //Allow Digit
            else if (Convert.ToInt32(e.Key) >= Convert.ToInt32(Key.D0)
                && Convert.ToInt32(e.Key) <= Convert.ToInt32(Key.D9)
                && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            { }
            //Allow Digit
            else if (Convert.ToInt32(e.Key) >= Convert.ToInt32(Key.NumPad0)
                && Convert.ToInt32(e.Key) <= Convert.ToInt32(Key.NumPad9)
                && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            { }
            //Not Allow Others
            else
                e.Handled = true;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            e.Handled = true;
        }
    }
}
