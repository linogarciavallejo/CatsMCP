using System.ComponentModel.DataAnnotations;

namespace CatsMCP.Domain.Entities;

public class Cat
{
    [Key]
    public int CatId { get; set; }
    public string? Nombre { get; set; }
    public string? Raza { get; set; }
    public string? OrigenRaza { get; set; }
    public bool RazaPura { get; set; }
    public int AniosExistenciaRaza { get; set; }
    public string? Popularidad { get; set; }
    public string? EstatusConservacion { get; set; }
    public string? Edad { get; set; }
    public string? Sexo { get; set; }
    public bool Esterilizado { get; set; }
    public string? HistorialVacunacion { get; set; }
    public string? Alergias { get; set; }
    public string? EnfermedadesCronicas { get; set; }
    public string? TratamientosPasados { get; set; }
    public string? NivelSocializacion { get; set; }
    public string? NivelActividad { get; set; }
    public string? Temperamento { get; set; }
    public string? HistoriaPrevia { get; set; }
    public string? ComidaPreferida { get; set; }
    public string? JuguetesFavoritos { get; set; }
    public string? LugaresDescanso { get; set; }
    public string? EstadoAdopcion { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string? FechasVisitas { get; set; }
    public string? EmparejamientosPotenciales { get; set; }
    public float[]? EmbeddingVector { get; set; }
}
