using Dapper;
using LoginService.Constants;
using LoginService.Core.Conection;
using LoginService.Models;
using System.Data;

namespace LoginService.Repositories
{
    public class Repositories(DapperContext _dapperContext) : IRepositories
    {
        public UserModel Authentication(LoginDataModel login)
        {
            var query = ConstantsQuery.AUTHENTICATION_USER;

            using (var connection = _dapperContext.CreateConection())
            {
                var resultData = connection.Query<UserModel>(sql: query, param: login, commandType: CommandType.Text, buffered: false);

                return resultData.FirstOrDefault();
            }
        }
        public bool CreateUser(UserModel newUser)
        {
            var query = ConstantsQuery.CREATE_USER;

            using (var connection = _dapperContext.CreateConection())
            {
                var resultData = connection.Execute(sql: query, param: newUser, commandType: CommandType.Text);

                return resultData == 1 ? true : false;
            }
        }
        public bool ResetPassword(string UserName, string NewPassword)
        {
            var query = ConstantsQuery.RESET_PASSWORD;

            using (var connection = _dapperContext.CreateConection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName);
                parameters.Add("@NewPassword", NewPassword);
                var resultData = connection.Execute(sql: query, param: parameters, commandType: CommandType.Text);

                return resultData == 1 ? true : false;
            }
        }
        public UserModel ValidateUser(string userName)
        {
            var query = ConstantsQuery.VERIFY_USER;

            using (var connection = _dapperContext.CreateConection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", userName);
                var resultData = connection.Query<UserModel>(sql: query, param: parameters, commandType: CommandType.Text, buffered: false);

                return resultData.FirstOrDefault();
            }
        }
    }
}
