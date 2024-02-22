using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Zakazi_Page.xaml
    /// </summary>
    public partial class Zakazi_Page : Page
    {
       
        public Zakazi_Page()
        {
            InitializeComponent();

            Update();
          



        }
        private void Update()
        {
            Lv_Zakazi.ItemsSource = CoreModel.init().Zakazis.ToList();
            //2 способ 
            //IEnumerable<Zakazi> zakazis = CoreModel.init().Zakazis.Include(p => p.Name).Where(p => p.Name.Contains(TB_Search.Text));

            //Lv_Zakazi.ItemsSource = zakazis.ToList();

            List<Zakazi> zakazis = CoreModel.init().Zakazis.Where(t => t.Name.Contains(TB_Search.Text) || t.Familia.Contains(TB_Search.Text)
            || t.Nomer.Contains(TB_Search.Text) || t.Adres.Contains(TB_Search.Text)).ToList();

            Lv_Zakazi.ItemsSource = zakazis;
        }
       



        private void Redact_Zakazi_Click(object sender, RoutedEventArgs e)
        {
            Zakazi ZakaziEdit = Lv_Zakazi.SelectedItem as Zakazi;
            NavigationService.Navigate(new Add_Zakazi_Page(ZakaziEdit));
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Zakazi_Page(new Zakazi()));
        }
        private void Del_Zakazi_Click(object sender, RoutedEventArgs e)
        {
            if (Lv_Zakazi.SelectedItems.Count > 1)
                return;
            {

                Zakazi ZakaziDel = Lv_Zakazi.SelectedItem as Zakazi;
                {
                    if (MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {

                        CoreModel.init().Zakazis.Remove(ZakaziDel);
                        CoreModel.init().SaveChanges();

                        Update();
                    }
                }
            }
        }
        private void Zak_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Search_Zaka(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}

