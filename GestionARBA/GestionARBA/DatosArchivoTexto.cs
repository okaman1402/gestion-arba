using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;



namespace GestionARBA
{
    public class  DatosArchivoTexto
    {
        /// <summary>
        /// Graba archivo de texto en path y archivo indicado en parametro archivo.
        /// Se graba la cena indicada en cadena. icluye 0d0a.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="cadena"></param>
        public static void grabaArchivoTexto(string archivo, string cadena)
        {
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(cadena);
            writer.Close();
        }
        /// <summary>
        /// Lee archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static string leeArchivoTexto(string archivo)
        {
            string cadena = null;
            FileStream stream = null;
            try
            {
                stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                cadena = string.Empty;
                return cadena;
            }
            if (stream != null)
            {
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    cadena = cadena + reader.ReadLine() + "\r\n";
                }
                reader.Close();
            }
            return cadena;
        }


        public static FileStream crearArchivo(string archivo)
        {
            FileStream stream = new FileStream(archivo, FileMode.Create, FileAccess.Write);
            return stream;
        }

        public static void GeneraArchivoTxT(string nomArchi, IDataReader dr)
        {
            string cadena = null;
            while (dr.Read())
            {
                cadena = null;
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    cadena = cadena + dr.GetString(i);
                }
                grabaArchivoTexto(nomArchi, cadena);
            }
            dr.Close();
        }

        public static void GeneraArchivoTxT(string nomArchi, IDataReader dr, char Separador)
        {
            string cadena = null;
            while (dr.Read())
            {
                cadena = null;
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    cadena = cadena + dr.GetString(i) + Separador;
                }
                grabaArchivoTexto(nomArchi, cadena);
            }
            dr.Close();
        }

 

        /// <summary>
        /// abre archivo y lo vacia.
        /// </summary>
        /// <param name="archivo"></param>
        public static void vaciarArchivo(string archivo)
        {
            FileStream stream = new FileStream(archivo, FileMode.Truncate, FileAccess.Write);
            stream.Close();
        }


        public static DataTable Lee_CSV(string nombre, string ruta)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +  ruta + ";" + "Extended Properties='text;HDR=No;FMT=Delimited'";
            DataTable dtCSV = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                using (OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + nombre, conn))
                {
                    da.Fill(dtCSV);
                }
            }
            catch (OleDbException ex)
            {
                return dtCSV;
            }
            return dtCSV;
        }

    }
}
