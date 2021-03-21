using LightController.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace LightController
{
    public class LightTimer
    {
        public LightTimer()
        {
        }

        #region Fields
        private DispatcherTimer timer;
        #endregion

        #region Properties
        public Action<Service.Dto.TemperatureDto> TranslateTemperatures { get; set; }
        public ILightService LightService { get; set; }

        private DispatcherTimer Timer
        {
            get
            {
                if (timer == null)
                {
                    timer = new System.Windows.Threading.DispatcherTimer();
                    timer.Tick += new EventHandler(lightTimer_Tick);
                    timer.Interval = new TimeSpan(0, 0, 2);
                }

                return timer;
            }
        }

        #endregion

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
        }

        private async void lightTimer_Tick(object sender, EventArgs e)
        {
            var data = await LightService.GetTemperaturesAsync();

            TranslateTemperatures.Invoke(data);
        }

    }
}
