using FinanzasBE.DTOs;
using FinanzasBE.Entities;

namespace FinanzasBE.Converters
{
	public class DiscountPoolConverter : IConverter<DiscountPool, DiscountPoolDTO>
	{
		public DiscountPool FromDto(DiscountPoolDTO dto)
		{
			return new DiscountPool
			{
				DiscountPoolId = dto.Id,
				DeliveredValue = dto.DeliveredValue,
				ReceivedValue = dto.ReceivedValue,
				DiscountDate = dto.DiscountDate,
				CurrencyCode = dto.CurrencyCode,
				TCEA = dto.TCEA
			};
		}

		public DiscountPoolDTO FromEntity(DiscountPool entity)
		{
			return new DiscountPoolDTO
			{
				Id = entity.DiscountPoolId,
				DeliveredValue = entity.DeliveredValue,
				ReceivedValue = entity.ReceivedValue,
				DiscountDate = entity.DiscountDate,
				CurrencyCode = entity.CurrencyCode,
				TCEA = entity.TCEA
			};
		}
	}
}