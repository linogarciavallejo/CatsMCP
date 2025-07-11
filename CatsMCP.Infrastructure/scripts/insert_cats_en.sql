IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Cats_EN')
BEGIN
CREATE TABLE Cats_EN (
    CatId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50),
    Breed NVARCHAR(50),
    BreedOrigin NVARCHAR(100),
    PureBreed BIT,
    BreedAgeYears INT,
    Popularity NVARCHAR(50),
    ConservationStatus NVARCHAR(50),
    Age NVARCHAR(20),
    Sex NVARCHAR(10),
    Neutered BIT,
    VaccinationHistory NVARCHAR(MAX),
    Allergies NVARCHAR(MAX),
    ChronicDiseases NVARCHAR(MAX),
    PastTreatments NVARCHAR(MAX),
    SocializationLevel NVARCHAR(50),
    ActivityLevel NVARCHAR(50),
    Temperament NVARCHAR(100),
    PreviousHistory NVARCHAR(200),
    PreferredFood NVARCHAR(100),
    FavoriteToys NVARCHAR(100),
    RestingPlaces NVARCHAR(100),
    AdoptionStatus NVARCHAR(50),
    IntakeDate DATE,
    VisitDates NVARCHAR(100),
    PotentialMatches NVARCHAR(100),
    EmbeddingVector NVARCHAR(MAX)
);
END
GO

INSERT INTO Cats_EN (Name, Breed, BreedOrigin, PureBreed, BreedAgeYears, Popularity, ConservationStatus,
Age, Sex, Neutered, VaccinationHistory, Allergies, ChronicDiseases, PastTreatments,
SocializationLevel, ActivityLevel, Temperament, PreviousHistory, PreferredFood, FavoriteToys, RestingPlaces,
AdoptionStatus, IntakeDate, VisitDates, PotentialMatches, EmbeddingVector)
VALUES
('Luna','Mixed','Unknown',0,100,'High','N/A','2 years','Female',1,'Rabies 2023-05-01; FVRCP 2023-05-01; Leukemia 2023-05-01; Next 2024-05-01','None','None','Deworming 2022-06-15','Very social with humans and cats','Playful','Affectionate','Rescued from the street','Wet salmon','Balls','High bed','Available','2022-06-01','2022-07-01,2022-08-15','Perez Family','[0.758,0.34,0.845,0.569,0.552]'),
('Simba','Domestic Shorthair','Europe',0,200,'High','N/A','3 years','Male',0,'Rabies 2023-04-10; FVRCP 2023-04-10; Next 2024-04-10','Pollen','None','-','Shy with strangers, friendly with caregivers','Energetic','Curious','Rescued from a rooftop','Dry chicken','Toy mice','Sunny window','Pending','2023-01-12','2023-02-10','-','[0.864,0.749,0.605,0.181,0.017]'),
('Nala','Siamese','Thailand',1,600,'High','N/A','1 year','Female',0,'Rabies 2023-06-20; FVRCP 2023-06-20; Next 2024-06-20','Fish','None','-','Very social','Energetic','Vocal and affectionate','Abandoned by previous owners','Wet chicken','Wands','Boxes','Available','2023-06-21','2023-06-30','-','[0.726,0.527,0.891,0.322,0.699]'),
('Tom','Mixed','Unknown',0,100,'Medium','N/A','5 years','Male',0,'Rabies 2022-12-01; FVRCP 2022-12-01; Next 2023-12-01','None','Asthma','Inhalers 2020-05-10','Independent','Calm','Quiet','Rescued from a house','Dry salmon','Balls','Couch','Adopted','2021-03-15','2021-04-01','-','[0.786,0.991,0.166,0.616,0.751]'),
('Mia','Turkish Angora','Turkey',1,300,'Medium','N/A','4 years','Female',1,'Rabies 2022-08-08; FVRCP 2022-08-08; Leukemia 2022-08-08; Next 2023-08-08','Chicken','None','Spay 2021-09-10','Very social','Playful','Affectionate','Previous home','Wet tuna','Feathers','Chair by window','Available','2022-09-01','2022-09-15','-','[0.399,0.391,0.906,0.347,0.603]');
GO

INSERT INTO Cats_EN (Name, Breed, BreedOrigin, PureBreed, BreedAgeYears, Popularity, ConservationStatus,
Age, Sex, Neutered, VaccinationHistory, Allergies, ChronicDiseases, PastTreatments,
SocializationLevel, ActivityLevel, Temperament, PreviousHistory, PreferredFood, FavoriteToys, RestingPlaces,
AdoptionStatus, IntakeDate, VisitDates, PotentialMatches, EmbeddingVector)
VALUES
('Leo','Mixed','Unknown',0,100,'High','N/A','6 months','Male',0,'Rabies 2023-07-01; FVRCP 2023-07-01; Next 2024-07-01','None','None','-','Curious','Energetic','Mischievous','Found in park','Dry kitten','Balls','Cave bed','Available','2023-07-02','2023-07-10','Garcia Family','[0.672,0.798,0.669,0.977,0.914]'),
('Chloe','Persian','Persia',1,500,'High','N/A','6 years','Female',1,'Rabies 2023-03-01; FVRCP 2023-03-01; Next 2024-03-01','None','Kidney disease','Kidney medication 2022-05-01','Shy','Calm','Very affectionate','Rescued from breeder','Wet turkey','Mice','Soft bed','Pending','2022-04-01','2022-04-15,2022-05-20','Ruiz Family','[0.118,0.612,0.093,0.802,0.555]'),
('Max','Domestic Shorthair','Europe',0,200,'High','N/A','2 years','Male',0,'Rabies 2023-05-05; FVRCP 2023-05-05; Next 2024-05-05','None','None','-','Sociable','Energetic','Curious','Rescued from street','Dry meat','Balls','High shelf','Available','2022-11-10','2022-11-20','-','[0.382,0.683,0.476,0.881,0.552]'),
('Lola','Mixed','Unknown',0,100,'Medium','N/A','8 years','Female',1,'Rabies 2023-01-15; FVRCP 2023-01-15; Next 2024-01-15','Dairy','Arthritis','Medication 2021-06-10','Shy','Calm','Quiet','Owner surrender','Wet turkey','Fabric mice','Warm bed','Adopted','2020-10-01','2020-10-10','-','[0.612,0.078,0.499,0.766,0.855]'),
('Oliver','Bombay','United States',1,60,'Low','N/A','3 years','Male',0,'Rabies 2023-02-01; FVRCP 2023-02-01; Next 2024-02-01','None','None','-','Very social','Energetic','Affectionate','Rescued from abandonment','Wet chicken','Wands','High bed','Available','2022-12-12','2022-12-20','-','[0.493,0.058,0.445,0.26,0.96]');
GO

INSERT INTO Cats_EN (Name, Breed, BreedOrigin, PureBreed, BreedAgeYears, Popularity, ConservationStatus,
Age, Sex, Neutered, VaccinationHistory, Allergies, ChronicDiseases, PastTreatments,
SocializationLevel, ActivityLevel, Temperament, PreviousHistory, PreferredFood, FavoriteToys, RestingPlaces,
AdoptionStatus, IntakeDate, VisitDates, PotentialMatches, EmbeddingVector)
VALUES
('Kiara','Mixed','Unknown',0,100,'High','N/A','1 year','Female',0,'Rabies 2023-06-10; FVRCP 2023-06-10; Next 2024-06-10','Grain','None','-','Sociable','Playful','Affectionate','Rescued from street','Wet chicken','Balls','Couch','Available','2023-06-12','2023-06-25','-','[0.011,0.47,0.237,0.073,0.826]'),
('Coco','Ragdoll','United States',1,60,'High','N/A','5 years','Male',0,'Rabies 2022-11-01; FVRCP 2022-11-01; Next 2023-11-01','None','None','-','Very social','Calm','Affectionate','Owner surrender','Dry salmon','Balls','Bed','Pending','2022-11-02','2022-11-15','Smith Family','[0.816,0.816,0.532,0.411,0.962]'),
('Frida','Mixed','Unknown',0,100,'High','N/A','2 years','Female',1,'Rabies 2023-04-01; FVRCP 2023-04-01; Next 2024-04-01','None','None','-','Sociable','Playful','Affectionate','Rescued from street','Wet tuna','Feathers','Basket','Available','2023-04-05','2023-04-20','-','[0.804,0.054,0.707,0.329,0.618]'),
('Toby','Domestic Shorthair','Europe',0,200,'High','N/A','4 years','Male',0,'Rabies 2023-03-05; FVRCP 2023-03-05; Next 2024-03-05','Dust','None','-','Sociable','Energetic','Curious','Abandoned at shelter','Dry meat','Mice','High bed','Available','2021-02-01','2021-02-10','-','[0.552,0.917,0.225,0.606,0.483]'),
('Misha','Russian Blue','Russia',1,150,'Medium','N/A','7 years','Female',1,'Rabies 2023-01-01; FVRCP 2023-01-01; Next 2024-01-01','None','Hyperthyroidism','Medication 2022-08-01','Shy','Calm','Docile','Rescued from breeder','Wet fish','Feathers','Bed','Adopted','2020-05-20','2020-06-01','-','[0.444,0.693,0.978,0.307,0.864]');
GO

INSERT INTO Cats_EN (Name, Breed, BreedOrigin, PureBreed, BreedAgeYears, Popularity, ConservationStatus,
Age, Sex, Neutered, VaccinationHistory, Allergies, ChronicDiseases, PastTreatments,
SocializationLevel, ActivityLevel, Temperament, PreviousHistory, PreferredFood, FavoriteToys, RestingPlaces,
AdoptionStatus, IntakeDate, VisitDates, PotentialMatches, EmbeddingVector)
VALUES
('Rocky','Mixed','Unknown',0,100,'High','N/A','9 months','Male',0,'Rabies 2023-08-01; FVRCP 2023-08-01; Next 2024-08-01','None','None','-','Very social','Energetic','Mischievous','Rescued from street','Dry kitten','Balls','Cardboard box','Available','2023-08-05','2023-08-15','-','[0.524,0.815,0.176,0.213,0.599]'),
('Nina','Siamese','Thailand',1,600,'High','N/A','3 years','Female',1,'Rabies 2023-05-10; FVRCP 2023-05-10; Next 2024-05-10','None','None','Spay 2021-02-10','Very social','Playful','Vocal','Owner surrender','Wet turkey','Wands','High bed','Available','2021-03-01','2021-03-15','-','[0.699,0.535,0.334,0.244,0.409]'),
('Felix','Mixed','Unknown',0,100,'High','N/A','6 years','Male',0,'Rabies 2023-04-15; FVRCP 2023-04-15; Next 2024-04-15','None','Diabetes','Daily insulin 2022-01-01','Sociable','Calm','Affectionate','Rescued from street','Special diabetic dry food','Balls','Bed','Pending','2022-02-01','2022-02-15','Gomez Family','[0.727,0.011,0.158,0.743,0.757]'),
('Cleo','Domestic Shorthair','Europe',0,200,'Medium','N/A','10 years','Female',1,'Rabies 2023-02-20; FVRCP 2023-02-20; Next 2024-02-20','None','Kidney disease','Medication 2020-05-01','Shy','Calm','Quiet','Abandoned at shelter','Wet turkey','Mice','Warm bed','Available','2020-06-01','2020-06-15','-','[0.017,0.256,0.555,0.31,0.564]'),
('Puss in Boots','Orange Mixed','Unknown',0,100,'High','N/A','5 years','Male',0,'Rabies 2023-07-20; FVRCP 2023-07-20; Next 2024-07-20','None','None','-','Very social','Energetic','Adventurous','Rescued from street','Dry meat','Mice','Bed','Available','2023-07-25','2023-08-01','-','[0.866,0.407,0.52,0.353,0.611]');
GO
