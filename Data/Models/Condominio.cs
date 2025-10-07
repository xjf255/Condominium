namespace Condominium.Data.Models;

public class Condominio
{
    public string Id { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string? ImageCondominio { get; set; }
    public ICollection<Propiedad> Propiedads { get; set; } = new List<Propiedad>();
    
    public Condominio() { }

    public Condominio(string Nombre, string Direccion, string? imageCondominio)
    {
        this.Nombre = Nombre;
        this.Direccion = Direccion;
        this.ImageCondominio = imageCondominio;
    }
}
