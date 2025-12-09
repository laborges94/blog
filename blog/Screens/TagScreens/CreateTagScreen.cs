using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class CreateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Criar Tag");
        Console.Write("Nome: ");
        var name = Console.ReadLine();
        Console.Write("Slug: ");
        var slug = Console.ReadLine();
        Create(new Tag
        {
            Name = name ?? string.Empty,
            Slug = slug ?? string.Empty
        });
    }

    private static void Create(Tag tag)
    {
        var repository = new Repository<Tag>();

        try
        {
            repository.Insert(tag);
            Console.WriteLine("Tag criada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível criar a Tag");
            Console.WriteLine(ex.Message);
        }
    }
}