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
using System.Collections.ObjectModel;
using BE;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChildPage.xaml
    /// </summary>
    public partial class ChildPage : Page
    {
        private List<string> errorMessages = new List<string>();
        Child oneChild;
        BL.IBL bl;

        private ObservableCollection<Child> childListObserver = new ObservableCollection<Child>();
        public ChildPage()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetIBL();
            AddToObserver(bl.getChildren());
            DataContext = childListObserver;
            oneChild = new Child();
            this.gridChildData.DataContext = oneChild;
        }

        public void AddToObserver(IList<Child> list)
        {
            list.ToList().ForEach(childListObserver.Add);
        }

        public void removeFromObserver(int? ID)
        {

            Child temp = new Child();
            foreach (var i in childListObserver) { if (i.Id == ID) { temp = i; } }
            childListObserver.Remove(temp);
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

                    bl.addChild(oneChild);
                    childListObserver.Add(oneChild);
                    oneChild = new Child();
                    this.gridChildData.DataContext = oneChild;

                    //clear the value from all fileds
                    //ClearValueOfFields();
                }
                // this.nameTextBox.Text = ""            
                catch (FormatException) { MessageBox.Show("check your input and try again"); }
                catch (OverflowException) { MessageBox.Show("check your input long number and try again"); }
                catch (BL.BLException exp) { MessageBox.Show(exp.Message); }
            }

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
                    if (idTextBox.Text.Count() == 0) throw new PlException("Threr is no child to delete");
                    bl.updateChildDetails(oneChild);
                    removeFromObserver(oneChild.Id);
                    childListObserver.Add(oneChild);
                    oneChild = new Child();
                    this.gridChildData.DataContext = oneChild;

                }
                catch (PlException plExe) { MessageBox.Show(plExe.Message); }
                catch (BL.BLException exp) { MessageBox.Show(exp.Message); }


            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (idTextBox.Text.Count() == 0) throw new PlException("Threr is no child to delete");
                bl.removeChild(int.Parse(this.idTextBox.Text));
                removeFromObserver(int.Parse(this.idTextBox.Text));
                oneChild = new Child();
                this.gridChildData.DataContext = oneChild;
                //ClearValueOfFields();
            }
            catch (PlException plExe) { MessageBox.Show(plExe.Message); }
            catch (BL.BLException exp) { MessageBox.Show(exp.Message); }
        }

		bool checkFildes()
		{
			if ( idTextBox.Text == "0" || firstNameTextBox.Text == ""
				|| lastNameTextBox.Text == "" || motherIdTextBox.Text =="0"
				)
			{
				return false;
			}
			return true;

		}



		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Child)
            {
                if (this.UpdateChild.IsChecked == true)
                {
                    oneChild = (Child)(dataGrid.SelectedItem as Child).Clone();
                    this.gridChildData.DataContext = oneChild;
                }
                else
                {
                    Child selectedChild = (Child)(dataGrid.SelectedItem as Child);
                    this.gridChildData.DataContext = selectedChild;
                }
            }

        }

        private void UpdateChild_Checked(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                oneChild = (Child)(dataGrid.SelectedItem as Child).Clone();
                this.gridChildData.DataContext = oneChild;
            }
        }




        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            var data = bl.getMothers();


            List<string> data1 = new List<string>();
            foreach (var obj in data)
            {
                data1.Add(obj.Id.ToString() + " FN - " + obj.FirstName + " LN- " + obj.LastName);

            }

            string query = (sender as TextBox).Text;

            if (query.Length == 0 || query == "0")
            {
                // Clear   
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            resultStack.Children.Clear();

            // Add the result   
            foreach (var obj in data1)
            {

                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                resultStack.Children.Add(new TextBlock() { Text = "No results found." });
            }
        }

        private void addItem(string text)
        {
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
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
                //motherIdTextBox.Text = textAfter[0];
                oneChild.MotherId = int.Parse(textAfter[0]);
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
            resultStack.Children.Add(block);
        }

        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                errorMessages.Add(e.Error.Exception.Message);
            }
            else
                errorMessages.Remove(e.Error.Exception.Message);
        }
    }
}