using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trade.Infra.Contract.Models.Dtos;
using Trade.Infra.Contract.Models.ViewModels.Shared;

namespace Trade.Infra.Contract.Models.ViewModels.Home
{
    public class HomeViewModel : CommonViewModel
    {
        public string Events { get; set; }
        public DateTime Date { get; set; }
        public DateTime? PreviousDate { get; set; }
        public DateTime? NextDate { get; set; }
    }
}
