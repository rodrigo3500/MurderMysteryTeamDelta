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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Floor1();
        }

        private void Floor_1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Floor1();
        }

        private void Floor_2_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Floor2();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Choose_Person_Click(object sender, RoutedEventArgs e)
        {
            ChoosePerson choosePerson = new ChoosePerson();
            choosePerson.Show();
        }
    }
}
