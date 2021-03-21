using LightController.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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

        private LightTimer lightTimer;
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

        private LightTimer LightTimer
        {
            get
            {
                if (lightTimer == null)
                {
                    lightTimer = new LightTimer() 
                    { 
                        LightService = LightService,
                        TranslateTemperatures = TranslateTemperatures
                    };
                }

                return lightTimer;
            }
        }

        #endregion

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            LightService.Run();

            EnableStatusControlls();
            StartTimer();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            LightService.Stop();

            DisableStatusControlls();
            StopTimer();
        }

        private async void checkButton_Click(object sender, RoutedEventArgs e)
        {
            var data = await LightService.GetTemperaturesAsync();

            UpdateTemperatures(data);
        }

        #region Timer

        private void StartTimer()
        {
            LightTimer.Start();
        }

        private void StopTimer()
        {
            LightTimer.Stop();
        }

        #endregion

        #region Private

        private void UpdateTemperatures(Service.Dto.TemperatureDto data)
        {
            throw new NotImplementedException();
        }

        private void TranslateTemperatures(Service.Dto.TemperatureDto data)
        {
            cpuTempTextBox.Text = data.CpuTemp.ToString();
        }

        private void EnableStatusControlls()
        {
            statusTextBox.Text = "Running";
            statusEllipse.Fill = new SolidColorBrush(Colors.LightGreen);

            checkButton.IsEnabled = true;
        }

        private void DisableStatusControlls()
        {
            statusTextBox.Text = "Not running";
            statusEllipse.Fill = new SolidColorBrush(Colors.LightGray);

            checkButton.IsEnabled = false;
        }

        #endregion

    }
}
