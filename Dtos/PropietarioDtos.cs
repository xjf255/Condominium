namespace Condominium.Dtos
{
  public record PropietarioCreateDto(string Dpi, string Nombre, string Apellido,string PrefijoPais, string Telefono, string Nit, bool? Estado);
  public record PropietarioUpdateDto(string Dpi, string Nombre, string Apellido,string PrefijoPais, string Telefono, string Nit,  bool? Estado);
  public record PropietarioReadDto(string Dpi, string Nombre, string Apellido,string PrefijoPais, string Telefono, string Nit, bool? Estado, ICollection<ReciboEncabezadoReadDto> Recibos, ICollection<PropiedadReadDto> Propiedades);
}