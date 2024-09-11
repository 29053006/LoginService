namespace LoginService.Constants
{
    public class ConstantsQuery
    {
        public static readonly string VERIFY_USER = @"SELECT * FROM Users WHERE UserName = @UserName";
        public static readonly string AUTHENTICATION_USER = @"SELECT * FROM Users WHERE UserName = @UserName";
        public static readonly string CREATE_USER = @"INSERT INTO Users( UserId, UserName, Password, RolId , Email, PhoneNumber,TwoStepVerification,ExpiratePassword) 
                                                      VALUES(NEWID(),@UserName,@Password,'8BA0FAD2-23B6-4224-A94F-A396B0E6CAF0', @Email, @PhoneNumber,@TwoStepVerification,@ExpiratePassword)";
        public static readonly string RESET_PASSWORD = @"UPDATE Users SET Password = @NewPassword WHERE UserName = @UserName";
    }
}
