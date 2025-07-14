# BioGenomTestProject

[API Docs (Redoc)](https://a-sharifov.github.io/BioGenomTestProject/)

---

## Описание
BioGenomTestProject — тестовый сервис для оценки нутриционного статуса пользователя. Проект демонстрирует работу с современным стеком .NET, автоматической документацией и контейнеризацией.

---

## Основные сущности

- **Nutrient**  
  Справочник нутриентов (витамины, минералы и т.д.). При необходимости можно добавить категорию вещества для расширения функционала.

- **NutritionAssessment**  
  Оценка питания пользователя за определённую дату. Содержит ссылку на пользователя (UserId).

- **NutrientResult**  
  Результат анализа по каждому нутриенту в рамках одной оценки.

> **Примечания:**
> - Все свойства сущностей имеют приватные сеттеры — это защищает данные от случайных изменений и помогает поддерживать чистую архитектуру.
> - Поле `UserId` в NutritionAssessment имитирует интеграцию с внешним микросервисом пользователей (auth).

---

## Технологии

- **Язык:** C# 13
- **Платформа:** .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Swashbuckle/Swagger
- Redoc (автоматическая генерация документации)
- Docker, Docker Compose
- GitHub Actions (CI/CD)

---

## Как запустить проект

1. **Клонируйте репозиторий:**
   ```sh
   git clone <repo-url>
   cd BioGenomTestProject
   ```
2. **Запустите все сервисы одной командой:**
   ```sh
   docker-compose up --build
   ```
   Всё поднимется автоматически: и база, и приложение, инициализация не требует ручных действий.
3. **API будет доступен по адресу:**
   - [http://localhost:8080](http://localhost:8080) (или порт, указанный в настройках)

---

## Документация и тестирование

- **Swagger UI** — для ручного тестирования и просмотра схемы API:  
  [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)
- **Redoc** — автоматически обновляемая документация:  
  [https://a-sharifov.github.io/BioGenomTestProject/](https://a-sharifov.github.io/BioGenomTestProject/)
- **OpenAPI спецификация** — доступна для скачивания на странице Redoc.
- **HTTP-запросы для тестирования** — файл [`BioGenomTestProject/BioGenomTestProject.http`](BioGenomTestProject/BioGenomTestProject.http) содержит примеры всех запросов к API (можно запускать прямо из IDE).

---

## Основные эндпоинты

- `GET /api/nutrition` — получить полную оценку питания
- `GET /api/nutrition/deficient` — получить дефицитные нутриенты
- `GET /api/nutrition/sufficient` — получить нутриенты в норме
- `GET /api/nutrition/summary` — получить сводку по нутриентам

---

> Документация по API и .http-файл обновляются автоматически при каждом изменении схемы.
