using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            
            Console.WriteLine("Average Scores:");
            double outputData;
            for(int j = 2; j < 5; j++)
            {
                outputData = 0;
                for(int i = 1; i <= stdCount; i++) {
                    outputData += double.Parse(data[i, j]);
                }
                outputData /= stdCount;
                Console.WriteLine($"{data[0, j]}: {Math.Round(outputData, 2)}");
            }
            
            Console.WriteLine("");
            double maxData;
            double minData;
            Console.WriteLine("Max and min Scores:");
            for(int j = 2; j < 5; j++)
            {
                maxData = 0;
                minData = 100;
                for(int i = 1; i <= stdCount; i++) {
                    if(minData >= double.Parse(data[i, j])) {
                        minData = double.Parse(data[i, j]);
                    }
                    if(maxData <= double.Parse(data[i, j])) {
                        maxData = double.Parse(data[i, j]);
                    }
                }
                
                Console.WriteLine($"{data[0, j]}: ({maxData}, {minData})");
            }
            
            Console.WriteLine("");
            double currentData;
            int rank;
            Console.WriteLine("Students rank by total scores:");
            for(int j = 1; j <= stdCount; j++)
            {
                rank = 1;
                currentData = double.Parse(data[j, 2]) + double.Parse(data[j, 3]) + double.Parse(data[j, 4]);
                for(int i = 1; i <= stdCount; i++) {
                    if(i != j) {
                        if(currentData <= double.Parse(data[i, 2]) + double.Parse(data[i, 3]) + double.Parse(data[i, 4])) {
                            rank++;
                        }
                    }
                    
                }
                
                string prefix = "th";
                if(rank == 1) prefix = "st";
                else if(rank == 2) prefix = "nd";
                else if(rank == 3) prefix = "rd";
                Console.WriteLine($"{data[j, 1]}: {rank}{prefix}");
            }
            
            
            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 4th
Bob: 1st
Charlie: 5th
David: 2nd
Eve: 3rd

*/
