namespace Condominium.Dtos
{
  public record PropiedadCreateDto(string Direccion, string? Avatar, string IdCondominio);
  public record PropiedadUpdateDto(string Direccion, string? Avatar, string IdCondominio);
  public record PropiedadReadDto(string Id, string Direccion, string? Avatar, string IdCondominio, CondominioReadDto Condominio);
}