using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class UpdateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualizar Tag");
        Console.Write("Id: ");
        var id = Console.ReadLine();
        Console.Write("Nome: ");
        var name = Console.ReadLine();
        Console.Write("Slug: ");
        var slug = Console.ReadLine();
        Update(new Tag
        {
            Id = Convert.ToInt32(id),
            Name = name ?? string.Empty,
            Slug = slug ?? string.Empty
        });
    }

    private static void Update(Tag tag)
    {
        var repository = new Repository<Tag>();

        try
        {
            repository.Update(tag);
            Console.WriteLine("Tag atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a Tag");
            Console.WriteLine(ex.Message);
        }
    }
}