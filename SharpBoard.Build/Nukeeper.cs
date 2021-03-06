using Nuke.Common;
using Nuke.Common.Tooling;

// ReSharper disable InconsistentNaming

sealed partial class Build
{
    [Parameter] readonly string NukeeperToken = string.Empty;

    [PackageExecutable(
        "nukeeper",
        "nukeeper.dll",
        Framework = "netcoreapp3.1")]
    readonly Tool Nukeeper = default!;

    Target UpdatePackages => _ => _
        .Requires(() => NukeeperToken)
        .Executes(() => Nukeeper(
            $"repo {Repository.HttpsUrl} {NukeeperToken} -a 0 --targetBranch develop --maxpackageupdates 100 --consolidate"));
}
