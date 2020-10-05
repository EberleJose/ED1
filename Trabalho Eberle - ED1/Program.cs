//Eberle José dos Santos Neto - CC4M
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;

    class MenuPrincipal
    {
        static void Main(string[] args)
        {
      bool fim = false;
      ProgramaAgenda lista = new ProgramaAgenda();

      do
      {
        Console.WriteLine("| Agenda Telefonica         |");
        Console.WriteLine("| Digite o Numero da Opcao  |");
        Console.WriteLine("| Adicionar Contato  : 1    |");
        Console.WriteLine("| Atualizar Contato  : 2    |");
        Console.WriteLine("| Mostrar Contatos   : 3    |");
        Console.WriteLine("| Remover Contato    : 4    |");
        Console.WriteLine("| Salvar Agenda      : 5    |");
        Console.WriteLine("| Finalizar Programa : 0    |");


        string opcao = Console.ReadLine();


        switch (opcao)
        {
          case "1":
            Contato contato = new Contato();
            contato.adicionarContato();
            lista.Add(contato);
            lista.SalvarArquivo();
            break;
            case "2":
            Console.WriteLine("Digite o Contato para Atualização: \n");
            ProgramaAgenda.ConsoleEditar(lista);
            break;
            case "3":
            Console.WriteLine();
            lista.Print();
            break;
          case "4":
            Console.WriteLine("Digite o Contato para Remoção: \n");
            ProgramaAgenda.ConsoleRemover(lista);
            break;
          case "5":
            lista.SalvarArquivo();
            break;
            case "0":
            Console.WriteLine("Finalizando Programa:\n");
            Console.WriteLine("Programa Finalizado:\n");
            fim = true;
            break;
        }
      } while (!fim);
        }
    }