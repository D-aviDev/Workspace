using System;
using MRV_DIO.Series.Classes;

namespace MRV_DIO.Series
{
    class Program
    {
        static RepositorySeries repository = new RepositorySeries();
        static void Main(string[] args)
        {
            string userOption = GetOptionUser();

            while(userOption.ToUpper() != "X"){

                switch(userOption){
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetOptionUser();

            }
        }

        private static void ListSeries()
        {
            Console.WriteLine("1 - Listar séries:");
            Console.WriteLine();

            var list = repository.List();

            if(list.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in list)
			{
                var deleted = serie.ReturnDeleted();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.ReturnId(), serie.ReturnTitle(), (deleted ? "|Deleted|" : ""));
			}

        }

        private static void InsertSerie()
        {
            Console.WriteLine("2 - Inserir nova série:");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Digite o gênero dentre as opções acima: ");
			int inputGender = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string inputDescription = Console.ReadLine();

			var newSerie = new Serie(id: repository.NextId(),
										gender: (Gender)inputGender,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Insert(newSerie);
        }

        private static void UpdateSeries()
        {
			Console.Write("3 - Digite o id da série que deseja atualizar: ");
			int indexSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Digite o gênero dentre as opções acima: ");
			int inputGender = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string inputDescription = Console.ReadLine();

			var upSerie = new Serie(id: indexSerie,
										gender: (Gender)inputGender,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Update(indexSerie, upSerie);
        }

        private static void DeleteSerie()
        {
			Console.Write("4 - Digite o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			repository.Delete(indexSerie);
        }

        private static void ViewSeries()
        {
			Console.Write("5 - Digite o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			var serie = repository.ReturnById(indexSerie);

			Console.WriteLine(serie);

        }

        private static string GetOptionUser()
        {
            Console.WriteLine();
            Console.WriteLine("MRV|DIO.Séries Fornecendo o melhor contéudo para você!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            string userOption = Console.ReadLine().ToUpper();
            Console.Clear();
            return userOption;
        }
    }
}
