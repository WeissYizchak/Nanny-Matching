using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DS
{
    public class DataSourceXml
    {
        public static XElement NannyRoot;
        static string nannyPath = @"Nanny.xml";

        public static XElement MotherRoot;
		static string MotherPath = @"Mother.xml";

        public static XElement ChildRoot;
		static string ChildPath = @"Child.xml";

        public static XElement ContractRoot;
		static string ContractPath = @"contract.xml";


		
		/// <summary>
		/// created new file to a root
		/// </summary>
		/// <param name="root"></param>
		/// <param name="rootName"></param>
		/// <param name="path"></param>
		private static void createdFile(ref XElement root ,string rootName ,string path)
        {
            root  = new XElement(rootName);
            root.Save(path);
        }

        /// <summary>
        /// Linking a file with an instance of Element.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="path"></param>
        public static XElement LoadData(string path)
        {
            try
            {
                XElement root = XElement.Load(path);
                return root;
            }
            catch
            {
                throw new Exception((string.Format("File {0} upload problem", path)));
            }
        }

        public static void saveNannis()
        {
            NannyRoot.Save(nannyPath);
        }

        public static void saveMothers()
        {
            MotherRoot.Save(MotherPath);
        }

        public static void saveChildren()
        {
            ChildRoot.Save(ChildPath);
        }

        public static void saveContracts()
        {
            ContractRoot.Save(ContractPath);
        }


        //constractor
        static DataSourceXml()
        {
            if (!File.Exists(nannyPath))
            {
                createdFile(ref NannyRoot, "nannies", nannyPath);
            }
            else
            {
                NannyRoot = XElement.Load(nannyPath);
            }
            if (!File.Exists(MotherPath))
            {
                createdFile(ref MotherRoot, "Mothers", MotherPath);
            }
            else
            {
                MotherRoot = XElement.Load(MotherPath);
            }
            if (!File.Exists(ChildPath))
            {
                createdFile(ref ChildRoot, "nannies", ChildPath);
            }
            else
            {
                ChildRoot = XElement.Load(ChildPath);
            }
            if (!File.Exists(ContractPath))
            {
                createdFile(ref ContractRoot, "Contract", ContractPath);
            }
            else
            {
                ContractRoot = XElement.Load(ContractPath);
            }
        }
    }
}
