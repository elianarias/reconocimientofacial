using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        // Ruta del video a procesar, modifiquela con la ruta correspondiente
        string videoPath = @"C:\Users\Eliana Arias\source\repos\facial\facial\video\videorostro.mp4";

        // Directorio para almacenar los frames extraídos, si utiliza una carpeta diferente modifique la linea 15
        string outputDirectory = @"C:\Users\Eliana Arias\source\repos\facial\facial\frames";

        // nos aseguramos que el directorio de salida existe
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // cargamos el video
        using (VideoCapture capture = new VideoCapture(videoPath))
        {
            // verificamos que se abra correctamente el video
            if (!capture.IsOpened)
            {
                Console.WriteLine("No se pudo abrir el archivo de video.");
                return;
            }

            // detectamos los rostros
            CascadeClassifier faceDetector = new CascadeClassifier(@"C:\Users\Eliana Arias\source\repos\facial\facial\haarcascade_frontalface_alt_tree.xml");

            // asignamos variamos para comparar cada captura de imagen del video 
            Mat currentFrame = new Mat();
            Mat previousFrame = new Mat();

            
            bool samePerson = true; // almacenamos el resultado

            //mensaje de espera mientras se ejecuta el programa
            Console.WriteLine("Espere mientras realizamos la verificación del video...");

            while (capture.Read(currentFrame) && samePerson)
            {
                // Verificar si el frame actual está vacío
                if (currentFrame.IsEmpty)
                    break;

                // Detección de caras en el frame actual
                var faces = faceDetector.DetectMultiScale(currentFrame, 1.1, 3);

                
            }

            if (samePerson)
            {
                Console.WriteLine("Verificación exitosa: es la misma persona.");
            }
            else
            {
                Console.WriteLine("No es la misma persona.");
            }
        }

        Console.WriteLine("Se han guardado los frames del video como imágenes en la carpeta asignada. Hasta luego! .");
    }
}
