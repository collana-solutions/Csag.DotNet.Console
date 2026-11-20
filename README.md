# Csag.DotNet.Console

[![Build Status](https://github.com/collana-solutions/Csag.DotNet.Console/actions/workflows/ci.yml/badge.svg)](https://github.com/collana-solutions/Csag.DotNet.Console/actions)
[![NuGet](https://img.shields.io/nuget/v/Csag.DotNet.Console.svg)](https://www.nuget.org/packages/Csag.DotNet.Console)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)

A library for building .NET console applications on the Microsoft.Extensions.Hosting model: async commands with cancellation, dependency injection like in ASP.NET Core, command-line parsing with verbs, NLog logging, and configuration from appsettings.json, environment variables, user secrets and the command line.

Up to version 5.0.1 the package was published as `Neolution.DotNet.Console`. The [migration guide](./Csag.DotNet.Console/README.md#migrate-from-neolutiondotnetconsole-to-csagdotnetconsole) lists the steps to switch.

## Projects

| Project | Description |
|---|---|
| [`Csag.DotNet.Console`](./Csag.DotNet.Console) | The library, published as the [Csag.DotNet.Console](https://www.nuget.org/packages/Csag.DotNet.Console) NuGet package for `net6.0` and `net8.0`. Its [README](./Csag.DotNet.Console/README.md) is the package documentation, and its [CHANGELOG](./Csag.DotNet.Console/CHANGELOG.md) is generated from changesets. |
| [`Csag.DotNet.Console.Demo`](./Csag.DotNet.Console.Demo) | A console application that shows the setup with a `Startup` class, a few commands and the NLog configuration. |
| [`Csag.DotNet.Console.UnitTests`](./Csag.DotNet.Console.UnitTests) | xunit tests for the library. |

## Installation

```shell
dotnet add package Csag.DotNet.Console
```

The [package README](./Csag.DotNet.Console/README.md) explains how to set up `Program.cs`, define commands and validate the service registrations with `check-deps`.

## Preview packages

Each pull request to `main` or to a `release/**` branch publishes the package to a public preview feed on feedz.io. A draft PR, a PR from a fork and a PR from Dependabot publish no preview. The version is one patch above the current release, for example `6.0.1-pr.42.183` (PR 42, workflow run 183). The **"chore: version packages"** PR publishes a release candidate of the upcoming version, for example `6.1.0-pr.73.190`. Thus you can test all the changes of the next release before the release. In prerelease mode the version in `package.json` is a prerelease such as `7.0.0-rc.0`. Then the preview extends it, for example `7.0.0-rc.0.pr.42.183`. That version sorts after the prerelease and before the next one. A comment on the PR gives the version of its latest push. The feed removes previews after 30 days. Releases go to nuget.org only.

To use a preview in an application, add the feed to the `nuget.config` of the application. The feed needs no credentials:

```xml
<packageSources>
  <clear />
  <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  <add key="csag-dotnet-console-previews" value="https://f.feedz.io/collana-solutions/csag-dotnet-console/nuget/index.json" />
</packageSources>
<packageSourceMapping>
  <packageSource key="nuget.org">
    <package pattern="*" />
    <package pattern="Csag.DotNet.Console" />
  </packageSource>
  <packageSource key="csag-dotnet-console-previews">
    <package pattern="Csag.DotNet.Console" />
  </packageSource>
</packageSourceMapping>
```

The `Csag.DotNet.Console` pattern is also necessary under nuget.org. NuGet looks for a package only in the sources of its most specific pattern, so the `*` pattern does not apply to `Csag.DotNet.Console`. If nuget.org does not have the `Csag.DotNet.Console` pattern, the released versions do not restore.

To test a preview:

1. Set `Csag.DotNet.Console` to the preview version.
2. If the application restores in locked mode, update its `packages.lock.json` files.
3. Add the feed only on the branch that tests the preview. The main branch of the application then does not need feedz.io to restore.

## Release process

This repository follows the [collana-solutions release playbook](https://github.com/collana-solutions/release-playbook) (Changesets, NuGet variant):

1. Every PR that changes the library needs a changeset: run `pnpm changeset`, choose the bump type and describe the change. CI blocks PRs without one (`pnpm changeset --empty` for changes that do not affect the package).
2. On merge to `main`, the Release workflow maintains a **"chore: version packages"** PR that collects the pending changesets. `scripts/sync-versions.mjs` keeps the `<Version>` in the `.csproj` in step with `package.json`.
3. Merging that PR creates the git tag and the GitHub Release. The **NuGet Publish** workflow then packs the package and pushes it to nuget.org through [trusted publishing](https://learn.microsoft.com/nuget/nuget-org/trusted-publishing), so no API key is stored in the repository. To publish an existing release again, for example after a failed push, run **NuGet Publish** from the Actions tab with the release tag.

Dependabot PRs get their changesets generated automatically.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.
