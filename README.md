# BioGenomTestProject 
## [API Docs](https://a-sharifov.github.io/BioGenomTestProject/)

## Описание

BioGenomTestProject — сервис для оценки нутриционного статуса (тестовый проект)

## Технологии
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Swashbuckle/Swagger
- Redoc (автоматическая генерация документации)
- GitHub Actions (CI/CD)
- Docker, Docker Compose

## Как запустить
1. Клонируйте репозиторий:
   ```
   git clone <repo-url>
   cd BioGenomTestProject
   ```
2. Запустите проект и базу данных одной командой:
   ```
   docker-compose up --build
   ```
   Это автоматически поднимет все необходимые сервисы, выполнит инициализацию базы и запустит приложение.
3. API будет доступен по адресу: `http://localhost:8080` (или порту, указанному в настройках).

## Документация и тестирование
- **Swagger UI** для ручного тестирования и просмотра схемы API (при запуске):  
  [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)
- **Автоматическая документация Redoc**:  
  [https://a-sharifov.github.io/BioGenomTestProject/](https://a-sharifov.github.io/BioGenomTestProject/)
- **OpenAPI спецификация** доступна для скачивания на странице Redoc.
- **HTTP-запросы для тестирования**: файл [`BioGenomTestProject/BioGenomTestProject.http`](BioGenomTestProject/BioGenomTestProject.http) содержит примеры всех запросов к API, которые можно запускать прямо из IDE (например, VS Code, Rider).

## Основные эндпоинты
- `GET /api/nutrition` — получить полную оценку питания
- `GET /api/nutrition/deficient` — получить дефицитные нутриенты
- `GET /api/nutrition/sufficient` — получить нутриенты в норме
- `GET /api/nutrition/summary` — получить сводку по нутриентам

---
Документация по API и .http-файл обновляются автоматически при каждом изменении схемы.
