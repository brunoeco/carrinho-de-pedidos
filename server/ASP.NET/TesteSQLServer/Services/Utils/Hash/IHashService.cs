namespace TesteSQLServer.Services.Utils.Hash
{
    public interface IHashService
    {
        public string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false);
        public bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck);
    }
}
