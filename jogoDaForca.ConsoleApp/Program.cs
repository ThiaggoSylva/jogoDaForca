using System.Security.Cryptography;
using System.Globalization;
using System.Text;

namespace jogoDaForca.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            ExibirCabecalho();

            string dificuldade = EscolherDificuldade();

            string palavraAleatoria = EscolherPalavraAleatoria(dificuldade);

            char[] letrasAcertadas = PreencherLetrasAcertadas(palavraAleatoria);

            ExecutarTentativas(letrasAcertadas, palavraAleatoria);

            if (!JogadorDesejaContinuar())
                break;
        }
    }

    static void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("        JOGO DA FORCA");
        Console.WriteLine("---------------------------------");
    }

    // DESAFIO 3
    static string EscolherDificuldade()
    {
        Console.WriteLine("Escolha a dificuldade:");
        Console.WriteLine("1 - Fácil (Frutas)");
        Console.WriteLine("2 - Médio (Animais)");
        Console.WriteLine("3 - Difícil (Países)");

        Console.Write("Opção: ");
        string? opcao = Console.ReadLine();

        if (opcao == "2") return "animais";
        if (opcao == "3") return "paises";

        return "frutas";
    }

    static string EscolherPalavraAleatoria(string categoria)
    {
        string[] palavras;

        if (categoria == "animais")
        {
            palavras =
            [
                "ELEFANTE","CACHORRO","GATO","GIRAFA","TARTARUGA",
                "JACARÉ","LEOPARDO","MACACO","CANGURU"
            ];
        }
        else if (categoria == "paises")
        {
            palavras =
            [
                "BRASIL","ARGENTINA","PORTUGAL","CANADÁ",
                "FRANÇA","ALEMANHA","AUSTRALIA","JAPÃO"
            ];
        }
        else
        {
            palavras =
            [
                "ABACAXI","BANANA","MANGA","GOIABA","ACAI",
                "MELANCIA","LARANJA","TANGERINA","CAJÁ","MARACUJÁ", "PEQUÍ",
                "AÇAÍ","ARAÇÁ","MAMÃO","MAÇÃ"
            ];
        }

        int indice = RandomNumberGenerator.GetInt32(palavras.Length);

        return palavras[indice];
    }

    static char[] PreencherLetrasAcertadas(string palavra)
    {
        char[] letras = new char[palavra.Length];

        for (int i = 0; i < letras.Length; i++)
            letras[i] = '_';

        return letras;
    }

    static void ExecutarTentativas(char[] letrasAcertadas, string palavra)
    {
        bool jogadorAcertou = false;
        bool jogadorPerdeu = false;

        int erros = 0;

        List<char> letrasDigitadas = new();
        List<char> letrasErradas = new();

        string palavraNormalizada = RemoverAcentos(palavra);

        while (!jogadorAcertou && !jogadorPerdeu)
        {
            DesenharForca(erros);

            Console.WriteLine("Palavra: " + string.Join(" ", letrasAcertadas));
            Console.WriteLine("Erros: " + erros);
            Console.WriteLine("Letras erradas: " + string.Join(", ", letrasErradas));

            Console.Write("\nDigite uma letra ou palavra: ");
            string? tentativa = Console.ReadLine()?.ToUpper();

            if (string.IsNullOrWhiteSpace(tentativa))
                continue;

            tentativa = RemoverAcentos(tentativa);

            // DESAFIO 4
            if (tentativa.Length > 1)
            {
                if (tentativa == palavraNormalizada)
                {
                    letrasAcertadas = palavra.ToCharArray();
                    jogadorAcertou = true;
                }
                else
                {
                    Console.WriteLine("Palavra incorreta!");
                    erros++;
                }

                Console.ReadLine();
                continue;
            }

            char letra = tentativa[0];

            // DESAFIO 1
            if (letrasDigitadas.Contains(letra))
            {
                Console.WriteLine("Você já digitou essa letra!");
                Console.ReadLine();
                continue;
            }

            letrasDigitadas.Add(letra);

            bool encontrou = false;

            for (int i = 0; i < palavra.Length; i++)
            {
                char letraPalavra = RemoverAcentos(palavra[i].ToString())[0];

                // DESAFIO 2
                if (letra == letraPalavra)
                {
                    letrasAcertadas[i] = palavra[i];
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                erros++;
                letrasErradas.Add(letra);
            }

            jogadorAcertou = palavra == string.Join("", letrasAcertadas);
            jogadorPerdeu = erros == 6;

            if (jogadorAcertou)
            {
                Console.WriteLine("\nVocê venceu!");
                Console.WriteLine("A palavra era: " + palavra);
            }
            else if (jogadorPerdeu)
            {
                Console.WriteLine("\nVocê perdeu!");
                Console.WriteLine("A palavra era: " + palavra);
            }

            Console.ReadLine();
        }
    }

    static void DesenharForca(int erros)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("JOGO DA FORCA");
        Console.WriteLine("---------------------------------");

        string[] desenho =
        {
            @" ___________",
            @" |/        |",
            erros >= 1 ? @" |         O" : @" |",
            erros >= 3 ? @" |        /|\" :
            erros == 2 ? @" |         |" : @" |",
            erros >= 5 ? @" |        / \" :
            erros == 4 ? @" |        /" : @" |",
            @" |",
            @"_|____"
        };

        foreach (string linha in desenho)
            Console.WriteLine(linha);

        Console.WriteLine("---------------------------------");
    }

    static bool JogadorDesejaContinuar()
    {
        Console.Write("Deseja continuar? (S/N): ");
        string? opcao = Console.ReadLine()?.ToUpper();

        return opcao == "S";
    }

    // DESAFIO 2
    static string RemoverAcentos(string texto)
    {
        string normalizado = texto.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new();

        foreach (char c in normalizado)
        {
            if (Char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
}