namespace CookieCookbook.DataAccess.BaseRepository;

interface IBaseRepository
{
    public abstract List<string> Read(string filePath);
    public abstract void Write(string filePath, List<int> data);
}
