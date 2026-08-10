# SharpSteroids: Console Edition

![Status](https://img.shields.io/badge/Status-Scaffold-yellow) ![.NET](https://img.shields.io/badge/.NET-10.0-purple) ![License](https://img.shields.io/badge/License-MIT-blue)

**SharpSteroids** is a recreation of the classic arcade game *Asteroids*, written in C# targeting .NET 10 and rendered with ASCII/Unicode characters in the system console.

The goal is a mini game-engine abstraction — vector physics, procedural waves, a character frame buffer — with no external game libraries.

## ⚠️ Current State

**The codebase is a scaffold.** It was deliberately reset to a minimal starting point, and today it prints `Hello World` and exits. None of the game is implemented yet: no input loop, no physics, no rendering beyond a single line of text.

What exists is the shape the rest will be built on:

```
AsteroidsGame/
├── Program.cs                      # Composition root
├── Core/Game.cs                    # The game; takes its dependencies via constructor
└── Engine/Rendering/
    ├── IRenderer.cs                # Output surface abstraction
    └── ConsoleRenderer.cs          # Console implementation
```

## 🛠️ Architecture

Two decisions define the current structure:

**Manual constructor injection.** Dependencies are declared as constructor parameters and wired by hand in `Program.cs`. There is no DI container and no generic host — no `Host.CreateApplicationBuilder`, no `IServiceCollection`, no `BackgroundService`.

```csharp
IRenderer renderer = new ConsoleRenderer();
Game game = new(renderer);

game.Run();
```

`Program.Main` is the single composition root: it is the only place that calls `new` on a dependency. Everything below it receives what it needs and never reaches out for it, which keeps `Game` testable against a fake `IRenderer` with no framework involved.

**Zero dependencies.** The project references no NuGet packages at all — only the .NET base class library. Anything the game needs gets written here.

## 🚀 How to Run

Prerequisites: **.NET 10 SDK** (pinned in `global.json`).

```bash
git clone repo_url
cd AsteroidsGame
dotnet run --project AsteroidsGame
```

Expected output:

```
Hello World
```

## 🗺️ Planned

* **Input loop** — non-blocking keypress interception, whitelisted keys.
* **Update loop** — delta time, position/velocity vectors, torus wrapping at screen edges.
* **Render loop** — a 2D `char` buffer written to `stdout` in one pass to minimise flicker.
* **Gameplay** — thrust and rotation, firing, asteroids that split into smaller ones, endless waves.

*For the best visual experience once rendering lands, use a terminal that supports ANSI escape codes (Windows Terminal, PowerShell Core, or iTerm2).*

## 📄 Maintenance & License

This project was created as a personal coding challenge and is provided as-is for educational purposes. Pull requests and issues are not monitored (mainly because I cannot be bothered). See [contributing.md](contributing.md).

Distributed under the MIT License.
