using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27_street_parade
{
    class Program
    {
        static void displayStackAndWait(Stack<int> stack)
        {
            Console.WriteLine("------- mobiles ------");
            foreach (var element in stack)
            {
                Console.Write(element + " ");
            }
            Console.ReadKey();
        }
        static bool streamToGarage(Stack<int> anyStack, Stack<int> garage, ref int garageAwaits)
        {
            /* garageAwaits has a begin value of 1, returns info whether the streaming has happened
             * is streams cars to garage until conditions are met */
   
            int currentValue;
            bool streamingHappened = false;

            while(anyStack.Count > 0)
            {
                currentValue = anyStack.Peek();
                if(currentValue == garageAwaits)
                {
                    anyStack.Pop();
                    garage.Push(currentValue);
                    garageAwaits += 1;
                    streamingHappened = true;
                }
                else
                {
                    break;
                }
            }
            return streamingHappened;
       
        }


        static void Main(string[] args)
        {

            int[] carsInMainStreet = new int[] { 4, 3, 1 };
            int[] carsInAlley = new int[] { 5, 2 };
            int[] carsInGarage = new int[] { };
            Stack<int> mainStreet = new Stack<int>(carsInMainStreet);
            Stack<int> alley = new Stack<int>(carsInAlley);
            Stack<int> garage = new Stack<int>(carsInGarage);


            bool continueLoop;
            int garageAwaits = 1;
            do
            {
                continueLoop = false;
                if (streamToGarage(mainStreet, garage, ref garageAwaits))
                    continueLoop = true;
                if (streamToGarage(alley, garage, ref garageAwaits))
                    continueLoop = true;
            } while (continueLoop);

            displayStackAndWait(garage);        
            
        }
    }
}
