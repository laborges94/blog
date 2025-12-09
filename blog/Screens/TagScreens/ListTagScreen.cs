using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class ListTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listar Tags");
        Console.WriteLine("============");
        List();
        Console.ReadKey();
    }

    private static void List()
    {
        var repository = new Repository<Tag>();
        var tags = repository.GetAll();
        foreach (var tag in tags)
            Console.WriteLine($"{tag.Id} - {tag.Name}");
    }
}