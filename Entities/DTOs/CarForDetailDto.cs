using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarForDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public List<CarImage> Images { get; set; }
    }
}
