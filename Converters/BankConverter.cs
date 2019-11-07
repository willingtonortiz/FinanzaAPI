using FinanzasBE.DTOs;
using FinanzasBE.DTOs.Input;
using FinanzasBE.Entities;

namespace FinanzasBE.Converters
{
    public class BankConverter : IConverter<Bank, BankDTO>
    {
        public Bank FromDto(BankDTO dto)
        {
            return new Bank
            {
                BankId = dto.Id,
                Ruc = dto.Ruc,
                BusinessName = dto.BusinessName,
                TEADolares = dto.TEASoles,
                TEASoles = dto.TEASoles
            };
        }

        public BankDTO FromEntity(Bank entity)
        {
            return new BankDTO
            {
                Id = entity.BankId,
                Ruc = entity.Ruc,
                BusinessName = entity.BusinessName,
                TEADolares = entity.TEASoles,
                TEASoles = entity.TEASoles
            };
        }

        public Bank CreateBankToBank(CreateBank dto)
        {
            return new Bank
            {
                Ruc = dto.Ruc,
                BusinessName = dto.BusinessName,
                TEADolares = dto.TEADolares,
                TEASoles = dto.TEASoles
            };
        }
    }
}