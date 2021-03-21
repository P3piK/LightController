using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightController.Service.Dto;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Collections;

namespace LightController.Service
{
    public class LightService : ILightService
    {
        #region Fields

        private Computer computer;

        #endregion

        #region Properties

        private Computer Computer 
        { 
            get
            {
                if (computer == null)
                {
                    computer = new Computer() { CPUEnabled = true };
                }

                return computer;
            }
        }

        #endregion

        #region ILightService

        public TemperatureDto GetTemperatures()
        {
            var ret = new TemperatureDto();
                
            ret.CpuTemp = (int)Computer.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.CPU)
                .Sensors.FirstOrDefault(s => s.SensorType == SensorType.Temperature && s.Name == "CPU Package").Value.Value;

            return ret;
        }

        public async Task<TemperatureDto> GetTemperaturesAsync()
        {
            var ret = new TemperatureDto();
            ret.CpuTemp = (int)Computer.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.CPU)
                .Sensors.FirstOrDefault(s => s.SensorType == SensorType.Temperature && s.Name == "CPU Package").Value.Value;

            return await Task.FromResult(ret);
        }

        public void Run()
        {
            Computer.Open();
        }

        public void Stop()
        {
            Computer.Close();
        }

        #endregion
    }
}
