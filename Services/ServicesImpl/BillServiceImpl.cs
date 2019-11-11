using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasBE.Entities;
using FinanzasBE.Enums;
using FinanzasBE.Repositories;
using FinanzasBE.Services;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.ServicesImpl
{
    public class BillServiceImpl : IBillService
    {
        private readonly BillRepository _billRepository;
        private readonly ILogger<BillServiceImpl> _logger;

        
        #region Constructor

        public BillServiceImpl(
            ILogger<BillServiceImpl> logger,
            BillRepository billRepository
        )
        {
            _billRepository = billRepository;
            _logger = logger;
        }

        #endregion


        #region FindByPymeId

        public IEnumerable<Bill> FindByPymeId(int pymeId)
        {
            return _billRepository.FindByPymeId(pymeId);
        }

        #endregion


        #region FindAllByPymeIdAsync

        public async Task<IEnumerable<Bill>> FindAllByPymeIdAsync(int pymeId)
        {
            // Obteniendo las letras
            IEnumerable<Bill> bills = await _billRepository.FindAllByPymeIdAsync(pymeId);

            DateTime today = DateTime.Now.Date;

            // Validando su vencimiento
            foreach (Bill bill in bills)
            {
                if (bill.EndDate < today)
                {
                    bill.Status = BillStatus.EXPIRED;
                    _billRepository.UpdateBill(bill);
                }
            }

            return bills;
        }

        #endregion


        #region FindAll

        public IEnumerable<Bill> FindAll()
        {
            return _billRepository.FindAll();
        }

        #endregion


        #region FindById

        public Bill FindById(int billId)
        {
            Bill bill = _billRepository.FindById(billId);

            DateTime today = DateTime.Now.Date;

            if (bill.EndDate < today)
            {
                bill.Status = BillStatus.EXPIRED;
                _billRepository.UpdateBill(bill);
            }

            return bill;
        }

        #endregion


        #region Create

        public Bill Create(Bill bill)
        {
            DateTime today = DateTime.Now.Date;

            if (bill.EndDate < today)
            {
                bill.Status = BillStatus.EXPIRED;
            }

            Bill newBill = _billRepository.Create(bill);

            return newBill;
        }

        #endregion


        #region DeleteByIdAsync

        public Task<Bill> DeleteByIdAsync(int billId)
        {
            return _billRepository.DeleteByIdAsync(billId);
        }

        #endregion


        #region DeleteAll

        public void DeleteAll()
        {
            _billRepository.DeleteAll();
        }

        #endregion
    }
}