namespace LoginService.Services.Hash
{
    public interface IHashingServices
    {
        public string hashing(string str);
        public bool verifyHash(string hashedPassword, string providedPassword, DateTimeOffset ExpiratePassword);
    }
}
