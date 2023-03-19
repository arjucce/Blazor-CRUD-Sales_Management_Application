
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
    public class Subelements
    {
        [Key]
        public int ElementId { get; set; }
        [Required]
        [DisplayName("Element Name")]
        public string ElelementType { get; set; }
        [Required]
        [DisplayName("Width")]
        public int Width { get; set; }
        [Required]
        [DisplayName("Height")]
        public int Height { get; set; }
        [ForeignKey("Windows")]
        public int WindowId { get; set; }
    }
}
