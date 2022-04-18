using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;

namespace SBroker
{
    public class Aktie
    {
        [Name("Name")]
        public string name { get; set; }
        [Name("ISIN")]
        public string isin { get; set; }
        [Name("Bought")]
        public DateTime bought { get; set; }
        [Name("Price")]
        public decimal price { get; set; }
        [Name("Amount")]
        public int amount { get; set; }
        [Name("Fees")]
        public decimal fees { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\dirkm\source\repos\SBroker\SBroker\sbroker.csv";
            using (var streamReader = new StreamReader(fileName))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<Aktie>().ToList();
                    Console.WriteLine(records.Count);
                    foreach (var item in records)
                    {
                        Console.WriteLine(item.name);
                        Console.WriteLine("ISIN:\t\t" + item.isin);
                        Console.WriteLine("Date:\t\t" + item.bought);
                        Console.WriteLine("Price:\t\t" + item.price);
                        Console.WriteLine("Amount:\t\t" + item.amount);
                        Console.WriteLine("Fees:\t\t" + item.fees);
                        Console.WriteLine("************");
                    }
                    decimal tot;
                    for (int i = 0; i < records.Count; i++)
                    {
                        tot = records[i].price * records[i].amount;
                        Console.WriteLine(records[i].name);
                        Console.WriteLine(String.Format("{0:0.00}", tot));
                        Console.WriteLine("\t\t+ " + records[i].fees);
                        tot += records[i].fees;
                        Console.WriteLine("Paid: " + tot);
                    }
                    Console.WriteLine();
                    //IEnumerable<Aktie> ienum = (IEnumerable<Aktie>)records;
                    //IEnumerator<Aktie> ienumerat = records.GetEnumerator();
                    //while (ienumerat.MoveNext())
                    //{
                    //    Console.Write(ienumerat.Current.name.ToString() + ": " + " EUR ");
                    //    decimal res = ienumerat.Current.price * ienumerat.Current.amount;
                    //    Console.WriteLine(res.ToString());
                    //    Console.WriteLine("Date: {0}", ienumerat.Current.bought.ToString());
                    //    Console.WriteLine("Fees: {0} EUR", ienumerat.Current.fees.ToString());
                    //    decimal total = res + ienumerat.Current.fees;
                    //    Console.WriteLine("Total: {0} EUR ", total);
                    //    Console.WriteLine();
                    //}
                }
            }
        }
        private List<Aktie> GetMethod()
        {
            string fileName = @"C:\Users\dirkm\source\repos\SBroker\SBroker\sbroker.csv";
            using (var streamReader = new StreamReader(fileName))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<Aktie>().ToList();
                    Console.WriteLine(records.Count);
                    foreach (var item in records)
                    {
                        Console.WriteLine(item.name);
                        Console.WriteLine(item.isin + ". Type: " + item.isin.GetType());
                        Console.WriteLine(item.bought + ". Type: " + item.bought.GetType());
                        Console.WriteLine(item.price + ". Type: " + item.price.GetType());
                        Console.WriteLine(item.amount + ". Type: " + item.amount.GetType());
                        Console.WriteLine(item.fees + ". Type: " + item.fees.GetType());
                        Console.WriteLine("************");
                    }
                    //Console.WriteLine();
                    //IEnumerable<Aktie> ienum = (IEnumerable<Aktie>)records;
                    //IEnumerator<Aktie> ienumerat = records.GetEnumerator();
                    //while (ienumerat.MoveNext())
                    //{
                    //    Console.Write(ienumerat.Current.name.ToString() + ": " + " EUR ");
                    //    decimal res = ienumerat.Current.price * ienumerat.Current.amount;
                    //    Console.WriteLine(res.ToString());
                    //    Console.WriteLine("Date: {0}", ienumerat.Current.bought.ToString());
                    //    Console.WriteLine("Fees: {0} EUR", ienumerat.Current.fees.ToString());
                    //    decimal total = res + ienumerat.Current.fees;
                    //    Console.WriteLine("Total: {0} EUR ", total);
                    //    Console.WriteLine();
                    //}
                    return records;
                }
            }
        }
    }
}
