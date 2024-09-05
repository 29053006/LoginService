using Dapper;
using LoginService.Connection;
using LoginService.Models;
using System.Data;

namespace LoginService.Repositories
{
    public class Repositories(DapperContext _dapperContext) : IRepositories
    {
        public UserResponse Authentication(LoginDataModel login)
        {
            var query = @"SELECT * FROM Users WHERE Username =@UserName";

            using (var connection = _dapperContext.CreateConection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", login.userName);
                parameters.Add("@Password", login.password);
                var resultData = connection.Query<UserResponse>(sql: query, param: parameters, commandType: CommandType.Text, buffered: false);

                return resultData.FirstOrDefault();
            }
        }
        public bool CreateUser(LoginDataModel login)
        {
            var query = @$"INSERT INTO User(id,userName,password,rol)VALUES(NEWID(),'{login.userName}','{login.password}','{login.rol}')";

            using (var connection = _dapperContext.CreateConection())
            {
                var resultData = connection.Query<LoginResultData>(sql: query, commandType: CommandType.Text, buffered: false);

                return resultData != null ? true : false;
            }
        }
        public bool ResetPassword(string UserName, string NewPassword)
        {
            var query = @$"UPDATE Users SET Password = @NewPassword WHERE UserName = @UserName";

            using (var connection = _dapperContext.CreateConection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName);
                parameters.Add("@NewPassword", NewPassword);
                var resultData = connection.Query<LoginResultData>(sql: query, param: parameters, commandType: CommandType.Text, buffered: false);

                return resultData != null ? true : false;
            }
        }
    }
}
