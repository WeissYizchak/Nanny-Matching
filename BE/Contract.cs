using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public int ContractNumber { get; set; }

        int _NannyID;
        public int NannyId
        {
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("you need to insert nanny id ");
                }
                _NannyID = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NannyId"));
            }
            get
            {
                return _NannyID;
            }

        }

        int _MotherId;
        public int MotherId
        {

            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("you need to insert mother id ");
                }
                _MotherId = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MotherId"));
            }
            get
            {
                return _MotherId;
            }

        }

        int _ChildId;
        public int ChildId
        {
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("you need to insert child id ");
                }
                _ChildId = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ChildId"));
            }
            get
            {
                return _ChildId;
            }

        }

        public bool IsAcquaintance { get; set; }

        public bool IsContract { get; set; }

		Double _RateOfHour;

		public double RateOfHour
		{
			get { return _RateOfHour; }
			set
			{
				_RateOfHour = value;
				if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs("RateOfHour"));
			}
		}

		Double _RateOfMonth;

		public double RateOfMonth
		{
			get { return _RateOfMonth; }
			set
			{
				_RateOfMonth = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("RateOfMonth"));
			}
		}


		double _Salary;

		public double Salary
		{
			get { return _Salary; }
			set
			{
				_Salary = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("Salary"));
			}

		}

		bool _IsHourlyRate;

		public bool IsHourlyRate
		{
			get { return _IsHourlyRate; }
			set
			{
				_IsHourlyRate = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("IsHourlyRate"));
			}
		}

        DateTime _startEmploment = DateTime.Now.Date;
        public DateTime stertEmployment
        {
            get { return _startEmploment; }
            set
            {
                if (value.Date > endEmployment) throw new Exception("ERROR: the start date is after the end date!!");
                _startEmploment = value.Date;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("stertEmployment"));
            }
        }

        DateTime _endEmploment = DateTime.Now;
        public DateTime endEmployment
        {
            get { return _startEmploment; }
            set
            {
                if (value.Date < stertEmployment) throw new Exception("ERROR: the end date is before the start date!!");
                _endEmploment = value.Date;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("endEmployment"));
            }
        }
        public override string ToString()
        {
            return "Contract ID: " + ContractNumber + ".  nenny id: " + NannyId + ". \nmother id: " + MotherId
                + ".  child id: " + ChildId + ". \nsalary: " + Salary + ".";
            ;
        }

        public Contract Clone()
        {
            return (Contract)MemberwiseClone();
        }
    }
}