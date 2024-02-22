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
using yeei.BdModels;

namespace yeei.Pages
{
    /// <summary>
    /// Логика взаимодействия для Uslugi_Page.xaml
    /// </summary>
    public partial class Uslugi_Page : Page
    {
        public Uslugi_Page()
        {
            InitializeComponent();
            Update();
        }
        private void Update()
        {
            DataGridUslugi.ItemsSource = CoreModel.init().Uslugis.ToList();

            List<Uslugi> uslugis = CoreModel.init().Uslugis.Where(t => t.Nazvanie.Contains(TB_Search.Text) || t.Cena.Contains(TB_Search.Text)
            || t.Vremya.Contains(TB_Search.Text)).ToList();

            DataGridUslugi.ItemsSource = uslugis;

        }

        private void Sot_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Search_Usl(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
