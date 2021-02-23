using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightController.Service.Dto;
using OpenHardwareMonitor;

namespace LightController.Service
{
    public class LightService : ILightService
    {
        public TemperatureDto GetTemperatures()
        {
            return new TemperatureDto()
            {
                CpuTemp = 43,
            };
        }

        public void Run()
        {

        }

        public void Stop()
        {

        }
    }
}
