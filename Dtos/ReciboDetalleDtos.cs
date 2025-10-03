namespace Condominium.Dtos;
{
  public record reciboDetalleCreateDto(string num_recibo, string concepto, decimal monto);
  public record reciboDetalleUpdateDto(string num_recibo, string concepto, decimal monto);
  public record ReciboDetalleReadDto(string num_recibo, string concepto, decimal monto, RubroReadDto rubro, ReciboEncabezadoReadDto recibo);
}