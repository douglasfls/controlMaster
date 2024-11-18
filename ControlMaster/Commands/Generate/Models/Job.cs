namespace ControlMaster.Commands.Generate.Models;

public class Job
{
    public string Name {
        get;
        set;
    }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Command { get; set; }
    public string OnSuccess { get; set; }
    public string OnFailure { get; set; }
    public string OnCompletion { get; set; }
    public Notification[] Notification { get; set; }
}