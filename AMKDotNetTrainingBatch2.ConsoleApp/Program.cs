// See https://aka.ms/new-console-template for more information
using AMKDotNetTrainingBatch2.ConsoleApp;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");


//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Delete();
dapperExample.Update();

Console.ReadKey();

