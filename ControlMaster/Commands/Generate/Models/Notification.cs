namespace ControlMaster.Commands.Generate.Models;

public class Notification
{
    public string Type { get; set; }
    public string Recipients { get; set; }
    public string Success { get; set; }
    public string Failure { get; set; }
    public string Completion { get; set; }
}