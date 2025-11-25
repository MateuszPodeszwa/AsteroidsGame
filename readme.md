# SharpSteroids: Console Edition

![Status](https://img.shields.io/badge/Status-Archived-red) ![.NET](https://img.shields.io/badge/.NET-10.0-purple) ![License](https://img.shields.io/badge/License-MIT-blue)

**SharpSteroids** is a high-performance recreation of the classic arcade game *Asteroids*, built entirely in C# targeting .NET 10.

This project was a "side quest" challenge to build a mini-game engine abstraction capable of vector-based physics and procedural level generation, rendered purely via ASCII/Unicode characters in the system console.

## 🎯 Project Goals
* **No External Game Libraries:** Built without Unity, MonoGame, or SDL. Just raw .NET.
* **Engine Abstraction:** Implemented a custom `IGameObject` and `IRenderer` pipeline.
* **Math:** Custom 2D vector physics for thrust, drag, and collision detection.
* **Procedural Generation:** Endless waves of asteroids with increasing difficulty.

## 🕹️ Gameplay
The game runs directly in your terminal.

* **Controls:**
    * `↑` / `W`: Thrust
    * `←` / `→` or `A` / `D`: Rotate Ship
    * `Space`: Fire
    * `Esc`: Quit
* **Objective:** Destroy all asteroids. Large asteroids break into smaller ones. Don't get hit.

## 🛠️ Architecture
The solution is built on a custom "Console Frame Buffer" approach:

1.  **Input Loop:** Asynchronous interception of keypresses.
2.  **Update Loop:** Calculates delta time ($dt$), updates position vectors, and handles torus-wrapping (screen wrap).
3.  **Render Loop:** Writes a 2D char array buffer to the Console `StdOut` in a single pass to minimize flickering.

## 🚀 How to Run
Prerequisites: **.NET 10 SDK** (Preview or Latest Daily Build).

1.  Clone the repository:
    ```bash
    git clone [https://github.com/yourusername/SharpSteroids-Console.git](https://github.com/yourusername/SharpSteroids-Console.git)
    ```
2.  Navigate to the directory:
    ```bash
    cd SharpSteroids-Console
    ```
3.  Run the application:
    ```bash
    dotnet run -c Release
    ```

*Note: For the best visual experience, use a terminal that supports ANSI escape codes (Windows Terminal, PowerShell Core, or iTerm2).*

## ⚠️ Maintenance Status
**This project is ARCHIVED.** It was created as a specific coding challenge and is provided as-is for educational purposes. Pull requests and issues are not monitored.

## 📄 License
Distributed under the MIT License.