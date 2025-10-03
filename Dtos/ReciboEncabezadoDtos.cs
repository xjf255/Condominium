namespace Condominium.Dtos;
{
  public record ReciboEncabezadoCreateDto(string dpi_propietario, string id_propiedad, DateTime fecha_emision);
  public record ReciboEncabezadoUpdateDto(string dpi_propietario, string id_propiedad, DateTime fecha_emision);
  public record ReciboEncabezadoReadDto(string num_rec, DateTime? fecha_recibo, string id_propiedad, string dpi_propietario, PropietarioReadDto propietario, PropiedadReadDto propiedad, ICollection<ReciboDetalleReadDto> detalles);
}