using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void addNanny(BE.Nanny nan);
        void removeNanny(int id);
        void updateNannyDetails(BE.Nanny nan);

        void addMother(BE.Mother mam);
        void removeMother(int id);
        void updateMotherDetalse(BE.Mother mam);

        void addChild(BE.Child child);
        void removeChild(int id);
        void updateChildDetails(BE.Child child);

        void addContract(BE.Contract con);
        void updateContract(BE.Contract con);
        void removeContract(int ContractNumber);

        List<BE.Nanny> getNannis();
        List<BE.Mother> getMothers();
        List<BE.Child> getChildren();
        List<BE.Contract> getContracts();

        List<BE.Nanny> getNannisOrderToMotherNeeds(int motherId);
        List<BE.Nanny> getOrderCompatibilityNannies(int idNumber);
        List<BE.Nanny> nannisByDistance(int MotherId, int distance, string address = null);
        bool checkCompatibilityMotherNanny(BE.Nanny nan, BE.Mother mam);

        BE.Child GetChild(int idNumber);
		bool GetChildExsist(int idNumber);
		BE.Nanny GetNanny(int idNumber);
        BE.Mother GetMother(int idNumber);
        BE.Contract GetContract(int idNumber);
		double SalaryPerMonth(BE.Nanny nan, bool isDalyRate, int someBrothers, Double SallaryPerMonths = 0, Double SallaryPerHour = 0);
		void UpdateSalaryContracts(double salary, int momId, int NannyID);


		List<BE.Contract> getContractByDelegate(Func<BE.Contract, bool> predicat = null);
        IEnumerable<BE.Child> getChildrenFromMother(int idNumber);
    }
}
