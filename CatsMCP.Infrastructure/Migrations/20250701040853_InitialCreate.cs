using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsMCP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrigenRaza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaPura = table.Column<bool>(type: "bit", nullable: false),
                    AniosExistenciaRaza = table.Column<int>(type: "int", nullable: false),
                    Popularidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstatusConservacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Esterilizado = table.Column<bool>(type: "bit", nullable: false),
                    HistorialVacunacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesCronicas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TratamientosPasados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelSocializacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelActividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaPrevia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComidaPreferida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuguetesFavoritos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugaresDescanso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoAdopcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechasVisitas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmparejamientosPotenciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmbeddingVector = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Cats_EN",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PureBreed = table.Column<bool>(type: "bit", nullable: false),
                    BreedAgeYears = table.Column<int>(type: "int", nullable: false),
                    Popularity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConservationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neutered = table.Column<bool>(type: "bit", nullable: false),
                    VaccinationHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChronicDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastTreatments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocializationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteToys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestingPlaces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdoptionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitDates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PotentialMatches = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmbeddingVector = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats_EN", x => x.CatId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Cats_EN");
        }
    }
}
