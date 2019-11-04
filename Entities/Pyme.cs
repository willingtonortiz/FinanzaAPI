using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinanzasBE.DTOs;

namespace FinanzasBE.Entities
{
    public class Pyme
    {
        // Attribute properties
        [Key] public int PymeId { get; set; }

        [DataType(DataType.Text)] public string Ruc { get; set; }

        [DataType(DataType.Text)] public string BusinessName { get; set; }

        [DataType(DataType.Text)] public string Address { get; set; }

        // Navigation properties
        public int UserId { get; set; }
        public User User { get; set; }


        public List<Bill> Bills { get; set; }


        public List<DiscountPool> DiscountPools { get; set; }

        public Pyme()
        {
        }


        public override string ToString()
        {
            return $"Pyme {{ PymeId: {PymeId}, Ruc: {Ruc}, BusinessName: {BusinessName}, Address: {Address} }}";
        }
    }
}