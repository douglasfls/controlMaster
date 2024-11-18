using ControlMaster.Commands.Generate.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ControlMaster.Commands.Generate;

internal class GenerateCommand : IRequestHandler<GenerateOptions>
{
    private readonly IFileProvider _fileProvider;

    public GenerateCommand(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }

    public async Task<Unit> Handle(GenerateOptions request, CancellationToken cancellationToken)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();
        try
        {
            var x = await _fileProvider.ReadAllText("teste.yaml", cancellationToken);
            var y = await _fileProvider.ReadAllText("environment.yaml", cancellationToken);


            var x1 = deserializer.Deserialize<FileModel>(x);
            var y1 = deserializer.Deserialize<EnvironmentYaml>(y);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // await AnsiConsole.Progress()
        //     .StartAsync(async ctx =>
        //     {
        //         // Define tasks
        //         var task1 = ctx.AddTask("[green]Load environment[/]");
        //         var task2 = ctx.AddTask("[green]Load dependencies[/]");
        //         var task3 = ctx.AddTask("[green]Build files[/]");
        //         
        //         while (!ctx.IsFinished)
        //         {
        //             // Simulate some work
        //             await Task.Delay(250);
        //
        //             // Increment
        //             task1.Increment(1.5);
        //             task2.Increment(0.5);
        //         }
        //     });

        return Unit.Value;
    }
}