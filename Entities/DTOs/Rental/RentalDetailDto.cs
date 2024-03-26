using Core.Entities;
using Entities.DTOs.Car;
using Entities.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Rental
{
    public class RentalDetailDto : IDto
    {
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public CarDetailDto Car { get; set; }
        public CustomerDetailDto Customer { get; set; }



    }
}
