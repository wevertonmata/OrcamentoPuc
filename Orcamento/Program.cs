using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orcamento.serv;
using Orcamento.cliente;
using Orcamento.orc;
using Orcamento.FileSystemCsv;
using System.IO;


namespace Orcamento
{
    public class Orcamento
    {
        public static void Main(string[] args)
        {
            List<Cliente> clienteDatabase = new();
            List<Servicos> servicosDatabase = new();
            List<Orcamentario> orcamentosDatabase = new();
            
            FileCsv csv = new FileCsv();
            csv.ReadClienteFile(clienteDatabase);
            csv.ReadServicoFile(servicosDatabase);
            csv.ReadOrcamentoFile(clienteDatabase, servicosDatabase, orcamentosDatabase);

            Console.WriteLine("========================================");
            Console.WriteLine(" Seja Bem Vindo ao Sistema Orçamentário ");
            Console.WriteLine("========================================\n");
            

            while (true)
            {
                Console.WriteLine("=-=-=-=-=-= MENU PRINCIPAL =-=-=-=-=-=-=");
                Console.WriteLine("0 - Cadastro/Exibir Clientes  ");
                Console.WriteLine("1 - Cadastro/Exibir Serviços  ");
                Console.WriteLine("2 - Cadastro/Exibir Orçamentos");
                Console.WriteLine("3 - Sair do Sistema           ");
                Console.WriteLine("=-=-=-=-=-= -------------- =-=-=-=-=-=-=");

                Console.WriteLine("--> Escolha uma das opções: ");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        menuCliente(clienteDatabase); 
                        break;
                    case 1:
                        menuServico(servicosDatabase);
                        break;
                    case 2:
                        menuOrcamento(clienteDatabase, servicosDatabase, orcamentosDatabase);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }

            }

        }
   

    public static bool VerificarCPF(List<Cliente> clientes,String cpf) {

        foreach (Cliente cliente in clientes)
        {
            if (cpf == cliente.getCpfCNPJ())
            {
                Console.WriteLine("CPF já registrado! Tente outro:");
                return true;
            }
        }

        return false;
    }

    public static bool VerificarCodigo(List<Servicos> servicos, String cpf)
    {

        foreach (Servicos servico in servicos)
        {
            if (cpf == servico.getCodigo())
            {
                Console.WriteLine("Código já registrado! Tente outro:");
                return true;
            }
        }

        return false;
    }

    public static bool VerificarCampoVazio(String value){

        if (value == null || value == ""){
            Console.WriteLine("Campo Vazio! Tente novamente:");
            return true;
        }

        return false;
    }

    public static void cadastrarServico(List<Servicos> servicos){
            FileCsv csv = new FileCsv();

            Console.WriteLine("Codigo do Serviço:");
            String codigo = Console.ReadLine();

            while (VerificarCampoVazio(codigo))
            {
                codigo = Console.ReadLine();
            }

            while (VerificarCodigo(servicos, codigo))
            {
                codigo = Console.ReadLine();
            }

            Console.WriteLine("Nome do Serviço:");
            String nome = Console.ReadLine();

            while (VerificarCampoVazio(nome))
            {
                nome = Console.ReadLine();
            }

            Console.WriteLine("Valor do Serviço (Ex: 1770.90):");
            string valorstr = Console.ReadLine();

            while (VerificarCampoVazio(valorstr))
            {
                valorstr = Console.ReadLine();
            }

            double valor = Double.Parse(valorstr);

            Console.WriteLine("Descrição do Serviço:");
            String descricao = Console.ReadLine();

            while (VerificarCampoVazio(descricao))
            {
                descricao = Console.ReadLine();
            }

            Console.WriteLine("Horas de Serviço:");
            string horasStr = Console.ReadLine();

            while (VerificarCampoVazio(horasStr))
            {
                horasStr = Console.ReadLine();
            }

            int horas = int.Parse(horasStr);

            csv.AppendToServicoFile(new Servicos(codigo, nome, descricao, valor, horas));
            servicos.Add(new Servicos(codigo, nome, descricao, valor, horas));

            Console.Clear();
            Console.WriteLine("Serviço cadastrado com sucesso!");
            Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
            Console.ReadKey();
            Console.Clear();
    }

    public static void cadastrarCliente(List<Cliente> clientes){
        FileCsv csv = new FileCsv();

        Console.WriteLine("Nome da empresa:");
        String nomeDaEmpresa = Console.ReadLine();

        while (VerificarCampoVazio(nomeDaEmpresa))
        {
            nomeDaEmpresa = Console.ReadLine();
        }

        Console.WriteLine("Nome do responsável:");
        String nome = Console.ReadLine();

        while (VerificarCampoVazio(nome))
        {
            nome = Console.ReadLine();
        }

        Console.WriteLine("Endereço do cliente por extenso:");
        String endereco = Console.ReadLine();

        while (VerificarCampoVazio(endereco))
        {
            endereco = Console.ReadLine();
        }

        Console.WriteLine("CPF/CNPJ:");
        String cpfCnpj = Console.ReadLine();

        while (VerificarCampoVazio(cpfCnpj))
        {
            cpfCnpj = Console.ReadLine();
        }

        while (VerificarCPF(clientes, cpfCnpj))
        {
            cpfCnpj = Console.ReadLine();
        }

        Console.WriteLine("Telefone (Ex: 31 98734-9684):");
        String telefone = Console.ReadLine();

        while (VerificarCampoVazio(telefone))
        {
            telefone = Console.ReadLine();
        }

        Console.WriteLine("E-mail:");
        String email = Console.ReadLine();

        while (VerificarCampoVazio(email))
        {
              email = Console.ReadLine();
        }

        Console.WriteLine("Distância do cliente relativo a sua localização: (Ex: 14, 20");
        string distanciastr = Console.ReadLine();

         while (VerificarCampoVazio(distanciastr))
         {
            distanciastr = Console.ReadLine();
         }

        int distancia = int.Parse(distanciastr);

        csv.AppendToClienteFile(new Cliente(nome, nomeDaEmpresa, endereco, cpfCnpj, telefone, email, distancia));
        clientes.Add(new Cliente(nome, nomeDaEmpresa, endereco, cpfCnpj, telefone, email, distancia));

        Console.Clear();
        Console.WriteLine("Cliente cadastrado com sucesso!");
        Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
        Console.ReadKey();
        Console.Clear();
    }

    public static void cadastrarOrcamento(List<Cliente> clientes, List<Servicos> servicos, List<Orcamentario> orcamentos){
            FileCsv csv = new FileCsv();

            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - " + clientes[i].getNome());
            }
            Console.WriteLine("Escolha uma dos clientes:");
            string codClienteStr = Console.ReadLine();

            while (VerificarCampoVazio(codClienteStr))
            {
                codClienteStr = Console.ReadLine();
            }

            int codCliente = int.Parse(codClienteStr);

            for (int i = 0; i < servicos.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - " + servicos[i].getNome());
            }
            Console.WriteLine("Escolha uma dos serviços:");
            string codServicoStr = Console.ReadLine();

            while (VerificarCampoVazio(codServicoStr))
            {
                codServicoStr = Console.ReadLine();
            }

            int codServico = int.Parse(codServicoStr);

            Console.WriteLine("Observações do Serviço:");
            String obs = Console.ReadLine();

            while (VerificarCampoVazio(obs))
            {
                obs = Console.ReadLine();
            }

            Cliente cli = new Cliente(clientes[codCliente].getNome(), clientes[codCliente].getNomeDaEmpresa(),
                clientes[codCliente].getEndereco(), clientes[codCliente].getCpfCNPJ(), clientes[codCliente].getTelefone(),
                clientes[codCliente].getEmail(), clientes[codCliente].getDistancia());

            Servicos serv = new Servicos(servicos[codServico].getCodigo(), servicos[codServico].getNome(),
                servicos[codServico].getDescricao(), servicos[codServico].getValorDaMateria(), servicos[codServico].getHoraDeTrabalho());

            csv.AppendToOrcamentoFile(new Orcamentario(serv, cli, obs));
            orcamentos.Add(new Orcamentario(serv, cli, obs));

            Console.Clear();
            Console.WriteLine("Orçamento cadastrado com sucesso!");
            Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
            Console.ReadKey();
            Console.Clear();
        }

    public static void menuOrcamento(List<Cliente> clientes, List<Servicos> servicos, List<Orcamentario> orcamentos)
    {
        if (clientes.Count == 0 || servicos.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Aluno ou disciplina não cadastrado.");
            Thread.Sleep(2000);
            Console.Clear();
        }

        else
        {

            Console.Clear();
            Console.WriteLine("=-========= MENU ORÇARMENTOS ========-=");
            Console.WriteLine("0 - Exibir Orçamentos");
            Console.WriteLine("1 - Cadastro Orçamentos");
            Console.WriteLine("2 - Excluir Orçamentos");
            Console.WriteLine("3 - Editar Orçamentos");

            Console.WriteLine("Escolha uma das opções do orçamento:");

            int z = int.Parse(Console.ReadLine());

            switch (z)
            {
                case 0:
                    if (orcamentos.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Não há orçamentos cadastrados.");
                        Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
                        Console.ReadKey();
                        Console.Clear();
                        }
                    else
                    {
                        for (int i = 0; i < orcamentos.Count; i++)
                        {
                            Console.WriteLine(">>> " + i + " - Orçamento cliente: " + orcamentos[i].getCliente().getNome() + " | Data: " + orcamentos[i].getData());
                        }
                        Console.WriteLine("Escolha uma dos serviços:");
                        int codOrcamento = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine(orcamentos[codOrcamento].toString());
                        Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                case 1:
                    cadastrarOrcamento(clientes, servicos, orcamentos);
                    break;
                case 2:
                    DeleteLineOrcamento(clientes, servicos, orcamentos);
                    break;
                case 3:
                    //Editar
                    break;
                }
        }
    }

    public static void menuServico(List<Servicos> servicosDatabase)
    {
        Console.Clear();
        Console.WriteLine("=-========== MENU SERVIÇOS ==========-=");
        Console.WriteLine("0 - Exibir Serviços");
        Console.WriteLine("1 - Cadastro Serviços");

        Console.WriteLine("Escolha uma das opções do serviços:");
        int y = int.Parse(Console.ReadLine());

        switch (y)
        {
            case 0:
                if (servicosDatabase.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Não há serviços cadastrados.");
                    Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
                    Console.ReadKey();
                    Console.Clear();
                    }
                else
                {
                    for (int i = 0; i < servicosDatabase.Count; i++)
                    {
                        Console.WriteLine(">>> " + i + " - " + servicosDatabase[i].getNome());
                    }
                    Console.WriteLine("Escolha uma dos serviços:");
                    int codServico = int.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine(servicosDatabase[codServico].toString());
                    Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
                    Console.ReadKey();
                    Console.Clear();
                }
                break;
            case 1:
                cadastrarServico(servicosDatabase);
                break;
            case 2:
                //Excluir
                break;
            case 3:
                //Editar
                break;
            }
    }

    public static void menuCliente(List<Cliente> clienteDatabase)
    {
        Console.Clear();
        Console.WriteLine("=-========== MENU CLIENTE ===========-=");
        Console.WriteLine("0 - Exibir Clientes");
        Console.WriteLine("1 - Cadastro Clientes");
        Console.WriteLine("2 - Excluir Clientes");
        Console.WriteLine("3 - Editar Clientes");

        Console.WriteLine("Escolha uma das opções do cliente:");

        int x = int.Parse(Console.ReadLine());

        switch (x)
        {
        case 0:
            if (clienteDatabase.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há clientes cadastrados.");
                Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
                Console.ReadKey();
                Console.Clear();
                    }
            else
            {
                for (int i = 0; i < clienteDatabase.Count; i++)
                {
                    Console.WriteLine(">>> " + i + " - " + clienteDatabase[i].getNome());
                }
                Console.WriteLine("Escolha uma dos clientes:");
                int codCliente = int.Parse(Console.ReadLine());

                Console.Clear();
                Console.WriteLine(clienteDatabase[codCliente].toString());
                Console.WriteLine("\nPara voltar ao menu incial basta clicar qualquer botão.");
                Console.ReadKey();
                Console.Clear();

            }
            break;
        case 1:
            cadastrarCliente(clienteDatabase);
            break;
        case 2:
            
            break;
        case 3:
            //Editar
            break;
        }
    }

    /*
    public static void DeleteLineOrcamento(List<Cliente> clientes, List<Servicos> servicos, List<Orcamentario> orcamentos){
    
        FileCsv csv = new FileCsv();

        for (int i = 0; i < orcamentos.Count; i++)
        {
            Console.WriteLine(">>> " + i + " - Orçamento cliente: " + orcamentos[i].getCliente().getNome() + " | Data: " + orcamentos[i].getData());
        }
        Console.WriteLine("Escolha uma dos serviços:");
        int codOrc = int.Parse(Console.ReadLine());

        orcamentos.RemoveAt(codOrc);

        File.Delete(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoOrcamento.csv");

        File.Create(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoOrcamento.csv");

        foreach (Orcamentario orcamento in orcamentos)
        {
            csv.AppendToOrcamentoFile(orcamento);
        } 

    }
    */

        //
    }
}
