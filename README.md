# NCShop - Stock Management System

A robust C# Console Application designed to manage shop inventory. This project demonstrates the transition from basic scripting to a structured, multi-layered architecture.

## 🛠 Project Architecture
The solution follows the **Separation of Concerns** principle by splitting logic into distinct projects:
- **NCShop.UI**: Handles all user interactions and console formatting.
- **NCShop.Business**: Contains the `ShopLogic` class to manage the internal state of the stock.

---

## 🧠 Logic & Design Decisions

### 1. The Persistent User Loop (`while`)
**The Challenge:** A standard console app runs once and closes. 
**The Solution:** I wrapped the menu in a `while (showChoices)` loop. This transforms the script into a persistent application that stays open until the user explicitly selects the "Exit" option. This mimics the behaviour of real-world enterprise software.

### 2. State Management & UX (`Console.Clear`)
**The Decision:** At the start of every loop iteration, I call `Console.Clear()`.
**The Why:** This provides a "Single Page Application" feel within the terminal. Without this, the console would become a cluttered wall of text. Clearing the screen ensures the user is always focused on the current menu and fresh options.

### 3. Timing & Flow Control (`Thread.Sleep`)
**The Decision:** I implemented `Thread.Sleep(2000)` followed by a `Console.ReadLine()` pause.
**The Why:** - **Readability:** If the screen clears instantly after adding a product, the user never sees the "Success" message.
- **Feedback Loop:** The 2-second sleep gives the user enough time to register the action's result.
- **User Agency:** The "Press Enter to return to menu" prompt ensures the app only refreshes when the user is ready, preventing the UI from jumping around unexpectedly.

### 4. Guard Clauses & Validation
Instead of simply iterating through a list, I implemented checks to handle edge cases:
- **Empty State:** Before the `foreach` loop runs in the "View Stock" section, I check if `Count == 0`. This prevents a "silent failure" where the user sees nothing and assumes the app is broken.
- **Default Switch Case:** This handles "fat-finger" errors where the user types an invalid character, ensuring the app handles the error gracefully rather than crashing.

---

## 🚀 How to Run
1. Open `NCShop.sln` in Visual Studio 2026.
2. Set `NCShop.UI` as the Startup Project.
3. Run using PowerShell or the VS Debugger.