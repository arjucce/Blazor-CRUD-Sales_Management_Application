using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Shared.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [DisplayName("Order Name")]
        public string OrderName { get; set; }
        [Required]
        [DisplayName("State Name")]
        public string State { get; set; }
        [ForeignKey("Windows")]
        public int WindowId { get; set; }
        [Required]
        [DisplayName("Quantity of Window")]
        public int Quantity { get; set; }
    }
}
