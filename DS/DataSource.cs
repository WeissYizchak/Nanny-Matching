using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public static class DataSource 
    {
        public static List<BE.Nanny> NannyList = new List<BE.Nanny>();
        public static List<BE.Mother> MotherList = new List<BE.Mother>();
		public static List<BE.Child> ChildrenList = new List<BE.Child>();
        public static List<BE.Contract> ContractList = new List<BE.Contract>();

        static DataSource() { }
    }
}
