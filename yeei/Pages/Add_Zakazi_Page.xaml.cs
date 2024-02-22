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
    /// Логика взаимодействия для Add_Zakazi_Page.xaml
    /// </summary>
    public partial class Add_Zakazi_Page : Page
    {
        private Zakazi zakazi;

        public Add_Zakazi_Page(Zakazi Zak)
        {
            this.zakazi = Zak;
            DataContext = zakazi;

            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (zakazi.IdZakazi == 0)
            {
                CoreModel.init().Zakazis.Add(zakazi);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
            
        }
        private void Zak_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (zakazi.IdZakazi != 0)

            {
                CoreModel.init().Entry(zakazi).Reload();
            }

        }
    }
}



