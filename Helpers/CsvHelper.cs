using BitsOrchestra_Test.Mappings;
using BitsOrchestra_Test.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace BitsOrchestra_Test.Helpers
{
    public class CSVHelper
    {
        public static async Task<List<Employee>> GetEmployeesFromByteArray(byte[] data, bool hasHeaderRecord = false)
        {
            var employees = new List<Employee>();

            using var memoryStream = new MemoryStream(data);
            using var fileReader = new StreamReader(memoryStream);

            try
            {
                var csvConfiguration = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = hasHeaderRecord,
                    ReadingExceptionOccurred = (re) =>
                    {
                        Console.WriteLine(re.Exception.Message);
                        return false;
                    }
                };

                using var csvReader = new CsvReader(fileReader, csvConfiguration);
                csvReader.Context.RegisterClassMap<CsvEmployeeMap>();

                while (await csvReader.ReadAsync())
                {
                    if (String.IsNullOrEmpty(csvReader.GetField(0)) ||
                        (hasHeaderRecord && String.IsNullOrEmpty(csvReader.GetField("Name"))))
                        continue;

                    employees.Add(csvReader.GetRecord<Employee>());
                }
            }
            catch
            {
                throw;
            }

            return employees;
        }
    }
}
