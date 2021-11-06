using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class CarImageForUpdateDto : IDto
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
