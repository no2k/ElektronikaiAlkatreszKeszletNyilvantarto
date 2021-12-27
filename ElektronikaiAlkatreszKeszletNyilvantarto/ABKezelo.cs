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
        } //OK!
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

        } //OK!
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
                            );
                    }
                    reader.Close();
                    return kategoriaLista;
                }
            }
            catch (Exception ex)
            {

                throw new ABKivetel("Adatbázis (Kategória) lekérdezési hiba! " + ex.Message);
            }

        } //OK!
        public static void KategoriaTorles(Kategoria torles)
        {
            /*
             * Nem feltétlen kell törölni, csak ha nagyon muszály. Kell egy bool változó ami jelzi a kategóriát hogy aktív vagy inaktív! A paraméter listát is érinti
             * */
            //  parancs.Parameters.Clear();
            //  parancs.Transaction = kapcsolat.BeginTransaction();
            //  parancs.CommandText=$"DELETE FROM[{torles.GetType().Name}] WHERE [KATEGORIA]"
        }
        public static void UjParameterLista(Kategoria kategoria, ParameterLista hozzaAd)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText = "INSERT INTO [Parameter]([KATEGORIA_ID],[PARAMETER_SORSZAM],[PARAMETER_MEGNEVEZES],[PARAMETER_MERTEKEGYSEG],[PARAMETER_ERTEKTIPUS]) VALUES (@kategoriaId, @parameterSorszam, @parameterMegnevezes, @parameterMertekegyseg, @parameterErtekTipus)";
                int? kategoriaId = hozzaAd.Kategoria.KategoriaId;
                foreach (Parameter item in hozzaAd)
                {
                    parancs.Parameters.AddWithValue("@kategoriaId", kategoriaId);
                    parancs.Parameters.AddWithValue("@parameterSorszam", item.ParameterSorszam);
                    parancs.Parameters.AddWithValue("@parameterMegnevezes", item.ParameterMegnevezes.ToString());
                   
                    parancs.Parameters.AddWithValue("@parameterMertekegyseg", Parameter.TombbolStringbeKonvertal(item.ParameterMertekEgyseg));
                    parancs.Parameters.AddWithValue("@parameterErtekTipus", item.ParameterTipus);
                    parancs.ExecuteNonQuery();
                }
                parancs.Transaction.Commit();
                //  kategoria.KategoriaId = (int)parancs.ExecuteScalar();
            }
            catch (Exception ex)
            {
                try
                {
                    if (parancs.Transaction != null)
                    {
                        parancs.Transaction.Rollback();
                    }
                }
                catch (Exception ex2)
                {
                    throw new ABKivetel("Végzetes hiba az adatbázisban. Adatbázis beavatkozásra van szükség!", ex2);
                }
                throw new ABKivetel($"Sikertelen paraméterlista felvitel az adatbázisba! \r\n {ex.Message}");
            }
        } //ok
        public static void UjParameter(Kategoria kategoria,Parameter parameter)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Parameter]([KATEGORIA_ID],[PARAMETER_SORSZAM],[PARAMETER_MEGNEVEZES],[PARAMETER_MERTEKEGYSEG],[PARAMETER_ERTEKTIPUS]) VALUES (@kategoriaId, @parameterSorszam, @parameterMegnevezes, @parameterMertekegyseg, @parameterErtekTipus)";
                parancs.Parameters.AddWithValue("@kategoriaId", kategoria.KategoriaId);
                parancs.Parameters.AddWithValue("@parameterSorszam", parameter.ParameterSorszam);
                parancs.Parameters.AddWithValue("@parameterMegnevezes", parameter.ParameterMegnevezes.ToString());
                parancs.Parameters.AddWithValue("@parameterMertekegyseg", Parameter.TombbolStringbeKonvertal(parameter.ParameterMertekEgyseg));
                parancs.Parameters.AddWithValue("@parameterErtekTipus", parameter.ParameterTipus);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel($"Sikertelen paraméterlista felvitel az adatbázisba! \r\n {ex.Message}");
            }
        } //ok
        public static ParameterLista ParameterekLekerdez(Kategoria melyik)
        {
            List<Parameter> lista = new List<Parameter>();
            try
            {
                int? kategoriaId = melyik.KategoriaId;
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT *, " +
                    "[PARAMETER_SORSZAM]," +
                    "[PARAMETER_MEGNEVEZES]," +
                    "[PARAMETER_MERTEKEGYSEG]," +
                    "[PARAMETER_ERTEKTIPUS] FROM [PARAMETER]" +
                    "LEFT JOIN [Kategoria] ON [Parameter].[KATEGORIA_ID] = [Kategoria].[KATEGORIA_ID] WHERE [Kategoria].[KATEGORIA_ID]=@kategoriaId";
                parancs.Parameters.AddWithValue("@kategoriaId", melyik.KategoriaId);
                //List<Parameter> lista = new List<Parameter>();
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PARAMETER_SORSZAM"]!=null)
                        {
                            lista.Add(
                            new Parameter(
                                (int)reader["PARAMETER_SORSZAM"],
                                reader["PARAMETER_MEGNEVEZES"].ToString(),
                                reader["PARAMETER_MERTEKEGYSEG"].ToString().Split(';'),
                                (int)reader["PARAMETER_ERTEKTIPUS"]
                                )
                            );
                        }
                        else
                        {
                            lista = null;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis (Kategória) lekérdezési hiba! " + ex.Message);
            }
            return new ParameterLista(melyik, lista); ;
        } //ok
        public static void ParameterTorles(Kategoria kategoria,Parameter parameter)
        {
            throw new NotImplementedException("Paraméter törlés nincs megvalósítva!");
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
