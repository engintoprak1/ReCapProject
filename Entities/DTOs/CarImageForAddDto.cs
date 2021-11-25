using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class CarImageForAddDto : IDto
    {
        public int CarId { get; set; }
        public string Image { get; set; }
    }
}
