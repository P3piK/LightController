using LightController.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightController.Service
{
    public interface ILightService
    {
        void Run();
        void Stop();
        TemperatureDto GetTemperatures();
        Task<TemperatureDto> GetTemperaturesAsync();
    }
}
