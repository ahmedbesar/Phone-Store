using Domains;

namespace PHONES_MARKETE.Models
{
    public class VmItems_
    {
        public VmItems_()
        {
            //item details
            Item = new VwItem();
            lstItemImages = new List<TbItem>();
            lstRecommendedItems = new List<VwItem>();
            //item list
            lstAllItems = new List<VwItem>();
            //items by category id
            lstAllItemsByCategoryId = new List<VwItem>();

        }
        //item details
        public VwItem Item { get; set; }
        public List<TbItem> lstItemImages { get; set; }
        public List<VwItem> lstRecommendedItems { get; set; }

        //item list
        public List<VwItem> lstAllItems { get; set; }

        //items by category id
        public List<VwItem> lstAllItemsByCategoryId { get; set; }

    }
}
