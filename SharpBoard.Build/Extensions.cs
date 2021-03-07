using Nuke.Common.Git;
using Nuke.Common.Utilities;

static class Extensions
{
    public static bool IsOnMainBranch(this GitRepository repository) => repository.Branch?.EqualsOrdinalIgnoreCase("main") ?? false;
    public static bool ShouldPushTag(this GitRepository repository) => repository.IsOnMainBranch() || repository.IsOnDevelopBranch();
}
