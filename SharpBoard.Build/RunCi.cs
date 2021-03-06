using Colorful;
using Nuke.Common;
using Nuke.Common.Git;
using static Nuke.Common.Tools.Git.GitTasks;

// ReSharper disable InconsistentNaming

sealed partial class Build
{
    [GitRepository] readonly GitRepository Repository = default!;

    Target PushTag => _ => _
        .DependsOn(Test)
        .Executes(() =>
        {
            var version = GitVersion.NuGetVersionV2;

            if (Repository.IsOnFeatureBranch())
            {
                Console.WriteLine("Tags are not pushed for feature branches");
                return;
            }

            Git($"tag {version}");
            Git($"push origin {version}");
        });

    Target RunCi => _ => _
        .DependsOn(CheckFormat)
        .DependsOn(PushTag)
        .DependsOn(SonarEnd)
        .Executes(() => { });
}
