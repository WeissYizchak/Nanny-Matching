using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child : Person, INotifyPropertyChanged
    {


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


        public event PropertyChangedEventHandler PropertyChanged;



        DateTime _BirthDate = DateTime.Now.Date;

        public DateTime BirthDate
        {
            get { return _BirthDate.Date; }
            set
            {
                if (value.Date > DateTime.Now.Date) throw new Exception("your date is in the future ");
                _BirthDate = value.Date;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BirthDate"));
            }
        }

        public bool IsSpecalNeed { get; set; }

        public string SpicialNeed { get; set; }

        public override string ToString()
        {
            return "name: " + FirstName + " " + LastName + " \nBithday: " + BirthDate.ToShortDateString();
        }

        public Child Clone()
        {
            return (Child)MemberwiseClone();
        }

    }
}