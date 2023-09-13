using Bl;
using Domains;
using System.Runtime;

namespace PHONES_MARKETE.Models
{
    public class VmHomePage
    {
        public VmHomePage()
        {
            
            lstItemImages = new List<TbItem>();
            lstAllItems = new List<VwItem>();
            lstRecommendedItems = new List<VwItem>();
            lstNewItems = new List<VwItem>();
            lstBestSellers = new List<VwItem>();
            lstCategories = new List<TbCategory>();
        }
        
        public List<TbItem> lstItemImages { get; set; }
       
        public List<VwItem> lstAllItems { get; set; }
        public List<VwItem> lstRecommendedItems { get; set; }
        public List<VwItem> lstNewItems { get; set; }
        public List<VwItem> lstBestSellers { get; set; }
        public List<TbCategory> lstCategories { get; set; }
        public List<TbSlider> lstSliders { get; set; }


    }
}
