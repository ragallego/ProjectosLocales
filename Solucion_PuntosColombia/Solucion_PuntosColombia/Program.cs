using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion_PuntosColombia
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se Ingresa la informacion para realizar el calculo de la primera linea
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            //Se Ingresa la informacion para realizar el calculo de la segunda linea
            int m = Convert.ToInt32(Console.ReadLine());
            string[] brr_temp = Console.ReadLine().Split(' ');
            int[] brr = Array.ConvertAll(brr_temp, Int32.Parse);

            //Validacion del rango entre primer valor y ultimo del segundo array
            Array.Sort(brr);
            
            //Declaracion de variables para mayor y menor
            int mayor = brr[0], menor = brr[0];
            for (int x = 0; x < m; x++) 
            {
                if (brr[x] > mayor)
                    mayor = brr[x];
                if (brr[x] < menor)
                    menor = brr[x];
            }

            int v = mayor - menor;
            if (v <= 100)
            {
                //Se ejecuta la operacion principal
                int[] result = missingNumbers(arr, brr);
                Array.Sort(result);
                Console.WriteLine(String.Join(" ", result));
            }
            else
                Console.WriteLine("La diferencia entre el valor minimo y maximo del segundo vector debe ser menor o igual a 100");
        }

        static int[] missingNumbers(int[] arr, int[] brr)
        {
            //Se crea la lista que se retornará finalmente
            List<int> result = new List<int>();
            
            //Se recorre el primer vector
            foreach (var registro in
                arr.GroupBy(x => x).Select(x => new
                {
                    Valor = x.Key,
                    Cantidad = x.Count(),
                }))
            {
                //Se recorre el segundo vector
                foreach (var registro2 in
                    brr.GroupBy(x => x).Select(x => new
                    {
                        Valor = x.Key,
                        Cantidad = x.Count(),
                    }))
                {
                    //Se validan los registros que aplican la condicion principal
                    var aplica = (registro.Valor == registro2.Valor && registro.Cantidad < registro2.Cantidad) ? true : false;
                    if (aplica){
                        result.Add(registro.Valor);
                        break;
                    }
                }
            }
            //Se convierte el valor a retornar a vector
            return result.ToArray();
        }
    }
}

