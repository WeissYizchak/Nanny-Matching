using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother  :Person, INotifyPropertyChanged
    {

        int _cellphon;
        public int cellPhone
        {
            set
            {
               _cellphon = value;
                //if (value < 100000000 || value > 999999999)
                //    throw new Exception("it is not a ligal number");
            }
            get { return _cellphon; }
        }

        string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("address cen't to be empty");
                }
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("Address"));
			}
        }

        public string AreaToSearch { get; set; }

		public Day[] timeWorkofWeek = new Day[]
		 {
			new Day(),
			new Day(),
			new Day(),
			new Day(),
			new Day(),
			new Day()
		 };
		public event PropertyChangedEventHandler PropertyChanged;

        public string Remarks { get; set; }

        public override string ToString()
        {
            return "name: " + FirstName + " " + LastName + ". \nID: " + Id + ". \nCellPhon number: " + "0" + cellPhone
                + ". address: " + Address;
        }

        public Mother Clone()
        {
            return (Mother)MemberwiseClone();
        }

        public Mother() { }

    }
}
