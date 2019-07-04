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
using System.Globalization;
using GoogleMapsApi;
using GoogleMapsApi.Entities.PlaceAutocomplete.Request;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace PLWPF
{

    public class NotBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (parameter != null)
            {
                switch (parameter as String)
                {
                    case "dataGrid":
                        if (boolValue)
                        {
                            
                            return Visibility.Collapsed;
                        }
                        else
                        {
                           
                            return Visibility.Visible;
                        }
                }
            }
            if (boolValue)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// Interaction logic for MotherPage.xaml
    /// </summary>
    public partial class MotherPage : Page
    {
        Mother mom;
		BL.IBL bl;
        Day tempDay;
        Day[] tempArray = new Day[6];
        List<string> errorMessages= new List<string>();
		private ObservableCollection<Mother> motherlistObserver = new ObservableCollection<Mother>();
        
		public MotherPage(BL.IBL Item)
        {
           
            InitializeComponent();
            bl = Item;
			mom = new Mother();
			nameDey.Content = "Sunday"; //set day name
            tempArray = mom.timeWorkofWeek; //create new array
            tempDay = new Day(); //show the first day
            timeGrid.DataContext = tempDay;
			
            
			
            AddToObserver(bl.getMothers());
            DataContext = motherlistObserver;
			
			gridMomData.DataContext = mom;
		}

        public void AddToObserver(IList<Mother> list)
        {
            list.ToList().ForEach(motherlistObserver.Add);
        }

        public void removeFromObserver(int ID)
        {

            Mother temp= new Mother();
            foreach(var i in motherlistObserver)  { if (i.Id == ID) { temp = i; }}
            motherlistObserver.Remove(temp);
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessages.Any() || checkFildes())
                {
                    string exception = "you have some Exceptions in your input ";
                    //foreach (var item in errorMessages)
                    //{
                    //    exception += item + "\n";
                    //}
                    MessageBox.Show(exception);
                    return;
                }

                mom.timeWorkofWeek = tempArray; //keep the time by the nother
                    bl.addMother(mom);
                    motherlistObserver.Add(mom);

				mom = new BE.Mother();
					nameDey.Content = "Sunday"; //set day name
                    tempArray = mom.timeWorkofWeek; //create new array
                    tempDay = new Day(); //show the first day
                    timeGrid.DataContext = tempDay;

                   
                    gridMomData.DataContext = mom;
               
            }          
            catch (FormatException){ MessageBox.Show("check your input and try again"); }
			catch (OverflowException) { MessageBox.Show("check your input long number and try again"); }
			catch (BL.BLException exp){ MessageBox.Show(exp.Message); }
			
		}

        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{

            try
            {
                if (errorMessages.Any() || checkFildes())
                {
                    string exception = "you have some Exceptions in your input! ";
                    //foreach(var item in errorMessages)
                    //{
                    //    exception += item + "\n";
                    //}
                    MessageBox.Show(exception);
                    return;
                }
                if (idTextBox.Text.Count() == 0) throw new PlException("Threr is no mother to Update");

                mom.timeWorkofWeek = tempArray;
                bl.updateMotherDetalse(mom);
                removeFromObserver(mom.Id);
                motherlistObserver.Add(mom);

                mom = new Mother();
                nameDey.Content = "Sunday";
                tempArray =mom.timeWorkofWeek ; //create new array
                tempDay = new Day(); //show the first day
                timeGrid.DataContext = tempDay;
                gridMomData.DataContext = mom;
                

            }
            catch (PlException plExe) { MessageBox.Show(plExe.Message); }
            catch (BL.BLException exp) { MessageBox.Show(exp.Message); }


        }
		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
            try
            {

                if (idTextBox.Text.Count() == 0) throw new PlException("Threr is no mother to delete");

                bl.removeMother(int.Parse(this.idTextBox.Text));
                removeFromObserver(int.Parse(this.idTextBox.Text));

                mom = new Mother();
                nameDey.Content = "Sunday";
                tempArray = mom.timeWorkofWeek; //create new array
                tempDay = new Day(); //show the first day

                timeGrid.DataContext = tempDay;
                gridMomData.DataContext = mom;


            }
            catch (PlException plExe) { MessageBox.Show(plExe.Message); }
            catch (BL.BLException exp) { MessageBox.Show(exp.Message); }
        }
		//====================

		bool checkFildes()
		{
			if (addressTextBox.Text == "" || cellPhoneTextBox.Text == "0"
				|| idTextBox.Text == "0" || firstNameTextBox.Text == ""
				|| lastNameTextBox.Text == "" || cellPhoneTextBox.Text == "0")
			{
				return true;
			}
			return false;

		}


		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dataGrid.SelectedItem is Mother)
			{ 
			    mom = (dataGrid.SelectedItem as Mother);

                //Displays the list of work hours of the selected mother
                tempArray = mom.timeWorkofWeek;

                nameDey.Content = "Sunday";
                tempDay = tempArray[0];
                if (tempDay == null) tempDay = new Day();
                timeGrid.DataContext = tempDay;

			    gridMomData.DataContext = mom;
			    
			}

		}
		
        private void Button_Click(object sender, RoutedEventArgs e)
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


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (nameDey.Content.ToString() != "Friday") {
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

        private void Page_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);
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

		

		private void addressTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
            if ((sender as TextBox).IsFocused)
            {
                bool found = false;
                var border = (resultStack.Parent as ScrollViewer).Parent as Border;
                var data = bl.getMothers();

                try
                {

                    string query = (sender as TextBox).Text;
                    List<string> data1 = new List<string>();
                    if (query.Length == 0 || query == "0")
                    {
                        // Clear   
                        resultStack.Children.Clear();
                        border.Visibility = Visibility.Collapsed;
                    }
                    else if (query.Length > 1) //>6
                    {
                        border.Visibility = Visibility.Visible;
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
                }catch(Exception exception)
                {
                    resultStack.Children.Add(new TextBlock() { Text = exception.Message });
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

			// Mouse events   - if 
			block.MouseLeftButtonUp += (sender, e) =>
			{
				//motherIdTextBox.Text = textAfter[0];
				mom.Address = text;
				border.Visibility = Visibility.Collapsed;
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
            try
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
            }catch(Exception exception)
            {
                throw exception;
            }
		}

        private void Mother_Checked(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text != "0" && idTextBox.Text != "")
            {
                try
                {
                    mom = new Mother();
                    nameDey.Content = "Sunday"; //set day name
                    tempArray = mom.timeWorkofWeek; //create new array
                    tempDay = new Day(); //show the first day
                    timeGrid.DataContext = tempDay;

                    AddToObserver(bl.getMothers());
                    DataContext = motherlistObserver;

                    gridMomData.DataContext = mom;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                ;
            }
        }

        private void addressTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            addresBordr.Visibility = Visibility.Collapsed;
        }
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

}


	
