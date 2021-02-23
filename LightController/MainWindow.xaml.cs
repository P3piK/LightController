using LightController.Service;
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

namespace LightController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DisableStatusControlls();
        }

        #region Fields

        private ILightService lightService;

        #endregion

        #region Properties 
         
        private ILightService LightService 
        {
            get
            {
                if (lightService == null)
                {
                    lightService = new LightService();
                }

                return lightService;
            }
        }

        #endregion

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            // async..
            LightService.Run();

            // todo..
            EnableStatusControlls();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            // async..
            LightService.Stop();

            // todo..
            DisableStatusControlls();
        }
        
        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            var data = LightService.GetTemperatures();

            cpuTempTextBox.Text = data.CpuTemp.ToString();
        }

        #region Private 

        private void EnableStatusControlls()
        {
            statusTextBox.Text = "Running";
            statusEllipse.Fill = new SolidColorBrush(Colors.LightGreen);
        }

        private void DisableStatusControlls()
        {
            statusTextBox.Text = "Not running";
            statusEllipse.Fill = new SolidColorBrush(Colors.LightGray);
        }

        #endregion
    }
}
