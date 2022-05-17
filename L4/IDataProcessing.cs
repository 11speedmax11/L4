using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4
{
    public interface IDataProcessing
    {
        bool isCorrect(string trainNumber, string destination, string classTrain, string arrives, string departs, string inf);
        void deleteData(List<Schedule> currentSchedule);
        void saveData(Schedule currentSchedule);
        void editData(Schedule currentSchedule, Schedule intermediateSchedule);

    }
}
