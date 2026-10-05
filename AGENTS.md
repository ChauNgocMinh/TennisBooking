# AGENTS.md

## Project

- Name: TennisBooking
- Type: ASP.NET Core MVC
- Language: C#
- UI: Razor Views
- Data access: Entity Framework Core
- Architecture: Controller -> Service -> Repository -> Data/EF Core

## Existing Project Structure

TennisBooking/
├── Common/
│ ├── Enum/
│ └── BaseModel.cs
├── Controllers/
├── Data/
├── Entities/
├── Migrations/
├── Repository/
├── Services/
├── ViewModels/
├── Views/
├── wwwroot/
│ ├── css/
│ ├── js/
│ ├── lib/
│ └── media/
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── README.md

## General Rules

- Read the existing implementation before changing code.
- Follow the current project structure and naming conventions.
- Make the smallest correct change needed for the task.
- Do not refactor unrelated code.
- Do not introduce new architectural patterns unless explicitly requested.
- Do not add new NuGet packages unless necessary.
- Do not invent business rules that cannot be verified from the codebase.
- Reuse existing classes, services, repositories, ViewModels, helpers, and enums when possible.
- Keep code simple, readable, and consistent with the existing codebase.

## Architecture Rules

Use this flow for application logic:

HTTP Request
-> Controller
-> Service
-> Repository
-> Data / Entity Framework Core
-> Database

Use this flow for MVC rendering:

Entity / Repository result
-> Service
-> ViewModel
-> Controller
-> Razor View

Do not bypass layers without a clear reason.

## Controllers

Location: `Controllers/`

Controllers should:

- Receive HTTP requests.
- Validate route/query/form input.
- Check `ModelState` for form submissions.
- Call Services.
- Prepare ViewModels.
- Return `View`, `RedirectToAction`, `Json`, `NotFound`, `BadRequest`, or other appropriate results.

Controllers should NOT:

- Contain complex business logic.
- Query the database directly if an appropriate Service/Repository exists.
- Contain repeated EF Core queries.
- Perform large calculations.
- Contain infrastructure code.

Prefer:

```csharp
public async Task<IActionResult> Create(CreateBookingViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    var result = await _bookingService.CreateAsync(model);

    if (!result.Success)
    {
        ModelState.AddModelError(string.Empty, result.Message);
        return View(model);
    }

    return RedirectToAction(nameof(Index));
}
```

## Services

Location: `Services/`

Services contain business logic.

Typical Service responsibilities:

- Booking validation.
- Court availability checks.
- Time validation.
- Price calculation.
- Booking cancellation rules.
- Status transitions.
- Coordination between multiple repositories.
- Mapping entities to ViewModels when appropriate.

Services should NOT:

- Return `IActionResult`.
- Render HTML.
- Depend on Razor Views.
- Contain UI-specific logic.

If interfaces already exist, preserve the interface-based pattern.

## Repository

Location: `Repository/`

Repositories are responsible for persistence and database queries.

Typical responsibilities:

- Get entity by id.
- List/filter entities.
- Add/update/delete entities.
- Check existence.
- Execute reusable EF Core queries.
- Save changes if the current repository pattern owns persistence.

Repositories should NOT:

- Contain MVC logic.
- Return Views.
- Contain business rules that belong in Services.

Reuse repository methods instead of duplicating equivalent EF Core queries.

## Data

Location: `Data/`

Use this folder for:

- `DbContext`.
- Entity Framework configuration.
- Seed data.
- Database initialization.
- Persistence infrastructure.

Do not put business logic in `DbContext`.

Before changing database configuration, inspect the current `DbContext` and existing relationships.

## Entities

Location: `Entities/`

Entities represent persisted domain models.

Rules:

- Preserve existing relationships and navigation properties.
- Reuse `BaseModel` if the project already uses it.
- Do not duplicate properties inherited from `BaseModel`.
- Avoid putting UI-only fields into Entities.
- Do not use Entities as form models when a ViewModel is more appropriate.
- Do not change an Entity property type without checking migration/database impact.

## Common

Location: `Common/`

Use this folder only for shared project-level definitions.

`Common/Enum/`

- Store shared enums.
- Prefer enums over magic numbers or magic strings.

`Common/BaseModel.cs`

- Reuse inherited common properties.
- Inspect all inheriting entities before changing `BaseModel`.
- Treat changes to `BaseModel` as potentially affecting multiple database tables.

## ViewModels

Location: `ViewModels/`

Use ViewModels for:

- Form input.
- Page-specific display data.
- Combined data from multiple entities.
- Validation attributes.
- Dropdown/select data.
- UI-specific calculated/display fields.

Do not expose database Entities directly to Views when the page has different requirements.

Use validation attributes where appropriate:

```csharp
[Required]
[StringLength(100)]
public string Name { get; set; } = string.Empty;
```

Server-side validation is mandatory for important data.

## Views

Location: `Views/`

Views should:

- Render HTML.
- Use Razor syntax.
- Display ViewModel data.
- Render forms.
- Display validation messages.
- Use partial views where appropriate.

Views should NOT:

- Query the database.
- Access repositories.
- Contain business rules.
- Perform large calculations.
- Contain large C# code blocks when the data can be prepared earlier.

## wwwroot

Location: `wwwroot/`

Use:

- `wwwroot/css/` for CSS.
- `wwwroot/js/` for JavaScript.
- `wwwroot/lib/` for frontend libraries.
- `wwwroot/media/` for static media.

Before adding new CSS or JS:

- Inspect existing files.
- Reuse existing styles/utilities.
- Avoid duplicate logic.
- Avoid global JavaScript when unnecessary.

Frontend validation does not replace backend validation.

## Internationalization (Vietnamese / English)

The project supports exactly two UI languages:

- Vietnamese: `vi`
- English: `en`

All user-facing content must follow the existing translation system implemented in:

```text
wwwroot/js/site.js
```

The existing translation source of truth is:

```javascript
const translations = {
  vi: {
    // translation keys
  },
  en: {
    // matching translation keys
  },
};
```

The current language is resolved from:

```javascript
let currentLanguage = localStorage.getItem("tennis-language") || "vi";
```

The page translation mechanism uses:

```javascript
document.querySelectorAll("[data-i18n]").forEach((element) => {
  const value = translations[currentLanguage][element.dataset.i18n];
  if (value) element.textContent = value;
});
```

### Mandatory i18n Rules

Every new user-facing text added to the application must support both Vietnamese and English.

Do NOT hard-code visible content directly in Razor Views when that content should change with the selected language.

Bad:

```html
<h1>Đặt sân tennis</h1>
<button>Gửi yêu cầu</button>
```

Good:

```html
<h1 data-i18n="booking.title"></h1>
<button data-i18n="booking.submit"></button>
```

Then add the same translation key to both language objects in `wwwroot/js/site.js`:

```javascript
vi: {
    "booking.title": "Đặt sân tennis",
    "booking.submit": "Gửi yêu cầu đặt sân"
},
en: {
    "booking.title": "Book a tennis court",
    "booking.submit": "Send booking request"
}
```

### Translation Key Rules

Translation keys must:

- Be descriptive.
- Use dot notation.
- Follow the existing naming convention.
- Be grouped by feature/page.
- Exist in both `vi` and `en`.
- Use the exact same key in both language dictionaries.

Examples:

```text
nav.home
booking.title
booking.submit
schedule.date
about.description
privacy.heading
news.tournamentTitle
```

For a new feature, create a clear namespace.

Example:

```javascript
vi: {
    "profile.title": "Hồ sơ cá nhân",
    "profile.save": "Lưu thay đổi"
},
en: {
    "profile.title": "Profile",
    "profile.save": "Save changes"
}
```

Do NOT create inconsistent keys such as:

```javascript
vi: {
    "profile.title": "Hồ sơ cá nhân"
},
en: {
    "profile.heading": "Profile"
}
```

Both objects must contain matching keys.

### Razor View Rules

All static user-visible Razor content must use `data-i18n` where appropriate.

Example:

```html
<section>
  <p data-i18n="booking.eyebrow"></p>
  <h1 data-i18n="booking.title"></h1>
  <p data-i18n="booking.description"></p>
</section>
```

Do not duplicate Vietnamese and English HTML blocks.

Bad:

```html
<div class="vi-content">Đặt sân</div>
<div class="en-content">Book a court</div>
```

Use one element with one translation key instead.

### JavaScript-Generated Content

If JavaScript creates user-visible text dynamically, it must use the active language dictionary.

Use:

```javascript
const text = translations[currentLanguage]["booking.weeklySuccess"];
```

Do not hard-code:

```javascript
message.textContent = "Thông tin của bạn đã được ghi nhận.";
```

Use:

```javascript
message.textContent = translations[currentLanguage]["booking.weeklySuccess"];
```

If the content must update immediately after the language changes, listen to the existing event:

```javascript
document.addEventListener("languageChanged", (event) => {
  const language = event.detail;

  // Re-render dynamic translated content here.
});
```

### Dynamic Server Data

Do not translate dynamic domain data blindly.

Examples of values that normally should remain data rather than translation keys:

- User names.
- Phone numbers.
- Booking ids.
- Court names stored in the database.
- Dates/times.
- Prices.
- Database-generated content.

Only UI labels, messages, headings, placeholders, validation messages, buttons, navigation labels, and similar interface text should normally use the translation system.

If database content itself has Vietnamese and English versions, preserve the existing database/domain model rather than forcing it into `site.js`.

### Form Labels and Buttons

All form labels and action text must be bilingual.

Example:

```html
<label data-i18n="booking.name"></label>
<button type="submit" data-i18n="booking.submit"></button>
<button type="button" data-i18n="booking.cancel"></button>
```

### Placeholder Text

The existing `translatePage()` implementation currently updates `textContent` for `[data-i18n]`.

Therefore, do not assume that `data-i18n` automatically translates attributes such as:

```html
placeholder title aria-label
```

For attribute-based content:

1. Inspect the existing translation mechanism.
2. Reuse an existing attribute translation pattern if one exists.
3. If no mechanism exists and the task requires it, extend `translatePage()` consistently instead of hard-coding one language.

Any extension must remain backward-compatible with the existing `data-i18n` behavior.

### Validation and Messages

Any custom user-visible validation or success/error message added in JavaScript must have both Vietnamese and English translations.

Example:

```javascript
vi: {
    "booking.invalidTime": "Giờ kết thúc phải sau giờ bắt đầu."
},
en: {
    "booking.invalidTime": "End time must be after start time."
}
```

Then:

```javascript
errorElement.textContent = translations[currentLanguage]["booking.invalidTime"];
```

Do not introduce a new message in only one language.

### Navigation and Layout

Shared UI content such as:

- navbar
- footer
- language selector
- shared modal text
- shared buttons
- shared alerts

must continue using the same translation source in `wwwroot/js/site.js`.

Do not create a second translation object in another JavaScript file unless explicitly requested.

`wwwroot/js/site.js` is the source of truth for the current frontend translation system.

### Language State

Do not change the current storage behavior unless explicitly requested.

The existing key is:

```text
tennis-language
```

The default language is:

```text
vi
```

Do not rename the localStorage key or change the default language without explicit instruction.

### Language Change Event

The existing translation function dispatches:

```javascript
document.dispatchEvent(
  new CustomEvent("languageChanged", { detail: currentLanguage }),
);
```

Any dynamic component that needs to rerender translated text should reuse this event.

Do not create another global language state system when the current mechanism is sufficient.

### Before Completing Any UI Task

For every change that adds or modifies visible UI content:

1. Identify every new user-facing string.
2. Create/update translation keys in `wwwroot/js/site.js`.
3. Add the Vietnamese value.
4. Add the English value.
5. Verify both dictionaries contain the same new keys.
6. Use `data-i18n` for static Razor content.
7. Use `translations[currentLanguage][key]` for dynamic JavaScript content.
8. Verify content changes when switching between `vi` and `en`.
9. Verify the selected language persists through `localStorage`.
10. Do not leave untranslated hard-coded UI text.

A UI task is incomplete if visible content was added but only one language was implemented.

## Dependency Injection

Use the existing DI setup in `Program.cs`.

Prefer constructor injection.

Example:

```csharp
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
```

Do not manually instantiate application services or repositories when DI should manage them.

## Entity Framework Core

Use async EF Core APIs when available.

Prefer:

- `ToListAsync`
- `FirstOrDefaultAsync`
- `SingleOrDefaultAsync`
- `AnyAsync`
- `SaveChangesAsync`

Avoid:

- `.Result`
- `.Wait()`

For read-only queries, consider `AsNoTracking()` when appropriate.

Avoid N+1 queries.

Prefer `Include`, projection, or a proper query over database queries inside loops.

Example:

```csharp
var bookings = await _context.Bookings
    .AsNoTracking()
    .Include(x => x.Court)
    .ToListAsync();
```

Use projection when only a subset of fields is needed:

```csharp
var models = await _context.Bookings
    .AsNoTracking()
    .Select(x => new BookingViewModel
    {
        Id = x.Id,
        StartTime = x.StartTime,
        EndTime = x.EndTime
    })
    .ToListAsync();
```

## Booking Domain

This is a tennis booking system.

Before implementing or changing booking behavior, inspect existing code for actual rules.

Common checks may include:

- Court exists.
- Court is active.
- Start time is valid.
- End time is valid.
- End time is after start time.
- Booking does not conflict with an existing booking.
- User has permission to perform the action.
- Current booking status allows the requested transition.

Do not assume these rules if the codebase defines something different.

For time-range conflict logic, the standard overlap condition is:

```text
newStart < existingEnd
AND
newEnd > existingStart
```

Adapt it to the existing entity/status model.

## Migrations

Location: `Migrations/`

Only create a migration when the database schema actually changes.

Before creating a migration:

1. Inspect the affected Entity.
2. Inspect `DbContext`.
3. Inspect relationships.
4. Inspect existing migrations.
5. Determine the intended schema change.

Typical commands:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

Do not:

- Rewrite old migrations without explicit reason.
- Delete database data.
- Drop tables/columns.
- Reset the database.

unless explicitly instructed.

## Configuration

Use:

- `appsettings.json`
- `appsettings.Development.json`
- environment variables / user secrets when appropriate.

Never hard-code:

- passwords
- production connection strings
- API secrets
- tokens
- private keys

Do not commit secrets.

## Error Handling

Do not use empty catch blocks.

Avoid catching generic `Exception` unless there is a clear reason and the error is logged or handled correctly.

Expected business failures should be represented as normal business results where practical.

Do not expose:

- stack traces
- SQL details
- connection strings
- internal exception messages

to normal users.

## Logging

Use `ILogger<T>` if logging is already configured.

Do not log:

- passwords
- access tokens
- secrets
- connection strings
- sensitive user data

## Async Naming

Async methods should use the `Async` suffix.

Examples:

- `GetByIdAsync`
- `CreateBookingAsync`
- `UpdateBookingAsync`
- `DeleteBookingAsync`

## C# Naming

Follow standard C# naming conventions.

Classes:

- `BookingController`
- `BookingService`
- `BookingRepository`
- `BookingViewModel`

Interfaces:

- `IBookingService`
- `IBookingRepository`

Private fields:

- `_bookingService`
- `_bookingRepository`
- `_context`

Avoid unnecessary abbreviations.

## Tests

Location: `tests/`

Before changing important business logic:

- Inspect existing tests.
- Update/add tests when practical.
- Do not delete failing tests just to make the suite pass.

Important behavior to test where applicable:

- Booking creation.
- Invalid booking time.
- Booking overlap.
- Booking cancellation.
- Status transitions.
- Authorization-sensitive actions.
- Service business rules.

## Security

Never trust client-supplied values automatically.

Validate sensitive or authoritative values on the server, including:

- UserId.
- Role.
- Booking status.
- Payment status.
- Price.
- Ownership.
- Resource ids.

Use the current project authentication/authorization pattern if one already exists.

Do not introduce a new authentication system unless explicitly requested.

## Do Not Over-Engineer

Do not introduce these unless explicitly requested or already used:

- Clean Architecture rewrite.
- CQRS.
- MediatR.
- Event sourcing.
- Microservices.
- Message brokers.
- New ORM.
- New frontend framework.
- Large generic abstraction layers.

Preserve the existing MVC project architecture.

## Workflow Before Coding

For every non-trivial task:

1. Read `AGENTS.md`.
2. Read the user/task requirement.
3. Search the codebase for related files.
4. Inspect the relevant Controller.
5. Inspect the relevant Service.
6. Inspect the relevant Repository.
7. Inspect the relevant Entity.
8. Inspect related ViewModels.
9. Inspect related Views.
10. Inspect Enums and `BaseModel` if relevant.
11. Inspect `DbContext`.
12. Inspect existing tests.
13. Identify affected files.
14. Make a short implementation plan.
15. Implement only the necessary changes.

Do not start generating code before understanding the existing implementation.

## Verification

After modifying C# code, run:

If Entity Framework changes were made, verify that the model and migration are consistent.

Do not claim that build/tests pass unless the commands actually pass.

## Final Report

After completing a coding task, report only factual results:

```text
Changed:
- <file>
- <file>

Implemented:
- <change>
- <change>

Verification:
- dotnet build: PASS / FAIL / NOT RUN
- dotnet test: PASS / FAIL / NOT RUN

Notes:
- <migration or unresolved issue if any>
```

## Priority

When instructions conflict, use this priority:

1. Explicit user/task requirement.
2. Existing working project behavior and architecture.
3. This `AGENTS.md`.
4. General coding conventions.

Primary rule:

Understand the existing code first, preserve the architecture, make the smallest correct change, and verify the result.
