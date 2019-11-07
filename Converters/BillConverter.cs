using FinanzasBE.DTOs;
using FinanzasBE.DTOs.Input;
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
                BillId = dto.Id,
                Type = dto.Type,
                Status = dto.Status
            };
        }

        public BillDTO FromEntity(Bill entity)
        {
            return new BillDTO
            {
                Id = entity.BillId,
                Amount = entity.Amount,
                CurrencyCode = entity.CurrencyCode,
                Type = entity.Type,
                DraweeRuc = entity.DraweeRuc,
                DrawerRuc = entity.DrawerRuc,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Status = entity.Status,
            };
        }

        public Bill FromCreateBill(CreateBill createBill)
        {
            return new Bill
            {
                Amount = createBill.Amount,
                PymeId = createBill.PymeId,
                Status = createBill.Status,
                Type = createBill.Type,
                CurrencyCode = createBill.CurrencyCode,
                DraweeRuc = createBill.DraweeRuc,
                DrawerRuc = createBill.DrawerRuc,
                EndDate = createBill.EndDate,
                StartDate = createBill.StartDate
            };
        }
    }
}