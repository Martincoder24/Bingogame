using System;
using System.Threading;

namespace Lottobollar
{
    class Program
    {
        static void Main(string[] args)
        {

            int slumpTal; //Deklarer en variabel för slumpagenererade tal.
            int count = 0;//Visar hur många matchningar användaren får.

            int[] slumpVektor = new int[10];//Skapar en vektor som har plats för 10 slumpTal.
            
            int[] lottoNummer = new int[10];//Skapar en vektor som har plats för 10 inmatade tal av användaren.

            Console.WriteLine("Hej och välkommen till lottoprogrammet!");
            Console.WriteLine("Du ska nu välja 10 separata nummer till dagens lottodragning som ligger i spannet mellan 1-25.");
            for(int i = 0; i < lottoNummer.Length; i++)//For-loop där användaren matar in 10st int variabler i vektorn.
            {
                bool invalidNumber = true;//För att try-catch-loopen skall nollställas vid varje lyckad inmatning.
                do//Try-catch-loop som ska se till att användaren matar in en siffra av datatypen int.
                {   
                    Console.WriteLine();
                    Console.WriteLine("Lottonummer {0}: Mata in ett nummer mellan 1-25.",  i+1);
                    Console.WriteLine();
                    try//Används för att felhantera ifall användarens inmatning inte är en siffra.
                    {
                        lottoNummer[i] = int.Parse(Console.ReadLine());
                        invalidNumber = false; //Bryter try-catch-loopen vid korrekt inmatat värde.
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Du måste välja ett nummer!");
                    }
                } while (invalidNumber);

                if(lottoNummer[i] < 1 || lottoNummer[i] > 25)//If-sats som kontrollerar om det inmatade numret är mellan 1-25.
                {
                    Console.WriteLine("Du kan bara välja ett lottonummer mellan 1-25.");
                    i--;//Sänker postionen för att återgå till samma index i vektorn.
                    Console.WriteLine("Välj om ett lottonummer för nuvarande position.");
                }
            }
                Console.WriteLine();
                Console.WriteLine("Du har valt följande lottorad:");
                Console.WriteLine();
            foreach (int dinaNummer in lottoNummer)//För att skriva ut användarens valda lottorad
            {
                Console.Write(" |" + dinaNummer + "|");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Nu börjar lottodragningen! Är du redo så tryck valfri tangent:");
            Console.ReadLine();
            Console.WriteLine("Här är dagens lottorad:");
            Console.WriteLine();
            
            for (int i = 0;i < slumpVektor.Length; i++)//Matar in slumptalsvektorn med slumpgenererade tal.
            {
                slumpTal = new Random().Next(1, 26);
                slumpVektor[i] = slumpTal;//Ett slumptal 
            }
            foreach(int dagensRad in slumpVektor)
            {
                Thread.Sleep(1000);//Spänningsmoment för dagens rad. Ger ett nytt lottonummer med sekunds mellanrum.
                Console.Write(" |" + dagensRad + "|");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dags för rättning. Tryck på vafri tangent:");
            Console.ReadLine();
            
            for(int i = 0; i < lottoNummer.Length;i++)//Här testas varje position av användarens lottorad.
            {
                for(int j = 0; j < slumpVektor.Length; j++)//Med alla positioner i den slumpade lottoraden.
                {
                    if(lottoNummer[i] == slumpVektor[j])
                    {
                        count++; //Vid matching så ökas matchningsräknaren med 1.
                    }
                }            
            }
            if (count > 0)
            {
                Console.WriteLine("Grattis du hade {0} rätt!", count);
            }
            else
            {
                Console.WriteLine("Du fick tyvärr inga rätt idag.");
            }
            Console.WriteLine();
            Console.WriteLine("Tack för att du har använt lottoprogrammet.");
            Console.WriteLine("Välkommen åter!");
            Console.ReadKey();
        }
    }
}
