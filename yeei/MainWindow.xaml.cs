using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using yeei.BdModels;
using yeei.Windows;

namespace yeei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnectionStringBuilder bild = new MySqlConnectionStringBuilder()
            {
                Server = "cfif31.ru",
                Port = 3306,
                Database = "ISPr22-43_CevelevAA_dplm",
                UserID = "ISPr22-43_CevelevAA",
                Password = "ISPr22-43_CevelevAA",
                CharacterSet = "utf8",
            };
            Trace.WriteLine(bild.ConnectionString);
            //"Server=cfif31.ru;Port=3306;Database=ISPr22-43_CevelevAA_dplm;User ID=ISPr22-43_CevelevAA;Password=ISPr22-43_CevelevAA;Character Set=utf8" Pomelo.EntityFrameworkCore.MySql -force
        }

        private void Autor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text==null || PassTB.Text==null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                 Polzovatel user = CoreModel.init().Polzovatels.FirstOrDefault(p => p.Login == LoginTB.Text &&
                  p.Pass == PassTB.Text);
                if (user != null)
                {
                    if (user.Type == "User")
                    {
                        MessageBox.Show("Бля че за тяги");
                    }

                    else
                    {
                        Window_Menu wind = new Window_Menu();
                        wind.Show();
                        Hide();
                    }
                }
            }
        }
        //private void Show_Pas(object sender, RoutedEventArgs e)
        //{
        //    PassTB.Text = PB_Parol.Password;
        //    PassTB.Visibility = Visibility.Visible;
        //    PB_Parol.Visibility = Visibility.Collapsed;
        //}

        //private void Hide_Pas(object sender, RoutedEventArgs e)
        //{
        //    PB_Parol.Password = PassTB.Text;
        //    PassTB.Visibility = Visibility.Collapsed;
        //    PB_Parol.Visibility = Visibility.Visible;
        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Show_Pas(object sender, RoutedEventArgs e)
        {
            PassTB.Text = PB_Parol.Password;
            PassTB.Visibility = Visibility.Visible;
            PB_Parol.Visibility = Visibility.Collapsed;
        }
        private void Hide_Pas(object sender, RoutedEventArgs e)
        {
            PB_Parol.Password = PassTB.Text;
            PassTB.Visibility = Visibility.Collapsed;
            PB_Parol.Visibility = Visibility.Visible;
        }

    }
}

