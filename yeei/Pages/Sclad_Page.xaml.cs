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
    /// Логика взаимодействия для Sclad_Page.xaml
    /// </summary>
    public partial class Sclad_Page : Page
    {
       
        public Sclad_Page()
        {
            InitializeComponent();
            Update();

        }

        private void Update()
        {
            DataGridSclad.ItemsSource = CoreModel.init().Sclads.ToList();

            List<Sclad> sclads = CoreModel.init().Sclads.Where(t => t.Name.Contains(TB_Search.Text) || t.Price.Contains(TB_Search.Text)
            || t.Name.Contains(TB_Search.Text) || t.Colvo.Contains(TB_Search.Text)).ToList();

            DataGridSclad.ItemsSource = sclads;

        }

        private void Del_Sclad_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridSclad.SelectedItems.Count > 1)
                return;
            Sclad ScladDel = DataGridSclad.SelectedItem as Sclad;

            if(MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo)==MessageBoxResult.Yes)

            {
               CoreModel.init().Sclads.Remove(ScladDel);
                CoreModel.init().SaveChanges();

                Update();
            }
         }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Sclad_Page(new Sclad()));
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            Sclad ScladEdit = DataGridSclad.SelectedItem as Sclad;
            NavigationService.Navigate(new Add_Sclad_Page(ScladEdit));
        }

        private void Sot_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        

        private void Search_Scl(object sender, TextChangedEventArgs e)
        {
            Update();
        }



        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    try
        //    {
        //        DataGridSclad.ItemsSource = CoreModel.init().Sclad.Where(item => item.Name == Search.Text).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(),"Error",MessageBoxButton.OK);
        //    }
        //}
    }

        //private void Del_Sclad_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DataGridSclad.SelectedItems.Count > 1)
        //        return;
        //    Sclad ScladDel = DataGridSclad.SelectedItems as Sclad;

        //    if(MessageBox.Show("Delete?","Realy Delete?", MessageBoxButton.YesNo)==MessageBoxResult.Yes)

        //    {
        //        CoreModel.init().Sclads.Remove(ScladDel);
        //        CoreModel.init().SaveChanges(); 
        //    }
        // }
}

