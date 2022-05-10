﻿
using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var githubPipeLine = new GithubPipeline
{
    Name = "TSwim Build",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Jobs()
    {
        Build = new BuildJob()
        {
            RunsOn = BuildMachines.Windows2022,
            
            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Checking out Code"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Installing .Net",

                    TargetDotNetVersion = new TargetDotNetVersion()
                    {
                        DotNetVersion = "6.0.300"
                    }
                },

                new RestoreTask
                {
                    Name = "Restoring Packages",
                },

                new DotNetBuildTask
                {
                    Name= "Building Project(s)"
                },

                new TestTask
                {
                    Name = "Running Test(s)"
                }
            }
        }
    }
};

var adotNetClient = new ADotNetClient();
adotNetClient.SerializeAndWriteToFile(
    githubPipeLine,
    path: "../../../../.github/workflows/dotnet.yml");
