//Eberle José dos Santos Neto - CC4M
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


    public class Node
    {
        public Contato dados;
        public Node pro;

        public Node(Contato contato)
        {
            dados = contato;
            pro = null;
        }
    }


