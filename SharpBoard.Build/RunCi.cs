using Colorful;
using Nuke.Common;
using Nuke.Common.Git;
using System.Drawing;
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

            if (!Repository.ShouldPushTag())
            {
                Console.WriteLine($"Tags are not pushed for this branch {Repository.Branch}", Color.Aqua);
                return;
            }

            Console.WriteLine(Repository.Branch, Color.Aqua);
            Git($"tag {version}");
            Git($"push origin {version}");
        });

    Target RunCi => _ => _
        .DependsOn(CheckFormat)
        .DependsOn(PushTag)
        .DependsOn(SonarEnd)
        .Executes(() => { });
}
