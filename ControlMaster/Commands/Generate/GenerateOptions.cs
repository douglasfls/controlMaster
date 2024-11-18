using ControlMaster.Configuration;

namespace ControlMaster.Commands.Generate;

[Verb("generate", HelpText = "Generate xml from yaml.")]
internal class GenerateOptions : ICommand
{
    [Option('a', "alpha", Required = true)]
    public string Option { get; set; }
}