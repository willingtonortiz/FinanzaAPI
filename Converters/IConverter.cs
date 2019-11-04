namespace FinanzasBE.Converters
{
    public interface IConverter<TE, TD>
    {
        TE FromDto(TD dto);

        TD FromEntity(TE entity);
    }
}