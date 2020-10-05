//Eberle José dos Santos Neto - CC4M
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;
public class Contato
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

        public string getNome()
        {
            return this.nome;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getTelefone()
        {
            return this.telefone;
        }

        //Adicionar Contato a Agenda
        public void adicionarContato()
        {
            Console.WriteLine("Adicionar Nome do contato:\n");
            this.nome = Console.ReadLine();
            Console.WriteLine("Adicionar Email do contato:\n");
            this.email = Console.ReadLine();
            Console.WriteLine("Adicionar Telefone do contato:\n");
            this.telefone = Console.ReadLine();
        }
        
        public void EditarContato(string nome = null, string email = null, string telefone = null)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
        }

    }

    