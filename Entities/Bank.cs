using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinanzasBE.DTOs;

namespace FinanzasBE.Entities
{
    public class Bank
    {
        [Key] public int BankId { get; set; }

        [DataType(DataType.Text)] public string Ruc { get; set; }

        [DataType(DataType.Text)] public string BusinessName { get; set; }

        [DataType(DataType.Currency)] public double TEASoles { get; set; }

        [DataType(DataType.Currency)] public double TEADolares { get; set; }


        public List<DiscountPool> DiscountPools { get; set; }


        public Bank()
        {
        }

        public Bank(BankDTO bankDTO)
        {
            BankId = bankDTO.BankId;
            Ruc = bankDTO.Ruc;
            BusinessName = bankDTO.BusinessName;
            TEASoles = bankDTO.TEASoles;
            TEADolares = bankDTO.TEADolares;
        }

        public override string ToString()
        {
            return
                $"Bank {{ BankId: {BankId}, Ruc: {Ruc}, BusinessName: {BusinessName} TEASoles: {TEASoles}, TEADolares: {TEADolares}}}";
        }
    }
}