using System;

namespace star
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the radius: ");
            int radius = int.Parse(Console.ReadLine());
            int size = 2 * (radius + 1);
            // ---------- TODO ----------
            
            for(int i = 0; i < size; i++) {
                for(int j = 0; j < size; j++) {
                    if(i >= 1 && i < size - 1) {
                        if((i == 1 || i == size - 2) && j >= 2 && j < size - 1) {
                            Console.Write("*");
                        }
                        else if(i >= 2 && i < size - 2 && j == 1) {
                            Console.Write("*");
                        }
                        else Console.Write(" ");
                    }
                    else Console.Write(" ");
                }
                
                for(int j = 0; j < size; j++) {
                    if(i != 0 && i != size - 1 && i % (size / 3) == 0) {
                        Console.Write("*");
                    }
                    else if(j != 0 && j != size - 1 && j % (size / 3) == 0) {
                        Console.Write("*");
                    }
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
            
            
            
            // --------------------
        }

        // calculate the distance between (x1, y1) and (x2, y2)
        static double SqrDistance2D(double x1, double y1, double x2, double y2)
        {
            return Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
        }

        // Checks if two values a and b are within a given distance.
        // |a - b| < distance
        static bool IsClose(double a, double b, double distance)
        {
            return Math.Abs(a - b) < distance;
        }
    }
}


/* example output
Enter the radius: 
>> 5
                *   *   
  *********     *   *   
 *              *   *   
 *              *   *   
 *          ************
 *              *   *   
 *              *   *   
 *              *   *   
 *          ************
 *              *   *   
 *              *   *   
  *********     *   *   

*/

/* example output (CHALLANGE)
Enter the radius: 
>> 5
                *   *  
      *         *   *  
   *     *      *   *  
  *                    
           ************
               *   *   
 *             *   *   
               *   *   
           ************
  *                    
   *     *    *   *    
      *       *   *    

*/
