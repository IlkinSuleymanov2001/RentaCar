using Core.Entities;
using Entities.DTOs.Brand;
using Entities.DTOs.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Car
{
    public class CarDetailDto : IDto
    {
        public string CarName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public BrandDto Brand { get; set; }
        public ColorDto Color { get; set; }
    }


}
