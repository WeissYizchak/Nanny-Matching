using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        int _id;
        public int Id
        {
            set
            {
                if (value < 100000000 || value > 999999999)
                    throw new Exception("the id shoulde be nine dighit!");
                _id = value;
            }
            get { return _id; }
        }

        string _lastName;
        public string LastName
        {
            set
            {
                _lastName = value;
                if (string.IsNullOrEmpty(value))
                    throw new Exception("the Lest name con't be empty");
            }
            get { return _lastName; }
        }

        string _firstName;
        public string FirstName
        {
            set
            {
                _firstName = value;
                if (string.IsNullOrEmpty(value))
                    throw new Exception("the First name con't be empty");
            }
            get { return _firstName; }
        }
    }
}