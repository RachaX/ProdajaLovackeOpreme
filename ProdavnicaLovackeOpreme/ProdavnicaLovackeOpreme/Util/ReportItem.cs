namespace ProdavnicaLovackeOpreme.Util
{
    public class ReportItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateOnly Date {  get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
    }
}
