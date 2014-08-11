namespace SampleApp.Infrastructure
{
    public interface IEntityKey<TKey>
    {
        TKey Id { get; }
    }
}
