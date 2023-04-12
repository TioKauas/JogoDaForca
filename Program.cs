using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = new string[]
            {
                "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA",
                "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ",
                "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA",
                "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA",
                "MANGA", "MARACUJÁ", "MURICI", "PEQUI",
                "PITANGA", "PITAYA", "SAPOTI", "TANGERINA",
                "UMBU", "UVA", "UVAIA"
            };

            Random rnd = new Random();
            string palavra = palavras[rnd.Next(0, 29)];

            Console.WriteLine(palavra);

            char[] palavraChars = palavra.ToCharArray();

            char[] palavraLetras = Enumerable.Repeat('_', palavra.Length).ToArray();


            int erros = 0;
            bool acertou = false;

            while (erros < 5 && !acertou)
            {
                Grafico(erros);

                Console.WriteLine(string.Join(" ", palavraLetras));

                Console.Write("Digite uma letra: ");
                char letra = Console.ReadKey().KeyChar;
                letra = char.ToUpper(letra);

                Console.WriteLine();

                bool letraEncontrada = false;
                for (int i = 0; i < palavraChars.Length; i++)
                {
                    if (palavraChars[i] == letra)
                    {
                        palavraLetras[i] = letra;
                        letraEncontrada = true;
                    }
                }

                if (!letraEncontrada)
                {
                    erros++;
                    Console.Write($"\nA letra '{letra}' não está na palavra. Erros: {erros}/5");
                    Console.ReadKey();
                }

                if (palavraChars.SequenceEqual(palavraLetras))
                {
                    acertou = true;
                    Console.Write($"\nParabéns, você acertou a palavra '{palavra}'!");
                    Console.ReadKey();
                }
            }

            if (!acertou)
            {
                Console.WriteLine($"\nVocê errou 5 vezes. A palavra correta era '{palavra}'.");
            }
        }

        private static void Grafico(int erros)
        {
            Console.Clear();

            Console.WriteLine("****************");
            Console.WriteLine("* Jogo de Forca *");
            Console.WriteLine("****************");

            Console.WriteLine();

            string cabecaDoBoneco = erros >= 1 ? " o " : " ";
            string bracoEsquerdo = erros >= 3 ? "/" : " ";
            string tronco = erros >= 2 ? "x" : " ";
            string troncoBaixo = erros >= 2 ? " x " : " ";
            string bracoDireito = erros >= 3 ? @"\" : " ";
            string pernas = erros >= 4 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
        }
    }
}