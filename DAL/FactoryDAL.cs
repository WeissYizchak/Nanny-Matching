using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDAL
    {
        public static IDAL GetIdal(string solution)
        {
            switch (solution)
            {
                case "XML":
                    return Dal_imp_XML.instance;
                case "colection":
                    return Dal_imp.Instance;
                default:
                    throw new DALException("ERROR: you have a critical problem in your progrem!!!");
            }
            
        }
    }
}
