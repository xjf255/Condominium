namespace Condominium.Dtos;
{
  public record PropietarioCreateDto(string dpi, string nombre, string apellido,string prefijo_pais, string telefono, string nit, bool? estado);
  public record PropietarioUpdateDto(string dpi, string nombre, string apellido,string prefijo_pais, string telefono, string nit,  bool? estado);
  public record PropietarioReadDto(string dpi, string nombre, string apellido,string prefijo_pais, string telefono, string nit, bool? estado, ICollection<ReciboEncabezadoReadDto> recibos, ICollection<PropiedadReadDto> propiedades);
}