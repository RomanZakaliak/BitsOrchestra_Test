using BitsOrchestra_Test.Models;
using CsvHelper.Configuration;
using System.Globalization;

namespace BitsOrchestra_Test.Mappings
{
    public sealed class CsvEmployeeMap : ClassMap<Employee>
    {
        public CsvEmployeeMap() 
        {
            AutoMap(CultureInfo.InvariantCulture);

            Map(e => e.Name).Index(0).Name("Name");
            Map(e => e.BirthDate).Index(1).Name("Date of Birth");
            Map(e => e.Maried).Index(2).Name("Married");
            Map(e => e.Phone).Index(3).Name("Phone");
            Map(e => e.Salary).Index(4).Name("Salary");

            Map(e => e.ID).Ignore();
        }
    }
}
