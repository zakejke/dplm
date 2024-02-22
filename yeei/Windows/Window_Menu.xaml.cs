using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using yeei.BdModels;
using yeei.Pages;

namespace yeei.Windows
{
    /// <summary>
    /// Interaction logic for Window_Menu.xaml
    /// </summary>
    public partial class Window_Menu : Window
    {
        public Window_Menu()
        {
            InitializeComponent();

        }

        private void Show_Sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Sotrudniki_Page());
        }


        private void Show_Sclad_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Sclad_Page());
        }

        private void Show_Zakazi_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Zakazi_Page());
        }

        private void Show_Uslugi_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Uslugi_Page());
        }

        private void Show_Setting_click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Setting_Page());
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            {
                if (WindowState == WindowState.Normal)
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    WindowState = WindowState.Normal;
                }

            }
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void Show_Todo_click(object sender, RoutedEventArgs e)
        {
            TodoWindows todoWindows = new TodoWindows();
            todoWindows.Show();
        }
    }
}
