using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.Xml.Linq;

namespace DAL
{
    sealed class Dal_imp_XML : IDAL
    {

        //static int Range = 1000; //to put number contract
        //singelton
        static public IDAL instance = new Dal_imp_XML();
        public static IDAL GetInstance { get { return instance; } }
        private Dal_imp_XML() { }
        static Dal_imp_XML() { }

       

        /// <summary>
        /// adds a child to the data base
        /// Exception:
        /// there is are the same Id in the data base.
        /// </summary>
        /// <param name="child">child object to add </param>
        public void addChild(Child child)
        {
			
			if (DataSourceXml.ChildRoot.Elements().Any(x=>(Convert.ToInt32(x.Element("Id").Value))==child.Id))
                throw new DALException("There is the same child id alredy");
            DataSourceXml.ChildRoot.Add(child.Clone().ChildToXML());
            DataSourceXml.saveChildren();
        }

        /// <summary>
        /// adds a contract to the data base
        /// Exception:
        /// there are a contract for this child
        /// in the data base no are a mother or nanny with approprite ID
        /// </summary>
        /// <param name="con">object of contract to add</param>
        public void addContract(Contract con)
        {
			
			if (DataSourceXml.ContractRoot.Elements().Any(x =>(Convert.ToInt32(x.Element("ChildId").Value) == con.ChildId)))
                throw new DALException("There is the same contract with this child id already");
            if (DataSourceXml.NannyRoot.Elements().All(x => (Convert.ToInt32(x.Element("Id").Value) != con.NannyId))) throw new DALException("ERROR: There is no are a nanny  with this id");
            if (DataSourceXml.MotherRoot.Elements().All(x => (Convert.ToInt32(x.Element("Id").Value) != con.MotherId)))
                throw new DALException("ERROR: There is no are a Mother with this id");
            //con.ContractNumber = ++Range;

            DataSourceXml.ContractRoot.Add(con.Clone().ContantToXML());
            DataSourceXml.saveContracts();
        }

        /// <summary>
        /// adds a mother to the data base
        /// Exception:
        /// in the data base is are a mother with the same ID
        /// </summary>
        /// <param name="mam">mother object to add</param>
        public void addMother(Mother mam)
        {
			
			if (DataSourceXml.MotherRoot.Elements().Any(x => (Convert.ToInt32(x.Element("Id").Value)) == mam.Id))
                throw new DALException("ERROR: There is the same mother id already");
            DataSourceXml.MotherRoot.Add(mam.MotherToXML());
            DataSourceXml.saveMothers();
        }

        /// <summary>
        /// adds a nanny to the data base
        /// Exception:
        /// in the data base is are a nanny with the same ID
        /// </summary>
        /// <param name="nan">nanny object to add</param>
        public void addNanny(Nanny nan)
        {
			var check = (from nanny in DataSourceXml.NannyRoot.Elements()
                         where (Convert.ToInt32(nanny.Element("Id").Value)) == nan.Id
                         select nanny).FirstOrDefault();

            if (check == null)
            {
                DataSourceXml.NannyRoot.Add(nan.Clone().NannyToXml());
                DataSourceXml.saveNannis();
            }
            else throw new Exception("There is the same nanny already");
        }

        /// <summary>
        /// gets child in accordance to the Id number
        /// </summary>
        /// <param name="idNumber">id number of child to cearch</param>
        /// <returns></returns>
        public Child GetChild(int idNumber)
        {
            Child result = (from child in DataSourceXml.ChildRoot.Elements()
                            where (Convert.ToInt32(child.Element("Id").Value)) == idNumber
                            select child.XmlToChild()).FirstOrDefault();
            if (result != null)
                return result;
            else
                throw new DALException("there is No Are a child with this ID number");
        }


		public bool GetChildExsist(int idNumber)
		{
			Child result = (from child in DataSourceXml.ChildRoot.Elements()
							where (Convert.ToInt32(child.Element("Id").Value)) == idNumber
							select child.XmlToChild()).FirstOrDefault();
			if (result != null)
				return true;
			else
				return false;
		}

		/// <summary>
		/// get all children from the data base
		/// </summary>
		/// <returns></returns>
		public List<Child> getChildren()
        {
            if (DataSourceXml.ChildRoot.Elements() == null)
                throw new DALException("ERROR: there no are Children");
            return (DataSourceXml.ChildRoot.Elements().Select(x => x.XmlToChild())).ToList();
        }

        /// <summary>
        /// gets contract in accordance to the Id number of the Child
        /// </summary>
        /// <param name="idNumber">id number of child to cearch his Contract</param>
        /// <returns></returns>
        public Contract GetContract(int idNumber)
        {
            Contract result = (from contract in DataSourceXml.ContractRoot.Elements()
                            where (Convert.ToInt32(contract.Element("ChildId").Value)) == idNumber
                            select contract.XmlToContract()).FirstOrDefault();
            if (result != null)
                return result;
            else
                throw new DALException("there is no are a contract for this Child ID number");
        }

        /// <summary>
        ///  get all contracts from the data base
        /// </summary>
        /// <returns></returns>
        public List<Contract> getContracts()
        {
            if (DataSourceXml.ContractRoot.Elements() == null)
                throw new DALException("ERROR: there no are contracts");
            return (DataSourceXml.ContractRoot.Elements().Select(x => x.XmlToContract())).ToList();
        }

        /// <summary>
        /// gets child in accordance to the Id number
        /// </summary>
        /// <param name="idNumber">id number of child to cearch</param>
        /// <returns></returns>
        public Mother GetMother(int idNumber)
        {
            Mother result = (from mother in DataSourceXml.MotherRoot.Elements()
                            where (Convert.ToInt32(mother.Element("Id").Value)) == idNumber
                            select mother.XmlToMother()).FirstOrDefault();
            if (result != null)
                return result;
            else
                throw new DALException("there is No Are a Mother with this ID number");
        }

        /// <summary>
        /// gets all Mothers from the data base
        /// </summary>
        /// <returns></returns>
        public List<Mother> getMothers()
        {
            if (DataSourceXml.MotherRoot.Elements() == null)
                throw new DALException("ERROR: there no are Mothers");
            return (DataSourceXml.MotherRoot.Elements().Select(x => x.XmlToMother())).ToList();
        }

        /// <summary>
        /// gets all Nannies from the data base
        /// </summary>
        /// <returns></returns>
        public List<Nanny> getNannis()
        {
            if (DataSourceXml.NannyRoot.Elements() == null)
                throw new DALException("ERROR: there no are nannies");
            return (DataSourceXml.NannyRoot.Elements().Select(x => x.XmlToNanny())).ToList();
        }

        /// <summary>
        /// gets child in accordance to the Id number
        /// </summary>
        /// <param name="idNumber">id number of Nanny to cearch</param>
        /// <returns></returns>
        public Nanny GetNanny(int idNumber)
        {
            Nanny result = (from nanny in DataSourceXml.NannyRoot.Elements()
                             where (Convert.ToInt32(nanny.Element("Id").Value)) == idNumber
                             select nanny.XmlToNanny()).FirstOrDefault();
            if (result != null)
                return result;
            else
                throw new DALException("there is No Are a Nanny with this ID number");
        }

        /// <summary>
        /// delete a Child from the data base
        /// </summary>
        /// <param name="id">childs id to remove</param>
        public void removeChild(int id)
        {
            XElement result = (from child in DataSourceXml.ChildRoot.Elements()
                            where Convert.ToInt32(child.Element("Id").Value) == id
                            select child).FirstOrDefault();
            if (result != null)
            {
                result.Remove();
                DataSourceXml.saveChildren();
            }
            else throw new DALException("ERROR: There is no Child with this id to remove");
        }

        /// <summary>
        /// dalete contract from the data base
        /// </summary>
        /// <param name="ContractNumber">contract number to remove</param>
        public void removeContract(int ContractNumber)
        {
            XElement result = (from contract in DataSourceXml.ContractRoot.Elements()
                               where Convert.ToInt32(contract.Element("ContractNumber").Value) == ContractNumber
                               select contract).FirstOrDefault();
            if(result != null)
            {
                result.Remove();
                DataSourceXml.saveContracts();
            }
            else throw new DALException("ERROR: There is no contract with this number to remove");
        }

        public void removeMother(int id)
        {
            XElement result = (from mother in DataSourceXml.MotherRoot.Elements()
                               where Convert.ToInt32(mother.Element("Id").Value) == id
                               select mother).FirstOrDefault();
            if (result != null)
            {
                result.Remove();
                DataSourceXml.saveMothers();
            }
            else throw new DALException("ERROR: There is no Mother with this id to remove");
        }

        public void removeNanny(int id)
        {
            XElement result = (from nanny in DataSourceXml.NannyRoot.Elements()
                               where Convert.ToInt32(nanny.Element("Id").Value) == id
                               select nanny).FirstOrDefault();
            if (result != null)
            {
                result.Remove();
                DataSourceXml.saveContracts();
            }
            else throw new DALException("ERROR: There is no nanny with this id to remove");
        }

        public void updateChildDetails(Child child)
        {
            removeChild(child.Id);
            addChild(child);
        }

        public void updateContract(Contract con)
        {
            removeContract(con.ContractNumber);
            addContract(con);
        }

        public void updateMotherDetalse(Mother mam)
        {
            removeMother(mam.Id);
            addMother(mam);
        }

        public void updateNannyDetails(Nanny nan)
        {
            removeNanny(nan.Id);
            addNanny(nan);
        }
    }
}
