---
"@collana-solutions/csag-dotnet-console": minor
---

pr: 25

New static class `DotNetConsoleLogger` for the application's own logger. `Initialize(IConfiguration)` loads NLog from the `NLog` configuration section and falls back to a plain console logger if that fails, `Log` returns the logger, and `Shutdown()` flushes it before the application exits. The README shows it in `Program.cs`. `DotNetConsole` writes its "Operation was canceled by the user." message through this logger, so the message only appears after `Initialize` has been called.
