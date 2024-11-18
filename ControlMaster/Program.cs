using System.Reflection;
using ControlMaster.Configuration;
using Microsoft.Extensions.DependencyInjection;

var assembly = Assembly.GetExecutingAssembly();
var cancellation = new CancellationTokenSource();
Console.CancelKeyPress += (sender, eventArgs) => cancellation.Cancel();

var services = new ServiceCollection();
services.AddScoped<IFileProvider, FileProvider>();
services.AddMediatR(assembly);
var provider = services.BuildServiceProvider();
var mediator = provider.GetRequiredService<IMediator>();

var commands = assembly.GetTypes()
    .Where(p => p is { IsClass: true, IsAbstract: false } && p.IsAssignableTo(typeof(ICommand)))
    .OrderBy(p => p.Name)
    .ToArray();

Parser.Default.ParseArguments(args, commands)
    .WithParsed<ICommand>(p => mediator.Send(p))
    .WithParsed<ISubCommand>(p => mediator.Send(p));