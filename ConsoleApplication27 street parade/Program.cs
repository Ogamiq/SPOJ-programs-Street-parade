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
        static bool pushFromMainRoadtoAlley(Stack<int> mainStreet, Stack<int> alley)
        {
            /* pushes one car form main road to alley
             * if a car with a value higher than the value of the car at the top of the alley enters a value,
             * it returns the info that this street parade can be sorted
             * */
            int currentValue;
            bool canBeSorted = true;
            int valueAtTheTopOfAlley = int.MaxValue;
            if(mainStreet.Count > 0)
            {

                if (alley.Count > 0)
                    valueAtTheTopOfAlley = alley.Peek();
                currentValue = mainStreet.Pop();
                if (currentValue > valueAtTheTopOfAlley)
                    canBeSorted = false;
                alley.Push(currentValue);
            }
            return canBeSorted;
        }


        static void Main(string[] args)
        {

            int[] carsInMainStreet = new int[] { 3, 2, 1, 7, 6};
            int[] carsInAlley = new int[] { };
            int[] carsInGarage = new int[] { };
            Stack<int> mainStreet = new Stack<int>(carsInMainStreet);
            Stack<int> alley = new Stack<int>(carsInAlley);
            Stack<int> garage = new Stack<int>(carsInGarage);
            int N = mainStreet.Count + alley.Count + garage.Count;

            bool continueInnerLoop;
            int garageAwaits = 1;
            bool canBeSorted = true;
            do
            {
                do
                {
                    continueInnerLoop = false;
                    if (streamToGarage(mainStreet, garage, ref garageAwaits))
                        continueInnerLoop = true;
                    if (streamToGarage(alley, garage, ref garageAwaits))
                        continueInnerLoop = true;
                } while (continueInnerLoop);
                canBeSorted = pushFromMainRoadtoAlley(mainStreet, alley);
                if (!canBeSorted)
                    Console.WriteLine("no");
                if (garage.Count == N)
                    Console.WriteLine("yes");
            } while (garage.Count != N && canBeSorted);
            displayStackAndWait(garage);       
        }
    }
}
