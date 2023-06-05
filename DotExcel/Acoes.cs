using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotExcel
{


    class Acoes
    {
        public  List<Pessoa> FuncaoExcel()
        {
            DbAcesso d = new DbAcesso();
            Console.WriteLine("Carregando");
            string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "Book1.xlsx");
            Excel e = new Excel();
            Console.WriteLine(".");
            List<Pessoa> pessoas = e.LerXls(caminhoArquivo);
            d.SetPessoa(pessoas);
            Console.WriteLine(".");
            Console.WriteLine(".");

            return pessoas;

        }

        public  void ConsultaBd()
        {
            DbAcesso d = new DbAcesso();
            //Pessoa pessoa;
            List<Pessoa> Listapessoas = d.getPessoa();
            foreach (var pessoa in Listapessoas)
            {
                Console.WriteLine("id:" + pessoa.id);
                Console.WriteLine("nome" + pessoa.nome);
                Console.WriteLine("email" + pessoa.email);
            }
        }
        public  Pessoa getDetalhadoBd()
        {
            int id = -1;
            Pessoa updateP = new Pessoa();
            Console.WriteLine("Digite o ID da pessoa que você deseja obter detalhes:");
            id = Convert.ToInt32(Console.ReadLine());
            DbAcesso db = new DbAcesso();
            updateP = db.GetDetalhado(id); // Atribui os detalhes obtidos à instância de Pessoa

            return updateP;
        }
        public  void ConsultaTipos()
        {
            int escolha = 1;
            while (escolha > 0 && escolha <= 2)
            {
                Console.WriteLine("digite o tipo de consulta que você quer: \n1-) Consulta geral\n2-) Consulta de uma unica pessoa\n3-)Sair\n");
                escolha = Convert.ToInt32(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        ConsultaBd();
                        break;
                    case 2:
                        DbAcesso d = new DbAcesso();
                        getDetalhadoBd();
                        break;
                }
            }

        }
        public  void UpdateBd()
        {
            DbAcesso db = new DbAcesso();
            int escolha = 0;
            Pessoa p = new Pessoa();
            p = getDetalhadoBd();
            Console.WriteLine(p.id);
            Console.WriteLine(p.nome);
            Console.WriteLine(p.email);
            Console.WriteLine("deseja atualizar?\n digite 1 para sim");
            escolha = Convert.ToInt32(Console.ReadLine());
            if (escolha == 1)
            {
                Console.WriteLine("Digite o nome");
                p.nome = Console.ReadLine();
                Console.WriteLine("Digite o email");
                p.email = Console.ReadLine();
                db.Update(p);

            }
        }

    }
}