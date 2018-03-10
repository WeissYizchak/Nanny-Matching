using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.Xml;

namespace DAL
{
    static class ToolsForXML
    {
        //===============================
        //converters objects to XElemnt
        //===============================


        public static XElement NannyToXml(this Nanny nanny)
        {
            return new XElement("Nanny",
                new XElement("Id", nanny.Id),
                new XElement("FirstName", nanny.FirstName),
                new XElement("LastName", nanny.LastName),
                new XElement("BirthDate", nanny.BirthDate),
                new XElement("Address", nanny.Address),
                new XElement("Elevetor", nanny.Elevetor),
                new XElement("Floor", nanny.Floor),
                new XElement("Experience", nanny.Experience),
                new XElement("cellPhone", nanny.cellPhone),
                new XElement("CapacityChildren", nanny.CapacityChildren),
                new XElement("MaxAge_monthe", nanny.MaxAge_monthe),
                new XElement("MinAge_monthe", nanny.MinAge_monthe),
                new XElement("IsHourlyRate", nanny.IsHourlyRate),
                new XElement("SallaryPerHour", nanny.SallaryPerHour),
                new XElement("SallaryPerMonths", nanny.SallaryPerMonths),
                new XElement("MinistryEducationVaction", nanny.MinistryEducationVaction),
                new XElement("Recommendations", nanny.Recommendations),
                new XElement("timeWorkofWeek",
				nanny.timeWorkofWeek[0].DayToXML(), nanny.timeWorkofWeek[1].DayToXML(),
				nanny.timeWorkofWeek[2].DayToXML(), nanny.timeWorkofWeek[3].DayToXML(),
				nanny.timeWorkofWeek[4].DayToXML(), nanny.timeWorkofWeek[5].DayToXML())
                );
        }
    
        public static XElement DayToXML(this Day day)
        {
            return new
                XElement("day",
                new XElement("IsWork", day.IsWork),
                new XElement("StartTime", day.StartTime),
                new XElement("EndTime", day.EndTime));
        }

        public static XElement MotherToXML(this Mother mother)
        {
            return new XElement("Mother",
                new XElement("Id", mother.Id),
                new XElement("FirstName", mother.FirstName),
                new XElement("LastName", mother.LastName),
                new XElement("Address", mother.Address),
                new XElement("cellPhone", mother.cellPhone),
                new XElement("AreaToSearch", mother.AreaToSearch),
                new XElement("Remarks", mother.Remarks),
				new XElement("timeWorkofWeek",
				mother.timeWorkofWeek[0].DayToXML(), mother.timeWorkofWeek[1].DayToXML(),
				mother.timeWorkofWeek[2].DayToXML(), mother.timeWorkofWeek[3].DayToXML(),
				mother.timeWorkofWeek[4].DayToXML(), mother.timeWorkofWeek[5].DayToXML())
				);
		}

        public static XElement ChildToXML(this Child child)
        {
            return new XElement("child",
                new XElement("Id", child.Id),
                new XElement("FirstName", child.FirstName),
                new XElement("LastName", child.LastName),
                new XElement("MotherId", child.MotherId),
                new XElement("BirthDate", child.BirthDate),
                new XElement("IsSpecalNeed", child.IsSpecalNeed),
                new XElement("SpicialNeed", child.SpicialNeed));
        }

        public static XElement ContantToXML(this Contract contract)
        {
            return new XElement("contract",
                new XElement("ChildId", contract.ChildId),
                new XElement("MotherId", contract.MotherId),
                new XElement("NannyId", contract.NannyId),
                new XElement("ContractNumber", contract.ContractNumber),
                
                new XElement("IsAcquaintance", contract.IsAcquaintance),
                new XElement("IsContract", contract.IsContract),
                
                new XElement("IsHourlyRate", contract.IsHourlyRate),
                new XElement("RateOfHour", contract.RateOfHour),
                new XElement("RateOfMonth", contract.RateOfMonth),
                new XElement("Salary", contract.Salary),
                new XElement("stertEmployment", contract.stertEmployment),
                new XElement("endEmployment", contract.endEmployment));
        }



        //================================
        //converters XElements to objects
        //================================

        /// <summary>
        /// convert XElement nanny to obj Nanny
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Nanny XmlToNanny(this XElement element)
        {
            try
            {
                return new Nanny
                {
                    Id = Convert.ToInt32(element.Element("Id").Value),
                    FirstName = element.Element("FirstName").Value,
                    LastName = element.Element("LastName").Value,
                    cellPhone = Convert.ToInt32(element.Element("cellPhone").Value),
                    Address = element.Element("Address").Value,
                    BirthDate = Convert.ToDateTime(element.Element("BirthDate").Value),
                    CapacityChildren = Convert.ToInt32(element.Element("CapacityChildren").Value),
                    Elevetor = Convert.ToBoolean(element.Element("Elevetor").Value),
                    Floor = Convert.ToInt32(element.Element("Floor").Value),
                    Experience = Convert.ToInt32(element.Element("Experience").Value),
                    IsHourlyRate = Convert.ToBoolean(element.Element("IsHourlyRate").Value),
                    MaxAge_monthe = Convert.ToInt32(element.Element("MaxAge_monthe").Value),
                    MinAge_monthe = Convert.ToInt32(element.Element("MinAge_monthe").Value),
                    MinistryEducationVaction = Convert.ToBoolean(element.Element("MinistryEducationVaction").Value),
                    Recommendations = element.Element("Recommendations").Value,
                    SallaryPerHour = Convert.ToDouble(element.Element("SallaryPerHour").Value),
                    SallaryPerMonths = Convert.ToDouble(element.Element("SallaryPerMonths").Value),
                    timeWorkofWeek = (from day in element.Element("timeWorkofWeek").Elements()
                                      select day.XmlToDay()).ToArray()
                };

            }
            catch
            {
                return new Nanny();
            }

        }

        public static Day XmlToDay(this XElement element)
        {
            try
            {
                Day temp = new Day
                {
                    IsWork = Convert.ToBoolean(element.Element("IsWork").Value),
                    StartTime = XmlConvert.ToTimeSpan(element.Element("StartTime").Value),
                    EndTime = XmlConvert.ToTimeSpan(element.Element("EndTime").Value)
                };
                return temp;
            }
            catch
            {
                return new Day();
            }

        }


        public static Mother XmlToMother(this XElement element)
        {
            try
            {
                return new Mother
                {
                    Id = Convert.ToInt32(element.Element("Id").Value),
                    FirstName = element.Element("FirstName").Value,
                    LastName = element.Element("LastName").Value,
                    Address = element.Element("Address").Value,
                    AreaToSearch = element.Element("AreaToSearch").Value,
                    cellPhone = Convert.ToInt32(element.Element("cellPhone").Value),
                    Remarks = element.Element("Remarks").Value,
                    timeWorkofWeek = (from day in element.Element("timeWorkofWeek").Elements()
                                      select day.XmlToDay()).ToArray()
                };
            }
            catch
            {
                return new Mother();
            }
        }

        public static Child XmlToChild(this XElement element)
        {
            try
            {
                return new Child
                {
                    Id = Convert.ToInt32(element.Element("Id").Value),
                    FirstName = element.Element("FirstName").Value,
                    LastName = element.Element("LastName").Value,
                    BirthDate = Convert.ToDateTime(element.Element("BirthDate").Value),
                    MotherId = Convert.ToInt32(element.Element("MotherId").Value),
                    IsSpecalNeed = Convert.ToBoolean(element.Element("IsSpecalNeed").Value),
                    SpicialNeed = element.Element("SpicialNeed").Value
                };
            }
            catch
            {
                return new Child();
            }
        }


        public static Contract XmlToContract(this XElement element)
        {
            try
            {
                
              return new Contract
			  {
                    ChildId = Convert.ToInt32(element.Element("ChildId").Value),
                    MotherId = Convert.ToInt32(element.Element("MotherId").Value),
                    NannyId = Convert.ToInt32(element.Element("NannyId").Value),
                    ContractNumber = Convert.ToInt32(element.Element("ContractNumber").Value),
                    stertEmployment = Convert.ToDateTime(element.Element("stertEmployment").Value),
                    endEmployment = Convert.ToDateTime(element.Element("endEmployment").Value),
                    IsAcquaintance = Convert.ToBoolean(element.Element("IsAcquaintance").Value),
                    IsContract = Convert.ToBoolean(element.Element("IsContract").Value),
                    IsHourlyRate = Convert.ToBoolean(element.Element("IsHourlyRate").Value),
                    RateOfHour = Convert.ToDouble(element.Element("RateOfHour").Value),
                    RateOfMonth = Convert.ToDouble(element.Element("RateOfMonth").Value),
                    Salary = Convert.ToDouble(element.Element("Salary").Value)
                };
            }
            catch
            {
                return new Contract();
            }
        }
    }
}
