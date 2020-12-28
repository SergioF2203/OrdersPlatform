namespace BLL.Models
{
    public class FilterModel
    {
        const int maxQuantity = 50;
        private int _pageSize = 10;
        public int Start { get; set; } = 1;
        public int Quantity
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (_pageSize > maxQuantity) ? maxQuantity : value;
            }
        }
        public string Status { get; set; }
    }
}
