namespace Core.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

public class Entity
{
    public int Id { get; set; }



    public Entity()
    {
    }

    public Entity(int id) : this()
    {
        Id = id;
    }
}