namespace KnockKnock.Interfaces
{
    public interface INumberSeries
    {
        bool Generate(long number, out long result);
    }
}