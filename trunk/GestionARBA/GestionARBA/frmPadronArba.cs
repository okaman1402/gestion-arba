using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Cryptography;


namespace GestionARBA
{
    public partial class frmPadronArba : Form
    {
        /// <summary>
        /// variable estatica para llevar el nombre del archivo que se procesa actualmente.
        /// Es asignada ante cualquier change de txtfile
        /// </summary>
        static string archivoEnProceso; 
        static string user;
        static string password;
        static string serverURL;

        public frmPadronArba()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            archivoEnProceso = this.txtFile.Text;
            user = this.txtUsr.Text;
            password = this.txtPwd.Text;
            serverURL = this.txtURL.Text;
            string contenidoDelArchivo = "";
            contenidoDelArchivo = obtieneContenidoDelArchivo(archivoEnProceso);
            if (contenidoDelArchivo!=null) this.enviaArchivo(contenidoDelArchivo);
        }


        private void enviaArchivo(string contenidoDelArchivo)
        {
            string boundary = "AaB03x";
            ASCIIEncoding encoding = new ASCIIEncoding();
            estableceEstado("Estableciendo datos a enviar ...");
            Console.WriteLine(this.obtieneHashMD5());
            archivoEnProceso = this.seteaNombreHashMD5(archivoEnProceso);
           // MessageBox.Show("no está seteado el obtieneHashMD5.");
            string postdata = string.Format("--" + boundary + "\r\n" +
                                            "Content-Disposition: form-data; name=\"user\"\r\n\r\n" + user +
                                            "\r\n" +
                                            "--" + boundary + "\r\n" +
                                            "Content-Disposition: form-data; name=\"password\"\r\n\r\n" + password +
                                            "\r\n" +
                                            "--" + boundary + "\r\n" +
                                            "Content-Disposition: form-data; name=\"file\"; filename=" 
                                            + archivoEnProceso //+ '_' + this.obtieneHashMD5()
                                            + "\r\n" +
                                            "Content-Type: text/xml\r\n\r\n" +
                                            contenidoDelArchivo +
                                            "--" + boundary + "--");
            estableceEstado("Codificando ...");
            byte[] buffer = encoding.GetBytes(postdata);
            //byte[] buffer = Encoding.UTF8.GetBytes(postdata);
            ///crea conexion
            estableceEstado("Estableciendo conexion con servidor ...");
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serverURL);
            myRequest.Method = "POST";
            myRequest.ContentType = "multipart/form-data;boundary=AaB03x";
            ///establece longitud de buffer
            myRequest.ContentLength = buffer.Length;
            ///abre stream para escribir
            Stream newStream = null;
            try
            {
                newStream = myRequest.GetRequestStream();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha instalado el certificado.\nDebe instalarlo antes de continuar");
            }
            if (newStream != null)
            {
                ///escribe stream
                estableceEstado("Enviando datos al servidor ...");
                newStream.Write(buffer, 0, buffer.Length);
                newStream.Close();
                estableceEstado("Obteniendo respuesta ...");
                consultaRespuesta(myRequest);
            }
            
            estableceEstado("");
        }

        /// <summary>
        /// Obtiene el contenido del archivo dentro de un string listo para ser enviado por método 
        /// POST.
        /// </summary>
        /// <param name="archivo"></param>
        /// Cadena con nombre del archivo a procesar. 
        /// <returns></returns>
        private string obtieneContenidoDelArchivo(string archivo)
        {
            string cadena=null;
            FileStream stream=null;
            try
            {
                stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            }
            catch(FileNotFoundException)
            {
                estableceEstado("No se encuentra el archivo especificado. Seleccione un archivo");
            }
            if (stream!=null)
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


        /// <summary>
        /// Consulta la respuesta del servidor a traves de httpWebRequest
        /// Almacena en archivo zip el archivo de salida
        /// </summary>
        /// <param name="webreq"></param>
        private void consultaRespuesta(HttpWebRequest webreq)
        {
            double bytesLeidos = 0;
            HttpWebResponse webresp;
            webresp = (HttpWebResponse)webreq.GetResponse();
            System.Windows.Forms.Application.DoEvents();
            Stream tmpStreamReader = webresp.GetResponseStream();

            string fileName = archivoEnProceso + ".zip";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

            byte[] buffer = new byte[4096];  
            int BytesRead=0;  

            do
            {
                //Read up to 4096 bytes from the response stream
                BytesRead = tmpStreamReader.Read(buffer, 0, 4096);
                System.Windows.Forms.Application.DoEvents();
                bytesLeidos = bytesLeidos + BytesRead;
                this.estableceEstado("Leidos: " + bytesLeidos.ToString() + " Bytes.");
                //Write the number of bytes actually read
                stream.Write(buffer, 0, BytesRead);
            }
            while (BytesRead > 0);

            tmpStreamReader.Close();
            webresp.Close();
            stream.Close();
        }
        
        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            serverURL = txtURL.Text;
        }

        /// <summary>
        /// Graba la respuesta del servidor en un archivo de salida, llamado igual al archivo de 
        /// entrada. Pero añadiendole .ACT
        /// Siempre que paso archivos paso path completo.
        /// </summary>
        private void grabaRespuestaEnArchivo(string cadenaRespuesta)
        {
            string tmpCadena = "";
            string fileName =  archivoEnProceso + ".zip";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(stream);

            byte[] bytes;
            ASCIIEncoding ascii = new ASCIIEncoding();
            bytes = ascii.GetBytes(cadenaRespuesta);
            //StreamWriter writer = new StreamWriter(stream);
            
            writer.Write( bytes);
         /*   for (int i=0; i < cadenaRespuesta.Length; i++) 
            {
                if (cadenaRespuesta[i].CompareTo('\n') == 0)
                {
                    writer.WriteLine(tmpCadena);
                    tmpCadena = "";
                    i++;
                }
                else
                {
                    tmpCadena = tmpCadena + cadenaRespuesta[i];
                }
            }*/
            writer.Close();
        }

        private void btnListarDirectorio_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// prueba para listar los archivos de un directorio
        /// </summary>
        private void listaArchivosDirectorio()
        {
            string[] listaArchivos;
            listaArchivos = System.IO.Directory.GetFiles("c:\\");
            MessageBox.Show(listaArchivos.GetUpperBound(0).ToString());
            for (int i = 0; i < listaArchivos.GetUpperBound(0); i++)
            {
                MessageBox.Show(listaArchivos[i].ToString());
            }
        }


        private void btnSeleccionaArchivo_Click(object sender, EventArgs e)
        {
            ofdAbrirArchivo.ShowDialog();
            this.txtFile.Text = ofdAbrirArchivo.FileName.ToString();
            estableceEstado("Archivo seleccionado");
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            archivoEnProceso = this.txtFile.Text;
        }

        private void txtUsr_TextChanged(object sender, EventArgs e)
        {
            user = txtUsr.Text;
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            password = txtPwd.Text;
        }

        private void frm4SCOT_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "";
        }

        private void estableceEstado(string estado)
        {
            lblEstado.Text = estado;
            lblEstado.Refresh();
        }

        private string obtieneHashMD5()
        {
            FileStream fs = new FileStream(archivoEnProceso, FileMode.Open);
            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
            Int64 currentPos = fs.Position;
            try
            {
                fs.Seek(0, SeekOrigin.Begin);
                StringBuilder sb = new StringBuilder();
                foreach (Byte b in hash.ComputeHash(fs))
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
            finally
            {
                fs.Seek(currentPos, SeekOrigin.Begin);
                fs.Close();
            }
        }

        private string seteaNombreHashMD5(string archivo)
        {
            string nombrearchivo = archivo.Substring(0, archivo.Length - 4);
            nombrearchivo = nombrearchivo + '_' + this.obtieneHashMD5() + ".xml";
            File.Move(archivo, nombrearchivo);
            MessageBox.Show("Se renombró archivo en proceso a: " + nombrearchivo);
            return nombrearchivo;
        }
        

    }
}