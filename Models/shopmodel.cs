using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class shopmodel
    {
        public List<M_Category> cat { get; set; }
        public List<M_Product> prod { get; set; }
    }
}