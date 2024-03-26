using Core.Entities;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CarImage
{
    public class CarImageDetailDto : IDto
    {

        public string ImagePath { get; set; }
        public DateTime? Date { get; set; }
        public CarDetailDto Car { get; set; }
    }
}
