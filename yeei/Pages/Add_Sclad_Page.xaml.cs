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
    /// Interaction logic for Add_Sclad_Page.xaml
    /// </summary>
    public partial class Add_Sclad_Page : Page
    {
        Sclad sclad;
        public Add_Sclad_Page(Sclad Sot)
        {
            this.sclad = Sot;
            DataContext = sclad;

            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (sclad.Idsclad == 0)
            {
                CoreModel.init().Sclads.Add(sclad);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();

        }
        private void Sot_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sclad.Idsclad != 0)

            {
                CoreModel.init().Entry(sclad).Reload();
            }

        }
    }
}
