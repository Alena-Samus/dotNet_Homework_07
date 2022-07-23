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
      public DateTime doneDateTime;
      private bool done;

        //Конструктор для новой записи
        public record(int number, string message, DateTime doneDateTime, bool done)
        {
            this.number = number;
            this.recordDateTime = DateTime.Now;
            this.message = message;
            this.doneDateTime = doneDateTime;           
            this.done = done;
        }

        //Переопределение конструктора
        public record(int number, DateTime doneDateTime, string message) :
            this(number, message, doneDateTime, false)
        {

        }

        public record(int number,  DateTime doneDateTime) :
            this(number, string.Empty, doneDateTime, false)
        {

        }

        public record(int number, string message) :
            this(number, string.Empty, DateTime.Now, false)
        {

        }

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
    }
}
