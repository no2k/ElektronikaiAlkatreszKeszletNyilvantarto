using System;
namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    public class Kategoria
    {
        string kategoriaMegnevezes;
        int? kategoriaId;

        public string KategoriaMegnevezes
        {
            get => kategoriaMegnevezes;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    kategoriaMegnevezes = value;
                }
                else
                {
                    throw new ArgumentNullException("A kategória megnevezése nem lehet üres!");
                }
            }
        }
        public int? KategoriaId
        {
            get => kategoriaId;
            set
            {
                if (kategoriaId == null)
                {
                    kategoriaId = value;
                }
                else
                {
                    throw new InvalidOperationException("A kategória ID csak egyszer adható meg!");
                }
            }
        }

        public Kategoria(int? kategoriaId,string kategoriaMegnevezes)
        {
            KategoriaId = kategoriaId;
            KategoriaMegnevezes = kategoriaMegnevezes;
        }
    }
}