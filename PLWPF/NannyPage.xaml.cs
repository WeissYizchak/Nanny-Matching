using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Net;
using Newtonsoft.Json;

namespace PLWPF
{


    /// <summary>
    /// Interaction logic for NannyPage.xaml
    /// </summary>
    public partial class NannyPage : Page
    {


        Day[] tempArray = new BE.Day[6];
        Day tempDay;
        Nanny nan;
        BL.IBL bl;
        List<string> errorMessages = new List<string>();
        private ObservableCollection<Nanny> nannyListObsrver = new ObservableCollection<Nanny>();

        //constractor
        public NannyPage(BL.IBL item)
        {
            bl = item;
            InitializeComponent();
            nan = new Nanny();

            nameDey.Content = "Sunday"; //set day name
            tempArray = nan.timeWorkofWeek; //create new array
            tempDay = new Day(); //show the first day
            timeGrid.DataContext = tempDay;

            AddToObserver(bl.getNannis());
            DataContext = nannyListObsrver;
            gridNanData.DataContext = nan;
        }


        //Manage an observer list
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public void AddToObserver(IList<Nanny> list)
        {
            list.ToList().ForEach(nannyListObsrver.Add);
        }

        public void removeFromObserver(int ID)
        {

            Nanny temp = new Nanny();
            foreach (var i in nannyListObsrver) { if (i.Id == ID) { temp = i; } }
            nannyListObsrver.Remove(temp);
        }
        //=========

        // add, Update and delete

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessages.Any() || checkFildes())
                {
                    string exception = "you have some Exceptions: \n";
                    foreach (var item in errorMessages)
                    {
                        exception += item + "\n";
                    }
                    MessageBox.Show(exception);
                    return;
                }

                nan.timeWorkofWeek = tempArray; //keep the time by the nother
                bl.addNanny(nan);
                nannyListObsrver.Add(nan);

                nan = new Nanny();
                nameDey.Content = "Sunday"; //set day name
                tempArray = nan.timeWorkofWeek; //create new array
                tempDay = new Day(); //show the first day
                timeGrid.DataContext = tempDay;


                gridNanData.DataContext = nan;

            }
            catch (FormatException) { MessageBox.Show("check your input and try again"); }
            catch (OverflowException) { MessageBox.Show("check your input long number and try again"); }
            catch (BL.BLException exp) { MessageBox.Show(exp.Message); }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (errorMessages.Any() || checkFildes())
                {
                    string exception = "you have some Exceptions: \n";
                    foreach (var item in errorMessages)
                    {
                        exception += item + "\n";
                    }
                    MessageBox.Show(exception);
                    return;
                }
                if (idTextBox.Text.Count() == 0) throw new PlException("Threr is no mother to Update");

                nan.timeWorkofWeek = tempArray;
                bl.updateNannyDetails(nan);
                removeFromObserver(nan.Id);
                nannyListObsrver.Add(nan);

                nan = new Nanny();
                nameDey.Content = "Sunday";
                tempArray = nan.timeWorkofWeek; //create new array
                tempDay = new Day(); //show the first day
                timeGrid.DataContext = tempDay;
                gridNanData.DataContext = nan;


            }
            catch (PlException plExe) { MessageBox.Show(plExe.Message); }
            catch (BL.BLException exp) { MessageBox.Show(exp.Message); }


        }


        bool checkFildes()
        {
            if (addressTextBox.Text == "" || cellPhoneTextBox.Text == "0"
                || idTextBox.Text == "0" || firstNameTextBox.Text == ""
                || lastNameTextBox.Text == "" || cellPhoneTextBox.Text == "0"
                || capacityChildrenTextBox.Text == "0")
            {
                return true;
            }
            return false;

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (idTextBox.Text.Count() == 0) throw new PlException("Threr is no mother to delete");

                bl.removeNanny(int.Parse(this.idTextBox.Text));
                removeFromObserver(int.Parse(this.idTextBox.Text));

                nan = new Nanny();
                nameDey.Content = "Sunday";
                tempArray = nan.timeWorkofWeek; //create new array
                tempDay = new Day(); //show the first day

                timeGrid.DataContext = tempDay;
                gridNanData.DataContext = nan;


            }
            catch (PlException plExe) { MessageBox.Show(plExe.Message); }
            catch (BL.BLException exp) { MessageBox.Show(exp.Message); }
        }
        //===============

        /// <summary>
        /// Links the selected nanny to the fields on the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Nanny)
            {
                nan = (dataGrid.SelectedItem as Nanny);

                //Displays the list of work hours of the selected nanny
                tempArray = nan.timeWorkofWeek;

                nameDey.Content = "Sunday";
                tempDay = tempArray[0];
                if (tempDay == null) tempDay = new Day();
                timeGrid.DataContext = tempDay;

                gridNanData.DataContext = nan;

            }

        }


        //Functions for handling input errors

        private void Page_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                errorMessages.Add(e.Error.Exception.Message);
                SaveButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
            }
            else
            {
                errorMessages.Remove(e.Error.Exception.Message);
                if (errorMessages.Count == 0)
                {
                    SaveButton.IsEnabled = true;
                    UpdateButton.IsEnabled = true;
                }
            }
        }

        //=============


        //Time input management

        /// <summary>
        /// givs the value of a day
        /// </summary>
        /// <returns></returns>
        int numberDay()
        {
            switch (nameDey.Content.ToString())
            {
                case "Sunday":
                    return 0;
                case "Monday":
                    return 1;
                case "Tuesday":
                    return 2;
                case "Wednesday":
                    return 3;
                case "Thursday":
                    return 4;
                case "Friday":
                    return 5;
                default:
                    throw new PlException();
            }
        }

        private void StartTimeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "00:00:00")
                (sender as TextBox).Clear();
        }

        private void EndTimeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "00:00:00")
                (sender as TextBox).Clear();
        }



        private void Button_DOWNClick(object sender, RoutedEventArgs e)
        {
            if (nameDey.Content.ToString() != "Friday")
            {
                int num = numberDay();
                tempArray[num] = tempDay;
                num++;
                tempDay = tempArray[num];
                if (tempDay == null) tempDay = new Day();
                timeGrid.DataContext = tempDay;

                switch (nameDey.Content.ToString())
                {
                    case "Sunday":
                        nameDey.Content = "Monday";
                        break;
                    case "Monday":
                        nameDey.Content = "Tuesday";
                        break;
                    case "Tuesday":
                        nameDey.Content = "Wednesday";
                        break;
                    case "Wednesday":
                        nameDey.Content = "Thursday";
                        break;
                    case "Thursday":
                        nameDey.Content = "Friday";
                        break;
                    default:
                        throw new PlException();
                }
            }
        }

        private void Button_UPClick(object sender, RoutedEventArgs e)
        {
            if (nameDey.Content.ToString() != "Sunday")
            {
                int num = numberDay();
                tempArray[num] = tempDay;
                num--;
                tempDay = tempArray[num];
                if (tempDay == null) tempDay = new Day();
                timeGrid.DataContext = tempDay;
                switch (nameDey.Content.ToString())
                {
                    case "Monday":
                        nameDey.Content = "Sunday";
                        break;
                    case "Tuesday":
                        nameDey.Content = "Monday";
                        break;
                    case "Wednesday":
                        nameDey.Content = "Tuesday";
                        break;
                    case "Thursday":
                        nameDey.Content = "Wednesday";
                        break;
                    case "Friday":
                        nameDey.Content = "Thursday";
                        break;
                    default:
                        throw new PlException();
                }
            }
        }


        private void addressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).IsFocused)
            {
                bool found = false;
                var border = (resultStack.Parent as ScrollViewer).Parent as Border;
                var data = bl.getMothers();



                string query = (sender as TextBox).Text;
                List<string> data1 = new List<string>();
                if (query.Length == 0 || query == "0")
                {
                    // Clear   
                    resultStack.Children.Clear();
                    border.Visibility = System.Windows.Visibility.Collapsed;
                }
                else if (query.Length > 6)
                {
                    border.Visibility = System.Windows.Visibility.Visible;
                    data1 = GetPlaceAutoComplete(query);
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
                nan.Address = text;
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

        public static List<string> GetPlaceAutoComplete(string str)
        {



            string url = @"https://maps.googleapis.com/maps/api/place/queryautocomplete/json?key=AIzaSyBOnlDaieP2QlVLk_LhpUi1kSEhRfds14M&input=" + str;
            List<string> result = new List<string>();
            WebRequest request = WebRequest.Create(url);

            WebClient wc = new WebClient();
            var json = wc.DownloadString(url);
            //	WebResponse response = request.GetResponse();

            //	Stream data = response.GetResponseStream();

            //	StreamReader reader = new StreamReader(data);


            // json-formatted string from maps api
            //	string responseFromServer = reader.ReadToEnd();
            RootObject datalist = JsonConvert.DeserializeObject<RootObject>(json);
            for (int i = 0; i < datalist.predictions.Count; i++)
            {
                result.Add(datalist.predictions[i].description);
            }

            // response.Close();


            return result;

            //List<string> result = new List<string>();
            //	PlaceAutocompleteRequest request = new PlaceAutocompleteRequest();
            //request.ApiKey = "AIzaSyBOnlDaieP2QlVLk_LhpUi1kSEhRfds14M";
            //request.Input = str;

            //var response = GoogleMaps.PlaceAutocomplete.Query(request);

            //	foreach (var item in response.Results) { result.Add(item.Description); }

        }



        public class MatchedSubstring
        {
            public int length { get; set; }
            public int offset { get; set; }
        }

        public class MainTextMatchedSubstring
        {
            public int length { get; set; }
            public int offset { get; set; }
        }

        public class StructuredFormatting
        {
            public string main_text { get; set; }
            public List<MainTextMatchedSubstring> main_text_matched_substrings { get; set; }
            public string secondary_text { get; set; }
        }

        public class Term
        {
            public int offset { get; set; }
            public string value { get; set; }
        }

        public class Prediction
        {
            public string description { get; set; }
            public string id { get; set; }
            public List<MatchedSubstring> matched_substrings { get; set; }
            public string place_id { get; set; }
            public string reference { get; set; }
            public StructuredFormatting structured_formatting { get; set; }
            public List<Term> terms { get; set; }
            public List<string> types { get; set; }
        }

        public class RootObject
        {
            public List<Prediction> predictions { get; set; }
            public string status { get; set; }
        }

        private void addressTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            addresBorder.Visibility = Visibility.Collapsed;
        }
    }


}