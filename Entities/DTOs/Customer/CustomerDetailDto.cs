using Core.Entities;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Customer
{
    public class CustomerDetailDto : IDto
    {
        public string CompanyName { get; set; }
        public UserForAddDto User { get; set; }

    }
}
