namespace CookieCookbook.DataAccess.BaseRepository;

interface IBaseRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<int> data);
}
