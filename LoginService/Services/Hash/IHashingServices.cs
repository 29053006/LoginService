namespace LoginService.Services.Hash
{
    public interface IHashingServices
    {
        public string hashing(string str);
        public bool verifyHash(string str);
    }
}
