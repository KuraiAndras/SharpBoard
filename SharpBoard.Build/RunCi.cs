using Nuke.Common;
using static Nuke.Common.Tools.Git.GitTasks;

sealed partial class Build
{
    Target PushTag => _ => _
        .DependsOn(Test)
        .Executes(() =>
        {
            var version = GitVersion.NuGetVersionV2;

            Git($"tag {version}");
            Git($"push origin {version}");
        });

    Target RunCi => _ => _
        .DependsOn(CheckFormat)
        .DependsOn(PushTag)
        .DependsOn(SonarEnd)
        .Executes(() => { });
}
