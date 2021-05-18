using System;
using System.Collections.Generic;
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = 
            new SerieRepositorio();
            
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listar();
						break;
					case "2":
						Inserir();
						break;
					case "3":
						Atualizar();
						break;
					case "4":
						Excluir();
						break;
					case "5":
						Visualizar();
						break;

					default:
						Console.WriteLine("Digite uma opção valida.");
                        break;
				}

                Console.WriteLine();
				Console.WriteLine("Aperte qualquer tecla para continuar.");
				Console.ReadKey();
				Console.Clear();

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar");
			Console.WriteLine("2- Inserir");
			Console.WriteLine("3- Atualizar");
			Console.WriteLine("4- Excluir");
			Console.WriteLine("5- Visualizar");
			Console.WriteLine("X- Finalizar");
			Console.WriteLine();

			return Console.ReadLine().ToUpper();
		}

        private static void Listar()
		{
            Console.Clear();
			Console.WriteLine("*** Listar ***");
            Console.WriteLine();

			IList<Serie> lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (Serie serie in lista)
			{
                string excluido = 
                    serie.RetornaExcluido() ? 
                    "*Excluído*" : 
                    "";
                
				Console.WriteLine(
                    $"#ID { serie.RetornarId() }: - { serie.RetornarTitulo() } { excluido }");
			}
		}

        private static void Inserir()
		{
            Console.Clear();
			Console.WriteLine("*** Inserir ***");
            Console.WriteLine();

			foreach (int i in System.Enum.GetValues(typeof(Genero)))
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
			
            Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static void Atualizar()
		{
            Console.Clear();
            Console.WriteLine("*** Atualizar ***");
            Console.WriteLine();
			Console.WriteLine("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in System.Enum.GetValues(typeof(Genero)))
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void Excluir()
		{
            Console.Clear();
            Console.WriteLine("*** Excluir ***");
            Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exlui(indiceSerie);
		}

        private static void Visualizar()
		{
            Console.Clear();
            Console.WriteLine("*** Visualizar ***");
            Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Serie serie = repositorio.RetornarPorId(indiceSerie);

			Console.WriteLine(serie);
		}
    }
}
