using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace L4
{
    public partial class AddElement : Window
    {
        private static IDataProcessing service;
        Schedule currentSchedule = new Schedule();

        public AddElement(Schedule schedule)
        {
            if (schedule != null)
                currentSchedule = (Schedule)schedule.Clone();

            InitializeComponent();
            DataContext = currentSchedule;
            classTrain.SelectedItem = currentSchedule.classTrain;
            destination.SelectedItem = currentSchedule.destination;
        }
        public AddElement(IDataProcessing serviceInner)
        {
            service = serviceInner;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!service.isCorrect(trainNumber.Text, destination.Text, classTrain.Text,
                                          arrives.Text, departs.Text, additionalInformation.Text))
                return;
            Schedule intermediateSchedule = new Schedule((int)trainNumber.Value, destination.Text, classTrain.Text,
                                                              arrives.Text, departs.Text, additionalInformation.Text);
            if (currentSchedule.classTrain == null)
                service.saveData(intermediateSchedule);
            else
                service.editData(currentSchedule, intermediateSchedule);
            Close();
        }
        private void classTrain_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string> { "passenger", "fast", "cargo" };
            var combo = sender as ComboBox;
            combo.ItemsSource = data;
        }
        private void destination_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string> { "Saint Petersburg — Moscow", "Moscow — Saint Petersburg", "Saint Petersburg — Arkhangelsk", "Arkhangelsk — Saint Petersburg",
                                                   "Saint Petersburg — Petrozavodsk", "Petrozavodsk — Saint Petersburg", "Saint Petersburg — Chelyabinsk", "Chelyabinsk — Saint Petersburg",
                                                   "Saint Petersburg — Pskov", "Pskov — Saint Petersburg", "Saint Petersburg — Vologda", "Vologda — Saint Petersburg" };
            var combo = sender as ComboBox;
            combo.ItemsSource = data;
        }
    }
}
