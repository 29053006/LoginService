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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", login.userName);
                parameters.Add("@Password", login.password);
                var resultData = connection.Query<UserModel>(sql: query, param: parameters, commandType: CommandType.Text, buffered: false);

                return resultData.FirstOrDefault();
            }
        }
        public bool CreateUser(UserModel login)
        {
            var query = ConstantsQuery.CREATE_USER;

            using (var connection = _dapperContext.CreateConection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", login.UserName);
                parameters.Add("@Password", login.Password);
                parameters.Add("@Rol", login.RolId);
                parameters.Add("@Email", login.Email);
                parameters.Add("@PhoneNumber", login.PhoneNumber);
                var resultData = connection.Query<UserModel>(sql: query, param: parameters, commandType: CommandType.Text, buffered: false);

                return resultData != null ? true : false;
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
                var resultData = connection.Query<bool>(sql: query, param: parameters, commandType: CommandType.Text, buffered: false);

                return resultData != null ? true : false;
            }
        }
        public MailModel ValidateUser(string userName)
        {
            var query = ConstantsQuery.VERIFY_USER;

            using (var connection = _dapperContext.CreateConection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", userName);
                var resultData = connection.Query<MailModel>(sql: query, param: parameters, commandType: CommandType.Text, buffered: false);

                return resultData.FirstOrDefault();
            }
        }
    }
}
