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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Autofac;
using System.ComponentModel;

namespace L4
{

    public partial class MainWindow : Window
    {
        private static ISaveFile service;
        private static IDataProcessing ser;
        private ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            update();
            if (!Properties.Settings.Default.isShowAbout)
            {
                About about = new About();
                about.ShowDialog();
            }
        }
        public MainWindow(ISaveFile serviceInner, IDataProcessing serInner)
        { 
            service = serviceInner; 
            ser = serInner; 
        }
        private void update() 
        {
            train_schedule.Items.Clear();
            db = new ApplicationContext();
            List<Schedule> schedules = db.Schedules.ToList();            
            foreach (Schedule schedule in schedules)
                train_schedule.Items.Add(schedule);             
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddElement addElement = new AddElement((Schedule)null);
            addElement.ShowDialog();
            update();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            ser.deleteData(train_schedule.SelectedItems.Cast<Schedule>().ToList());
            update();
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            AddElement addElement = new AddElement((sender as Button).DataContext as Schedule);
            addElement.ShowDialog();
            update();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<Schedule> items = new List<Schedule>();
            for (int i = 0; i < train_schedule.Items.Count; i++)
                items.Add((Schedule)train_schedule.Items[i]);
            service.Save_File(items);
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
