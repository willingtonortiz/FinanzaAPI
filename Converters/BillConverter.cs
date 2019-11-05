using FinanzasBE.DTOs;
using FinanzasBE.Entities;

namespace FinanzasBE.Converters
{
    public class BillConverter : IConverter<Bill, BillDTO>
    {
        public Bill FromDto(BillDTO dto)
        {
            return new Bill
            {
                Amount = dto.Amount,
                CurrencyCode = dto.CurrencyCode,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                DraweeRuc = dto.DraweeRuc,
                DrawerRuc = dto.DrawerRuc,
                PymeId = dto.BillId,
                Type = dto.Type,
                Status = dto.Status
            };
        }

        public BillDTO FromEntity(Bill entity)
        {
            return new BillDTO
            {
                Amount = entity.Amount,
                CurrencyCode = entity.CurrencyCode,
                BillId = entity.BillId,
                Type = entity.Type,
                DraweeRuc = entity.DraweeRuc,
                DrawerRuc = entity.DrawerRuc,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Status = entity.Status
            };
        }
    }
}