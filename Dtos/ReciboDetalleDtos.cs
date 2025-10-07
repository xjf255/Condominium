namespace Condominium.Dtos
{
  public record ReciboDetalleCreateDto(string NumRecibo, string Concepto, decimal Monto);
  public record ReciboDetalleUpdateDto(string NumRecibo, string Concepto, decimal Monto);
  public record ReciboDetalleReadDto(string NumRecibo, string Concepto, decimal Monto, RubroReadDto Rubro, ReciboEncabezadoReadDto Recibo);
}