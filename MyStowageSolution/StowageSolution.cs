namespace MyStowageSolution;

public class MyStorage : IDisposable
{
    public MyStorage()
    {

    }
    //string folder = @"D:\wetok\Projetos\Stowage2022\Stowage";
    //IFileStorage fs = Files.Of.LocalDisk ;

    public void Dispose()
    {
        //fechar o 'fs' se ele estiver carregado
        //...
    }

    public async Task SaveAsync(string path)
    {
        //converter o path para stream
        //...

        //chamar o Save 
        //..
    }

    public async Task SaveAsync(Stream stream)
    {
        //salvar o stream no Stowage
        //..
    }

    //public async Task<Stream> OpenAsync(string path)
    //{
    //    //recuperar o Stream a partir do Stowage
    //    //..
    //}

    public async Task DeleteAsync(string path)
    {
        //excluir o arquivo a partir do Stowage
        //..
    }

    public async Task CopyAsync(string source, string destination)
    {
        //OpenRead do Stowage
        //...

        //copy (cópia não exclui o arquivo origem!)
        //..

        //obs: ver exemplo do console
    }

}