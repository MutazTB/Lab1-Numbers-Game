using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to my game! Let's do some math !");
            try
            {
                // call a function 
                StartSequence();
            }
            catch(Exception e) // if StartSequence method has an error , throw an error with details 
            {
                Console.WriteLine(e.Message);
            }
            finally //I need this statment even every thing is good or not
            {
                Console.WriteLine("Program is complete.");
            }
        }

        static void StartSequence() 
        {
            try
            {
                Console.WriteLine("Please enter a number greater than zero"); //ask user to inter a number greater than zero
                String arraySize = Console.ReadLine(); // we store the number as string because user may be inter any thing not a number
                int sizeOfArray = Convert.ToInt32(arraySize); // convert the number from user to int 

                int[] myArray = new int[sizeOfArray]; // define an array with size from user input
                int[] resultArray = Populate(myArray); // define an array to store the user input from populate method 
                int sum = GetSum(resultArray);// define sum to store sum of array from GetSum methd
                int product = GetProduct(resultArray, sum);
                decimal quotient = GetQuotient(product);

                // to show user the results
                Console.WriteLine("Your array is size: " + resultArray.Length);
                Console.Write("The numbers in the array are ");
                for (int i = 0; i < resultArray.Length; i++)
                {
                    Console.Write(resultArray[i] + ",");
                }
                Console.WriteLine(" ");
                Console.WriteLine("The sum of the array is " + sum);
                // int multiply = sum * product;
                Console.WriteLine(sum + " * " + (product/sum) + " = " + product);
                decimal division = Convert.ToDecimal(product) / quotient;
                Console.WriteLine(product + " / " + division  + " = " + quotient);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int[] Populate(int[] arr) 
        {
            
            int[] populateArray = new int[arr.Length]; // define empty int array to store user's input
            int j = 0;
            for (int i = 0; i < arr.Length; i++) // Loop to ask user to enter a number for each element in the array
            {
                Console.WriteLine("Please enter a number "+ ++j + " of " + arr.Length);
                String elementsFromUser = Console.ReadLine();
                int arrayElement = Convert.ToInt32(elementsFromUser);
                populateArray[i] = arrayElement; // save user's input to the array
            }

            return populateArray;
        }

        static int GetSum(int[] arr) 
        {
           
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) // loop to Sum elements of array
            {
                sum += arr[i];
            }
            if (sum < 20) 
            {
                // if sum of user's input less than 20 throw an error
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }

        static int GetProduct(int[] arr , int sum) 
        {
            
            try
            {
                Console.WriteLine($"Please inter a number between 1 and {arr.Length}");// ask user to inter random number between 1 and size of array 
                String ranNum = Console.ReadLine();                                    // to get the element in that index and multiply it with sum
                int productNum = Convert.ToInt32(ranNum);
                int product = sum * arr[productNum - 1];
                return product;
            }
            catch(IndexOutOfRangeException e ) // if user input number greater than array's size 
            {                                  // throw an error to let user know his input greater than array's size
                Console.WriteLine(e.Message);
                throw;
            }
            
        }

        static decimal GetQuotient(int product)
        {             
            try
            {
                Console.WriteLine($"Please inter a number to divide your product {product} by"); // ask user to inter random number to divide the product on it 
                String divideNum = Console.ReadLine();
                decimal divide = Convert.ToDecimal(divideNum);

                decimal quotient = decimal.Divide(product, divide);
                return quotient;
            }
            catch(DivideByZeroException e) // if user input zero , throw an error because we cannot divide by zero
            {
                Console.WriteLine(e.Message);
                return 0;
            }            
        }

    }
}
