//Eberle José dos Santos Neto - CC4M
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;
 
    public class ProgramaAgenda
    {
        public Node ini;
        public Node fim;
        public ProgramaAgenda()
        {
            ini = null;
            fim = null;
        }

        public void Add(Contato contato)
        {
            var newNode = new Node(contato);
            if (ini == null)
            {
                ini = newNode;
            }
            else
            {
                fim.pro = newNode;
            }
            fim = newNode;
            newNode.pro = ini;
        }

        //Remover Contato da Agenda:
        public void Remover(Contato contato)
        {
            if(ini == null)
            {
                Console.Write("Lista vazia!");
            }
            else
            {
                var atual = ini;
                var anterior = ini;
                do
                {
                    if (atual.dados == contato)
                    {
                        if (atual == ini)
                        {
                            if(atual.dados == ini.pro.dados)
                            {
                                ini = null;
                                atual = null;
                            }
                            else
                            {
                                ini = atual.pro;
                                fim.pro = atual.pro;
                                atual = null;
                            }
                            break;
                        }
                        else
                        {
                            anterior.pro = atual.pro;
                            if(atual == fim)
                            {
                                fim = anterior;
                            }
                            atual = null;
                            break;
                        }
                    }
                    else
                    {
                        anterior = atual;
                        atual = atual.pro;
                    }
                } while (atual != ini);
            }
        }

//Mostrar Contatos da Agenda
        public string PrintString()
        {
            string resp = null;
            if (ini == null)
            {
                resp = "Agenda Sem COntatos:";
            }

            else
            {
                var aux = ini;
                do
                {
                    resp = resp + $"NOME: [{aux.dados.getNome()}] EMAIL: [{aux.dados.getEmail()}] TEL: [{aux.dados.getTelefone()}]\n";
                    aux = aux.pro;
                } while (aux != ini);
            }
            return resp;
        }
        
                // Salvar Contatos da Agenda
        public void SalvarArquivo()
        {
            StreamWriter x;

            Console.Clear();

            x = File.CreateText("Agenda.TXT");

            string list = this.PrintString();

            x.WriteLine(list);

            x.Close();
        }

        //Listar Contatos da Agenda
        public List<Contato> Listar()
        {
            List<Contato> contatos = new List<Contato>();
            if (ini == null)
            {
                Console.Write("Agenda Vazia.");
            }
            var aux = ini;

            do
            {
                contatos.Add(aux.dados);
                aux = aux.pro;
            } while (aux != ini);
            return contatos;
        }
    
        

        //Editar Contato existente da agenda:
        public void Editar(Contato contato)
        {
            Console.WriteLine("Adicionar novo Nome para o Contato:\n");
            var nome = Console.ReadLine();
            Console.WriteLine("Adicionar novo Email para o Contato\n");
            var email = Console.ReadLine();
            Console.WriteLine("Adicionar Novo Numero para o Contato:");
            var telefone = Console.ReadLine();
            contato.EditarContato(nome, email, telefone);
        }

        //Mostrar Contatos da Agenda
        public void Print()
        {
            if (ini == null)
            {
                Console.Write("Agenda Vazia.\n");
            }

            else
            {
                var aux = ini;

                do
                {
                    Console.Write($"NOME: [{aux.dados.getNome()}] EMAIL: [{aux.dados.getEmail()}] TEL: [{aux.dados.getTelefone()}]\n");
                    aux = aux.pro;
                } while (aux != ini);
            }
        }
        
        private static Contato DesenharMenu(List<Contato> items)
        {
            int index = 0;
            bool enter = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Selecionar Contato para Remoção:\n");
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(items[i].getNome());
                    }
                    else
                    {
                        Console.WriteLine(items[i].getNome());
                    }
                    Console.ResetColor();
                }
                ConsoleKeyInfo ckey = Console.ReadKey();

                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == items.Count - 1)
                    {
                        index = 0; 
                    }
                    else { index++; }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = items.Count - 1; 
                    }
                    else { index--; }
                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    enter = true;
                }
                else if (ckey.Key == ConsoleKey.Escape)
                {
                    return null;
                }
            } while (!enter);
            Console.Clear();
            return items[index];
        }

        //Remover Contato da Agenda
        public static void ConsoleRemover(ProgramaAgenda lista)
        {
            List<Contato> menuItems = lista.Listar();
            bool removeu = false;
            while (!removeu)
            {
                Contato selectedMenuItem = DesenharMenu(menuItems);
                if (selectedMenuItem != null)
                {
                    lista.Remover(selectedMenuItem);
                    Console.WriteLine("Contato Excluido:");
                    removeu = true;
                }
                else if (selectedMenuItem == null)
                {
                    Console.Clear();
                    removeu = true;
                }
            }
        }

        public static void ConsoleEditar(ProgramaAgenda lista)
        {
            List<Contato> menuItems = lista.Listar();
            bool editou = false;
            Console.CursorVisible = false;
            while (!editou)
            {
                Contato selectedMenuItem = DesenharMenu(menuItems);
                if (selectedMenuItem != null)
                {
                    lista.Editar(selectedMenuItem);
                    Console.WriteLine("Contato Editado:");
                    editou = true;
                }
                else if (selectedMenuItem == null)
                {
                    Console.Clear();
                    editou = true;
                }
            }
        }
    }