using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Shared.Models.VM
{
    public class OrderVM
    {
        public int OrderId { get; set; }                
        public string OrderName { get; set; }                
        public string OrderState { get; set; }                
        public string WindowName { get; set; }        
        public int OrderQuantity { get; set; }
        public int WindowId { get; set; }
        public string ElelementType { get; set; }
    }
}
