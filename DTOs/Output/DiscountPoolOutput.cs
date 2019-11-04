using System;
using System.Collections.Generic;
using FinanzasBE.Entities;

namespace FinanzasBE.DTOs.Output
{
    public class DiscountPoolOutput
    {
        public int Id { get; set; }
        public double ReceivedValue { get; set; }
        public double DeliveredValue { get; set; }
        public double Tcea { get; set; }
        public DateTime DiscountDate { get; set; }
        public int PymeId { get; set; }
        public IEnumerable<DiscountOutput> Discounts { get; set; } = new List<DiscountOutput>();
    }
}