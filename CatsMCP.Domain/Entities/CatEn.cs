using System.ComponentModel.DataAnnotations;

namespace CatsMCP.Domain.Entities;

public class CatEn
{
    [Key]
    public int CatId { get; set; }
    public string? Name { get; set; }
    public string? Breed { get; set; }
    public string? BreedOrigin { get; set; }
    public bool PureBreed { get; set; }
    public int BreedAgeYears { get; set; }
    public string? Popularity { get; set; }
    public string? ConservationStatus { get; set; }
    public string? Age { get; set; }
    public string? Sex { get; set; }
    public bool Neutered { get; set; }
    public string? VaccinationHistory { get; set; }
    public string? Allergies { get; set; }
    public string? ChronicDiseases { get; set; }
    public string? PastTreatments { get; set; }
    public string? SocializationLevel { get; set; }
    public string? ActivityLevel { get; set; }
    public string? Temperament { get; set; }
    public string? PreviousHistory { get; set; }
    public string? PreferredFood { get; set; }
    public string? FavoriteToys { get; set; }
    public string? RestingPlaces { get; set; }
    public string? AdoptionStatus { get; set; }
    public DateTime IntakeDate { get; set; }
    public string? VisitDates { get; set; }
    public string? PotentialMatches { get; set; }
    public float[]? EmbeddingVector { get; set; }
}
