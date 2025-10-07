namespace Condominium.Dtos
{
  public record RubroCreateDto(string Nombre, string Descripcion);
  public record RubroUpdateDto(string Nombre, string Descripcion);
  public record RubroReadDto(int Id, string Nombre, string Descripcion, ICollection<ReciboDetalleReadDto> ReciboDetalles);
}