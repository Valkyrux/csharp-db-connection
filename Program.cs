using System;
using System.Data.SqlClient;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string dbConnectionString = "Data Source=DESKTOP-IN7U4B6;Initial Catalog=biblioteca;User ID=sa;Password=sa;Pooling=False";
            using (SqlConnection con = new SqlConnection(dbConnectionString))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM sys.all_columns;", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine(reader.FieldCount);
                        /*
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0]);
                        }*/
                    }
                }
                
                con.Close();
            }

            dbConnectionString = "Data Source=DESKTOP-IN7U4B6;Initial Catalog=mio_database;User ID=sa;Password=sa;Pooling=False";
            using (SqlConnection con = new SqlConnection(dbConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clienti;", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        int j = 0;
                        while (reader.Read())
                        {
                            Console.WriteLine("Riga {0}", ++j);
                            for(int i = 0; i < reader.FieldCount; i++)
                            {
                                if(i != reader.FieldCount - 1)
                                {
                                    Console.Write("{0}, ", reader[i]);
                                } else
                                {
                                    Console.Write("{0}\n", reader[i]);
                                }
                            }
                            
                        }
                    }
                }

                con.Close();
            }
        }
    }
}