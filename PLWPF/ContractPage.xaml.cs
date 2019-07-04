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
using BE;
using System.Collections.ObjectModel;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ContractPage.xaml
    /// </summary>
    /// 

    public partial class ContractPage : Page
    {

        private List<string> errorMessages = new List<string>();
        public Contract oneContract;
        BL.IBL bl;

        private ObservableCollection<Contract> contractListObserver = new ObservableCollection<Contract>();
        public ContractPage(IBL item)
        {


            InitializeComponent();
            bl = item;
            AddToObserver(bl.getContracts());

            DataContext = contractListObserver;
            oneContract = new Contract();
            this.contractGrid.DataContext = oneContract;

        }

        public void AddToObserver(IList<Contract> list)
        {
            list.ToList().ForEach(contractListObserver.Add);
        }

        public void removeFromObserver(int ID)
        {

            Contract temp = new Contract();
            foreach (var i in contractListObserver) { if (i.ContractNumber == ID) { temp = i; } }
            contractListObserver.Remove(temp);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

			
			
			if (errorMessages.Any() || checkFildes()) //errorMessages.Count > 0 
            {
                string err = "Exception:";
                foreach (var item in errorMessages) err += "\n" + item;
                MessageBox.Show(err);
                return;
            }
            else
            {
                try
                {
                    // mom = insertValueFromFildesToDB(mom);

                    bl.addContract(oneContract);
                    contractListObserver.Add(oneContract);
					oneContract.ContractNumber = generateID();
                    oneContract = new Contract();
                    this.contractGrid.DataContext = oneContract;

                    //clear the value from all fileds
                    //ClearValueOfFields();
                }
                // this.nameTextBox.Text = ""            
                catch (FormatException) { MessageBox.Show("check your input and try again"); }
                catch (OverflowException) { MessageBox.Show("check your input long number and try again"); }
                catch (BL.BLException exp) { MessageBox.Show(exp.Message); }
            }

        }
		public int generateID()
		{
			Random rnd = new Random();
			int myRandomNo = 0;
			do
			{
				 myRandomNo = rnd.Next(10000000, 99999999);
			}
			while (contractListObserver.Any(x => x.ContractNumber == myRandomNo));
			
			return myRandomNo;
		}
		private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (errorMessages.Any() || checkFildes()) //errorMessages.Count > 0 
            {
                string err = "Exception:";
                foreach (var item in errorMessages) err += "\n" + item;
                MessageBox.Show(err);
                return;
            }
            else
            {
                try
                {
					removeFromObserver(oneContract.ContractNumber);
					bl.updateContract(oneContract);
					contractListObserver.Add(oneContract);
					oneContract = new Contract();
					this.contractGrid.DataContext = oneContract;

				}
                catch (PlException plExe) { MessageBox.Show(plExe.Message); }
                catch (BL.BLException exp) { MessageBox.Show(exp.Message); }


            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
				removeFromObserver(oneContract.ContractNumber);
				bl.removeContract(oneContract.ContractNumber);

            }
            catch (PlException plExe) { MessageBox.Show(plExe.Message); }
            catch (BL.BLException exp) { MessageBox.Show(exp.Message); }
        }

		bool checkFildes()
		{
			if (childIdTextBox.Text == "0" || nannyIdTextBox.Text == "0" || motherIdTextBox.Text =="0")
			{
				return true;
			}
			return false;

		}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Contract)
            {
                if (this.UpdateContract.IsChecked == true)
                {
                    oneContract = (Contract)(dataGrid.SelectedItem as Contract).Clone();
                    this.contractGrid.DataContext = oneContract;
                }
                else
                {
                    Contract selectedContract = (Contract)(dataGrid.SelectedItem as Contract);
                    this.contractGrid.DataContext = selectedContract;
                }
            }

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
			string query = (sender as TextBox).Text;
			Border border = (resultStack.Parent as ScrollViewer).Parent as Border;
            StackPanel stackPanelTemp = resultStack;
            switch ((sender as TextBox).Name)
            {
                case "childIdTextBox":
                    border = (resultStack.Parent as ScrollViewer).Parent as Border;
                    stackPanelTemp = resultStack;
					break;
                case "nannyIdTextBox":
                    border = (resultStackNanny.Parent as ScrollViewer).Parent as Border;
                    stackPanelTemp = resultStackNanny;
                    break;
                case "motherIdTextBox":
                    border = (resultStackMother.Parent as ScrollViewer).Parent as Border;
                    stackPanelTemp = resultStackMother;
                    break;
            }
            //var border = (resultStack.Parent as ScrollViewer).Parent as Border;


            List<Person> data = new List<Person>();


            if ((sender as TextBox).Name == this.childIdTextBox.Name)
            {
				if(oneContract.MotherId != 0)
				{

					data = bl.getChildrenFromMother(oneContract.MotherId).Cast<Person>().ToList();
				}
				else
				{
					data = bl.getChildren().Cast<Person>().ToList();
				}
                
            }
            else if ((sender as TextBox).Name == this.nannyIdTextBox.Name)
            {
                data = bl.getNannis().Cast<Person>().ToList();
            }
            else if ((sender as TextBox).Name == this.motherIdTextBox.Name)
            {
                data = bl.getMothers().Cast<Person>().ToList();
            }


            List<string> data1 = new List<string>();
            foreach (var obj in data)
            {
                data1.Add(obj.Id.ToString() + " " + obj.FirstName + "  " + obj.LastName);

            }


            if (query.Length == 0 || query == "0")
            {
                // Clear   
                stackPanelTemp.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stackPanelTemp.Children.Clear();

            // Add the result   
            foreach (var obj in data1)
            {

                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work  
                    switch ((sender as TextBox).Name)
                    {
                        case "childIdTextBox":
                            addItem(obj, "childIdTextBox");
                            break;
                        case "nannyIdTextBox":
                            addItem(obj, "nannyIdTextBox");
                            break;
                        case "motherIdTextBox":
                            addItem(obj, "motherIdTextBox");
                            break;
                    }
                    found = true;
                }
            }

            if (!found)
            {
                stackPanelTemp.Children.Add(new TextBlock() { Text = "No results found." });
            }
        }

        private void addItem(string text, string person)
        {

            Border border = (resultStack.Parent as ScrollViewer).Parent as Border;
            StackPanel stackPanelTemp = resultStack;

            switch (person)
            {
                case "childIdTextBox":
                    border = (resultStack.Parent as ScrollViewer).Parent as Border;
                    stackPanelTemp = resultStack;
                    break;
                case "nannyIdTextBox":
                    border = (resultStackNanny.Parent as ScrollViewer).Parent as Border;
                    stackPanelTemp = resultStackNanny;
                    break;
                case "motherIdTextBox":
                    border = (resultStackMother.Parent as ScrollViewer).Parent as Border;
                    stackPanelTemp = resultStackMother;
                    break;
            }
            // var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            TextBlock block = new TextBlock();

            // Add the text   
            string[] textAfter = text.Split(' ');
            block.Text = text;

            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                switch (person)
                {
                    case "childIdTextBox":
                        oneContract.ChildId = int.Parse(textAfter[0]);
                        break;
                    case "nannyIdTextBox":
                        oneContract.NannyId = int.Parse(textAfter[0]);
                        break;
                    case "motherIdTextBox":
                        oneContract.MotherId = int.Parse(textAfter[0]);
                        break;
                }
                border.Visibility = System.Windows.Visibility.Collapsed;

            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.LightGray;
            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };

            // Add to the panel   
            stackPanelTemp.Children.Add(block);

        }

		private void childIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			string query = (sender as TextBox).Text;

			if (query.Length == 9)
			{
				if (bl.GetChildExsist(int.Parse(query)))
				{
					oneContract.MotherId = bl.GetChild(int.Parse(query)).MotherId;
				}
			}

		}

		



		private void nannyIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (oneContract.NannyId != 0)
			{


				try
				{
					Nanny tempNanny = bl.GetNanny(oneContract.NannyId);
					oneContract.IsHourlyRate = tempNanny.IsHourlyRate;
					oneContract.RateOfHour = tempNanny.SallaryPerHour;
					oneContract.RateOfMonth = tempNanny.SallaryPerMonths;
					oneContract.Salary = bl.SalaryPerMonth(tempNanny, oneContract.IsHourlyRate,
						bl.getContractByDelegate(x => x.MotherId == oneContract.MotherId).Count());
				}
				catch (BLException exp)
				{
					MessageBox.Show(exp.Message);
				}

			}

		}

		private void rateOfHourTextBox_LostFocus(object sender, RoutedEventArgs e)
		{

			double query = double.Parse((sender as TextBox).Text);

			if (oneContract.NannyId != 0)
			{
				try
				{
					oneContract.Salary = bl.SalaryPerMonth(bl.GetNanny(oneContract.NannyId), oneContract.IsHourlyRate,
					bl.getContractByDelegate(x => x.MotherId == oneContract.MotherId).Count(), oneContract.RateOfMonth, query);
				}
				catch (BLException exp)
				{
					MessageBox.Show(exp.Message);
				}
			}

		}

		private void rateOfMonthTextBox_LostFocus(object sender, RoutedEventArgs e)
		{

			double query = double.Parse((sender as TextBox).Text);

			if (oneContract.NannyId != 0)
			{
				try
				{
					oneContract.Salary = bl.SalaryPerMonth(bl.GetNanny(oneContract.NannyId), oneContract.IsHourlyRate,
					bl.getContractByDelegate(x => x.MotherId == oneContract.MotherId).Count(), query);
				}
				catch (BLException exp)
				{
					MessageBox.Show(exp.Message);
				}
			}

		}
	}
}