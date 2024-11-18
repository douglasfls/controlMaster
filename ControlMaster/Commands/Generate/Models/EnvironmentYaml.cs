namespace ControlMaster.Commands.Generate.Models;

public class EnvironmentYaml
{
    public long Version { get; set; }
    public Dictionary<string, object> Variables { get; set; }
}