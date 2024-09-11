using System;
using System.Collections.Generic;

class JogoDaForca
{
    static void Main()
    {
        string[] palavras = { "computador", "programacao", "csharp", "tecnologia", "software" };
        Random random = new Random();
        string palavraSecreta = palavras[random.Next(0, palavras.Length)];
        char[] letrasDescobertas = new char[palavraSecreta.Length];
        for (int i = 0; i < letrasDescobertas.Length; i++)
        {
            letrasDescobertas[i] = '_';
        }

        int tentativas = 6;
        List<char> letrasChutadas = new List<char>();
        bool venceu = false;

        while (tentativas > 0 && !venceu)
        {
            Console.Clear();
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine($"Tentativas restantes: {tentativas}");
            Console.WriteLine("Palavra: " + new string(letrasDescobertas));
            Console.WriteLine("Letras já chutadas: " + string.Join(", ", letrasChutadas));
            
            Console.Write("Digite uma letra: ");
            char chute = char.ToLower(Console.ReadKey().KeyChar);

            if (letrasChutadas.Contains(chute))
            {
                Console.WriteLine("\nVocê já chutou essa letra!");
                continue;
            }

            letrasChutadas.Add(chute);

            if (palavraSecreta.Contains(chute))
            {
                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    if (palavraSecreta[i] == chute)
                    {
                        letrasDescobertas[i] = chute;
                    }
                }
            }
            else
            {
                tentativas--;
            }

            if (!new string(letrasDescobertas).Contains('_'))
            {
                venceu = true;
            }
        }

        Console.Clear();
        if (venceu)
        {
            Console.WriteLine($"Parabéns! Você adivinhou a palavra: {palavraSecreta}");
        }
        else
        {
            Console.WriteLine($"Você perdeu! A palavra era: {palavraSecreta}");
        }
    }
}
