IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Cats')
BEGIN
CREATE TABLE Cats (
    CatId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50),
    Raza NVARCHAR(50),
    OrigenRaza NVARCHAR(100),
    RazaPura BIT,
    AniosExistenciaRaza INT,
    Popularidad NVARCHAR(50),
    EstatusConservacion NVARCHAR(50),
    Edad NVARCHAR(20),
    Sexo NVARCHAR(10),
    Esterilizado BIT,
    HistorialVacunacion NVARCHAR(MAX),
    Alergias NVARCHAR(MAX),
    EnfermedadesCronicas NVARCHAR(MAX),
    TratamientosPasados NVARCHAR(MAX),
    NivelSocializacion NVARCHAR(50),
    NivelActividad NVARCHAR(50),
    Temperamento NVARCHAR(100),
    HistoriaPrevia NVARCHAR(200),
    ComidaPreferida NVARCHAR(100),
    JuguetesFavoritos NVARCHAR(100),
    LugaresDescanso NVARCHAR(100),
    EstadoAdopcion NVARCHAR(50),
    FechaIngreso DATE,
    FechasVisitas NVARCHAR(100),
    EmparejamientosPotenciales NVARCHAR(100),
    EmbeddingVector NVARCHAR(MAX)
);
END
GO

INSERT INTO Cats (Nombre, Raza, OrigenRaza, RazaPura, AniosExistenciaRaza, Popularidad, EstatusConservacion,
Edad, Sexo, Esterilizado, HistorialVacunacion, Alergias, EnfermedadesCronicas, TratamientosPasados,
NivelSocializacion, NivelActividad, Temperamento, HistoriaPrevia, ComidaPreferida, JuguetesFavoritos, LugaresDescanso,
EstadoAdopcion, FechaIngreso, FechasVisitas, EmparejamientosPotenciales, EmbeddingVector)
VALUES
('Luna','Mestizo','Desconocido',0,100,'Alta','N/A','2 años','Hembra',1,'Rabia 2023-05-01; Triple Felina 2023-05-01; Leucemia 2023-05-01; Próxima 2024-05-01','Ninguna','Ninguna','Desparasitación 2022-06-15','Muy social con humanos y gatos','Juguetona','Cariñosa','Rescatada de la calle','Húmeda sabor salmón','Pelotas','Cama alta','Disponible','2022-06-01','2022-07-01,2022-08-15','Familia Pérez','[0.758,0.34,0.845,0.569,0.552]'),
('Simba','Común Europeo','Europa',0,200,'Alta','N/A','3 años','Macho',0,'Rabia 2023-04-10; Triple Felina 2023-04-10; Próxima 2024-04-10','Polen','Ninguna','-',
'Tímido con extraños, sociable con cuidadores','Energético','Curioso','Rescatado de una azotea','Seca pollo','Ratones de juguete','Ventana soleada','En proceso','2023-01-12','2023-02-10','-','[0.864,0.749,0.605,0.181,0.017]'),
('Nala','Siamés','Tailandia',1,600,'Alta','N/A','1 año','Hembra',0,'Rabia 2023-06-20; Triple Felina 2023-06-20; Próxima 2024-06-20','Pescado','Ninguna','-',
'Muy social','Enérgica','Vocal y cariñosa','Abandonada por dueños previos','Húmeda pollo','Cañas','Cajas','Disponible','2023-06-21','2023-06-30','-','[0.726,0.527,0.891,0.322,0.699]'),
('Tom','Mestizo','Desconocido',0,100,'Media','N/A','5 años','Macho',0,'Rabia 2022-12-01; Triple Felina 2022-12-01; Próxima 2023-12-01','Ninguna','Asma','Inhaladores 2020-05-10','Independiente','Calmado','Tranquilo','Rescatado de una casa','Seca salmón','Pelotas','Sillón','Adoptado','2021-03-15','2021-04-01','-','[0.786,0.991,0.166,0.616,0.751]'),
('Mía','Angora Turco','Turquía',1,300,'Media','N/A','4 años','Hembra',1,'Rabia 2022-08-08; Triple Felina 2022-08-08; Leucemia 2022-08-08; Próxima 2023-08-08','Pollo','Ninguna','Castración 2021-09-10','Muy social','Juguetona','Cariñosa','Casa anterior','Húmeda atún','Plumas','Silla cerca de ventana','Disponible','2022-09-01','2022-09-15','-','[0.399,0.391,0.906,0.347,0.603]');
GO

INSERT INTO Cats (Nombre, Raza, OrigenRaza, RazaPura, AniosExistenciaRaza, Popularidad, EstatusConservacion,
Edad, Sexo, Esterilizado, HistorialVacunacion, Alergias, EnfermedadesCronicas, TratamientosPasados,
NivelSocializacion, NivelActividad, Temperamento, HistoriaPrevia, ComidaPreferida, JuguetesFavoritos, LugaresDescanso,
EstadoAdopcion, FechaIngreso, FechasVisitas, EmparejamientosPotenciales, EmbeddingVector)
VALUES
('Leo','Mestizo','Desconocido',0,100,'Alta','N/A','6 meses','Macho',0,'Rabia 2023-07-01; Triple Felina 2023-07-01; Próxima 2024-07-01','Ninguna','Ninguna','-',
'Curioso','Energético','Travieso','Encontrado en parque','Seca gatitos','Pelotas','Cama de cueva','Disponible','2023-07-02','2023-07-10','Familia García','[0.672,0.798,0.669,0.977,0.914]'),
('Chloe','Persa','Persia',1,500,'Alta','N/A','6 años','Hembra',1,'Rabia 2023-03-01; Triple Felina 2023-03-01; Próxima 2024-03-01','Ninguna','Enfermedad renal','Medicamento renal 2022-05-01','Tímida','Calmada','Muy cariñosa','Rescatada de criadero','Húmeda pavo','Ratones','Cama suave','En proceso','2022-04-01','2022-04-15,2022-05-20','Familia Ruiz','[0.118,0.612,0.093,0.802,0.555]'),
('Max','Común Europeo','Europa',0,200,'Alta','N/A','2 años','Macho',0,'Rabia 2023-05-05; Triple Felina 2023-05-05; Próxima 2024-05-05','Ninguna','Ninguna','-',
'Sociable','Energético','Curioso','Rescatado de la calle','Seca carne','Pelotas','Estante alto','Disponible','2022-11-10','2022-11-20','-','[0.382,0.683,0.476,0.881,0.552]'),
('Lola','Mestizo','Desconocido',0,100,'Media','N/A','8 años','Hembra',1,'Rabia 2023-01-15; Triple Felina 2023-01-15; Próxima 2024-01-15','Lácteos','Artritis','Medicamentos 2021-06-10','Tímida','Calmada','Tranquila','Entregada por dueños','Húmeda pavo','Ratones de tela','Cama calentita','Adoptado','2020-10-01','2020-10-10','-','[0.612,0.078,0.499,0.766,0.855]'),
('Oliver','Bombay','Estados Unidos',1,60,'Baja','N/A','3 años','Macho',0,'Rabia 2023-02-01; Triple Felina 2023-02-01; Próxima 2024-02-01','Ninguna','Ninguna','-',
'Muy social','Energético','Cariñoso','Rescatado de abandono','Húmeda pollo','Cañas','Cama alta','Disponible','2022-12-12','2022-12-20','-','[0.493,0.058,0.445,0.26,0.96]'),
('Kiara','Mestizo','Desconocido',0,100,'Alta','N/A','1 año','Hembra',0,'Rabia 2023-06-10; Triple Felina 2023-06-10; Próxima 2024-06-10','Cereal','Ninguna','-',
'Sociable','Juguetona','Cariñosa','Rescatada de la calle','Húmeda pollo','Pelotas','Sillón','Disponible','2023-06-12','2023-06-25','-','[0.011,0.47,0.237,0.073,0.826]'),
('Coco','Ragdoll','Estados Unidos',1,60,'Alta','N/A','5 años','Macho',0,'Rabia 2022-11-01; Triple Felina 2022-11-01; Próxima 2023-11-01','Ninguna','Ninguna','-',
'Muy social','Calmado','Cariñoso','Entregado por familia','Seca salmón','Pelotas','Cama','En proceso','2022-11-02','2022-11-15','Familia Smith','[0.816,0.816,0.532,0.411,0.962]');
GO

INSERT INTO Cats (Nombre, Raza, OrigenRaza, RazaPura, AniosExistenciaRaza, Popularidad, EstatusConservacion,
Edad, Sexo, Esterilizado, HistorialVacunacion, Alergias, EnfermedadesCronicas, TratamientosPasados,
NivelSocializacion, NivelActividad, Temperamento, HistoriaPrevia, ComidaPreferida, JuguetesFavoritos, LugaresDescanso,
EstadoAdopcion, FechaIngreso, FechasVisitas, EmparejamientosPotenciales, EmbeddingVector)
VALUES
('Frida','Mestizo','Desconocido',0,100,'Alta','N/A','2 años','Hembra',1,'Rabia 2023-04-01; Triple Felina 2023-04-01; Próxima 2024-04-01','Ninguna','Ninguna','-',
'Sociable','Juguetona','Cariñosa','Rescatada de la calle','Húmeda atún','Plumas','Cesta','Disponible','2023-04-05','2023-04-20','-','[0.804,0.054,0.707,0.329,0.618]'),
('Toby','Común Europeo','Europa',0,200,'Alta','N/A','4 años','Macho',0,'Rabia 2023-03-05; Triple Felina 2023-03-05; Próxima 2024-03-05','Polvo','Ninguna','-',
'Sociable','Energético','Curioso','Abandonado en refugio','Seca carne','Ratones','Cama alta','Disponible','2021-02-01','2021-02-10','-','[0.552,0.917,0.225,0.606,0.483]'),
('Misha','Azul Ruso','Rusia',1,150,'Media','N/A','7 años','Hembra',1,'Rabia 2023-01-01; Triple Felina 2023-01-01; Próxima 2024-01-01','Ninguna','Hipertiroidismo','Medicamento 2022-08-01','Tímida','Calmada','Dócil','Rescatada de un criadero','Húmeda pescado','Plumas','Cama','Adoptado','2020-05-20','2020-06-01','-','[0.444,0.693,0.978,0.307,0.864]'),
('Rocky','Mestizo','Desconocido',0,100,'Alta','N/A','9 meses','Macho',0,'Rabia 2023-08-01; Triple Felina 2023-08-01; Próxima 2024-08-01','Ninguna','Ninguna','-',
'Muy social','Energético','Travieso','Rescatado de la calle','Seca gatitos','Pelotas','Caja de cartón','Disponible','2023-08-05','2023-08-15','-','[0.524,0.815,0.176,0.213,0.599]'),
('Nina','Siamés','Tailandia',1,600,'Alta','N/A','3 años','Hembra',1,'Rabia 2023-05-10; Triple Felina 2023-05-10; Próxima 2024-05-10','Ninguna','Ninguna','Castración 2021-02-10','Muy social','Juguetona','Vocal','Entregada por familia','Húmeda pavo','Cañas','Cama alta','Disponible','2021-03-01','2021-03-15','-','[0.699,0.535,0.334,0.244,0.409]');
GO

INSERT INTO Cats (Nombre, Raza, OrigenRaza, RazaPura, AniosExistenciaRaza, Popularidad, EstatusConservacion,
Edad, Sexo, Esterilizado, HistorialVacunacion, Alergias, EnfermedadesCronicas, TratamientosPasados,
NivelSocializacion, NivelActividad, Temperamento, HistoriaPrevia, ComidaPreferida, JuguetesFavoritos, LugaresDescanso,
EstadoAdopcion, FechaIngreso, FechasVisitas, EmparejamientosPotenciales, EmbeddingVector)
VALUES
('Felix','Mestizo','Desconocido',0,100,'Alta','N/A','6 años','Macho',0,'Rabia 2023-04-15; Triple Felina 2023-04-15; Próxima 2024-04-15','Ninguna','Diabetes','Insulina diaria 2022-01-01','Sociable','Calmado','Cariñoso','Rescatado de la calle','Seca especial diabetes','Pelotas','Cama','En proceso','2022-02-01','2022-02-15','Familia Gómez','[0.727,0.011,0.158,0.743,0.757]'),
('Cleo','Común Europeo','Europa',0,200,'Media','N/A','10 años','Hembra',1,'Rabia 2023-02-20; Triple Felina 2023-02-20; Próxima 2024-02-20','Ninguna','Enfermedad renal','Medicamentos 2020-05-01','Tímida','Calmada','Tranquila','Abandonada en refugio','Húmeda pavo','Ratones','Cama calentita','Disponible','2020-06-01','2020-06-15','-','[0.017,0.256,0.555,0.31,0.564]'),
('Gato con Botas','Mestizo Naranja','Desconocido',0,100,'Alta','N/A','5 años','Macho',0,'Rabia 2023-07-20; Triple Felina 2023-07-20; Próxima 2024-07-20','Ninguna','Ninguna','-',
'Muy social','Energético','Aventurero','Rescatado de la calle','Seca carne','Ratones','Cama','Disponible','2023-07-25','2023-08-01','-','[0.866,0.407,0.52,0.353,0.611]');
GO
