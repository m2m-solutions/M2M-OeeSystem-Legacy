using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace M2M.DataCenter.AdminTool
{
    public class SuperUser
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public bool Load()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.M2M_DataCenterConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Parameters.AddWithValue("@Role", "SuperUser");
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT " +
                                        "u.UserId," +
                                        "u.Password" +
                                        " FROM Users u JOIN UserRoles ur " +
                                        " ON u.UserId=ur.UserId " +
                                        " WHERE ur.Role=@Role";

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            UserId = dataReader["UserId"].ToString();
                            Password = dataReader["Password"].ToString();

                            if (Password.Length == 48)
                            {
                                SimpleAES aes = new SimpleAES();
                                Password = aes.DecryptString(Password);
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void Remove()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.M2M_DataCenterConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@Role", "SuperUser");
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM UserRoles WHERE UserId=@UserId;" +
                                          "DELETE FROM UserModules WHERE UserId=@UserId;" +
                                          "DELETE FROM UserSettings WHERE UserId=@UserId;" +
                                          "DELETE FROM UserDivisions WHERE UserId=@UserId;" +
                                          "DELETE FROM Roles WHERE Role=@Role;" +
                                          "DELETE FROM Users WHERE UserId=@UserId;";

                    command.ExecuteNonQuery();

                    UserId = "";
                    Password = "";
                }
            }
        }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.M2M_DataCenterConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SimpleAES aes = new SimpleAES();
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@Password", aes.EncryptToString(Password));
                    command.Parameters.AddWithValue("@UserRoleId", Guid.NewGuid());
                    command.Parameters.AddWithValue("@Role", "SuperUser");

                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Users (UserId,DisplayName,Password) VALUES (@UserId,@Role,@Password);" +
                                          "INSERT INTO Roles (Role,DisplayName) VALUES (@Role,@Role);" +
                                          "INSERT INTO UserRoles (UserRoleId,UserId,Role) VALUES (@UserRoleId,@UserId,@Role)";

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
