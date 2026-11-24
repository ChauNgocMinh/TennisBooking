# News data and index design

## Goal

Add a database-backed bilingual news list at `News/Index` while preserving the existing MVC architecture and static news routes.

## Data model

`News` inherits `BaseModel` and stores `TitleVi`, `TitleEn`, `ContentVi`, `ContentEn`, `Link`, `BannerImageUrl`, and `PublishedAt`. The shared link/image fields are not localized. Default records live in `Data/NewsSeedData.cs` and are applied through EF Core `HasData`.

## Request and rendering flow

`NewsController.Index` calls `INewsService`, which calls `INewsRepository`. The repository returns the newest records from EF Core with `AsNoTracking`. The service maps them to `NewsViewModel`. The Razor view renders both language variants as data attributes; `site.js` selects the active language and re-renders them on the existing `languageChanged` event.

## UI and compatibility

The existing `Tournament`, `TrainingCourt`, and `Promotion` actions remain unchanged. The shared News navigation receives an `Index` link. Static labels use the existing `data-i18n` dictionary with matching Vietnamese and English keys. A migration adds the `News` table and seed rows.

## Verification

Run the available .NET build and EF migration/model checks. There is no existing test project in this repository, so `dotnet test` is reported as not run if the solution has no test project.
