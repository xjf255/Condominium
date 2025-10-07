namespace Condominium.Dtos
{
  public record ReciboEncabezadoCreateDto(string DpiPropietario, string IdPropiedad, DateTime FechaEmision);
  public record ReciboEncabezadoUpdateDto(string DpiPropietario, string IdPropiedad, DateTime FechaEmision);
  public record ReciboEncabezadoReadDto(string NumRec, DateTime? FechaRecibo, string IdPropiedad, string DpiPropietario, PropietarioReadDto Propietario, PropiedadReadDto Propiedad, ICollection<ReciboDetalleReadDto> Detalles);
}