namespace ControlMaster.Commands.Generate.Models;

public class FileModel
{
    public long Version { get; set; }
    public string[] Imports { get; set; }
    public Job[] Jobs { get; set; }
}