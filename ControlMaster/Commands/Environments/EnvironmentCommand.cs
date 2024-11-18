using ControlMaster.Configuration;

namespace ControlMaster.Commands.Test;

[Verb("environments", false, HelpText = "List environment files.")]
internal class EnvironmentCommand : ICommand
{
    [Verb("add", false)]

    public class AddCommand : ISubCommand
    {
        [Option("name", Required = true)]
        public string Name { get; set; }

        [Option("value", Required = true)]
        public string Value { get; set; }
    }
}

internal class EnvironmentCommandHandler : IRequestHandler<EnvironmentCommand>
{
    public async Task<Unit> Handle(EnvironmentCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("some value");

        return Unit.Value;
    }
}