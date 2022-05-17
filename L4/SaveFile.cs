using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace L4
{
    class SaveFile : ISaveFile
    {
        public List<string> Get_String(List<Schedule> items)
        {
            List<string> table = new List<string> {" " + "number".PadRight(9, ' ') + " " + "destination".PadLeft(20, ' ').PadRight(40, ' ') +
                                                         "class train".PadRight(15, ' ') + "arrives".PadRight(11, ' ') +
                                                         "departs".PadRight(11, ' ') + "additional Information" };
            for (int i = 0; i < items.Count; i++)
            {
                table.Add("  " + items[i].trainNumber.ToString().PadRight(9, ' ') + items[i].destination.PadRight(40, ' ') + " " +
                                 items[i].classTrain.PadRight(14, ' ') + items[i].arrives.PadLeft(8, ' ').PadRight(11, ' ') +
                                 items[i].departs.PadLeft(8, ' ').PadRight(11, ' ') + items[i].additionalInformation);
            }
            return table;
        }
        public void Save_File(List<Schedule> items)
        {
            List<string> table = Get_String(items);
            SaveFileDialog fileTable = new SaveFileDialog();
            fileTable.Filter = "Text files(*.txt)|*.txt";
            fileTable.CreatePrompt = true;
            fileTable.OverwritePrompt = true;
            fileTable.ShowDialog();
            try
            {
                File.WriteAllLines(fileTable.FileName, table);
                MessageBox.Show("data successfully saved", "successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("file was not selected, data was not saved", "warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
