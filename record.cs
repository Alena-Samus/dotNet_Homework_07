using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwless7
{
    struct record
    {
        private int number;
        private DateTime recordDateTime;
        private string message;
        private int countOfDays;
        private DateTime doneDateTime;
        private bool done;
        

        //Конструктор для новой записи
        public record(int number, DateTime recordDateTime, string message, int countOfDays, DateTime doneDateTime, bool done)
        {
            this.number = number;
            this.recordDateTime = recordDateTime;
            this.message = message;
            this.countOfDays = countOfDays;
            this.doneDateTime = doneDateTime;
            this.done = done;
        }

        //Переопределение конструктора

        public record(int number, string message, int countOfDays, bool done)
        {
            this.number = number;
            this.recordDateTime = DateTime.Now;
            this.message = message;
            this.countOfDays = countOfDays;
            this.doneDateTime = recordDateTime.AddDays(countOfDays);
            this.done = done;
        }

        public record(int number, DateTime recordDateTime, string message, DateTime doneDateTime, bool done)
        {
            this.number = number;
            this.recordDateTime = recordDateTime;
            this.message = message;
            this.doneDateTime = doneDateTime;                     
            this.done = done;
            this.countOfDays = 0;
        }
        public record(int number, string message, int countOfDates) :
            this(number, message, countOfDates, false)
        {

        }


        public record(int number, string message) :
            this(number, message, 1, false)
        {

        }


         //Свойства полей для установки и возврата значений
        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public bool Done
        {
            get { return this.done; }
            set { this.done = value; }
        }

        public DateTime RecordDateTime
        {
            get { return this.recordDateTime; }

        }

        public int CountOfDays
        {
            get { return this.countOfDays; }
            set { this.countOfDays = value; }
        }

        public DateTime DoneDateTime
        {
            get { return this.doneDateTime; }
            set
            {
                this.doneDateTime = DateTime.Now.AddDays(countOfDays);
            }
        }
    }
}
