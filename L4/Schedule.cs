using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Schedules")]
    public class Schedule
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int numRecord { get; set; }
        public int trainNumber { get; set; }
        public string destination { get; set; }
        public string classTrain { get; set; }
        public string arrives { get; set; }
        public string departs { get; set; }
        public string additionalInformation { get; set; }
        public object Clone() 
        {
            return this.MemberwiseClone();
        }

        public Schedule() { }

        public Schedule(int trainNumber, string destination, string classTrain, string arrives, string departs, string additionalInformation) 
        {
            this.trainNumber = trainNumber;
            this.destination = destination;
            this.classTrain = classTrain;
            this.arrives = arrives;
            this.departs = departs;
            this.additionalInformation = additionalInformation;
        }
    }
}
