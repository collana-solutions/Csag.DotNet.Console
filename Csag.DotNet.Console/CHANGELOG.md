# @collana-solutions/csag-dotnet-console

## 6.0.0

### Major Changes

- [#27](https://github.com/collana-solutions/Csag.DotNet.Console/pull/27) [`6be6297`](https://github.com/collana-solutions/Csag.DotNet.Console/commit/6be629730224468c0d597dcd9b265206aa147528) Thanks [@neotrow](https://github.com/neotrow)! - The package moves to a new ID and new namespaces. Apart from that, 6.0.0 brings the changes listed in the other entries of this release, which were not part of 5.0.1.
  
  **New package ID:**
  
  | Up to 5.0.1 | From 6.0.0 |
  | --- | --- |
  | `Neolution.DotNet.Console` | `Csag.DotNet.Console` |
  
  **To migrate:**
  
  1. Replace the `Neolution.DotNet.Console` package reference with `Csag.DotNet.Console`, at 6.0.0 or later.
  2. Change the namespaces: `using Neolution.DotNet.Console;` becomes `using Csag.DotNet.Console;`, and the same for `.Abstractions`, `.Attributes` and `.Logging`.
  3. In the NLog configuration, load the extensions from the new assembly name. The assembly is now `Csag.DotNet.Console`, so NLog cannot load `Neolution.DotNet.Console` any more: with `throwConfigExceptions` the logger setup fails, and without it `${NLNHelperLogLevel}` renders nothing.
  
     ```json
     "NLog": {
       "extensions": [
         { "assembly": "Csag.DotNet.Console" }
       ]
     }
     ```
  
  These names stay as they are, so the rest of an existing configuration keeps working: the `${NLNHelperLogLevel}` layout renderer, the `NLog` configuration section, the `DOTNET_` prefix for environment variables, the `check-deps` verb and the type names such as `DotNetConsole`, `DotNetConsoleLogger` and `IDotNetConsoleCommand<TOptions>`.
  
  The `Neolution.DotNet.Console` ID gets deprecated on nuget.org, with `Csag.DotNet.Console` as the alternate. Its existing versions stay available, but it gets no new releases.

- [#25](https://github.com/collana-solutions/Csag.DotNet.Console/pull/25) [`a2a6317`](https://github.com/collana-solutions/Csag.DotNet.Console/commit/a2a6317e10f66989bb61d866a932bef00a5bf1d2) Thanks [@neoscie](https://github.com/neoscie)! - `DotNetConsoleException` no longer has the `[Serializable]` attribute and the protected serialization constructor. Formatter-based serialization is obsolete in .NET (`SYSLIB0051`). Only a subclass that calls that constructor, or code that serializes the exception with `BinaryFormatter`, has to change.

### Minor Changes

- [#25](https://github.com/collana-solutions/Csag.DotNet.Console/pull/25) [`a2a6317`](https://github.com/collana-solutions/Csag.DotNet.Console/commit/a2a6317e10f66989bb61d866a932bef00a5bf1d2) Thanks [@neoscie](https://github.com/neoscie)! - New static class `DotNetConsoleLogger` for the application's own logger. `Initialize(IConfiguration)` loads NLog from the `NLog` configuration section and falls back to a plain console logger if that fails, `Log` returns the logger, and `Shutdown()` flushes it before the application exits. The README shows it in `Program.cs`. `DotNetConsole` writes its "Operation was canceled by the user." message through this logger, so the message only appears after `Initialize` has been called.

### Patch Changes

- [#25](https://github.com/collana-solutions/Csag.DotNet.Console/pull/25) [`a2a6317`](https://github.com/collana-solutions/Csag.DotNet.Console/commit/a2a6317e10f66989bb61d866a932bef00a5bf1d2) Thanks [@neoscie](https://github.com/neoscie)! - Scrutor 6.1.0 (5.0.1 used 6.0.1). The minimum versions of the other dependencies stay as in 5.0.1.

## [5.0.1] - 2026-03-25

### Added

- `ConfigureAppConfiguration` method to `DotNetConsoleBuilder` (re-)enabling custom configuration providers
- `CustomArgumentParsingAttribute` to allow verbs to accept unknown arguments for manual parsing

### Fixed

- Fixed configuration provider timing: `DotNetConsole.Configuration` now properly reflects all configuration providers (including those added via `ConfigureAppConfiguration`) when accessed early in the application lifecycle.

## [5.0.0] - 2025-01-27

### Added

- Added cancellation token support for commands
- Added a built-in `check-deps` command that validates the application's Dependency Injection setup by ensuring all required services are fully and correctly registered in the composition root.

### Changed

- Updated Scrutor to v6.0.1
- Updated NLog.Extensions.Logging to v5.3.15
- Updated Microsoft.Extensions.Configuration.Json to v8.0.1
- Updated Microsoft.Extensions.Configuration.UserSecrets to v8.0.1
- Updated Microsoft.Extensions.DependencyInjection to v8.0.1
- Updated Microsoft.Extensions.Hosting to v8.0.1
- Updated Microsoft.Extensions.Logging to v8.0.1
- Updated Microsoft.Extensions.Logging.Configuration to v8.0.1

## [3.0.4] - 2024-11-28

### Fixed

- Resolved another case where appsettings.json was being loaded from the current working directory instead of the executable's directory.

## [3.0.3] - 2024-10-09

### Fixed

- Resolved an issue where appsettings.json was being loaded from the current working directory instead of the executable's directory.

## [3.0.2] - 2024-10-04

### Fixed

- If a default verb is defined, calls of the application that only use parameters should be allowed

### Changed

- Updated NLog.Extensions.Logging to v5.3.14

## [3.0.1] - 2024-10-02

### Fixed

- Bump version number to 3.0.1 to release the package to nuget.org

## [3.0.0] - 2024-09-30

### Changed

- Updated everything to .NET 8
- Enabled nullable reference types
- Changed app builder initialization code to resemble the current default ASP.NET Core hosting model
- If a default verb is defined, the verb passed by the user must strictly match one of the available verbs
- Updated NLog to v5.3.4
- Updated NLog.Extensions.Logging to v5.3.13

### Added

- Commands are now async by default, they must use the new `IDotNetConsoleCommand` interface instead of `IConsoleAppCommand` and `IAsyncConsoleAppCommand`.

### Removed

- Lots of classes that were originally copied from the ASP.NET Core hosting model source code and are now no longer needed
- Removed `IAsyncConsoleAppCommand` and `IConsoleAppCommand` in favor of the new `IDotNetConsoleCommand` interface

## [2.0.2] - 2024-06-06

### Fixed

- Added README.md file to the NuGet package

## [2.0.1] - 2024-06-06

### Changed

- Updated NLog to v5.3
- Updated Neolution.CodeAnalysis to v3.0.5

## [2.0.0] - 2024-02-07

### Fixed

- Create Console App Scope asynchronously
- Cleaned repository from now unused Azure DevOps files

### Added

- Async Console Application variant
- MIT licence expression for NuGet package

### Changed

- Updated NLog to V5
- Updated CommandLineParser to v2.9.1

### Removed

- Removed AWS NLog Logger assembly that was used for logging to Amazon CloudWatch

[3.0.1]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v3.0.0...v3.0.1
[3.0.0]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v2.0.2...v3.0.0
[2.0.2]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v2.0.1...v2.0.2
[2.0.1]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v2.0.0...v2.0.1
[2.0.0]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v1.1.0-beta1...v2.0.0
[3.0.4]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v3.0.3...v3.0.4
[3.0.3]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v3.0.2...v3.0.3
[3.0.2]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v3.0.2-rc.0...v3.0.2
[5.0.0]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v4.0.0...v5.0.0
[4.0.0]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v4.0.0-rc.0...v4.0.0
[5.0.1]: https://github.com/neolution-ch/Neolution.DotNet.Console/compare/v5.0.1-beta.2...v5.0.1
