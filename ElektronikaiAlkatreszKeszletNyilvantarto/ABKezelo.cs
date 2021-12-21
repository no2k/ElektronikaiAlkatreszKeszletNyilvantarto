using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElektronikaiAlkatreszKeszletNyilvantarto.AlkatreszOsztalyok;

namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    static class ABKezelo
    {
        static SqlConnection kapcsolat;
        static SqlCommand parancs;

        public static void Csatlakozas(/*string adatbazis*/)
        {
            try
            {
                kapcsolat = new SqlConnection();
                //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pejoc\source\repos\ElektronikaiAlkatreszKeszletNyilvantarto\ElektronikaiAlkatreszKeszletNyilvantarto\KeszletAB.mdf;Integrated Security=True
                kapcsolat.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\KeszletAB.mdf;Integrated Security=True";
                kapcsolat.Open();
                parancs = new SqlCommand();
                parancs.Connection = kapcsolat;
                parancs.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Sikertelen csatlakozás az adatbázishoz", ex);
            }
        }
        public static void KapcsolatBontas()
        {
            try
            {
                kapcsolat.Close();
                parancs.Dispose();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Az adatbázis kapcsolat bontása sikertelen!", ex);
            }
        }
        public static void UjKategoria(Kategoria kategoria)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Kategoria] ([KATEGORIA]) OUTPUT INSERTED.KATEGORIA_ID VALUES(@kategoria)";
                parancs.Parameters.AddWithValue("@kategoria", kategoria.KategoriaMegnevezes);
                kategoria.KategoriaId = (int)parancs.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new ABKivetel($"Sikertelen kategória felvitel az adatbázisba! \r\n\t {ex.Message}");
            }

        }
        public static List<Kategoria> KategoriaLekerdezes()
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT * FROM [Kategoria]";


                List<Kategoria> kategoriaLista = new List<Kategoria>();
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kategoriaLista.Add(
                            new Kategoria(
                                (int)reader["KATEGORIA_ID"],
                                reader["KATEGORIA"].ToString()
                                )
                            ) ;
                    }  
                    reader.Close();
                    return kategoriaLista;
                }
            }
            catch (Exception ex)
            {

                throw new ABKivetel("Adatbázis (Kategória) lekérdezési hiba! " + ex.Message);
            }

        }
        public static void KategoriaTorles(Kategoria torles)
        {
            /*
             * Nem feltétlen kell törölni, csak ha nagyon muszály. Kell egy bool változó ami jelzi a kategóriát hogy aktív vagy inaktív!
             * */
            //  parancs.Parameters.Clear();
            //  parancs.Transaction = kapcsolat.BeginTransaction();
            //  parancs.CommandText=$"DELETE FROM[{torles.GetType().Name}] WHERE [KATEGORIA]"
        }
        public static void UjAlkatresz(Alkatresz ujAlkatresz)
        {
            try
            {
                //throw new NotImplementedException("ABKezelo.cs /UjAlkatresz nincs megírva!!");
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText = "INSERT INTO [Kategoria] VALUES (@kategoria)"/*OUTPUT INSERTED.KATEGORIA_ID*/;
                // parancs.Parameters.AddWithValue(@"kategoria",ujAlkatresz.Kategoria);
                parancs.ExecuteNonQuery();
                //ujAlkatresz.id=parancs.ExecuteScalar();
                parancs.CommandText = "INSERT INTO []";


            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AlkatreszModositas(Alkatresz alkatreszModosit)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AlkatreszTorles(Alkatresz alkatreszTorol)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UjProjekt(object ujProjekt)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void ProjektModositas(object prjModosit)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void ProjektTorles(object prjTorol)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        /*   public static Alkatresz LekerdezAlkatresz()
           {
               try
               {

               }
               catch (Exception)
               {

                   throw;
               }
           }
           public static List<Alkatresz> LekerdezKeszlet()
           {
               try
               {

               }
               catch (Exception)
               {

                   throw;
               }
           }
           public static Projekt LekerdezProjekt()
           {
               try
               {

               }
               catch (Exception)
               {

                   throw;
               }
           }
           public static List<Projekt> LekerdezProjektek()
           {
               try
               {

               }
               catch (Exception)
               {

                   throw;
               }
           }
          // public static List*/
    }
}
