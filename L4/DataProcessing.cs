using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace L4
{
    public class DataProcessing : IDataProcessing
    {
        private ApplicationContext db = new ApplicationContext();
        public bool isCorrect(string trainNumber, string destination, string classTrain, string arrives, string departs, string inf)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(trainNumber))
                errors.AppendLine("enter train number");
            if (string.IsNullOrWhiteSpace(destination))
                errors.AppendLine("enter destination");
            if (string.IsNullOrWhiteSpace(classTrain))
                errors.AppendLine("enter class");
            if (string.IsNullOrWhiteSpace(arrives))
                errors.AppendLine("enter arrives");
            if (string.IsNullOrWhiteSpace(departs))
                errors.AppendLine("enter departs");
            if (string.IsNullOrWhiteSpace(inf))
                errors.AppendLine("enter additional information");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "error adding", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
                return true;
        }
        public async void deleteData(List<Schedule> currentSchedule)
        {
            if (MessageBox.Show($"you definitely want to remove {currentSchedule.Count()} elements", "attention", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                for(int i = 0; i < currentSchedule.Count; i++)
                    db.Schedules.Remove(db.Schedules.Find(currentSchedule[i].numRecord));
                await db.SaveChangesAsync();
            }
        }
        public async void saveData(Schedule currentSchedule)
        {
            try
            {
                db.Schedules.Add(currentSchedule);
                await db.SaveChangesAsync();
                MessageBox.Show("information successfully saved", "successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public async void editData(Schedule currentSchedule, Schedule intermediateSchedule)
        {
            try
            {
                Schedule modifiedSchedule = intermediateSchedule;
                modifiedSchedule.numRecord = db.Schedules.Find(currentSchedule.numRecord).numRecord;
                db.Schedules.Remove(db.Schedules.Find(currentSchedule.numRecord));
                db.Schedules.Add(modifiedSchedule);
                await db.SaveChangesAsync();
                MessageBox.Show("information changed successfully", "successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
