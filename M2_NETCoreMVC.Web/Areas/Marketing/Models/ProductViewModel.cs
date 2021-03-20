using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Areas.Marketing.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> ListadoProducto { get; set; }
        public IEnumerable<string> ListadoNombres { get; set; }
    }
}
