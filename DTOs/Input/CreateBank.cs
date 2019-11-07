namespace FinanzasBE.DTOs.Input
{
    public class CreateBank
    {
        public string Ruc { get; set; }
        public string BusinessName { get; set; }
        public double TEASoles { get; set; }
        public double TEADolares { get; set; }
    }
}