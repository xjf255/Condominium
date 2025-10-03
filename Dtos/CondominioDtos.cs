namespace Condominium.Dtos;
{
  public record CondominioCreateDto(string nombre, string direccion, string image_condominio);
  public record CondominioUpdateDto(string nombre, string direccion, string image_condominio);
  public record CondominioReadDto(string id, string nombre, string direccion, string image_condominio, ICollection<PropiedadReadDto> propiedades);
}