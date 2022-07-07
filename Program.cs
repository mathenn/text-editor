using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Você acessou o editor de textos");
            Console.WriteLine("");

            Console.WriteLine("Oque gostaria de realizar?");
            Console.WriteLine("");

            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Editar arquivo");
            Console.WriteLine("");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Sair(); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo que deseja abrir?");
            Console.WriteLine("");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Você acessou a opção: Editar.");
            Console.WriteLine("");

            Console.WriteLine("Digite seu texto abaixo. (ESC para sair)");
            string text = "";

            do
            {
            text += Console.ReadLine();
            text += Environment.NewLine;
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Onde deseja salvar seu arquivo?");
            Console.WriteLine("");

            var path =  Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Console.ReadLine();
            Menu();
        }

        static void Sair()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Obrigado por usar o editor de textos :)");
            Console.WriteLine("");
            System.Environment.Exit(0);
        }
    }
}