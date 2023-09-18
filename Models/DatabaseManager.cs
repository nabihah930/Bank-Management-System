using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace k181297_k180326.Models
{
    public class DatabaseManager
    {
        public static string Connect()
        {
            string message = "Not Connected";
            string connectionStr = @"Data Source=DESKTOP-JHDR8CQ\SQLEXPRESS;Initial Catalog=finance_management;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    message = "Connected";
                    connection.Close();
                }
                catch (Exception err)
                {
                    message = "Exception thrown!";
                }
            }
            return message;
        }

        public static string AddComplaint(string complaint_id, string user_id, string complaint_body, string date_str)
        {
            string result = "";
            string connectionStr = @"Data Source=DESKTOP-JHDR8CQ\SQLEXPRESS;Initial Catalog=finance_management;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO complaints(complaint_id,user_id,complaint_body,date) VALUES(@complaint_id,@user_id,@complaint_body,@date);", connection);
                    cmd.Parameters.AddWithValue("@complaint_id", complaint_id);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@complaint_body", complaint_body);
                    cmd.Parameters.AddWithValue("@date", date_str);
                    cmd.ExecuteNonQuery();
                    result = "Success!";
                    connection.Close();
                }
                catch (Exception err)
                {
                    result = err.Message;
                }
            }
            return result;
        }

        public static string GenerateID(string tableName)
        {
            string newID = "";
            string maxID = "";
            int maxID_num = 0;
            string connectionStr = @"Data Source=DESKTOP-JHDR8CQ\SQLEXPRESS;Initial Catalog=finance_management;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    if (tableName == "users")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(user_id) AS user_id FROM users;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["user_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "UID" + maxID_num.ToString("D2");

                    }
                    else if (tableName == "complaints")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(complaint_id) AS complaint_id FROM complaints;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["complaint_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "CID" + maxID_num.ToString("D2");

                    }
                    else if (tableName == "transfers")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(transfer_id) AS transfer_id FROM transfers;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["transfer_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "TID" + maxID_num.ToString("D2");
                    }
                    else if (tableName == "budgets")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(budget_id) AS budget_id FROM budgets;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["budget_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "BID" + maxID_num.ToString("D2");
                    }
                    else if (tableName == "payrolls")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(payroll_id) AS payroll_id FROM payrolls;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["payroll_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "PID" + maxID_num.ToString("D2");
                    }
                    else if (tableName == "incomeStatements")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(income_id) AS income_id FROM incomeStatements;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["income_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "IID" + maxID_num.ToString("D2");
                    }
                    else if (tableName == "balanceSheets")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(balance_id) AS balance_id FROM balanceSheets;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["balance_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "XID" + maxID_num.ToString("D2");
                    }
                    else if (tableName == "expenses")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT MAX(expense_id) AS expense_id FROM expenses;", connection);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            maxID = dataReader["expense_id"].ToString();
                        }
                        dataReader.Close();
                        maxID_num = int.Parse(maxID.Substring(3));
                        maxID_num++;
                        newID = "EID" + maxID_num.ToString("D2");
                    }
                    connection.Close();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            return newID;
        }

        public static string AddUser(string cnic, string name, string email, string password, string accountNo)
        {
            string result = "";
            string connectionStr = @"Data Source=DESKTOP-JHDR8CQ\SQLEXPRESS;Initial Catalog=finance_management;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users(user_id,CNIC,full_name,email,password,account_num,current_balance) VALUES(@user_id,@CNIC,@full_name,@email,@password,@account_num,@current_balance);", connection);
                    cmd.Parameters.AddWithValue("@user_id", GenerateID("users"));
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.Parameters.AddWithValue("@full_name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_num", accountNo);
                    cmd.Parameters.AddWithValue("@current_balance", 0);
                    cmd.ExecuteNonQuery();
                    result = "Success!";
                    connection.Close();
                }
                catch (Exception err)
                {
                    result = err.Message;
                }
            }
            return result;
        }

        public static Users LoginUser(string cnic, string password)
        {
            string result = "You don't seem to have an account, try signing up.";
            Users user = new Users();
            //IDictionary<string, string> userInfo = new Dictionary<string, string>();
            string connectionStr = @"Data Source=DESKTOP-JHDR8CQ\SQLEXPRESS;Initial Catalog=finance_management;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users where CNIC='" + cnic + "' AND password='" + password + "'", connection);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        /*string user_id = "", name = "", email = "", acc_num = "";
                        float balance = 0;*/
                        while (dataReader.Read())
                        {
                            user.user_id = dataReader.GetValue(0).ToString();
                            user.CNIC = cnic;
                            user.full_name = dataReader.GetValue(2).ToString();
                            user.email = dataReader.GetValue(3).ToString();
                            user.account_num = dataReader.GetValue(5).ToString();
                            user.current_balance = float.Parse(dataReader.GetValue(6).ToString());
                            /*userInfo.Add("user_id", user_id);
                            userInfo.Add("CNIC", cnic);
                            userInfo.Add("full_name", name);
                            userInfo.Add("email", email);
                            userInfo.Add("password", password);
                            userInfo.Add("account_num", acc_num);*/
                        }
                        dataReader.Close();
                    }
                    connection.Close();
                }
                catch (Exception err)
                {
                    result = err.Message;
                }
            }
            return user;
        }
    }
}