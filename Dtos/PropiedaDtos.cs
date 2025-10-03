namespace Condominium.Dtos;
{
  public record PropiedadCreateDto(string direccion, string? avatar, string id_condominio);
  public record PropiedadUpdateDto(string direccion, string? avatar, string id_condominio);
  public record PropiedadReadDto(string id, string direccion, string? avatar, string id_condominio, CondominioReadDto condominio);
}