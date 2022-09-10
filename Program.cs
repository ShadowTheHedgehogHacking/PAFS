using AFSLib;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("PAFS: Patch AFS - github.com/shadowthehedgehoghacking");
        Console.WriteLine("Usage: PAFS <filenames of AFS>");
        Console.WriteLine("Example: \"PAFS PJS.afs\" would use PJS.afs and check \"PJS\" directory for file replacement names, resulting in PJS_PATCHED.afs output file");

        if (args.Count() < 1 || args.Count() > 1)
        {
            Console.WriteLine("Invalid arguments");
        }
        foreach (var arg in args)
        {
            var file = Path.GetFullPath(arg);
            var data = File.ReadAllBytes(file);
            AfsArchive target;
            if (AfsArchive.TryFromFile(data, out var afsArchive))
            {
                target = afsArchive;
            } else
            {
                Console.WriteLine(arg.ToString() + " AFS file not found or issue detected.");
                continue;
            };

            var folder = file.Substring(0, file.Length - 4);
            if (!Directory.Exists(folder))
            {
                Console.WriteLine("Directory with replacements not found for " + arg.ToString());
                continue;
            }

            string[] replacementFiles = Directory.GetFiles(folder, "*.adx", SearchOption.TopDirectoryOnly);

            foreach (var replacement in replacementFiles) {
                var fileName = replacement.Substring(folder.Length + 1);
                var fileToPatch = target.Files.FindIndex(x => x.Name == fileName);
                target.Files[fileToPatch].Data = File.ReadAllBytes(replacement);
            }

            try
            {
                File.WriteAllBytes(folder + "_PATCHED.afs", target.ToBytes());
            } catch (IOException e){
                Console.WriteLine("Failed to write patched file, stacktrace below for " + folder + "_PATCHED.afs");
                Console.WriteLine(e);
            }
        }
        Console.WriteLine("All done!");
    }
}