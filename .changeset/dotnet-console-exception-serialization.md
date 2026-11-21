---
"@collana-solutions/csag-dotnet-console": major
---

pr: 25

`DotNetConsoleException` no longer has the `[Serializable]` attribute and the protected serialization constructor. Formatter-based serialization is obsolete in .NET (`SYSLIB0051`). Only a subclass that calls that constructor, or code that serializes the exception with `BinaryFormatter`, has to change.
