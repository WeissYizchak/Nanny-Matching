using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using BE;
namespace PLWPF
{
    
    /// <summary>
    /// Interaction logic for Metodes.xaml
    /// </summary>
    public partial class Metodes : Page
    {
        List<Nanny> tempNannyList;


        string select;
        public List<BE.Nanny> myNannyList = new List<BE.Nanny>();
        BL.IBL bl;
        List<string> errorMessages = new List<string>();
        int tempIdNumber;
		int tempIdForNanny;
        

        //constractor
        public Metodes(BL.IBL item, string solution, string senderName)
        {
            select = senderName;
            InitializeComponent();
            bl = item;

            switch (solution)
            {
                case "all":
                    tabSelect.SelectedIndex = 1;
                    break;
                case "one":
                    tabSelect.SelectedIndex = 0;

                    break;
                default:
                    MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                    break;
            }


            if (solution == "all")
                switch (senderName)
                {
                    case "Nanny":
                        tempNannyList = bl.getNannis();
                        DataContext = tempNannyList;
                        BirthdayColumn.Visibility = Visibility.Collapsed;
                        AddressColumn.Visibility = Visibility.Visible;
                        MotherIDColumn.Visibility = Visibility.Collapsed;
                        CellPhonColumn.Visibility = Visibility.Visible;
						SalaryColumn.Visibility = Visibility.Collapsed;
						ContractNumberColumn.Visibility = Visibility.Collapsed;
						nannyIdColumn.Visibility = Visibility.Collapsed;
						break;
                    case "Mother":
                        DataContext = bl.getMothers();
                        BirthdayColumn.Visibility = Visibility.Collapsed;
                        AddressColumn.Visibility = Visibility.Visible;
                        MotherIDColumn.Visibility = Visibility.Collapsed;
                        CellPhonColumn.Visibility = Visibility.Visible;
						SalaryColumn.Visibility = Visibility.Collapsed;
						ContractNumberColumn.Visibility = Visibility.Collapsed;
						nannyIdColumn.Visibility = Visibility.Collapsed;
						break;
                    case "Child":
                        DataContext = bl.getChildren();
                        BirthdayColumn.Visibility = Visibility.Visible;
                        AddressColumn.Visibility = Visibility.Collapsed;
                        MotherIDColumn.Visibility = Visibility.Visible;
                        CellPhonColumn.Visibility = Visibility.Collapsed;
						SalaryColumn.Visibility = Visibility.Collapsed;
						ContractNumberColumn.Visibility = Visibility.Collapsed;
						nannyIdColumn.Visibility = Visibility.Collapsed;
						break;
                    case "Contracts":
                        DataContext = bl.getContracts();
                        MotherIDColumn.Visibility = Visibility.Visible;
						BirthdayColumn.Visibility = Visibility.Collapsed;
						AddressColumn.Visibility = Visibility.Collapsed;
						CellPhonColumn.Visibility = Visibility.Collapsed;
						IdColumn.Visibility = Visibility.Collapsed;
						SalaryColumn.Visibility = Visibility.Visible;
						ContractNumberColumn.Visibility = Visibility.Visible;
						nannyIdColumn.Visibility = Visibility.Visible;
						LastNameColumn.Visibility = Visibility.Collapsed;
						FirstNameColumn.Visibility = Visibility.Collapsed;
						


						break;
                    default:
                        MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                        break;
                }
            if (solution == "one")
                switch (senderName)
                {
                    case "Nanny":
                        searchLabel.Content = "Enter the ID of the Nanny:";
                        break;
                    case "Mother":
                        searchLabel.Content = "Enter the ID of the Mother:";
                        break;
                    case "Child":
                        searchLabel.Content = "Enter the ID of the Child:";
                        break;
                    case "Contracts":
                        searchLabel.Content = "Enter the ID of the Child:";
                        break;
                    default:
                        MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                        break;
                }
        }



        //Functions for handling input errors
        private void Page_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(idToSearch.Text) < 1000000 || int.Parse(idToSearch.Text) > 999999999)
                    throw new Exception();
                tempIdNumber = int.Parse(idToSearch.Text);

                switch (select)
                {
                    case "Nanny":
                        ResultLable.Content = bl.GetNanny(tempIdNumber);
                        SelectButton1.Content = "get all her Contracts";
                        SelectButton2.Content = "get all her children";
                        ButtonsGrid.Visibility = Visibility.Visible;
                        
                        break;

                    case "Mother":
                        ResultLable.Content = bl.GetMother(tempIdNumber);
                        SelectButton1.Content = "get all children";
                        SelectButton2.Content = "find suitable nanny";
                        ButtonsGrid.Visibility = Visibility.Visible;
                        break;

                    case "Child":
                        ResultLable.Content = bl.GetChild(tempIdNumber);
                        SelectButton1.Content = "get his mother";
                        SelectButton2.Content = "get his nanny";
                        ButtonsGrid.Visibility = Visibility.Visible;
                        break;

                    case "Contracts":
                        ResultLable.Content = bl.GetContract(tempIdNumber);
                        break;

                    default:
                        MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR INPUT", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        //======================
        //Three right buttons
        //======================

        /// <summary>
        /// Responsible for deletion
        /// Returns a message after deletion and returns an exception message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                MessageBoxResult toCheck = new MessageBoxResult();
                switch (select)
                {
                    case "Nanny":
                        toCheck = MessageBox.Show("you sour you wont to remove this nanny?", "Messege", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if(toCheck == MessageBoxResult.Yes)
                            bl.removeNanny(tempIdNumber);
                        break;
                    case "Mother":
                        toCheck = MessageBox.Show("you sour you wont to remove this Mother?", "Messege", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (toCheck == MessageBoxResult.Yes)
                            bl.removeMother(tempIdNumber);
                        break;
                    case "Child":
                        toCheck = MessageBox.Show("you sour you wont to remove this Child?", "Messege", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (toCheck == MessageBoxResult.Yes)
                            bl.removeChild(tempIdNumber);
                        break;
                    case "Contracts":
                        toCheck = MessageBox.Show("you sour you wont to remove this contract?", "Messege", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (toCheck == MessageBoxResult.Yes)
                        {
                            BE.Contract temp = bl.GetContract(tempIdNumber);
                            bl.removeContract(temp.ContractNumber);
                        }
                        break;
                    default:
                        MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                        break;
                }
                if (toCheck == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Deletion completed", "messagge", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResultLable.Content = "";
                }
            }
            catch (BL.BLException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// event of the second button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button cornt = sender as Button;
                if (cornt != null)
                {
                    switch (select)
                    {
                        case "Nanny": //get All Contracts
                            dataGrid.DataContext = bl.getContractByDelegate(x => x.NannyId == tempIdNumber);
                            DataLabel.Content = "Here is a list of all the contracts from this nanny:";
                            DataLabel.Visibility = Visibility.Visible;
                            dataGrid.Visibility = Visibility.Visible;
                            resultElemntLabel.Visibility = Visibility.Collapsed;
                            break;
                        case "Mother": //"get al children"
                            dataGrid.DataContext = bl.getChildrenFromMother(tempIdNumber);
                            DataLabel.Content = "Here is a list of all the nannies who meet your requirements:";
                            DataLabel.Visibility = Visibility.Visible;
                            dataGrid.Visibility = Visibility.Visible;
                            resultElemntLabel.Visibility = Visibility.Collapsed;
                            break;
                        case "Child": //"get his mother
                            DataLabel.Content = "the mother of child: ";
                            resultElemntLabel.Content = bl.GetMother((bl.GetChild(tempIdNumber)).MotherId);
                            DataLabel.Visibility = Visibility.Visible;
                            dataGrid.Visibility = Visibility.Collapsed;
                            resultElemntLabel.Visibility = Visibility.Visible;
                            break;
                        case "Contracts":

                            break;
                        default:
                            MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                            break;
                    }
                }
            }
            catch (BL.BLException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// event of the thrid button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton2_Click(object sender, RoutedEventArgs e)
        {

            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            //backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            try
            {
                Button cornt = sender as Button;
                if (cornt != null)
                {
                    switch (select)
                    {
                        case "Nanny": //get all children
                            List<BE.Child> tempChild = new List<BE.Child>();
                            foreach (BE.Contract item in bl.getContractByDelegate(x => x.NannyId == tempIdNumber))
                            {
                                tempChild.Add(bl.GetChild(item.ChildId));
                            }
                            int spaces = -(bl.GetNanny(tempIdNumber)).CapacityChildren - tempChild.Count();
                            if (spaces > 0)
                            {
                                DataLabel.Content = "there are " + spaces + "available spaces. \nHere is a list of all children who are with this nanny";
                            }
                            else
                            {
                                DataLabel.Content = "there  no are available spaces. \nHere is a list of all children who are with this nanny";
                            }
                                
                            DataLabel.Visibility = Visibility.Visible;
                            dataGrid.Visibility = Visibility.Visible;
                            resultElemntLabel.Visibility = Visibility.Collapsed;
                            break;
                        case "Mother": //button "find suitable nanny" 
                            if (backgroundWorker1.IsBusy != true)
                            {
                                backgroundWorker1.RunWorkerAsync();
                            }
                            break;
                        case "Child": //button "get his nanny"
                            resultElemntLabel.Content = bl.GetNanny(bl.GetContract(tempIdNumber).NannyId);
                            DataLabel.Content = "the nanny of this Child: ";
                            dataGrid.Visibility = Visibility.Collapsed;
                            DataLabel.Visibility = Visibility.Visible;
                            resultElemntLabel.Visibility = Visibility.Visible;
							
							break;
                        case "Contracts":

                            break;
                        default:
                            MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                            break;
                    }
                }
            }
            catch (BL.BLException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        //===========================
        //Backround Worker
        //===========================
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        /// <summary>
        /// Runs another process for the distance function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                getNannisOrderMothers();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\nDisplays a list of nannis according to needs", "Error calculation of distance", MessageBoxButton.OK, MessageBoxImage.Error);
                tempNannyList = bl.getOrderCompatibilityNannies(tempIdNumber);
                this.Dispatcher.Invoke(() =>
                {
                    dataGrid.DataContext = tempNannyList;
                    dataGrid.Visibility = Visibility.Visible;
                    DataLabel.Content = "Here is a list of all the nannies who meet your requirements:";
                });
            }

        }

        /// <summary>
        /// call to the function that givs the nannis order to distance.
        /// if there is are a prublame he throw Exception
        /// </summary>
        private void getNannisOrderMothers()
        {
            try
            {
                tempNannyList = bl.nannisByDistance(tempIdNumber, 5000);
                //MessageBox.Show("ceccess");//check messege
                this.Dispatcher.Invoke(() =>
                {
                    dataGrid.DataContext = tempNannyList;
                    resultElemntLabel.Visibility = Visibility.Collapsed;
                    dataGrid.Visibility = Visibility.Visible;
                    DataLabel.Visibility = Visibility.Visible;
                    DataLabel.Content = "Here is a list of all nannies located 5 km from your address:";
                });

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        //============================

        private void listBoxOfColection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (select)
                {
                    case "Nanny":
                        tempIdNumber = (listBoxOfColection.SelectedItem as Nanny).Id;
                        idToSearch.Text = tempIdNumber.ToString();
                        tabSelect.SelectedIndex = 0;
                        ResultLable.Content = bl.GetNanny(tempIdNumber);
                        SelectButton1.Content = "get all her Contracts";
                        SelectButton2.Content = "get all her children";
                        ButtonsGrid.Visibility = Visibility.Visible;

                        break;

                    case "Mother":
                        tabSelect.SelectedIndex = 0;
						tempIdNumber = (listBoxOfColection.SelectedItem as Mother).Id;
                        idToSearch.Text = tempIdNumber.ToString();
                        ResultLable.Content = bl.GetMother(tempIdNumber);
                        SelectButton1.Content = "get all children";
                        SelectButton2.Content = "find suitable nanny";
                        ButtonsGrid.Visibility = Visibility.Visible;
                        break;

                    case "Child":
						tabSelect.SelectedIndex = 0;
						tempIdNumber = (listBoxOfColection.SelectedItem as Child).Id;
						idToSearch.Text = tempIdNumber.ToString();
                        ResultLable.Content = bl.GetChild(tempIdNumber);
                        SelectButton1.Content = "get his mother";
                        SelectButton2.Content = "get his nanny";
                        ButtonsGrid.Visibility = Visibility.Visible;
						break;

                    case "Contracts":
                        tempIdNumber = (listBoxOfColection.SelectedItem as Contract).ChildId;
                        idToSearch.Text = tempIdNumber.ToString();
                        tabSelect.SelectedIndex = 0;
                        ResultLable.Content = bl.GetContract(tempIdNumber);
                        searchLabel.Visibility = Visibility.Collapsed;
                        break;

                    default:
                        MessageBox.Show("There is an obvious problem with the program", "ERROR MASSAGE", 0, MessageBoxImage.Error);
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR INPUT", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

		private void Addcontract_Click(object sender, RoutedEventArgs e)
		{

			
			var main = Application.Current.Windows
								.Cast<Window>()
								.FirstOrDefault(window => window is MainWindow) as MainWindow;

			ContractPage i = new ContractPage(bl);
			i.oneContract.NannyId = tempIdForNanny;
			i.oneContract.MotherId = tempIdNumber;
			main.selectPage.Content = i;
			main.MotherButton.Background = Brushes.LightGray;
			main.ContractButton.Background = Brushes.LightBlue;
			main.getAllList.Content = "Get all Contracts";
			main.getOneFromList.Content = "Get some Contract";
		}

		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (select =="Mother" && dataGrid.SelectedItem is Nanny)
			{
				tempIdForNanny = (dataGrid.SelectedItem as Nanny).Id;
				Addcontract.Visibility = Visibility.Visible;

			}

		}
	}
}
