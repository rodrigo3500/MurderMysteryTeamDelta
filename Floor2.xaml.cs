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

namespace CuHackingMurder
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Floor2 : Page
    {
        public Floor2()
        {
            InitializeComponent();
        }

        private void Device_Click(object sender, RoutedEventArgs e)
        {
            PopUp popUp = new PopUp(sender);
            popUp.ShowDialog();
        }
    }
}
