var projectPath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
Console.WriteLine(projectPath);

var demoFilesPath = $"{projectPath}/demoFiles";

Console.WriteLine("_Dirs_");

var dirs = Directory.GetDirectories(demoFilesPath, "*", SearchOption.AllDirectories);
foreach (var dir in dirs)
    Console.WriteLine($"=>{dir}");

FileReading(demoFilesPath);

DirectoryOperations(demoFilesPath);

CopyingFiles(demoFilesPath);

var javaFiles = Directory.GetFiles(demoFilesPath, "*.java", SearchOption.AllDirectories);

foreach (var f in javaFiles)
{
    Console.WriteLine(f);
    File.Delete(f);
}

void FileReading(string path)
{
    Console.WriteLine("_Files_");

    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
    foreach (var f in files)
    {
        Console.WriteLine($"path => {f}");
        Console.WriteLine($"file name => {Path.GetFileName(f)}");
        Console.WriteLine($"file name wo extension => {Path.GetFileNameWithoutExtension(f)}");
        Console.WriteLine($"directory name => {Path.GetDirectoryName(f)}");
        var info = new FileInfo(f);
        Console.WriteLine($"bytes: {info.Length} created: {info.CreationTime}");
    }
}

void DirectoryOperations(string path)
{
    Console.WriteLine(Directory.Exists(@$"{path}/notExistentFolder")); //false
    Console.WriteLine(Directory.Exists(@$"{path}/SUBFOLDERA")); // true

    Directory.Delete(@$"{path}/NewDir");
    if (Directory.Exists(@$"{path}/NewDir"))
        Console.WriteLine("already exists");
    else
        Console.WriteLine(Directory.CreateDirectory(@$"{path}/NewDir"));
}

void CopyingFiles(string path)
{
    var files = Directory.GetFiles(path);
    var destination = Directory.CreateDirectory($"{path}/NewDestination");

    foreach (var file in files)
    {
        File.Copy(file, $"{destination}/{Path.GetFileName(file)}", true);
        Console.WriteLine(file);
    }

    for (var i = 0; i < files.Length; i++)
        if (!File.Exists($"{destination}/{i}.db"))
            //throws exception when overwrite is false if file exists
            File.Copy(files[i], $"{destination}/{i}.db", false);

    // for (var i = 0; i < files.Length; i++)
    // {
    //     if (!(File.Exists($"{destination}/{i}.db")))
    //     {
    //         //throws exception when overwrite is false if file exists
    //         File.Move(files[i], $"{destination}/{i}.db", false);
    //     }
    // }
}
