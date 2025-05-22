# MW3 RTE Tool by Mx444

This repository contains a C# Windows Forms application designed for Real-Time Editing (RTE) of the game Call of Duty: Modern Warfare 3 on PlayStation 3 consoles. It allows users to interact with the game's memory and features.

## Repository Structure

The core application files are located within the `Mw3 RTE Tool by Mx444/` directory. Key directories and files include:

-   **Mw3 RTE Tool by Mx444/**: Main application directory
    -   **Classes/**: Contains C# classes for various game elements and functionalities.
        -   `Buttons.cs`: Likely related to in-game button interactions or UI elements.
        -   `EndianType.cs`: Handles endianness conversions for memory reading/writing.
        -   `Hud.cs`: Functionality related to the in-game Heads-Up Display.
        -   `Offsets.cs`: Contains memory addresses (offsets) for game data.
        -   `RPC MW3.cs`: Remote Procedure Call functions specific to MW3.
        -   `TicTac.cs`: Possibly related to a specific game mode or feature.
        -   `Weapons.cs`: Contains data or functions related to in-game weapons.
    -   **Turret/**: Contains classes for interacting with turrets or similar game objects.
        -   `Offsets.cs`: Memory offsets specific to turret functionality.
        -   `PS3.cs`: Core class for connecting and interacting with the PS3 console via TMAPI/CCAPI.
        -   `PS3TMAPI.cs`: Wrapper for the PS3TMAPI library.
        -   `RPC.cs`: Generic RPC functions.
        -   `Spawn_Turret.cs`: Functionality for spawning turrets.
    -   **Form1.cs**: The main application form.
    -   **Painter.cs**: Functionality related to drawing or visual effects in-game.
    -   **Program.cs**: Application entry point.
    -   **Properties/**: Project properties and resources.
    -   **bin/**: Compiled executable and dependencies.
    -   **obj/**: Intermediate build files.
-   `Mw3 RTE Tool by Mx444.csproj`: The C# project file.
-   `Mw3 RTE Tool by Mx444.sln`: The Visual Studio solution file.

## Features

Based on the file names, the tool likely includes features such as:

-   Connecting to a PS3 console.
-   Attaching to the MW3 game process.
-   Reading and writing game memory.
-   Interacting with in-game elements like HUD, Weapons, and Turrets.
-   Executing Remote Procedure Calls (RPCs) within the game.
-   Visual effects or "painting" in-game.

## How to Use

1.  **Prerequisites**: Ensure you have a compatible PS3 console with TMAPI or CCAPI installed and configured. You will also need Visual Studio to build and run the project.
2.  **Connect to PS3**: Use the connection features within the tool (likely on `Form1`) to connect to your PS3.
3.  **Attach to Game**: Attach the tool to the Modern Warfare 3 game process running on your PS3.
4.  **Utilize Features**: Explore the different sections and buttons in the application's user interface to access the various RTE features (e.g., modifying weapons, spawning turrets, changing HUD elements).

## Technical Implementation

The application is built using:

-   C# programming language
-   Windows Forms for the user interface
-   PS3Lib and ps3tmapi_net libraries for communication with the PS3 console.

## Requirements

-   Windows Operating System
-   .NET Framework (version 4.5 or higher, based on project file)
-   Visual Studio (version 2013 or higher, based on solution file)
-   A PlayStation 3 console with TMAPI or CCAPI installed
-   Call of Duty: Modern Warfare 3 running on the PS3

## Getting Started

1.  Clone this repository to your local machine.
2.  Open the solution file (`Mw3 RTE Tool by Mx444.sln`) in Visual Studio.
3.  Restore any missing NuGet packages or references if prompted. The project references `PS3Lib.dll`, `ps3tmapi_net.dll`, `DevComponents.DotNetBar2.dll`, and `MetroFramework.dll`. You may need to locate these libraries and add them as references if they are not found automatically.
4.  Build the solution.
5.  Run the application from Visual Studio or the compiled executable in the `bin/Debug` or `bin/Release` folder.
6.  Follow the "How to Use" steps to connect to your PS3 and start using the tool.

---

*Disclaimer: This tool interacts with game memory and is intended for educational or personal use only. Use at your own risk. The author is not responsible for any consequences resulting from its use.*