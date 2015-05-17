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

namespace Alzheimers_Clock {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        System.Windows.Threading.DispatcherTimer clockTimer;
        DateTime lastDay;
        DateTime lastTime;

        public MainWindow() {
            InitializeComponent();

            updateDate();
            updateTime();

            clockTimer = new System.Windows.Threading.DispatcherTimer();
            clockTimer.Tick += new EventHandler(clockTimer_Tick);
            clockTimer.Interval = new TimeSpan(0, 0, 1);
            clockTimer.Start();
        }

        private void updateDate() {
            lbl_date.Content = String.Format("{0:dddd d}{1} {0:MMMM}", DateTime.Now, (DateTime.Now.Day % 10 == 1 && DateTime.Now.Day != 11) ? "st" :
                (DateTime.Now.Day % 10 == 2 && DateTime.Now.Day != 12) ? "nd" :
                (DateTime.Now.Day % 10 == 3 && DateTime.Now.Day != 13) ? "rd" :
                "th");
            lastDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        private void updateTime() {
            lbl_time.Content = DateTime.Now.ToString("hh:mmtt").ToLower();
            lastTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
        }

        private void clockTimer_Tick(object sender, EventArgs e) {
            if (lastTime != new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)) updateTime();
            if (lastDay != new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)) updateDate();
        }
    }
}
