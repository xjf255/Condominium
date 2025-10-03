namespace Condominium.Dtos;
{
  public record RubroCreateDto(string nombre, string descripcion);
  public record RubroUpdateDto(string nombre, string descripcion);
  public record RubroReadDto(int id, string nombre, string descripcion, ICollection<reciboDetalleReadDto> recibo_detalles);
}