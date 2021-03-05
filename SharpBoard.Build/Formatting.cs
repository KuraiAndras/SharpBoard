using Nuke.Common;
using Nuke.Common.Tooling;

// ReSharper disable InconsistentNaming

sealed partial class Build
{
    [PackageExecutable(
        "dotnet-format",
        "dotnet-format.dll")]
    readonly Tool DotnetFormat = default!;

    Target CheckFormat => _ => _
        .Executes(() => DotnetFormat("--check"));

    Target Format => _ => _
        .Executes(() => DotnetFormat());
}
