namespace Condominium.Dtos
{
  public record CondominioCreateDto(string Nombre, string Direccion, string ImageCondominio);
  public record CondominioUpdateDto(string Nombre, string Direccion, string ImageCondominio);
  public record CondominioReadDto(string Id, string Nombre, string Direccion, string ImageCondominio, ICollection<PropiedadReadDto> Propiedades);
}