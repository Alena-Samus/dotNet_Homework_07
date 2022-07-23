using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwless7
{
    struct timeOnly
    {
        private string hours;
        private string minutes;
        private string seconds;

        public void setTime (DateTime newDate)
        {
            this.hours = Convert.ToString(newDate.Hour);
            this.minutes = Convert.ToString(newDate.Minute);
            this.seconds = Convert.ToString(newDate.Second);

        }
        public void setTime(int hour, int minute, int second)
        {
            this.hours = Convert.ToString(hour);
            this.minutes = Convert.ToString(minute);
            this.seconds = Convert.ToString(second);

        }
        public string getTime()
        {
            return (this.hours + ":" + this.minutes +":" + this.seconds);
        }
        
    }
}
