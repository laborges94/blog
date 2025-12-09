using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class DeleteTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Excluir Tag");
        Console.Write("Id: ");
        var id = Console.ReadLine();
        Delete(Convert.ToInt32(id));
    }

    private static void Delete(int id)
    {
        var repository = new Repository<Tag>();

        try
        {
            var tag = repository.GetById(id);
            if (tag == null)
            {
                Console.WriteLine("Tag não encontrada.");
                return;
            }

            repository.Delete(tag);
            Console.WriteLine("Tag excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir a Tag");
            Console.WriteLine(ex.Message);
        }
    }
}