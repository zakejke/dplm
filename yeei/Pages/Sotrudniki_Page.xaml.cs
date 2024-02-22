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
    /// Interaction logic for Sotrudniki_Page.xaml
    /// </summary>
    public partial class Sotrudniki_Page : Page
    {
        public Sotrudniki_Page()
        {
            InitializeComponent();
            Update();
        }
        private void Update()
        {
            DataGridSotrudniki.ItemsSource = CoreModel.init().Sotrudnikis.ToList();

            List<Sotrudniki> sotrudnikis = CoreModel.init().Sotrudnikis.Where(t => t.Name.Contains(TB_Search.Text) || t.Surname.Contains(TB_Search.Text)
           || t.PhoneSotr.Contains(TB_Search.Text) || t.Famsotr.Contains(TB_Search.Text)).ToList();

            DataGridSotrudniki.ItemsSource = sotrudnikis;
        }


        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Sotrudniki_Page(new Sotrudniki()));

        }

        private void Del_Sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridSotrudniki.SelectedItems.Count > 1)
                return;
            Sotrudniki SotrudnikiDel = DataGridSotrudniki.SelectedItem as Sotrudniki;

            if (MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //ХУЙ ПОЙМИ ЧТО ЭТО
                //{

                //    foreach (Sotrudniki sotrudnikiDelSvas in SotrudnikiDel.Sotrudnikis.ToList())
                //    {
                //        CoreModel.init().Sotrudnikis.Remove(SotrudnikiDel);
                //        CoreModel.init().SaveChanges();
                //    }
                //}
                CoreModel.init().Sotrudnikis.Remove(SotrudnikiDel);
                CoreModel.init().SaveChanges();

                Update();
            }
        }
        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            Sotrudniki SotrudnikiEdit = DataGridSotrudniki.SelectedItem as Sotrudniki;
            NavigationService.Navigate(new Add_Sotrudniki_Page(SotrudnikiEdit));
        }
        private void Sot_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Search_Sotr(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
