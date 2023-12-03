namespace CookieCookbook.DataAccess.BaseRepository;

abstract class BaseRepository
{
    protected readonly string _separator = Environment.NewLine;
    public abstract List<string> Read(string filePath);
    public abstract void Write(string filePath, List<int> data);
}
