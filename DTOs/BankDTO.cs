using System.ComponentModel.DataAnnotations;
using FinanzasBE.Entities;

namespace FinanzasBE.DTOs
{
    public class BankDTO
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string BusinessName { get; set; }
        public double TEASoles { get; set; }
        public double TEADolares { get; set; }
    }
}