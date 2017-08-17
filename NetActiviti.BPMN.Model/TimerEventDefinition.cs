using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class TimerEventDefinition : EventDefinition
    {

        private string timeDate;
        private string timeDuration;
        private string timeCycle;
        private string endDate;
        private string calendarName;

        public string TimeDate
        {
            get { return timeDate; }
            set { timeDate = value; }
        }


        public string TimeDuration
        {
            get { return timeDuration; }
            set { timeDuration = value; }
        }


        public string TimeCycle
        {
            get { return timeCycle; }
            set { timeCycle = value; }
        }


        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string CalendarName
        {
            get { return calendarName; }
            set { calendarName = value; }
        }

        public override BaseElement Clone()
        {
            TimerEventDefinition clone = new TimerEventDefinition();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(TimerEventDefinition otherDefinition)
        {
            base.SetValues(otherDefinition);
            timeDate = otherDefinition.TimeDate;
            timeDuration = otherDefinition.TimeDuration;
            timeCycle = otherDefinition.TimeCycle;
            endDate = otherDefinition.EndDate;
            calendarName = otherDefinition.CalendarName;
        }
    }
}
