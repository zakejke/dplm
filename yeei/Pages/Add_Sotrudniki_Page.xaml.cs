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
    /// Interaction logic for Add_Sotrudniki_Page.xaml
    /// </summary>
    public partial class Add_Sotrudniki_Page : Page
    {
        Sotrudniki sotrudniki;

        public Add_Sotrudniki_Page(Sotrudniki Sot)
        {
            this.sotrudniki = Sot;
            DataContext = sotrudniki;

            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (sotrudniki.Idsotrudniki == 0)
            {
                CoreModel.init().Sotrudnikis.Add(sotrudniki);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }
        private void Sot_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sotrudniki.Idsotrudniki != 0)

            {
                CoreModel.init().Entry(sotrudniki).Reload();
            }

        }
    }
}
