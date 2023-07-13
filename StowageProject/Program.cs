using MyStowageSolution;
using Stowage;

namespace StowageProject;

internal class Program
{
    public static async Task Main(string[] args)
    {
        string path = @"D:\wetok\Stowage\README.txt";
        string pathCopy = @"D:\wetok\Stowage\Transfer\READMETESTE.txt";
        
        string folder = @"D:\wetok\Stowage";
        string folder2 = @"D:\wetok\Stowage\Transfer";

        string text = "Conteúdo";
        string text2 = "Novo Conteúdo";



        MyStorage myStorage = new MyStorage();

        await myStorage.OpenAsync(path, folder);
        
        await myStorage.WriteAsync(folder, path, text);

        myStorage.Dispose();

        await myStorage.UpdateAsync(path, text2);

        await myStorage.CopyAsync(folder, path, pathCopy);

        await myStorage.SaveAsync(@"D:\wetok\Stowage\README.txt", @"D:\wetok\Stowage\Transfer");

        await myStorage.ListAsync(folder);

        using (IFileStorage fs = Files.Of.LocalDisk(@"D:\wetok\Stowage"))
        {

            await myStorage.DeleteAsync(pathCopy);

        }
        
    }

}