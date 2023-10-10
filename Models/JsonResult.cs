using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Estudos.Models
{
    public class JsonResult
    {
        public bool Success { get; set; }
        public VideoResult? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }
}