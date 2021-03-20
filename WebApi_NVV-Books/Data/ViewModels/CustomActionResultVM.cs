using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_NVV_Books.Data.Models;

namespace WebApi_NVV_Books.Data.ViewModels
{
    public class CustomActionResultVM
    {
        public System.Exception Exception { get; set; }

        //public object Data { get; set; }
        public Publisher Publisher { get; set; }
    }
}
