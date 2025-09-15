namespace BeauProject.Shared.Application.Interfaces
{
    public interface IEncrypter
    {
        string GetSalt();
        string GetHash(string value, string salt);
    }
}
