---
"@collana-solutions/csag-dotnet-console": major
---

The package moves to a new ID and new namespaces. Apart from that, 6.0.0 brings the changes listed in the other entries of this release, which were not part of 5.0.1.

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
