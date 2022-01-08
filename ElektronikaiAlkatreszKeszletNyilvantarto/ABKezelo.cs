using System;
using System.Collections.Generic;
using System.Configuration;
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


        public static void Csatlakozas()
        {
            try
            {
                //"KeszletABConStr"
                kapcsolat = new SqlConnection();
                kapcsolat.ConnectionString = ConfigurationManager.ConnectionStrings["KeszletABConStr"].ConnectionString;
                kapcsolat.Open();
                parancs = new SqlCommand();
                parancs.Connection = kapcsolat;
                parancs.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Sikertelen csatlakozás az adatbázishoz", ex);
            }
        } //OK
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


        #region Kategoria kapcsolatok

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
        public static List<Kategoria> AktivKategoriaLekerdezes()
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT * FROM [Kategoria] WHERE [STATUSZ]=1";
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
        public static List<Kategoria> InaktivKategoriaLekerdezes()
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT * FROM [Kategoria] WHERE [STATUSZ]=0";
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
        public static void KategoriaInaktival(Kategoria melyiket)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "UPDATE [Kategoria] SET [STATUSZ] = 0 WHERE [KATEGORIA_ID]=@kategoriaId";
                parancs.Parameters.AddWithValue("@kategoriaId", melyiket.KategoriaId);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel($"Sikertelen kategória muvelet az adatbázisba! \r\n\t {ex.Message}");
            }
        } //OK!
        #endregion

        #region Parameter definíciós kapcsolatok 
        public static void UjParameterLista(Kategoria hova, ParameterLista miket)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText = "INSERT INTO [Parameter_Def]([KATEGORIA_ID],[PARAMETER_SORSZAM],[PARAMETER_MEGNEVEZES],[PARAMETER_MERTEKEGYSEG],[PARAMETER_ERTEKTIPUS]) VALUES (@kategoriaId, @parameterSorszam, @parameterMegnevezes, @parameterMertekegyseg, @parameterErtekTipus)";
                int? kategoriaId = hova.KategoriaId;
                foreach (Parameter item in miket)
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
        } //OK
        public static void UjParameter(Kategoria hova, Parameter mit)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Parameter_Def]([KATEGORIA_ID],[PARAMETER_SORSZAM],[PARAMETER_MEGNEVEZES],[PARAMETER_MERTEKEGYSEG],[PARAMETER_ERTEKTIPUS]) VALUES (@kategoriaId, @parameterSorszam, @parameterMegnevezes, @parameterMertekegyseg, @parameterErtekTipus)";
                parancs.Parameters.AddWithValue("@kategoriaId", hova.KategoriaId);
                parancs.Parameters.AddWithValue("@parameterSorszam", mit.ParameterSorszam);
                parancs.Parameters.AddWithValue("@parameterMegnevezes", mit.ParameterMegnevezes.ToString());
                parancs.Parameters.AddWithValue("@parameterMertekegyseg", Parameter.TombbolStringbeKonvertal(mit.ParameterMertekEgyseg));
                parancs.Parameters.AddWithValue("@parameterErtekTipus", mit.ParameterTipus);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel($"Sikertelen paraméterlista felvitel az adatbázisba! \r\n {ex.Message}");
            }
        } //OK
        public static void ParameterModositas(Kategoria hol, Parameter melyiket)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "UPDATE [Parameter_Def] SET " +
                                      "[PARAMETER_MEGNEVEZES]=@parameterMegnevezes, " +
                                      "[PARAMETER_MERTEKEGYSEG]=@parameterMertekegyseg, " +
                                      "[PARAMETER_ERTEKTIPUS]=@parameterErtekTipus " +
                                      "WHERE [KATEGORIA_ID]=@kategoriaId AND" +
                                            "[PARAMETER_SORSZAM]=@parameterSorszam";
                parancs.Parameters.AddWithValue("@parameterMegnevezes", melyiket.ParameterMegnevezes.ToString());
                parancs.Parameters.AddWithValue("@parameterMertekegyseg", Parameter.TombbolStringbeKonvertal(melyiket.ParameterMertekEgyseg));
                parancs.Parameters.AddWithValue("@parameterErtekTipus", melyiket.ParameterTipus);
                parancs.Parameters.AddWithValue("@kategoriaId", hol.KategoriaId);
                parancs.Parameters.AddWithValue("@parameterSorszam", melyiket.ParameterSorszam);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Paraméter módosítási hiba az adatbázisban!" + ex.Message, ex);
            }
        }  //OK
        public static void ParameterListaModositas(Kategoria hol, List<Parameter> miket)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText = "UPDATE [Parameter_Def] SET " +
                                      "[PARAMETER_MEGNEVEZES]=@parameterMegnevezes, " +
                                      "[PARAMETER_MERTEKEGYSEG]=@parameterMertekegyseg, " +
                                      "[PARAMETER_ERTEKTIPUS]=@parameterErtekTipus " +
                                      "WHERE [KATEGORIA_ID]=@kategoriaId AND" +
                                            "[PARAMETER_SORSZAM]=@parameterSorszam";
                foreach (Parameter item in miket)
                {
                    parancs.Parameters.AddWithValue("@parameterMegnevezes", item.ParameterMegnevezes.ToString());
                    parancs.Parameters.AddWithValue("@parameterMertekegyseg", Parameter.TombbolStringbeKonvertal(item.ParameterMertekEgyseg));
                    parancs.Parameters.AddWithValue("@parameterErtekTipus", item.ParameterTipus);
                    parancs.Parameters.AddWithValue("@kategoriaId", hol.KategoriaId);
                    parancs.Parameters.AddWithValue("@parameterSorszam", item.ParameterSorszam);
                    parancs.ExecuteNonQuery();
                }
                parancs.Transaction.Commit();
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
                throw new ABKivetel("Paraméter lista módosítási hiba az adatbázisban!" + ex.Message, ex);
            }
        } //OK
        public static int ParameterTores(Kategoria honnan, Parameter mit)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "DELETE FROM [Parameter_Def] WHERE [KATEGORIA_ID]=@kategoriaId AND [PARAMETER_SORSZAM]=@parameterSorszam";
                parancs.Parameters.AddWithValue("@kategoriaId", honnan.KategoriaId);
                parancs.Parameters.AddWithValue("@parameterSorszam", mit.ParameterSorszam);
                return parancs.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new ABKivetel("Hiba az adatbázisból való, paraméter kitörlése közben!", ex);
            }
        } //OK!
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
                    "[PARAMETER_ERTEKTIPUS] FROM [Parameter_Def]" +
                    "LEFT JOIN [Kategoria] ON [Parameter_def].[KATEGORIA_ID] = [Kategoria].[KATEGORIA_ID] WHERE [Kategoria].[KATEGORIA_ID]=@kategoriaId";
                parancs.Parameters.AddWithValue("@kategoriaId", melyik.KategoriaId);
                //List<Parameter> lista = new List<Parameter>();
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PARAMETER_SORSZAM"] != null)
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
        } //OK!
        #endregion

        #region Parameterek kapcsolatok
        private static List<AlkatreszParameter> ParameterListaLekerdez(Kategoria kategoria, int parameterId)
        {
            try
            {
                List<AlkatreszParameter> parameterLista = new List<AlkatreszParameter>();
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT [PARAMETER_SORSZAM],[PARAMETER_ERTEK],[PARAMETER_MERTEKEGYSEG] FROM [Parameterek] WHERE [PARAMETER_ID]=@parameterId AND [KATEGORIA_ID]=@kategoriaId";
                parancs.Parameters.AddWithValue("@parameterId", parameterId);
                parancs.Parameters.AddWithValue("@kategoriaId", kategoria.KategoriaId);
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PARAMETER_SORSZAM"] != null)
                        {
                            parameterLista.Add(new AlkatreszParameter(
                            (int)reader["PARAMETER_SORSZAM"],
                            reader["PARAMETER_ERTEK"].ToString(),
                            reader["PARAMETER_MERTEKEGYSEG"].ToString()));


                        }
                    }

                }

                return parameterLista;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Sikertelen paraméter(ek) beolvasás az adatbázisból" + ex.Message);
            }
        }  //OK!
        #endregion
        #region Alkatresz kapcsolatok
        private static (bool, int) UjAlkatreszIdHozzaAdas(string megnevezes, int kategoriaId)
        {
            try
            {
                int? ujId;
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Alkatresz] ([MEGNEVEZES],[KATEGORIA_ID]) OUTPUT INSERTED.ALKATRESZ_ID VALUES(@megnevezes,@kategoriaId)";
                parancs.Parameters.AddWithValue("@megnevezes", megnevezes);
                parancs.Parameters.AddWithValue("@kategoriaId", kategoriaId);
                ujId = (int)parancs.ExecuteScalar();
                if (ujId != null)
                {
                    return (true, (int)ujId);
                }
                return (false, 0);
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Sikertelen alkatrész felvitel az adatbázisba" + ex.Message);
            }
        }  //OK!
        public static int? UjAlkatresz(Alkatresz ujAlkatresz)
        {
            try
            {
                (bool, int) ujId = UjAlkatreszIdHozzaAdas(ujAlkatresz.Megnevezes, (int)ujAlkatresz.Kategoria.KategoriaId);
                if (ujId.Item1 == true)
                {
                    int alkatreszId;
                    alkatreszId = ujId.Item2;
                    parancs.Parameters.Clear();
                    parancs.Transaction = kapcsolat.BeginTransaction();
                    parancs.CommandText = "INSERT INTO [Parameterek] ([PARAMETER_ID],[KATEGORIA_ID],[PARAMETER_SORSZAM],[PARAMETER_ERTEK],[PARAMETER_MERTEKEGYSEG]) VALUES (@paramId,@katId,@paramSorszam,@paramErtek,@paramMertekEgyseg)";


                    foreach (AlkatreszParameter item in ujAlkatresz.Parameterek)
                    {
                        parancs.Parameters.Clear();
                        parancs.Parameters.AddWithValue(@"paramId", ujAlkatresz.AlkatreszId);
                        parancs.Parameters.AddWithValue(@"katId", ujAlkatresz.Kategoria.KategoriaId);
                        parancs.Parameters.AddWithValue(@"paramSorszam", item.ParameterSorszam);
                        parancs.Parameters.AddWithValue(@"paramErtek", item.ParameterErtek);
                        parancs.Parameters.AddWithValue(@"paramMertekEgyseg", item.ParameterMertekegyseg);
                        parancs.ExecuteNonQuery();
                    }
                    parancs.Transaction.Commit();
                    return alkatreszId;
                }
                return null;
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
                throw new ABKivetel($"Sikertelen alkatrész felvitel az adatbázisba! \r\n\t {ex.Message}");
            }
        } //OK!
        public static void AlkatreszModositas(Keszlet alkatreszModosit)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AlkatreszTorles(Keszlet alkatreszTorol)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal static int UtolsoAlkatreszId()
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT [ALKATRESZ_ID] FROM [Alkatresz] WHERE [ALKATRESZ_ID]=(SELECT MAX([ALKATRESZ_ID]) FROM [Alkatresz])";

                int? i = (int?)parancs.ExecuteScalar();
                return (i != null) ? (int)i : 0;
            }
            catch (Exception ex)
            {
                throw new ABKivetel($"Sikertelen paraméter kiolvasás az adatbázisból! \r\n {ex.Message}");
            }
        } //OK!

        public static Alkatresz AlkatresztLekerdez(Kategoria kategoria)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT [MEGNEVEZES],[ALKATRESZ_ID] FROM [ALKATRESZ] WHERE [KATEGORIA_ID]=@kategoriaId";
                parancs.Parameters.AddWithValue("@kategoriaId", kategoria.KategoriaId);
                int alkatreszId = 0;
                string megnevezes = "";
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    if (reader["ALKATRESZ_ID"] != null)
                    {
                        alkatreszId = (int)reader["ALKATRESZ_ID"];
                        megnevezes = reader["MEGNEVEZES"].ToString();
                    }
                        return new Alkatresz(alkatreszId, kategoria, megnevezes, null);
                    //le kell hívni  készletet, majd az alkatrész paraméter listáját fel kell
                    //tölteni külön mert nincs még meg a paraméter id a lekérdezéshez!!!!
                }
            }  
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Keszlet kapcsolatok

        public static void UjKeszlet(Keszlet hozzaAd)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Keszlet] ([ALKATRESZ_ID],[MENNYISEG],[EGYSEGAR],[MEGJEGYZES]) OUTPUT INSERTED.KESZLET_ID VALUES(@alkatreszId,@darabSzam,@ar,@megjegyzes)";
                parancs.Parameters.AddWithValue("@keszletId", (int)hozzaAd.KeszletId);
                parancs.Parameters.AddWithValue("@alkatreszId", hozzaAd.Alkatresz.AlkatreszId);
                parancs.Parameters.AddWithValue("@darabSzam", hozzaAd.DarabSzam);
                parancs.Parameters.AddWithValue("@ar", hozzaAd.DarabAr);
                parancs.Parameters.AddWithValue("@megjegyzes", hozzaAd.Megjegyzes);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba történt a készlet adatbázisba való felvitelekor felvitelekor!" + ex.Message);
            }
        } //OK!

        public static List<Keszlet> KeszletTeljesLekerdezes()
        {
            try
            {   //először lekérdezem a paramétereket, majd az alkatrész táblát és utánna a készletet
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT * FROM [Keszlet]";

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Keszlet> KeszletListaLekerdezes(Kategoria kategoria)
        {

            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT * FROM [Keszlet] LEFT JOIN [Alkatresz] ";

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Keszlet KeszletLekerdezes(Kategoria kategoria)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int UtolsoKeszletId()
        {
            try
            {
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Projekt kapcsolatok

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
        #endregion
    }
}
