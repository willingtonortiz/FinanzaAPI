using FinanzasBE.DTOs;
using FinanzasBE.Entities;

namespace FinanzasBE.Converters
{
    public class DiscountConverter : IConverter<Discount, DiscountDTO>
    {
        public Discount FromDto(DiscountDTO dto)
        {
            return new Discount
            {
                Retention = dto.Retention,
                Tcea = dto.Tcea,
                Tep = dto.Tep,
                DiscountId = dto.Id,
                DeliveredValue = dto.DeliveredValue,
                ReceivedValue = dto.ReceivedValue,
                DiscountDays = dto.DiscountDays,
                DiscountRate = dto.DiscountRate,
                FinalCost = dto.FinalCost,
                InitialCost = dto.InitialCost,
                NetValue = dto.NetValue
            };
        }

        public DiscountDTO FromEntity(Discount entity)
        {
            return new DiscountDTO
            {
                Retention = entity.Retention,
                Tcea = entity.Tcea,
                Tep = entity.Tep,
                Id = entity.DiscountId,
                DeliveredValue = entity.DeliveredValue,
                ReceivedValue = entity.ReceivedValue,
                DiscountDays = entity.DiscountDays,
                DiscountRate = entity.DiscountRate,
                FinalCost = entity.FinalCost,
                InitialCost = entity.InitialCost,
                NetValue = entity.NetValue
            };
        }
    }
}