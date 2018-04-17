namespace BankAccountApp.Services
{
    using System.Collections.Generic;
    using System.IO;

    public class CSVFileReader
    {
        public static void ReadFromCSV(string filePath, IList<CustomerAccount> entities)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(',');

                    entities.Add(new CustomerAccount(line[0], line[1],line[2], line[3]));
                }
            }
        }

        public static List<string> ReadDigitAccountNumber(string filePath)
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(',');
                    list.Add(line[2].Substring(2,5));
                }
            }

            return list;
        }
    }
}