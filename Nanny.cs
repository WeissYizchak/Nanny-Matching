using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny :Person, INotifyPropertyChanged
    {
        DateTime _birthday = DateTime.Now.Date;
        public DateTime BirthDate
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                if (value > DateTime.Now)
                    throw new Exception("error data!!");
            }
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

        public bool Elevetor { get; set; }

        public int Floor { get; set; }

        public int Experience { get; set; }

        int _cellphon;
        public int cellPhone
        {
            set
            {
                _cellphon = value;
                //if (value < 10000000 || value > 99999999)
                //    throw new Exception("it is not a ligal number");
            }
            get { return _cellphon; }
        }

        int _capacityChildren;
        public int CapacityChildren
        {
            get { return _capacityChildren; }
            set
            {
                _capacityChildren = value;
                if (value < 0) throw new Exception("capacity cen't to be negitiv number");
            }
        }

        int _maxAge;
        public int MaxAge_monthe
        {
            get { return _maxAge; }
            set
            {
                _maxAge = value;
                if (value < _minAge)
                    throw new Exception("the max age must to be bigger from the minimum age");
            }
        }

        int _minAge;
        public int MinAge_monthe
        {
            get { return _minAge; }
            set
            {
                _minAge = value;
                if (value > _maxAge)
                    throw new Exception("the min age must to be smolest from the max age");
            }
        }

        public bool IsHourlyRate { get; set; }

        public double SallaryPerHour { get; set; }

        public double SallaryPerMonths { get; set; }

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

        public bool MinistryEducationVaction { get; set; }

        public string Recommendations { get; set; }
        //public int MaxChildren { get; set; }

        public override string ToString()
        {
            return "first name: " + FirstName + ". last name: " + LastName +". \nID: " + Id + 
                ". \nAddress: " + Address + ". cellPhone: " + "0"+cellPhone;
        }

        public Nanny Clone()
        {
            return (Nanny)MemberwiseClone();
        }
    }
}
