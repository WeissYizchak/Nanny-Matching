using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.Runtime.Serialization;

namespace DAL
{
    sealed class Dal_imp : IDAL
    {

        static readonly IDAL instance = new Dal_imp();
        // static int Range = 1000;
        public static IDAL Instance { get { return instance; } }

        Dal_imp() { }
        static Dal_imp() { }


        /// <summary>
        /// adds a Nanny object to the list
        /// throw Exception if there a Nanny with the same id.
        /// </summary>
        /// <param name="nen">a Nanny object to add</param>
        public void addNanny(Nanny nen)
        {
            if (DataSource.NannyList.Any(x => x.Id == nen.Id)) throw new DALException("There is the same nanny already");
            DataSource.NannyList.Add(nen.Clone());
        }

        /// <summary>
        /// Deletes a certain Nanny from the list.
        /// Sending an exception if it does not exist.
        /// </summary>
        /// <param name="nan">id number</param>
        public void removeNanny(int id)
        {
            if (DataSource.NannyList.All(X => X.Id != id)) throw new DALException("There is  no nanny to delete");
            DataSource.NannyList = DataSource.NannyList.Where(c => c.Id != id).ToList();
        }

        /// <summary>
        /// update a one nanny
        /// 
        /// replice the old nanny with updated nanny
        /// </summary>
        /// <param name="nan">updeted nanny object</param>
        public void updateNannyDetails(Nanny nan)
        {
            if (DataSource.NannyList.All(X => X.Id != nan.Id)) throw new DALException("There is no nanny to update");
            DataSource.NannyList = (from item in DataSource.NannyList
                                    where item.Id != nan.Id
                                    select item).ToList();
            DataSource.NannyList.Add(nan.Clone());
        }


        /// <summary>
        /// adds a Mother object to the list
        /// throw Exception if there a mother with the same id.
        /// </summary>
        /// <param name="mam">mother object to add</param>
        public void addMother(Mother mam)
        {
            if (DataSource.MotherList.Any(x => x.Id == mam.Id))
                throw new DALException("There is the same mother id already");
            DataSource.MotherList.Add(mam.Clone());
        }


        /// <summary>
        /// Deletes a certain Mother from the list.
        /// Sending an exception if it does not exist.
        /// </summary>
        /// <param name="id">id number</param>
        public void removeMother(int id)
        {
            if (DataSource.MotherList.All(X => X.Id != id))
                throw new DALException("There is no Mother to Delete");
            DataSource.MotherList = DataSource.MotherList.Where(c => c.Id != id).ToList();
        }

        /// <summary>
        /// update one mother
        /// replice the old mother with updated mother
        /// </summary>
        /// <param name="mam">updated mother object</param>
        public void updateMotherDetalse(Mother mam)
        {
            if (DataSource.MotherList.All(X => X.Id != mam.Id)) throw new DALException("There is no Mother to update");
            DataSource.MotherList = (from item in DataSource.MotherList
                                     where item.Id != mam.Id
                                     select item).ToList();
            DataSource.MotherList.Add(mam.Clone());
        }


        /// <summary>
        /// adds a Child object to the list
        /// throw Exception if there a Child with the same id.
        /// </summary>
        /// <param name="child">a Child object to add</param>
        public void addChild(Child child)
        {
            if (DataSource.ChildrenList.Any(x => x.Id == child.Id))
                throw new DALException("There is the same child id alredy");
            DataSource.ChildrenList.Add(child.Clone());
        }


        /// <summary>
        /// Deletes a certain Child from the list.
        /// Sending an exception if it does not exist
        /// </summary>
        /// <param name="id">id number</param>
        public void removeChild(int id)
        {
            if (DataSource.ChildrenList.All(x => x.Id != id)) throw new DALException("There is no child to delete");
            DataSource.ChildrenList = DataSource.ChildrenList.Where(x => x.Id == id).ToList();
            //delete the childs contract
            DataSource.ContractList = DataSource.ContractList.Where(x => x.ChildId == id).ToList();
        }

        /// <summary>
        /// update one child
        /// replice the old child with updated child
        /// </summary>
        /// <param name="child">updated child object</param>
        public void updateChildDetails(Child child)
        {
            if (DataSource.ChildrenList.All(X => X.Id != child.Id)) throw new DALException("There is no child to update");
            DataSource.ChildrenList = (from item in DataSource.ChildrenList
                                       where item.Id != child.Id
                                       select item).ToList();
            DataSource.ChildrenList.Add(child.Clone());
        }

        /// <summary>
        /// adds to the contract a range number
        /// adds a Contract to the collction of Contracts
        /// 
        /// Exseption:
        /// if there are a contract to this child
        /// or if the mother or the nanny is not there
        /// </summary>
        /// <param name="con">a contract to add</param>
        public void addContract(Contract con)
        {
            if (DataSource.ContractList.Any(x => x.ChildId == con.ChildId)) throw new DALException("There is the same contract with this child id already");
            if (DataSource.NannyList.All(x => x.Id != con.NannyId))
                throw new DALException("ERROR: There is no are a nanny  with this id");
            if (DataSource.MotherList.All(x => x.Id != con.MotherId)) throw new DALException("There is the same contract with this mother id  already");
            DataSource.ContractList.Add(con.Clone());
        }

        /// <summary>
        /// updete one contract
        /// replice the old contract with updated contract
        /// </summary>
        /// <param name="con">updated contract object</param>
        public void updateContract(Contract con)
        {
            if (DataSource.ContractList.All(X => X.ChildId != con.ChildId)) throw new DALException("There is no contract to update");
            DataSource.ContractList = (from item in DataSource.ContractList
                                       where item.ChildId != con.ChildId
                                       select item).ToList();
            DataSource.ContractList.Add(con.Clone());
        }

        /// <summary>
        /// delete one contract from the colection
        /// 
        /// Exception:
        /// if there not exsist the certin contract.
        /// </summary>
        /// <param name="con">the contract number to delete</param>
        public void removeContract(int numberContract)
        {
            if (DataSource.ContractList.All(x => x.ContractNumber != numberContract))
                throw new DALException("There is no contract to remove");
            DataSource.ContractList = DataSource.ContractList.Where(x => x.ContractNumber != numberContract).ToList();
        }

        /// <summary>
        /// return the clone list of nannies
        /// </summary>
        /// <returns></returns>
        public List<Nanny> getNannis()
        {
            if (DataSource.NannyList == null) throw new DALException("The list of nannis are empty");
            var temp = DataSource.NannyList.Select(item => item.Clone()).ToList();
            return temp;
        }

        /// <summary>
        /// return clone list of Motheres
        /// </summary>
        /// <returns></returns>
        public List<Mother> getMothers()
        {
            if (DataSource.MotherList == null) throw new DALException("The list of mothers are empty");
            var temp = DataSource.MotherList.Select(item => item.Clone()).ToList();
            return temp;
        }

        /// <summary>
        /// return clone list of Children
        /// </summary>
        /// <returns></returns>
        public List<Child> getChildren()
        {
            if (DataSource.ChildrenList == null) throw new DALException("The list of children are empty");
            var temp = DataSource.ChildrenList.Select(item => item.Clone()).ToList();
            return temp;
        }

        /// <summary>
        /// return clone list of contractes
        /// </summary>
        /// <returns></returns>
        public List<Contract> getContracts()
        {
            if (DataSource.ContractList == null) throw new DALException("The list of contracts are empty");
            var temp = DataSource.ContractList.Select(item => item.Clone()).ToList();
            return temp;
        }

        /// <summary>
        /// get one Child from the collection order to the child's id
        /// </summary>
        /// <param name="idNumber">child's id</param>
        /// <returns>Child object</returns>
        public Child GetChild(int idNumber)
        {
            if (DataSource.ChildrenList.All(x => x.Id != idNumber)) throw new DALException("There is no Child with this id");
            var child = from item in DataSource.ChildrenList
                        where item.Id == idNumber
                        select item.Clone();
            return child.ToList()[0];
        }

		public bool GetChildExsist(int idNumber)
		{
			if (DataSource.ChildrenList.All(x => x.Id != idNumber))
			{
				return false;
			}
			else
			{
				return true;
			}

		}

        /// <summary>
        /// get one Nanny from the collction, order to the naani's id
        /// </summary>
        /// <param name="idNumber">nanni's id</param>
        /// <returns>Nanny object</returns>
        public Nanny GetNanny(int idNumber)
        {
            if (DataSource.NannyList.All(x => x.Id != idNumber)) throw new DALException("There is no nanny with this id");
            var nanny = from item in DataSource.NannyList
                        where item.Id == idNumber
                        select item.Clone();
            return nanny.ToList()[0];
        }

        /// <summary>
        /// get one Mother from the collction, order to the mother's id
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        public Mother GetMother(int idNumber)
        {
            if (DataSource.MotherList.All(x => x.Id != idNumber)) throw new DALException("There is no mother with this id");
            var mother = from item in DataSource.MotherList
                         where item.Id == idNumber
                         select item.Clone();
            return mother.ToList()[0];
        }

        /// <summary>
        /// get one contract from the collection order to the child's id
        /// </summary>
        /// <param name="idNumber">child id to cerch</param>
        /// <returns>contract object</returns>
        public Contract GetContract(int idNumber)
        {
            if (DataSource.ContractList.All(x => x.ChildId != idNumber)) throw new DALException("There is no contract with this id child");
            var con = from item in DataSource.ContractList
                      where item.ChildId == idNumber
                      select item.Clone();
            return con.ToList()[0];
        }
    }
}
