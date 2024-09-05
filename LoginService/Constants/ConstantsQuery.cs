namespace LoginService.Constants
{
    public class ConstantsQuery
    {
        public static readonly string VERIFY_USER = @"SELECT * FROM Users WHERE UserName = @UserName";
        public static readonly string AUTHENTICATION_USER = @"SELECT * FROM Users WHERE UserName = @UserName";
        public static readonly string CREATE_USER = @"INSERT INTO Users( id, userName, password, rol , mail, phoneNumber) VALUES(NEWID(),'@UserName','@Password','@Rol', @Email, @PhoneNumber)";
        public static readonly string RESET_PASSWORD = @"UPDATE Users SET Password = @NewPassword WHERE UserName = @UserName";
    }
}
