using System.ComponentModel;

namespace SalesManagementApp.Shared.Models.VM
{
    public class WindowElementsVM
    {
        public int WindowId { get; set; }        
        public string WindowName { get; set; }
        public int ElementId { get; set; }        
        [DisplayName("Element Name")]
        public string ElelementType { get; set; }        
        [DisplayName("Element Width")]
        public int Width { get; set; }        
        [DisplayName("Element Height")]
        public int Height { get; set; }



    }
}
