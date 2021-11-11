using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalForAddDto
    {
        public int CarId { get; set; }
        public int RentDays { get; set; }
        public string CartNumber { get; set; }
    }
}
