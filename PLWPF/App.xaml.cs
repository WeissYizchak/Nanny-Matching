using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            //set the global culture to hebrew to avoid errors
            //CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("he-IL");
            //CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("he-IL");
            //CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("he-IL");
            //CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("he-IL");
        }
    }
}
