using ControlMaster.Configuration;

namespace ControlMaster.Commands.Test;

[Verb("test", false, HelpText = "Test yaml file.")]
internal class TestCommand : ICommand
{
    [Option('f', "file", Required = true, HelpText = "Yaml file to test.")]
    public string File { get; set; } = string.Empty;
}

internal class TestCommandHandler : IRequestHandler<TestCommand>
{
    private readonly IFileProvider _fileProvider;

    public TestCommandHandler(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }
    
    public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
    {
        var file = await _fileProvider.ReadAllText(request.File, cancellationToken);
          
        return Unit.Value;
    }
}