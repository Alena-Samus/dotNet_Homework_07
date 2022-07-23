using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwless7
{
    class Program
    {
        static void Main(string[] args)
        {

            record newRecord = new record(1, "newTask", DateTime.Now, true);
            record newRecord1 = new record(2,  DateTime.Now, "newTask1");
            record newRecord2 = new record(3,  DateTime.Now);
            Console.WriteLine("{0} {1} {2} {3} {4}",
                               newRecord.Number,
                               newRecord.RecordDateTime,
                               newRecord.Message,
                               newRecord.doneDateTime,
                               newRecord.Done);

            //timeOnly newTime = new timeOnly();

            //DateTime current = new DateTime();

            //current = DateTime.Now;
            //newTime.setTime(current);

            //Console.WriteLine($"newTime = {newTime.getTime()}");

            //timeOnly newTime1 = new timeOnly();
            //newTime1.setTime(12, 15, 46);
            //Console.WriteLine($"newTime1 = {newTime1.getTime()}");

            Console.ReadLine();
            
           
        }
    }
}
