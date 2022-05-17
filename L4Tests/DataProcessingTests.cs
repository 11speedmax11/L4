using Microsoft.VisualStudio.TestTools.UnitTesting;
using L4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace L4.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        [TestMethod()]
        public void saveDataTest()
        {
            ApplicationContext db = new ApplicationContext();
            Schedule firstRecording = new Schedule(55555, "Saint Petersburg — Moscow", "passenger", "10:00 PM", "10:01 PM", "qwerty");
            Schedule secondRecording = new Schedule(55556, "Saint Petersburg — Moscow", "fast", "11:00 PM", "12:01 PM", "qwerty");
            Schedule[] recordings = new[] { firstRecording, secondRecording };
            DataProcessing dataProcessing = new DataProcessing();
            for (int i = 0; i < recordings.Length; i++)
                dataProcessing.saveData(recordings[i]);
            //db.SaveChangesAsync();
            for (int i = 0; i < recordings.Length; i++)
            {
                Assert.AreEqual(recordings[i].trainNumber, db.Schedules.Find(recordings[i].numRecord).trainNumber);
                Assert.AreEqual(recordings[i].destination, db.Schedules.Find(recordings[i].numRecord).destination);
                Assert.AreEqual(recordings[i].classTrain, db.Schedules.Find(recordings[i].numRecord).classTrain);
                Assert.AreEqual(recordings[i].arrives, db.Schedules.Find(recordings[i].numRecord).arrives);
                Assert.AreEqual(recordings[i].departs, db.Schedules.Find(recordings[i].numRecord).departs);
                Assert.AreEqual(recordings[i].additionalInformation, db.Schedules.Find(recordings[i].numRecord).additionalInformation);
            }
            for (int i = 0; i < recordings.Length; i++)
            {
                db.Schedules.Remove(db.Schedules.Find(recordings[i].numRecord));
            }
            //db.SaveChangesAsync();
        }
    }
}