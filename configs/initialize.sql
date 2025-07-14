CREATE TABLE IF NOT EXISTS nutrients (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    unit VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS nutrition_assessments (
    id SERIAL PRIMARY KEY,
    assessment_date TIMESTAMP NOT NULL,
    user_id INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS nutrient_results (
    id SERIAL PRIMARY KEY,
    nutrient_id INTEGER NOT NULL,
    current_value REAL NOT NULL,
    recommended_min REAL NOT NULL,
    recommended_max REAL,
    is_deficient BOOLEAN NOT NULL,
    food_supplement_amount REAL,
    pharma_supplement_amount REAL,
    assessment_id INTEGER NOT NULL,
    CONSTRAINT fk_nutrient_results_nutrients_nutrient_id FOREIGN KEY (nutrient_id) REFERENCES nutrients (id) ON DELETE CASCADE,
    CONSTRAINT fk_nutrient_results_nutrition_assessments_assessment_id FOREIGN KEY (assessment_id) REFERENCES nutrition_assessments (id) ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS ix_nutrient_results_nutrient_id ON nutrient_results (nutrient_id);
CREATE INDEX IF NOT EXISTS ix_nutrient_results_assessment_id ON nutrient_results (assessment_id);
CREATE INDEX IF NOT EXISTS ix_nutrition_assessments_assessment_date ON nutrition_assessments (assessment_date);
CREATE INDEX IF NOT EXISTS ix_nutrition_assessments_user_id ON nutrition_assessments (user_id);

INSERT INTO nutrients (id, name, unit) VALUES
(1, 'Витамин D', 'мкг'),
(2, 'Витамин C', 'мг'),
(3, 'Витамин B12', 'мкг'),
(4, 'Омега-3', 'г'),
(5, 'Железо', 'мг'),
(6, 'Кальций', 'мг'),
(7, 'Магний', 'мг'),
(8, 'Цинк', 'мг'),
(9, 'Фолиевая кислота', 'мкг'),
(10, 'Витамин A', 'мкг')
ON CONFLICT (name) DO NOTHING;

INSERT INTO nutrition_assessments (assessment_date, user_id) VALUES
('2024-01-15 10:30:00', 1)
ON CONFLICT DO NOTHING;

INSERT INTO nutrient_results (nutrient_id, current_value, recommended_min, recommended_max, is_deficient, food_supplement_amount, pharma_supplement_amount, assessment_id) VALUES
(1, 15.5, 20.0, 50.0, true, 5.0, 10.0, 1),
(2, 45.0, 75.0, 2000.0, true, 30.0, NULL, 1),
(3, 2.1, 2.4, NULL, true, 0.5, 1.0, 1),
(4, 0.8, 1.1, 4.0, true, 0.3, NULL, 1),
(5, 6.5, 8.0, 45.0, true, 2.0, 5.0, 1),
(6, 1200.0, 1000.0, 2500.0, false, NULL, NULL, 1),
(7, 280.0, 310.0, 420.0, true, 30.0, NULL, 1),
(8, 8.5, 8.0, 40.0, false, NULL, NULL, 1),
(9, 200.0, 400.0, 1000.0, true, 200.0, NULL, 1),
(10, 700.0, 600.0, 3000.0, false, NULL, NULL, 1),
(1, 25.0, 20.0, 50.0, false, NULL, NULL, 1),
(2, 120.0, 75.0, 2000.0, false, NULL, NULL, 1),
(3, 3.2, 2.4, NULL, false, NULL, NULL, 1),
(4, 1.5, 1.1, 4.0, false, NULL, NULL, 1),
(5, 12.0, 8.0, 45.0, false, NULL, NULL, 1)
ON CONFLICT DO NOTHING; 