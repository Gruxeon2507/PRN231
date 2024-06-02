namespace Assignment02.Models
{
    public class ServicePriceList
    {
        public int ServiceId { get; set; }
        public int ServiceLevel { get; set; } // Levels 1-5
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
