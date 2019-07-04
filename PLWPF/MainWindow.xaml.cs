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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Defult s = new Defult();
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = Factory_BL.GetIBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NannyButton.Background = Brushes.LightGray;
            MotherButton.Background = Brushes.LightGray;
            ChildButton.Background = Brushes.LightGray;
            ContractButton.Background = Brushes.LightGray;
            

            Button temp = (Button)sender;
            switch (temp.Name)
            {
                case "NannyButton":
                    selectPage.Content = new NannyPage(bl);
                    temp.Background = Brushes.LightBlue;
                    butoomGrid.Visibility = Visibility.Visible;
                    getAllList.Content = "Get all Nannies";
                    getOneFromList.Content = "Get some nanny";
                    break;
                case "MotherButton":
                    selectPage.Content = new MotherPage(bl);
                    temp.Background = Brushes.LightBlue;
                    butoomGrid.Visibility = Visibility.Visible;
                    getAllList.Content = "Get all Mothers";
                    getOneFromList.Content = "Get some Mother";
                    break;
                case "ChildButton":
                    selectPage.Content = new ChildPage();
                    temp.Background = Brushes.LightBlue;
                    butoomGrid.Visibility = Visibility.Visible;
                    getAllList.Content = "Get all Children";
                    getOneFromList.Content = "Get some Child";
                    break;
                case "ContractButton":
                    selectPage.Content = new ContractPage(bl);
                    temp.Background = Brushes.LightBlue;
                    butoomGrid.Visibility = Visibility.Visible;
                    getAllList.Content = "Get all Contracts";
                    getOneFromList.Content = "Get some Contract";
                    break;
                case "metodes":
                    Grid.SetRowSpan(selectPage,4);
                    butoomGrid.Visibility = Visibility.Visible;
                    //selectPage.Content = new Metodes(bl);
                    temp.Background = Brushes.LightSkyBlue;
                    break;
                default:
                    break;
            }

        }

        private void getAllList_Click(object sender, RoutedEventArgs e)
        {
            Button temp = (Button)sender;

            switch (temp.Content)
            {
                case "Get all Nannies":
                    selectPage.Content = new Metodes(bl, "all", "Nanny");
                    break;
                case "Get all Mothers":
                    selectPage.Content = new Metodes(bl, "all", "Mother");
                    break;
                case "Get all Children":
                    selectPage.Content = new Metodes(bl, "all", "Child");
                    break;
                case "Get all Contracts":
                    selectPage.Content = new Metodes(bl, "all", "Contracts");
                    break;
                default:
                    break;
            }
        }

        private void getOneFromList_Click(object sender, RoutedEventArgs e)
        {
            Button temp = (Button)sender;

            switch (temp.Content)
            {
                case "Get some nanny":
                    selectPage.Content = new Metodes(bl, "one", "Nanny");
                    break;
                case "Get some Mother":
                    selectPage.Content = new Metodes(bl, "one", "Mother");
                    break;
                case "Get some Child":
                    selectPage.Content = new Metodes(bl, "one", "Child");
                    break;
                case "Get some Contract":
                    selectPage.Content = new Metodes(bl, "one", "Contracts");
                    break;
                default:
                    break;
            }
        }
    }
}
