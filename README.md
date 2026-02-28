# MVPTracker — Desktop Version

> A Windows desktop application for tracking **Ragnarok Online** MVP (boss monster) respawn timers, built with C# and Windows Forms.

---

## Table of Contents

1. [Key Features](#key-features)
2. [Screenshots / Demo](#screenshots--demo)
3. [Tech Stack](#tech-stack)
4. [Architecture / Project Structure](#architecture--project-structure)
5. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Installation](#installation)
   - [Database Setup](#database-setup)
   - [Configuration](#configuration)
   - [Running the App](#running-the-app)
6. [Build and Packaging](#build-and-packaging)
7. [Testing](#testing)
8. [Linting / Formatting](#linting--formatting)
9. [Usage Guide](#usage-guide)
10. [Tracked MVPs](#tracked-mvps)
11. [Troubleshooting / FAQ](#troubleshooting--faq)
12. [Roadmap](#roadmap)
13. [Contributing](#contributing)
14. [License](#license)
15. [Security](#security)
16. [Acknowledgements](#acknowledgements)

---

## Key Features

- **One-click kill registration** — click an MVP's button the moment it dies and the app calculates the exact respawn window automatically.
- **Live respawn list** — a colour-coded panel shows which MVPs are dead (red, sorted by respawn time) and which are possibly alive (green).
- **Auto-refresh timer** — a background timer periodically checks whether each tracked MVP's respawn window has elapsed and moves it back to the "alive" pool without manual intervention.
- **"Track for other player" mode** — record a kill without adding it to your personal statistics, useful for relay-tracking in a guild.
- **Privacy overlay** — a checkbox masks the exact respawn timestamps with asterisks, preventing screen-readers or spectators from seeing your timers.
- **Kill statistics window** — a dedicated grid view shows how many times you have killed each MVP, sorted descending.
- **24 MVPs supported out of the box** — covers the most popular bosses from classic Ragnarok Online servers.
- **Persistent storage** — all tracking data is persisted in a Microsoft SQL Server database and survives application restarts.

---

## Screenshots / Demo

> **📸 Placeholder** — Screenshots of the running application have not yet been added to this repository.
>
> To add screenshots:
> 1. Run the application and take screenshots of the main tracker form and the statistics window.
> 2. Save the images inside an `Images/Screenshots/` directory (create it if it doesn't exist).
> 3. Replace the placeholder blocks below with relative Markdown image links, e.g.:
>    ```markdown
>    ![Main Tracker Window](Images/Screenshots/main-form.png)
>    ![Statistics Window](Images/Screenshots/statistics-form.png)
>    ```

| Main Tracker Window | Statistics Window |
|---|---|
| _Screenshot pending_ | _Screenshot pending_ |

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET Framework 4.7.2) |
| UI Framework | Windows Forms (WinForms) |
| Database | Microsoft SQL Server (local) |
| Data Access | `System.Data.SqlClient` |
| IDE / Build | Visual Studio 2022 (MSBuild) |
| Package Manager | NuGet (packages.config) |
| NuGet Dependencies | `Microsoft.Data.Sqlite` 8.0.10, `SQLitePCLRaw` 2.1.6 (bundled) |

> **Note:** The core data-access layer uses `System.Data.SqlClient` against a SQL Server instance. The `Microsoft.Data.Sqlite` package is present in `packages.config` but is not used by the current codebase.

---

## Architecture / Project Structure

```
MVPTracker-Desktop-Version/
├── MvpTracker.sln              # Visual Studio solution file
├── MvpTracker/                 # Main project
│   ├── Program.cs              # Application entry point
│   ├── MvpTrackerForm.cs       # Main WinForms window (UI logic & timer)
│   ├── MvpTrackerForm.Designer.cs  # Auto-generated form designer code
│   ├── StatisticsForm.cs       # Kill-statistics window
│   ├── StatisticsForm.Designer.cs
│   ├── Database.cs             # All SQL Server data-access methods
│   ├── Mvp.cs                  # Domain model for an MVP entity
│   ├── App.config              # Application configuration (server, database)
│   ├── packages.config         # NuGet package references
│   ├── Properties/
│   │   ├── AssemblyInfo.cs
│   │   ├── Resources.resx      # Embedded image resources
│   │   └── Settings.settings
│   └── Resources/              # MVP sprite images (PNG/GIF)
├── Images/                     # Larger MVP animated GIFs (external assets)
└── packages/                   # Restored NuGet packages
```

### Key classes

| Class | Responsibility |
|---|---|
| `mvpTrackerForm` | Main window; holds the kill buttons, the two text boxes (dead / alive), the periodic timer, and all button-click handlers. _(Note: class uses lowercase naming; renaming to `MvpTrackerForm` to match C# PascalCase conventions is recommended.)_ |
| `Database` | Wraps all SQL Server operations: registering kills, updating alive status, reading MVP lists, and fetching statistics. |
| `Mvp` | Plain data object carrying `Id`, `Name`, `KilledTime`, `RespawnDate`, and a reference to the associated UI button. |
| `StatisticsForm` | Secondary window that displays kill counts in a `DataGridView`. |

---

## Getting Started

### Prerequisites

| Requirement | Notes |
|---|---|
| **Windows 10 / 11** | The app targets Windows Forms and requires a Windows environment. |
| **.NET Framework 4.7.2** | Usually pre-installed on Windows 10+. [Download here](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) if missing. |
| **Visual Studio 2019 or later** | Community Edition is free. The solution was created with VS 2022. |
| **SQL Server 2017 or later** | The free [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) edition is sufficient. |
| **SQL Server Management Studio (SSMS)** _(optional)_ | Useful for running the setup scripts and inspecting data. |

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/raulpellizzer/MVPTracker-Desktop-Version.git
   cd MVPTracker-Desktop-Version
   ```

2. **Open the solution in Visual Studio**

   ```
   File → Open → Project/Solution → MvpTracker.sln
   ```

3. **Restore NuGet packages**

   Visual Studio restores packages automatically on first build. If it does not:

   ```
   Tools → NuGet Package Manager → Package Manager Console
   PM> Update-Package -reinstall
   ```

### Database Setup

The application requires two tables — `Mvp` and `MvpTracking` — in a SQL Server database named `MvpTracker` on `localhost`.

> **⚠️ Placeholder** — A SQL setup script has not yet been included in the repository.
> The maintainer should add a `Database/setup.sql` file with `CREATE TABLE` statements and initial MVP data.
> The expected schema, based on the application source, is described below.

**Minimum expected schema:**

```sql
CREATE DATABASE MvpTracker;
GO

USE MvpTracker;
GO

CREATE TABLE Mvp (
    id   INT PRIMARY KEY,
    name NVARCHAR(100) NOT NULL
);

CREATE TABLE MvpTracking (
    id                INT PRIMARY KEY,          -- matches Mvp.id
    killed_time       DATETIME NULL,
    next_respawn_time DATETIME NULL,
    is_mvp_dead       BIT NOT NULL DEFAULT 0,
    killed_count      INT NOT NULL DEFAULT 0
);
```

Populate the `Mvp` and `MvpTracking` tables with one row per MVP (see [Tracked MVPs](#tracked-mvps) for the full list).

### Configuration

All connection settings live in `MvpTracker/App.config`:

```xml
<appSettings>
    <add key="server"   value="localhost" />
    <add key="database" value="MvpTracker" />
</appSettings>
```

| Key | Default | Description |
|---|---|---|
| `server` | `localhost` | SQL Server host name or IP address. |
| `database` | `MvpTracker` | Name of the SQL Server database. |

The connection uses **Windows Integrated Authentication** (`Trusted_Connection=True`). To connect with a SQL login instead, modify the `ConnectionString` property in `Database.cs` accordingly.

> **Security note:** Do not commit credentials or connection strings containing passwords to source control.

### Running the App

1. Set `MvpTracker` as the **startup project** in Visual Studio (it should be by default).
2. Press **F5** (Debug) or **Ctrl+F5** (Run without debugging).

The main tracker window will open and immediately synchronise the live/dead status from the database.

---

## Build and Packaging

### Debug build

```
Build → Build Solution   (Ctrl+Shift+B)
```

Output: `MvpTracker/bin/Debug/MvpTracker.exe`

### Release build

1. Change the build configuration to **Release** in the toolbar dropdown.
2. `Build → Build Solution`

Output: `MvpTracker/bin/Release/MvpTracker.exe`

### Distributing

To distribute the application to end users:

- Copy the entire contents of `bin/Release/` to the target machine.
- Ensure .NET Framework 4.7.2 is installed on the target machine.
- Ensure the target machine has access to the SQL Server instance configured in `App.config`.

> **💡 Tip:** For a fully self-contained installer you can use tools such as **Inno Setup** or the Visual Studio **Setup Project** extension, but these are not yet configured in this repository.

---

## Testing

There is currently **no automated test project** in this solution. All validation is performed manually by running the application.

If you wish to add unit tests:

1. Add a new **NUnit** or **MSTest** project to the solution:
   ```
   File → Add → New Project → NUnit Test Project (.NET Framework)
   ```
2. Add a project reference to `MvpTracker`.
3. Write tests targeting the `Database` and `Mvp` classes.

Pull requests that introduce new logic are encouraged to include corresponding tests.

---

## Linting / Formatting

There is no automated linter or formatter configured in this repository.

**Recommended tools:**
- [**StyleCop Analyzers**](https://github.com/DotNetAnalyzers/StyleCopAnalyzers) — enforce C# style rules via Roslyn (add via NuGet).
- **Visual Studio built-in formatter** — `Edit → Advanced → Format Document` (`Ctrl+K, Ctrl+D`).
- [**EditorConfig**](https://editorconfig.org/) — add a `.editorconfig` file to the repo root to share formatting rules across editors.

---

## Usage Guide

### Basic workflow

1. **Launch** the application. MVPs whose respawn windows have already elapsed are shown in the **Possibly Alive** (green) box.
2. **Register a kill** — when you (or a guild member) kills an MVP, click the corresponding button. The button becomes disabled and the MVP moves to the **Next Respawns** (red) box with the calculated respawn timestamp.
3. **Wait** — the internal timer automatically moves MVPs back to **Possibly Alive** once their respawn window elapses.
4. **Track for another player** — check the **"Track for other player"** checkbox before clicking an MVP button. A confirmation dialog will appear. The kill is recorded but does **not** increment your personal kill counter.
5. **Hide respawn times** — check **"Hide times"** to mask the timestamps with asterisks (useful when streaming or sharing your screen).
6. **View statistics** — click the **Statistics** button to open the kill-count grid, sorted by most-killed first.

### Common tasks

| Task | How to do it |
|---|---|
| Record a kill (personal) | Uncheck "Track for other player" → click the MVP button. |
| Record a kill (for others) | Check "Track for other player" → click the MVP button → confirm the dialog. |
| See when an MVP respawns | Read the **Next Respawns** text box (red). |
| Check which MVPs are up | Read the **Possibly Alive** text box (green). |
| Review your kill history | Click the **Statistics** button. |
| Mask timers on stream | Tick the **Hide times** checkbox. |

---

## Tracked MVPs

The following 24 bosses are pre-configured in the application. Respawn times are listed as they are coded in the application (minutes after kill).

| # | MVP Name | Respawn (min) |
|---|---|---|
| 1 | Baphomet | 60 |
| 2 | Dark Lord | 130 |
| 3 | Doppelganger | 130 |
| 4 | Dracula | 70 |
| 5 | Drake | 60 |
| 6 | Eddga | 60 |
| 7 | Evil Snake Lord | 60 |
| 8 | Golden Thief Bug | 60 |
| 9 | Hatii | 60 |
| 10 | Hela | 130 |
| 11 | Lord of Death | 130 |
| 12 | Maya | 60 |
| 13 | Maya Purple | 60 |
| 14 | Mistress | 60 |
| 15 | Moonlight Flower | 60 |
| 16 | Orc Hero | 60 |
| 17 | Orc Lord | 60 |
| 18 | Osiris | 60 |
| 19 | Pharaoh | 60 |
| 20 | Phreeoni | 60 |
| 21 | Scaraba Queen | 60 |
| 22 | Stormy Knight | 70 |
| 23 | Turtle General | 60 |
| 24 | Abysmal Knights (4) | 150 |

---

## Troubleshooting / FAQ

**Q: The application does not start and shows a connection error.**  
A: Verify that SQL Server is running and that `App.config` contains the correct `server` and `database` values. Confirm the current Windows user has `db_datareader` and `db_datawriter` permissions on the `MvpTracker` database.

**Q: All MVPs show as "Possibly Alive" even though I just killed some.**  
A: This is the expected state on a fresh install before any kills have been registered. Click an MVP button to log the first kill.

**Q: An MVP's button stays greyed-out after its respawn window elapsed.**  
A: The auto-refresh timer fires every minute. Wait up to 60 seconds, or restart the application to force an immediate sync.

**Q: I registered a kill by mistake. How do I undo it?**  
A: There is currently no undo button. You can manually update the `MvpTracking` row in SQL Server to reset `is_mvp_dead = 0` and clear `killed_time` / `next_respawn_time`.

**Q: Can I change the respawn time for an MVP?**  
A: Respawn times are currently hard-coded in `MvpTrackerForm.cs` (the `GetNextRespawnTime` call in each button handler). To change a time, modify the value passed to `GetNextRespawnTime` for the relevant button and rebuild.

**Q: The respawn times seem off by a minute or two.**  
A: Respawn windows in Ragnarok Online have a ±0–10 minute variance on most servers. The application records the kill timestamp precisely but each server's variance applies on top of that.

**Q: What is the `environment` variable in `MvpTrackerForm.cs`?**  
A: When `environment` is set to anything other than `"prod"`, `GetNextRespawnTime` uses a 15-second window instead of the real respawn time. This is a development/testing convenience. Set it back to `"prod"` before building a release.

---

## Roadmap

> **Note:** This roadmap is aspirational and reflects ideas derived from the existing codebase. Maintainer input is required to confirm, prioritise, or remove items.

- [ ] Add a SQL setup script (`Database/setup.sql`) so new users can initialise the database without reverse-engineering the schema.
- [ ] Replace hard-coded respawn times with database-driven configuration so new MVPs can be added without a rebuild.
- [ ] Implement an "undo last kill" button.
- [ ] Add a countdown timer display (time remaining until respawn) instead of a static timestamp.
- [ ] Support multiple server profiles (different respawn timers per server type).
- [ ] Add an automated test project.
- [ ] Introduce a `.editorconfig` and StyleCop to enforce consistent code style.
- [ ] Package as a ClickOnce or Inno Setup installer for easier distribution.
- [ ] Add application version number to the main window title bar.
- [ ] Investigate replacing `System.Data.SqlClient` with `Microsoft.Data.Sqlite` to remove the SQL Server dependency for single-user installs.

---

## Contributing

Contributions are welcome! Please follow these steps:

1. **Fork** the repository and create a feature branch from `main`:
   ```bash
   git checkout -b feature/my-improvement
   ```
2. **Make your changes** — keep commits small and focused.
3. **Test manually** — there is no automated test suite yet, so please verify the affected flows in a running instance.
4. **Ensure the project builds cleanly** in Visual Studio (no errors or new warnings at warning level 4).
5. **Open a Pull Request** against `main` with a clear description of what was changed and why.

> There is currently no `CONTRIBUTING.md` file in this repository. The maintainer may wish to add one with more detailed guidelines (branching strategy, commit message format, code-review process, etc.).

---

## License

> **⚠️ Placeholder** — This repository does not currently contain a `LICENSE` file.
>
> The copyright header in `MvpTracker/Properties/AssemblyInfo.cs` states:
> ```
> Copyright © 2024
> ```
> Until a license is explicitly added, all rights are reserved by the author and the code may **not** be redistributed or used in other projects without written permission.
>
> The maintainer should choose an appropriate open-source license (e.g., [MIT](https://choosealicense.com/licenses/mit/), [GPL-3.0](https://choosealicense.com/licenses/gpl-3.0/)) and add a `LICENSE` file to the root of the repository.

---

## Security

- **Connection strings** — The default configuration uses Windows Integrated Authentication. If you modify `Database.cs` to accept a username/password, **never** commit credentials to source control. Use environment variables or a secrets manager instead.
- **SQL injection** — The current `Database.cs` builds SQL queries via string concatenation which may be vulnerable to SQL injection if MVP names or other values come from untrusted input. Refactoring to use parameterised queries (`SqlCommand.Parameters`) is strongly recommended.
- **Responsible disclosure** — If you discover a security vulnerability in this project, please report it privately to the repository owner via GitHub's [Private Vulnerability Reporting](https://docs.github.com/en/code-security/security-advisories/guidance-on-reporting-and-writing/privately-reporting-a-security-vulnerability) feature rather than opening a public issue.

---

## Acknowledgements

- **Ragnarok Online** — the game that inspired this tool, originally developed and published by [Gravity Co., Ltd.](https://www.gravity.co.kr/).
- MVP sprite images in `Images/` and `MvpTracker/Resources/` are game assets belonging to their respective copyright holders and are included here for identification purposes only.
- Built with [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/) and the open-source .NET ecosystem.
