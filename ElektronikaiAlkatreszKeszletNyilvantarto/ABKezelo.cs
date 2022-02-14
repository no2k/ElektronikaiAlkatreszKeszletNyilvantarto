using EKNyilvantarto.AlkatreszOsztalyok;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EKNyilvantarto
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
        private static Kategoria KategoriaLekerdezIdAlapjan(int kategoriaId)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT [MEGNEVEZES] FROM [Kategoria] WHERE [KATEGORIA_ID]=@id";
                parancs.Parameters.AddWithValue("@id", kategoriaId);
                string megnevezes = parancs.ExecuteScalar().ToString();

                return new Kategoria(kategoriaId, megnevezes);
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba történt a kategória lekérdezése közben! ", ex);
            }

        } //OK!
        #endregion

        #region Parameter definíciós kapcsolatok 

        //OK 
        public static void UjParameterDef(Kategoria hova, ParameterDef mit)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Parameter_Def]([KATEGORIA_ID],[PARAMETER_SORSZAM],[PARAMETER_MEGNEVEZES],[PARAMETER_MERTEKEGYSEG],[PARAMETER_ERTEKTIPUS]) VALUES (@kategoriaId, @parameterSorszam, @parameterMegnevezes, @parameterMertekegyseg, @parameterErtekTipus)";
                parancs.Parameters.AddWithValue("@kategoriaId", hova.KategoriaId);
                parancs.Parameters.AddWithValue("@parameterSorszam", mit.ParameterSorszam);
                parancs.Parameters.AddWithValue("@parameterMegnevezes", mit.ParameterMegnevezes.ToString());
                parancs.Parameters.AddWithValue("@parameterMertekegyseg", ParameterDef.TombbolStringbeKonvertal(mit.ParameterMertekEgyseg));
                parancs.Parameters.AddWithValue("@parameterErtekTipus", mit.ParameterTipus);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel($"Sikertelen paraméterlista felvitel az adatbázisba! \r\n {ex.Message}");
            }
        }   //OK
        public static void ParameterDefModositas(Kategoria hol, ParameterDef melyiket)
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
                parancs.Parameters.AddWithValue("@parameterMertekegyseg", ParameterDef.TombbolStringbeKonvertal(melyiket.ParameterMertekEgyseg));
                parancs.Parameters.AddWithValue("@parameterErtekTipus", melyiket.ParameterTipus);
                parancs.Parameters.AddWithValue("@kategoriaId", hol.KategoriaId);
                parancs.Parameters.AddWithValue("@parameterSorszam", melyiket.ParameterSorszam);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Paraméter módosítási hiba az adatbázisban!" + ex.Message, ex);
            }
        }   //OK
        public static int ParameterDefTores(Kategoria honnan, ParameterDef mit)
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
        public static ParameterDefLista ParameterDefLekerdez(Kategoria melyik)
        {
            List<ParameterDef> lista = new List<ParameterDef>();
            try
            {
                int? kategoriaId = melyik.KategoriaId;
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT *, " +
                    "[PARAMETER_SORSZAM]," +
                    "[PARAMETER_MEGNEVEZES]," +
                    "[PARAMETER_MERTEKEGYSEG]," +
                    "[PARAMETER_ERTEKTIPUS] FROM [Parameter_Def]" +
                    "LEFT JOIN [Kategoria] ON [Parameter_def].[KATEGORIA_ID] = [Kategoria].[KATEGORIA_ID] " +
                    "WHERE [Kategoria].[KATEGORIA_ID]=@kategoriaId";
                parancs.Parameters.AddWithValue("@kategoriaId", melyik.KategoriaId);
                //List<Parameter> lista = new List<Parameter>();
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PARAMETER_SORSZAM"] != null)
                        {
                            lista.Add(
                            new ParameterDef(
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
            return new ParameterDefLista(melyik, lista); ;
        } //OK!
        #endregion

        #region Parameterek kapcsolatok
        public static bool VanMarIlyenKategoriavalAlkatresz(Kategoria kategoria)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT COUNT([ALKATRESZ_ID]) FROM [Alkatresz] WHERE [KATEGORIA_ID]=@kategoriaId";
                parancs.Parameters.AddWithValue("@kategoriaId", kategoria.KategoriaId);
                int i = (int)parancs.ExecuteScalar();
                return (i != 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw new ABKivetel($"Sikertelen parméter(darabszám) kiolvasás az adatbázisból! \r\n {ex.Message}");
            }
        }
        private static List<int> ParameterIdkLekerdezParameterekAlapjan(string adat)
        {
            List<string> adatok = Szeparator(adat);
            Queue<string> parameterSor = new Queue<string>();
            foreach (string item in adatok)
            {
                parameterSor.Enqueue(item);
            }
            try
            {
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText = "SELECT [PARAMETER_ID] FROM [Parameterek]" +
                    "WHERE " +
                    "[PARAMETER_ERTEK] LIKE @ertek AND [PARAMETER_MERTEKEGYSEG] LIKE @mertekEgyseg" +
                    " AND [PARAMETER_SORSZAM]=[PARAMETER_SORSZAM]" +
                    " AND [PARAMETER_ID]=[PARAMETER_ID] ";
                List<int> idk = new List<int>();
                while (parameterSor.Count > 0)
                {
                    idk.Clear();
                    parancs.Parameters.Clear();
                    float f; //nem használt csak a tipusellenörzés miat kell!!
                    string s = (parameterSor.Count > 0 &&
                        float.TryParse(parameterSor.Peek(), out f)
                        ) ? parameterSor.Dequeue() : string.Empty;
                    parancs.Parameters.AddWithValue("@ertek", s + "%");
                    s = (parameterSor.Count > 0) ? parameterSor.Dequeue() : string.Empty;
                    parancs.Parameters.AddWithValue("@mertekEgyseg", s + "%");
                    //parancs.Parameters.AddWithValue("@szuretlenAdat", adat);
                    using (SqlDataReader reader = parancs.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = (int)reader["PARAMETER_ID"];
                            idk.Add(i);

                        }
                        reader.Close();
                    }
                }
                parancs.Transaction.Commit();
                return idk;
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
                throw new ABKivetel("Hiba a paraméterek lekérdezése közben!", ex);
            }
        }

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
                if (ujId.Item1 == true) // id 7
                {
                    int alkatreszId = ujId.Item2;
                    ujAlkatresz.AlkatreszId = alkatreszId;
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
        public static Alkatresz AlkatreszKeresesParameterListaAlapjan(List<AlkatreszParameter> parameterek)
        {
            try
            {
                if (UtolsoAlkatreszId() < 1) return null;
                List<int> keresettIdk = new List<int>();
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText =
                    "SELECT [ALKATRESZ_ID] FROM [Alkatresz] AS A " +
                    "INNER JOIN [Parameterek] AS P ON P.[PARAMETER_ID]=A.[ALKATRESZ_ID]  " +
                    "WHERE [PARAMETER_SORSZAM]=@sorSzam AND " +
                          "[PARAMETER_ERTEK]=@ertek AND " +
                          "[PARAMETER_MERTEKEGYSEG]=@mertekEgyseg";
                foreach (AlkatreszParameter item in parameterek)
                {
                    parancs.Parameters.Clear();
                    parancs.Parameters.AddWithValue("@sorSzam", item.ParameterSorszam);
                    parancs.Parameters.AddWithValue("@ertek", item.ParameterErtek);
                    parancs.Parameters.AddWithValue("@mertekEgyseg", item.ParameterMertekegyseg);
                    using (SqlDataReader reader = parancs.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["ALKATRESZ_ID"];
                            if (!keresettIdk.Contains(id))
                            {
                                keresettIdk.Add(id);
                            }
                        }
                        reader.Close();
                    }
                }
                parancs.Transaction.Commit();
                List<Alkatresz> talalatok = new List<Alkatresz>();
                Alkatresz keresettAlkatresz = new Alkatresz();
                foreach (int id in keresettIdk)
                {
                    keresettAlkatresz = AlkatreszLekerdezIdAlapjan(id);
                    if (keresettAlkatresz.Equals(parameterek))
                    {
                        return keresettAlkatresz;
                    }
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
                throw new ABKivetel("Hiba az alkatrész keresésekor az adatbázisban!" + ex.Message);
            }
        }
        private static List<Alkatresz> AlkatreszListaLekerdezes(Kategoria kategoria)
        {
            List<Alkatresz> alkatreszLista = new List<Alkatresz>();
            try
            {

                List<Keszlet> keszletLista = new List<Keszlet>();
                List<AlkatreszParameter> parameterLista = new List<AlkatreszParameter>();
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT " +
                         "P.[KATEGORIA_ID],P.[PARAMETER_ID],p.[PARAMETER_SORSZAM]," +
                         "p.[PARAMETER_ERTEK],p.[PARAMETER_MERTEKEGYSEG],a.[MEGNEVEZES] " +
                         "FROM [Alkatresz] AS A INNER JOIN [Parameterek] AS P ON A.[ALKATRESZ_ID]=P.[PARAMETER_ID] " +
                                      "WHERE P.[KATEGORIA_ID]=A.[KATEGORIA_ID] AND P.[KATEGORIA_ID]=@kategoria ";
                parancs.Parameters.AddWithValue("@kategoria", kategoria.KategoriaId);
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    Alkatresz ujAlkatresz = new Alkatresz();
                    while (reader.Read())
                    {
                        if (ujAlkatresz.AlkatreszId == 0)
                        {
                            ujAlkatresz = null;
                            ujAlkatresz = new Alkatresz((int)reader["PARAMETER_ID"], kategoria, reader["MEGNEVEZES"].ToString(), new List<AlkatreszParameter>());
                        }
                        AlkatreszParameter parameter = new AlkatreszParameter((int)reader["PARAMETER_ID"], reader["PARAMETER_ERTEK"].ToString(), reader["PARAMETER_MERTEKEGYSEG"].ToString());
                        if (ujAlkatresz.AlkatreszId == (int)reader["PARAMETER_ID"])
                        {
                            ujAlkatresz.Parameterek.Add(parameter);
                        }
                        else
                        {
                            alkatreszLista.Add(ujAlkatresz);
                            ujAlkatresz = new Alkatresz((int)reader["PARAMETER_ID"], kategoria, reader["MEGNEVEZES"].ToString(), new List<AlkatreszParameter>());
                            ujAlkatresz.Parameterek.Add(parameter);
                        }
                    }
                    //mivel hamarabb kilép a ciklusból ezért az utolsó alkatrészt itt kell hozzáadni!!!
                    alkatreszLista.Add(ujAlkatresz);
                    reader.Close();
                    return alkatreszLista;
                }
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a készlet lekérdezés közben!" + ex.Message);
            }

        }  //OK!
        private static Alkatresz AlkatreszLekerdezIdAlapjan(int id)
        {
            try
            {
                if (UtolsoAlkatreszId() < 1) return null;
                parancs.Parameters.Clear();
                parancs.CommandText =
                    "SELECT P.[PARAMETER_ID], P.[PARAMETER_SORSZAM], P.[PARAMETER_ERTEK], P.[PARAMETER_MERTEKEGYSEG],K.[KATEGORIA_ID], K.[KATEGORIA], A.[MEGNEVEZES]  " +
                    "FROM [Alkatresz] AS A " +
                    "INNER JOIN [Parameterek] AS P ON P.[PARAMETER_ID]= A.[ALKATRESZ_ID]" +
                    "INNER JOIN [Kategoria] AS K ON P.[KATEGORIA_ID]=K.[KATEGORIA_ID]" +
                    "WHERE A.[ALKATRESZ_ID]=@id";
                parancs.Parameters.AddWithValue("@id", id);
                List<Keszlet> keszletLista = new List<Keszlet>();
                List<AlkatreszParameter> parameterLista = new List<AlkatreszParameter>();
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    Alkatresz keresettAlkatresz = new Alkatresz();
                    while (reader.Read())
                    {
                        if (keresettAlkatresz.AlkatreszId == 0)
                        {
                            keresettAlkatresz = null;
                            keresettAlkatresz = new Alkatresz((int)reader["PARAMETER_ID"], new Kategoria((int)reader["KATEGORIA_ID"], reader["KATEGORIA"].ToString()), reader["MEGNEVEZES"].ToString(), new List<AlkatreszParameter>());
                        }
                        AlkatreszParameter parameter = new AlkatreszParameter((int)reader["PARAMETER_ID"], reader["PARAMETER_ERTEK"].ToString(), reader["PARAMETER_MERTEKEGYSEG"].ToString());
                        if (keresettAlkatresz.AlkatreszId == (int)reader["PARAMETER_ID"])
                        {
                            keresettAlkatresz.Parameterek.Add(parameter);
                        }
                        else
                        {
                            keresettAlkatresz = new Alkatresz((int)reader["PARAMETER_ID"], new Kategoria((int)reader["KATEGORIA_ID"], reader["KATEGORIA"].ToString()), reader["MEGNEVEZES"].ToString(), new List<AlkatreszParameter>());
                            keresettAlkatresz.Parameterek.Add(parameter);
                        }
                    }
                    reader.Close();
                    return keresettAlkatresz;
                }
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
                throw new ABKivetel("Hiba az alkatrész keresésekor az adatbázisban!" + ex.Message);
            }
        }
        internal static List<Keszlet> GlobalisKereses(string parameter)
        {
            try
            {
                if (UtolsoAlkatreszId() < 1) return null;
                List<int> keresettIdk = ParameterIdkLekerdezParameterekAlapjan(parameter);
                List<Alkatresz> keresettAlkatreszek = new List<Alkatresz>();
                foreach (int id in keresettIdk)
                {
                    keresettAlkatreszek.Add(AlkatreszLekerdezIdAlapjan(id));
                }
                List<Keszlet> keresettKeszlet = new List<Keszlet>();
                foreach (Alkatresz alkatresz in keresettAlkatreszek)
                {
                    keresettKeszlet.Add(KeszletKeres(alkatresz));
                }
                return keresettKeszlet;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba az adatbázisban való teljes keresés közben!", ex);
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
        public static bool VanIlyenAlkatresz(Alkatresz alkatresz)
        {
            if (UtolsoAlkatreszId() < 1) return false;
            try
            {
                Alkatresz keresett = AlkatreszKeresesParameterListaAlapjan(alkatresz.Parameterek);
                if (keresett != null)
                {
                    alkatresz = keresett;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba az alkatrész meglétének ellenőrzésekor az adatbázisban!" + ex.Message);
            }
        }
        #endregion

        #region Keszlet kapcsolatok

        internal static Keszlet KeszletKeresParameterekAlapjan(List<AlkatreszParameter> keresettParameterek)
        {
            try
            {
                Alkatresz keresettAlkatresz = AlkatreszKeresesParameterListaAlapjan(keresettParameterek);
                if (keresettAlkatresz == null) return null;
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText =
                    "SELECT [KESZLET_ID],[MENNYISEG],[EGYSEGAR],[MEGJEGYZES] FROM [Keszlet]" +
                          "WHERE [ALKATRESZ_ID]=@id";
                parancs.Parameters.AddWithValue("@id", keresettAlkatresz.AlkatreszId);
                Keszlet keresettKeszlet = null;
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        keresettKeszlet = new Keszlet((int)reader["KESZLET_ID"], float.Parse(reader["MENNYISEG"].ToString()), float.Parse(reader["EGYSEGAR"].ToString()), reader["MEGJEGYZES"].ToString(), keresettAlkatresz);
                    }
                    reader.Close();
                    parancs.Transaction.Commit();
                    return keresettKeszlet;
                }
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
                throw new ABKivetel("Hiba a készletben való  kereséskor az adatbázisban!" + ex.Message);
            }
        }
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
        public static List<Keszlet> KeszletLeker(Kategoria kategoria)
        {
            List<Alkatresz> alkatreszLista = AlkatreszListaLekerdezes(kategoria);
            try
            {
                List<Keszlet> keszletLista = new List<Keszlet>();
                parancs.Parameters.Clear();
                // K.[KESZLET_ID],K.[ALKATRESZ_ID],K.[MENNYISEG],K.[EGYSEGAR],K.[MEGJEGYZES]
                parancs.CommandText = "SELECT * FROM [Keszlet] AS K INNER JOIN [Alkatresz] AS A ON K.[ALKATRESZ_ID]=A.[ALKATRESZ_ID] WHERE A.[KATEGORIA_ID]=@id";
                parancs.Parameters.AddWithValue("@id", kategoria.KategoriaId);
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        int alkatreszId = (int)reader["ALKATRESZ_ID"];
                        foreach (Alkatresz alkatresz in alkatreszLista)
                        {
                            if (alkatreszId == alkatresz.AlkatreszId)
                            {
                                keszletLista.Add(new Keszlet((int)reader["ALKATRESZ_ID"], (float)reader.GetDouble(2), (float)reader.GetDouble(3), reader["MEGJEGYZES"].ToString(), alkatresz));
                                i++;
                            }
                        }
                    }
                    reader.Close();
                }
                return keszletLista;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hibás készlet beolvasás az adatbázisból!" + ex.Message);
            }
        }  //OK!
        internal static Keszlet KeszletKeres(Alkatresz alkatresz)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT * FROM [Keszlet] WHERE [ALKATRESZ_ID]=@alkatreszId";
                parancs.Parameters.AddWithValue("@alkatreszId", alkatresz.AlkatreszId);
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader["KESZLET_ID"] > 0)
                        {
                            return new Keszlet(
                                 (int)reader["KESZLET_ID"],
                                 float.Parse(reader["MENNYISEG"].ToString()),
                                 float.Parse(reader["EGYSEGAR"].ToString()),
                                 reader["MEGJEGYZES"].ToString(),
                                 alkatresz);
                        }
                    }
                    reader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba az adatbázisban való alkatrész keresése közben!", ex);
            }
        }  //OK!
        internal static void KeszletModositas(Keszlet mit)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "UPDATE [Keszlet] SET [MENNYISEG]=@darabSzam ,[EGYSEGAR]=@darabAr WHERE [ALKATRESZ_ID]=@alkatreszId";
                parancs.Parameters.AddWithValue("@darabSzam", mit.DarabSzam);
                parancs.Parameters.AddWithValue("@darabAr", mit.DarabAr);
                parancs.Parameters.AddWithValue("@alkatreszId", mit.Alkatresz.AlkatreszId);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba az alkatrész adatainak frissítésekor, az adatbázisban!", ex);
            }
        }  //OK!

        #endregion

        #region Projekt kapcsolatok

        public static void UjProjekt(Projekt ujProjekt)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Projekt] ([MEGNEVEZES],[LEIRAS],[MEGJEGYZES],[STATUSZ]) OUTPUT INSERTED.PROJEKT_ID VALUES(@megnevezes,@leiras,@megjegyzes,@statusz)";
                parancs.Parameters.AddWithValue("@megnevezes", ujProjekt.ProjektNev);
                parancs.Parameters.AddWithValue("@leiras", ujProjekt.Leiras);
                parancs.Parameters.AddWithValue("@megjegyzes", ujProjekt.Megjegyzes);
                parancs.Parameters.AddWithValue("@statusz", SqlDbType.Bit).Value = ujProjekt.LezartStatusz;

                ujProjekt.ProjektAzonosito = (int)parancs.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projekt adatbázisba történő létrehozásakor!", ex);
            }
        }  //OK!
        public static void ProjektModositas(Projekt prjModosit)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = " UPDATE [Projekt] SET [LEIRAS]=@leiras,[MEGJEGYZES]=@megjegyzes WHERE [PROJEKT_ID]=@id";
                parancs.Parameters.AddWithValue("@leiras", prjModosit.Leiras);
                parancs.Parameters.AddWithValue("@megjegyzes", prjModosit.Megjegyzes);
                parancs.Parameters.AddWithValue("@id", prjModosit.ProjektAzonosito);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projekt adatainak módosításakor, az adatbázisban!", ex);
            }
        }  //OK!
        public static void ProjektStatuszBeallit(Projekt projekt, bool statusz)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = " UPDATE [Projekt] SET [STATUSZ]=@statusz WHERE [PROJEKT_ID]=@id";
                parancs.Parameters.AddWithValue("@statusz", statusz);
                parancs.Parameters.AddWithValue("@id", projekt.ProjektAzonosito);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projekt státuszának módosításakor, az adatbázisban!", ex);
            }
        }  //OK!
        public static void ProjektTorles(Projekt prjTorol)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandText = "DELETE FROM [PrJ_Alkatresz] WHERE [PROJEKT_ID]=@id";
                parancs.Parameters.AddWithValue("@id", prjTorol.ProjektAzonosito);
                parancs.ExecuteNonQuery();
                parancs.CommandText = "DELETE FROM [Projekt] WHERE [PROJEKT_ID]=@id";
                parancs.ExecuteNonQuery();
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
                    throw new ABKivetel("Végzetes hiba az adatbázisban, adatbázis beavatkozásra van szükség!", ex2);
                }
                throw new ABKivetel("Sikertelen projekt törlés!", ex);
            }
        }  //OK!
        public static List<Projekt> ProjektekLekerdez()
        {
            try
            {
                List<Projekt> lista = new List<Projekt>();
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT * FROM [Projekt]";
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Projekt(
                            reader["MEGNEVEZES"].ToString(),
                            reader["LEIRAS"].ToString(),
                            (int)reader["PROJEKT_ID"],
                            new List<Keszlet>(),
                            reader["MEGJEGYZES"].ToString(),
                            (bool)reader["STATUSZ"]
                            ));
                    }
                    reader.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projektek adatbázisból való lekérdezésekor!", ex);
            }
        }  //OK!
        public static int UtolsoProjektAzonosito()
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT [PROJEKT_ID] FROM [Projekt] WHERE [PROJEKT_ID]=(SELECT MAX([PROJEKT_ID]) FROM [PROJEKT])";
                int? i = (int?)parancs.ExecuteScalar();
                return (i != null) ? (int)i : 0;
            }
            catch (Exception ex)
            {
                throw new ABKivetel($"Sikertelen Projekt azonosító kiolvasás az adatbázisból! \r\n {ex.Message}");
            }
        }  //OK!
        public static void ProjektAlkatreszFelvitel(int projektId, Keszlet alkatresz)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "INSERT INTO [Prj_Alkatresz] ([PROJEKT_ID],[ALKATRESZ_ID],[DARABSZAM],[DARAB_AR]) VALUES(@projektId,@alkatreszId,@darabSzam,@darabAr)";

                parancs.Parameters.AddWithValue("@projektId", projektId);
                parancs.Parameters.AddWithValue("@alkatreszId", alkatresz.Alkatresz.
                    AlkatreszId);
                parancs.Parameters.AddWithValue("@darabSzam", alkatresz.DarabSzam);
                parancs.Parameters.AddWithValue("@darabAr", alkatresz.DarabAr);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projekt alkatrészeinek adatbázisba történő felvitele közben!", ex);
            }
        }  //OK!
        public static void ProjektAlkatreszLekerdez(Projekt projekt)
        {
            try
            {

                parancs.Parameters.Clear(); // 
                parancs.CommandText =
                  "SELECT PA.[ALKATRESZ_ID], PA.[DARAB_AR], " +
                     "PA.[DARABSZAM], K.[KATEGORIA_ID], K.[KATEGORIA], KE.[MEGJEGYZES]," +
                     "P.[PARAMETER_SORSZAM],P.[PARAMETER_ERTEK]," +
                     "P.[PARAMETER_MERTEKEGYSEG], A.[MEGNEVEZES]" +
                        "FROM [Prj_Alkatresz] AS PA " +
                        "INNER JOIN [Parameterek] AS P ON PA.[ALKATRESZ_ID]= P.[PARAMETER_ID] " +
                        "INNER JOIN [Alkatresz] AS A ON A.[ALKATRESZ_ID]=PA.[ALKATRESZ_ID]" +
                        "INNER JOIN [Keszlet] AS KE ON A.[ALKATRESZ_ID]= KE.[ALKATRESZ_ID]"+
                        "LEFT JOIN [Kategoria] AS K ON K.[KATEGORIA_ID]= P.[KATEGORIA_ID] " +
                           "WHERE PA.[PROJEKT_ID]= @projektId";
                parancs.Parameters.AddWithValue("@projektId", projekt.ProjektAzonosito);
                projekt.AlkatreszLista.Clear();
                using (SqlDataReader reader = parancs.ExecuteReader())
                {
                    Keszlet keszlet;
                    int alkatreszId = 0;
                   // List<AlkatreszParameter> parameterek = new List<AlkatreszParameter>();
                    float darabszam = 0;
                    float darabar = 0;
                    int kategoriaId = 0;
                    string kategoria = string.Empty;
                    string megnevezes = string.Empty;
                    string megjegyzes = string.Empty;
                    int index = -1; 
                    while (reader.Read())
                    {
                        darabszam = float.Parse(reader["DARABSZAM"].ToString());
                        darabar = float.Parse(reader["DARAB_AR"].ToString());
                        kategoriaId = (int)reader["KATEGORIA_ID"];
                        kategoria = reader["KATEGORIA"].ToString();
                        megnevezes = reader["MEGNEVEZES"].ToString();
                        int id_ = (int)reader["ALKATRESZ_ID"];
                        megjegyzes = reader["MEGJEGYZES"].ToString();
                        if (alkatreszId == id_ /* || alkatreszId == 0*/)
                        {
                            projekt.AlkatreszLista[index].Alkatresz.Parameterek.Add(
                                new AlkatreszParameter(
                                (int)reader["PARAMETER_SORSZAM"],
                                reader["PARAMETER_ERTEK"].ToString(),
                                reader["PARAMETER_MERTEKEGYSEG"].ToString()));
                        }
                        else
                        {
                            alkatreszId = id_;
                            keszlet = new Keszlet(alkatreszId, darabszam, darabar, megjegyzes,
                            new Alkatresz(alkatreszId, new Kategoria(kategoriaId, kategoria), megnevezes,
                            new List<AlkatreszParameter>()));
                           // parameterek.Clear();
                           keszlet.Alkatresz.Parameterek.Add(new AlkatreszParameter(
                               (int)reader["PARAMETER_SORSZAM"],
                               reader["PARAMETER_ERTEK"].ToString(),
                               reader["PARAMETER_MERTEKEGYSEG"].ToString()));
                            projekt.AlkatreszLista.Add(keszlet);
                            index++;
                        }
                        //alkatreszId = (int)reader["ALKATRESZ_ID"];
                    }
                   /* if (parameterek.Count > 0)
                    {
                        projekt.AlkatreszLista.Add(
                                    new Keszlet(alkatreszId, darabszam, darabar, "",
                                    new Alkatresz(alkatreszId, new Kategoria(kategoriaId, kategoria), megnevezes,
                                    new List<AlkatreszParameter>(parameterek))));
                    }*/
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba történt a projekt alkatrész adatbázisból való lekérdezése közben!", ex);
            }
        }  //OK!
        public static void ProjektAlkatreszTorles(int projektId, int alkatreszId)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "DELETE FROM [Prj_Alkatresz] WHERE [PROJEKT_ID]=@projektId AND [ALKATRESZ_ID]=@alkatreszId";
                parancs.Parameters.AddWithValue("@projektId", projektId);
                parancs.Parameters.AddWithValue("@alkatreszId", alkatreszId);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projekt alkatrész adatbázisból való törlése közben!", ex);
            }
        }  //OK!
        public static bool VanIlyenProjekt(string projektNev)
        {
            if (UtolsoProjektAzonosito() < 1)
            {
                return false;
            }
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "SELECT [PROJEKT_ID] FROM [Projekt] WHERE [Projekt].[MEGNEVEZES]=@megnevezes";
                parancs.Parameters.AddWithValue("@megnevezes", projektNev);
                int? id = (int?)parancs.ExecuteScalar();
                if (id != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projekt azonosításának lekérdezése közben!", ex);
            }
        }  //OK!
        internal static void ProjektAlkatreszModositas(int projektId, Keszlet mit)
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "UPDATE [Prj_Alkatresz] SET [DARABSZAM]=@darabSzam WHERE[PROJEKT_ID]=@projektId AND [ALKATRESZ_ID]=@alkatreszId";
                parancs.Parameters.AddWithValue("@darabSzam", mit.DarabSzam);
                parancs.Parameters.AddWithValue("@projektId", projektId);
                parancs.Parameters.AddWithValue("@alkatreszId", mit.Alkatresz.AlkatreszId);
                parancs.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Hiba a projekt alkatrész adatainak frissítésekor, az adatbázisban!", ex);
            }
        }  //OK!
        #endregion

        #region Felhasznált metódusok (Stackowerflow)
        //nem releváns
        //https://stackoverflow-com.translate.goog/questions/1968049/how-to-separate-character-and-number-part-from-string/1968064?_x_tr_sl=en&_x_tr_tl=hu&_x_tr_hl=en#1968064
        private static List<string> Szeparator(string input)
        {
            string[] adatTomb = input.Split(' ');
            var words = new List<string>();// { string.Empty };
            foreach (string item in adatTomb)
            {
                words.Add(item);
            }
            return words;
        }

        #endregion
    }
}
