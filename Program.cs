using AFSLib;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("PAFS: Patch AFS");
        Console.WriteLine("Usage: PAFS <filenames of AFS>");
        Console.WriteLine("Example: \"PAFS PJS.AFS\" would use PJS.AFS and check \"PJS\" directory for file replacement names, resulting in PATCHED_PJS.AFS output file");

        if (args.Count() < 2 || args.Count() > 2)
        {
            Console.WriteLine("Invalid arguments");
        }
        foreach (var arg in args)
        {
            //var file = Path.GetFullPath(arg);
        }
    }
}