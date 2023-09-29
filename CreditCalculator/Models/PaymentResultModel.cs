namespace Kalkulator.Models
{
    public class PaymentResultModel
    {
        public int ID { get; set; }
        public string? Date { get; set; }
        public decimal Body { get; set; }
        public decimal Percent { get; set; }
        public decimal Balance { get; set; }
    }
}
