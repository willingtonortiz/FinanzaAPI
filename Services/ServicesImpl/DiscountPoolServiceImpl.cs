using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Data;
using FinanzasBE.DTOs.Input;
using FinanzasBE.Entities;
using FinanzasBE.Enums;
using FinanzasBE.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.ServicesImpl
{
	public class DiscountPoolServiceImpl : IDiscountPoolService
	{
		private readonly FinanzasContext _context;
		private readonly ILogger<DiscountPoolServiceImpl> _logger;

		public DiscountPoolServiceImpl(
			FinanzasContext context,
			ILogger<DiscountPoolServiceImpl> logger
		)
		{
			_logger = logger;
			_context = context;
		}


		public IEnumerable<DiscountPool> FindAll()
		{
			return _context.DiscountPools
				.AsNoTracking()
				.Include(x => x.Discounts)
				.ThenInclude(x => x.Bill);
		}


		public DiscountPool Create(DiscountPool discountPool)
		{
			_context.DiscountPools
				.Add(discountPool);

			_context.SaveChanges();

			return discountPool;
		}


		public DiscountPool CreateCompleteDiscountPool(DiscountPool discountPool)
		{
			_context.DiscountPools
				.Add(discountPool);

			IEnumerable<Discount> discounts = discountPool.Discounts;

			foreach (Discount discount in discounts)
			{
				_context.Discounts.Add(discount);

				Bill bill = _context.Bills.FirstOrDefault(x => x.BillId == discount.BillId);
				bill.Status = BillStatus.DISCOUNTED;

				foreach (Cost cost in discount.Costs)
				{
					_context.Costs.Add(cost);
				}
			}

			_context.SaveChanges();

			return discountPool;
		}


		public void DeleteAll()
		{
			IEnumerable<DiscountPool> discountPools = _context.DiscountPools.AsNoTracking();

			foreach (DiscountPool discountPool in discountPools)
			{
				_context.DiscountPools.Remove(discountPool);
			}

			_context.SaveChanges();
		}

		public IEnumerable<DiscountPool> FindAllByPymeId(int pymeId)
		{
			return _context.DiscountPools
				.AsNoTracking()
				.Where(x => x.PymeId == pymeId);
		}

		public DiscountPool FindById(int discontPoolId)
		{
			return _context.DiscountPools
				.AsNoTracking()
					.Include(x => x.Discounts)
						.ThenInclude(y => y.Costs)
					.Include(x => x.Discounts)
						.ThenInclude(y => y.Bill)
				.FirstOrDefault(x => x.DiscountPoolId == discontPoolId);
		}
	}
}