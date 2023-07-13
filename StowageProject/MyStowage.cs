using Stowage;
using System.IO;
using System.Text;

namespace MyStowageSolution;
public class MyStorage : IDisposable
{
    IFileStorage? fs;

    public void Dispose()
    {
        using (fs)
        {
            if (fs != null)
            {
                fs.Dispose();
            }
        }
        //fechar o 'fs' se ele estiver carregado
        //...
    }

    public async Task SaveAsync(string path, string folder)
    {
        using (fs = Files.Of.LocalDisk(folder))
        {
            // Converter a string em um array de bytes usando a codificação UTF-8
            byte[] bytes = Encoding.UTF8.GetBytes(path);

            // Criar um MemoryStream com os bytes
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                //converter o path para stream
                //...

                //chamar o Save 
                //..
                await SaveAsync(stream);
            }

        }
    }

    public async Task SaveAsync(Stream stream)
    {
        using (fs)
        {
            //salvar o stream no Stowage
            //..
            await stream.FlushAsync();
        }
    }

    public async Task<Stream> OpenAsync(string path, string folder)
    {
        using (fs = Files.Of.LocalDisk(folder))
        {
            var stream = await fs.OpenRead(path);
            //await SaveAsync(stream);

            return stream;
        }
        //recuperar o Stream a partir do Stowage
        //..
    }

    public async Task<Stream> WriteAsync(string folder, string path, string text)
    {
        using (fs = Files.Of.LocalDisk(folder))
        {
            if (!await fs.Exists(path))
            {
                using (var stream = await fs.OpenWrite(path))
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        sw.Write(text);
                        return stream;
                    }
                }
            }
            else
            {
                throw new Exception("Arquivo já existente");
            }
        }
    }

    public async Task DeleteAsync(string path)
    {
        //Deletar arquivo
        using (fs = Files.Of.LocalDisk(path))
        {
            if (await fs.Exists(path))
            {
                await fs.Rm(path);
            }
            else
            {
                throw new Exception("Arquivo não existente");
            }
            //excluir o arquivo a partir do Stowage
            //..
        }
    }

    public async Task CopyAsync(string folder, string source, string destination)
    {
        //OpenRead do Stowage
        //...
        using (fs = Files.Of.LocalDisk(folder))
        {
            using (var stream = await OpenAsync(source, folder))
            {
                //copy (cópia não exclui o arquivo origem!)
                //..
                using (var copy = await fs.OpenWrite(destination))
                {
                    stream.CopyTo(copy);
                    await SaveAsync(copy);
                }
            }
        }
        //obs: ver exemplo do console
    }

    public async Task UpdateAsync(string path, string text)
    {
        using (fs = Files.Of.LocalDisk(@"D:\wetok\Stowage"))
        {
            using (var stream = await fs.OpenWrite(path))
            {
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(text);
                    await SaveAsync(stream);
                }
            }
        }
    }

    public async Task ListAsync(string folder)
    {
        using (fs = Files.Of.LocalDisk(folder))
        {
            IReadOnlyCollection<IOEntry> fileList = await fs.Ls();
            IEnumerable<string> fileName = fileList.Select(x => x.Name);

            if (fileName.Count() != 0)
            {
                foreach (string file in fileName)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                throw new Exception("Essa pasta não possui arquivos!");
            }
        }
        //excluir o arquivo a partir do Stowage
    }

}