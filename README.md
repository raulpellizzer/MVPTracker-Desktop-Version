# MVPTracker — Desktop Version

> A Windows desktop application for tracking **Ragnarok Online** MVP (boss monster) respawn timers, built with C# and Windows Forms. DISCLAIMER: This is a quick *for fun* project intended to run on your localhost only. This is NOT production ready.

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

To be added in future updates.

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

The following 24 bosses (old times Ragnarok Online) are pre-configured in the application. Respawn times are listed as they are coded in the application (minutes after kill).

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

## Acknowledgements

- **Ragnarok Online** — the game that inspired this tool, originally developed and published by [Gravity Co., Ltd.](https://www.gravity.co.kr/).
- MVP sprite images in `Images/` and `MvpTracker/Resources/` are game assets belonging to their respective copyright holders and are included here for identification purposes only.
- Built with [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/) and the open-source .NET ecosystem.
