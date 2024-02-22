using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace yeei.Pages
{
    /// <summary>
    /// Логика взаимодействия для Setting_Page.xaml
    /// </summary>
    public partial class Setting_Page : Page
    {
        public Setting_Page()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Language == "ru")
            {
                cbLearn.SelectedIndex = 1;
            }
            else
            {
                cbLearn.SelectedIndex = 0;
            }
            
        }
    

        private void But1_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Themes/Black.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear(); 
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void But2_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"Themes/Blue.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void PropReload()
        {
            ResourceDictionary dictionary = new ResourceDictionary();

            Properties.Settings.Default.Save();

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            if (Properties.Settings.Default.Language == "ru")
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Localisation/Localisation.ru.xaml", UriKind.Relative) });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Localisation/Localisation.en.xaml", UriKind.Relative) });
            }
        }

        private void UpdateLocale()
        {
            ResourceDictionary resourceDictionary;
            if (Properties.Settings.Default.Language == "RU")
            {
                resourceDictionary = new ResourceDictionary { Source = new Uri("Localisation/Localisation.ru.xaml", UriKind.Relative) };
            }
            else
            {
                resourceDictionary = new ResourceDictionary { Source = new Uri("Localisation/Localisation.en.xaml", UriKind.Relative) };
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.Language);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void cbLangChancked(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem localItem = cbLearn.SelectedItem as ComboBoxItem;
            Properties.Settings.Default.Language = localItem.Tag as string;
            Properties.Settings.Default.Save();
            UpdateLocale();
        }
    }
}
