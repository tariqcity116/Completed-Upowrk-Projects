using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SOAPServicePOC.Model
{
    public class Logger
    {
        #region Atributos

        private static Dictionary<string, object> bloqueos = new Dictionary<string, object>();

        #endregion

        #region Operaciones

        private static string CarpetaLogObtener()
        {
            return "C:\\LOGS SOAP";
        }

        private static StreamWriter StreamWriterObtener(string archivoLog)
        {
            try
            {
                string rutaArchivoLog = Logger.CarpetaLogObtener();
                if (!Directory.Exists(rutaArchivoLog))
                    Directory.CreateDirectory(rutaArchivoLog);
                rutaArchivoLog += @"\" + archivoLog;
                return !File.Exists(rutaArchivoLog) ? File.CreateText(rutaArchivoLog) : File.AppendText(rutaArchivoLog);
            }
            catch
            {
                return null;
            }
        }

        public static void LogGrabar(Exception ex, string archivoLog)
        {
            try
            {
                object objBloqueo = ObtenerBloqueo(archivoLog);
                lock (objBloqueo)
                {
                    StreamWriter sw = Logger.StreamWriterObtener(archivoLog);
                    if (sw != null)
                        try
                        {
                            sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " : ");
                            sw.WriteLine();
                            sw.WriteLine("InnerException.Message: ");
                            sw.WriteLine(ex.InnerException != null ? ex.InnerException.Message : "");
                            sw.WriteLine();
                            sw.WriteLine("Message: ");
                            sw.WriteLine(ex.Message);
                            sw.WriteLine();
                            sw.WriteLine("Source: ");
                            sw.WriteLine(ex.Source);
                            sw.WriteLine();
                            sw.WriteLine("StackTrace: ");
                            sw.WriteLine(ex.StackTrace);
                            sw.WriteLine("_____________________");
                            sw.WriteLine();
                            Console.WriteLine(ex.Message);
                        }
                        catch { }
                        finally
                        {
                            sw.Close();
                        }
                }
            }
            catch { }
        }

        public static void LogGrabar(string texto, string archivoLog)
        {
            try
            {
                object objBloqueo = ObtenerBloqueo(archivoLog);
                lock (objBloqueo)
                {
                    texto = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " : " + texto;
                    StreamWriter sw = Logger.StreamWriterObtener(archivoLog);
                    if (sw != null)
                        try
                        {
                            sw.WriteLine(texto);
                            Console.WriteLine(texto);
                        }
                        catch { }
                        finally
                        {
                            sw.Close();
                        }
                }
            }
            catch { }
        }



        /// Fecha Creación:06/04/2011
        /// Fecha Modificación:
        /// <summary>
        /// Graba en el archivo de log los bytes indicados en ASCII y en Hexa.
        /// </summary>
        /// <param name="fechaHora"></param>
        /// <param name="datos"></param>
        /// <param name="archivoLog"></param>
        public static void LogGrabarBytes(DateTime fechaHora, List<byte> datos, string archivoLog)
        {
            try
            {
                //string texto1 = "";
                //string texto2 = "";

                StringBuilder texto1 = new StringBuilder("");
                StringBuilder texto2 = new StringBuilder("");

                foreach (byte b in datos)
                {
                    texto1.Append((b >= 33 && b <= 166) ? " " + Convert.ToChar(b) + " " : "   ");
                    texto2.Append("-" + String.Format("{0:X}", b).PadLeft(2, '0'));
                }
                if (datos.Count > 0)
                {
                    texto1.Remove(0, 1);
                    texto2.Remove(0, 1);
                }
                texto1.Insert(0, fechaHora.ToString("dd/MM/yyyy HH:mm:ss"));
                texto2.Insert(0, fechaHora.ToString("dd/MM/yyyy HH:mm:ss"));

                object objBloqueo = ObtenerBloqueo(archivoLog);
                lock (objBloqueo)
                {
                    StreamWriter sw = Logger.StreamWriterObtener(archivoLog);
                    if (sw != null)
                        try
                        {
                            sw.WriteLine(texto1);
                            Console.WriteLine(texto1);
                            sw.WriteLine(texto2);
                            Console.WriteLine(texto2);
                            sw.WriteLine();
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                            sw.Close();
                        }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static object ObtenerBloqueo(string nroNodo)
        {
            if (!bloqueos.ContainsKey(nroNodo))
                bloqueos.Add(nroNodo, new object());
            return bloqueos[nroNodo];
        }
    }

    #endregion

}