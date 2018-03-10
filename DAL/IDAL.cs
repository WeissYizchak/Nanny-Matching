using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        void addNanny(Nanny nan);
        void removeNanny(int id);
        void updateNannyDetails(Nanny nan);

        void addMother(Mother mam);
        void removeMother(int id);
        void updateMotherDetalse(Mother mam);

        void addChild(Child child);
        void removeChild(int id);
        void updateChildDetails(Child child);

        void addContract(Contract con);
        void updateContract(Contract con);
        void removeContract(int ContractNumber);

        List<Nanny> getNannis();
        List<Mother> getMothers();
        List<Child> getChildren();
        List<Contract> getContracts();

        Child GetChild(int idNumber);
		bool GetChildExsist(int idNumber);
		Nanny GetNanny(int idNumber);
        Mother GetMother(int idNumber);
        Contract GetContract(int idNumber);
    }
}
