using FinanzasBE.DTOs;
using FinanzasBE.Entities;

namespace FinanzasBE.Converters
{
    public class PymeConverter:IConverter<Pyme,PymeDTO>
    {
        public Pyme FromDto(PymeDTO dto)
        {
            return new Pyme
            {
                PymeId = dto.PymeId,
                Address = dto.Address,
                Ruc = dto.Ruc,
                BusinessName = dto.BusinessName
            };
        }

        public PymeDTO FromEntity(Pyme entity)
        {
            return new PymeDTO
            {
                PymeId = entity.PymeId,
                Address = entity.Address,
                Ruc = entity.Ruc,
                BusinessName = entity.BusinessName
            };
        }
    }
}