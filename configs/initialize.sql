-- Создание таблиц на основе Entity из папки Entities
CREATE TABLE IF NOT EXISTS "Nutrients" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL UNIQUE,
    "Unit" VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS "NutritionAssessments" (
    "Id" SERIAL PRIMARY KEY,
    "AssessmentDate" TIMESTAMP NOT NULL,
    "UserId" INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS "NutrientResults" (
    "Id" SERIAL PRIMARY KEY,
    "NutrientId" INTEGER NOT NULL,
    "CurrentValue" REAL NOT NULL,
    "RecommendedMin" REAL NOT NULL,
    "RecommendedMax" REAL,
    "IsDeficient" BOOLEAN NOT NULL,
    "FoodSupplementAmount" REAL,
    "PharmaSupplementAmount" REAL,
    "AssessmentId" INTEGER NOT NULL,
    CONSTRAINT "FK_NutrientResults_Nutrients_NutrientId" FOREIGN KEY ("NutrientId") REFERENCES "Nutrients" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_NutrientResults_NutritionAssessments_AssessmentId" FOREIGN KEY ("AssessmentId") REFERENCES "NutritionAssessments" ("Id") ON DELETE CASCADE
);

-- Создание индексов
CREATE INDEX IF NOT EXISTS "IX_NutrientResults_NutrientId" ON "NutrientResults" ("NutrientId");
CREATE INDEX IF NOT EXISTS "IX_NutrientResults_AssessmentId" ON "NutrientResults" ("AssessmentId");
CREATE INDEX IF NOT EXISTS "IX_NutritionAssessments_AssessmentDate" ON "NutritionAssessments" ("AssessmentDate");
CREATE INDEX IF NOT EXISTS "IX_NutritionAssessments_UserId" ON "NutritionAssessments" ("UserId");

-- Вставка тестовых данных для витаминов и питательных веществ
INSERT INTO "Nutrients" ("Id", "Name", "Unit") VALUES
(1, 'Витамин D', 'мкг/день'),
(2, 'Витамин C', 'мг/день'),
(3, 'Витамин B12', 'мкг/день'),
(4, 'Омега-3', 'г/день'),
(5, 'Железо', 'мг/день'),
(6, 'Кальций', 'мг/день'),
(7, 'Магний', 'мг/день'),
(8, 'Цинк', 'мг/день'),
(9, 'Фолиевая кислота', 'мкг/день'),
(10, 'Витамин A', 'мкг/день')
ON CONFLICT ("Name") DO NOTHING;

-- Вставка одного общего NutritionAssessment для всех пользователей
INSERT INTO "NutritionAssessments" ("AssessmentDate", "UserId") VALUES
('2024-01-15 10:30:00', 1)
ON CONFLICT DO NOTHING;

-- Вставка результатов анализов для разных пользователей (все ссылаются на один AssessmentId = 1)
INSERT INTO "NutrientResults" ("NutrientId", "CurrentValue", "RecommendedMin", "RecommendedMax", "IsDeficient", "FoodSupplementAmount", "PharmaSupplementAmount", "AssessmentId") VALUES
-- Пользователь 1 (дефициты)
(1, 15.5, 20.0, 50.0, true, 5.0, 10.0, 1),  -- Витамин D дефицит
(2, 45.0, 75.0, 2000.0, true, 30.0, NULL, 1), -- Витамин C дефицит
(3, 2.1, 2.4, NULL, true, 0.5, 1.0, 1),  -- B12 дефицит
(4, 0.8, 1.1, 4.0, true, 0.3, NULL, 1), -- Омега-3 дефицит
(5, 6.5, 8.0, 45.0, true, 2.0, 5.0, 1),  -- Железо дефицит

-- Пользователь 2 (смешанные результаты)
(6, 1200.0, 1000.0, 2500.0, false, NULL, NULL, 1), -- Кальций в норме
(7, 280.0, 310.0, 420.0, true, 30.0, NULL, 1), -- Магний дефицит
(8, 8.5, 8.0, 40.0, false, NULL, NULL, 1), -- Цинк в норме
(9, 200.0, 400.0, 1000.0, true, 200.0, NULL, 1), -- Фолиевая кислота дефицит
(10, 700.0, 600.0, 3000.0, false, NULL, NULL, 1), -- Витамин A в норме

-- Пользователь 3 (все в норме)
(1, 25.0, 20.0, 50.0, false, NULL, NULL, 1), -- Витамин D в норме
(2, 120.0, 75.0, 2000.0, false, NULL, NULL, 1), -- Витамин C в норме
(3, 3.2, 2.4, NULL, false, NULL, NULL, 1), -- B12 в норме
(4, 1.5, 1.1, 4.0, false, NULL, NULL, 1), -- Омега-3 в норме
(5, 12.0, 8.0, 45.0, false, NULL, NULL, 1)  -- Железо в норме
ON CONFLICT DO NOTHING; 