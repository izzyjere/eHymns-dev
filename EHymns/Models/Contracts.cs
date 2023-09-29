namespace EHymns.Models;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
public abstract class Entity<TKey> : IEntity<TKey>
{
    public virtual TKey Id { get; set; }
}
