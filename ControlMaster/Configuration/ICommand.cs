namespace ControlMaster.Configuration;

public interface ICommand : IRequest
{ }

public interface ISubCommand : IRequest
{ }

public abstract class BaseCommand : ICommand
{
    public bool HasSubCommand()
    {
        return GetType().GetProperties()
            .Any(p => p.PropertyType.IsAssignableTo(typeof(ISubCommand)));
    }
    
    // public async Task ExecuteAsync(ISubCommand subCommand)
    // {
    //     await Parser.Default.ParseArguments(args, commands)
    //         .WithParsedAsync(p => mediator.Send(p));
    // }
}

public abstract class BaseSubCommand : ISubCommand
{ }
