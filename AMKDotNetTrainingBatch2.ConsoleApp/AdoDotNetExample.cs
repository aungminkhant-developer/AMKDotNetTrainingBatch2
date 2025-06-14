﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMKDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
            }
        }

        public void Create()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            //       string query = $@"INSERT INTO [dbo].[Tbl_Blog]
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent])
            //VALUES
            //      ('{title}'
            //      ,'{author}'
            //      ,'{content}')";

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Title
           ,@Author
           ,@Content)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");
        }

        public void Edit()
        {
            Console.Write("Enter Id: ");
            string blogId = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"select * from Tbl_Blog Where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
            }
        }

        public void Update()
        {
            Console.Write("Enter Id: ");
            string blogId = Console.ReadLine()!;

            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @Title
      ,[BlogAuthor] = @Author
      ,[BlogContent] = @Content
 WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Update Success!" : "Update Failed!");
        }
    }

}
