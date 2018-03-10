using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Factory_BL
    {
        public static IBL GetIBL()
        {
            return new Bl_imp();
        }
    }
}
