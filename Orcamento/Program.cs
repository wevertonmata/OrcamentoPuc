using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orcamento.serv;
using Orcamento.cliente;
using Orcamento.orc;
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


            Console.WriteLine("=======================================");
            Console.WriteLine("Seja Bem Vindo ao Sistema Orçamentário!");
            Console.WriteLine("=======================================");

            while (true)
            {
                Console.WriteLine("=-=-=-=-=-= MENU PRINCIPAL =-=-=-=-=-=-=");
                Console.WriteLine("0 - Cadastro/Exibir Clientes  ");
                Console.WriteLine("1 - Cadastro/Exibir Serviços  ");
                Console.WriteLine("2 - Cadastro/Exibir Orçamentos");
                Console.WriteLine("3 - Sair do Sistema           ");

                Console.WriteLine("--> Escolha uma das opções: ");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                         Console.Clear();
                         Console.WriteLine("=-========== MENU CLIENTE ===========-=");
                         Console.WriteLine("0 - Exibir Clientes");
                         Console.WriteLine("1 - Cadastro Clientes");

                         Console.WriteLine("Escolha uma das opções do cliente:");
                        
                        int x = int.Parse(Console.ReadLine());

                        switch (x)
                        {
                            case 0:
                                if (clienteDatabase.Count == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Não há clientes cadastrados.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    foreach (Cliente cliente in clienteDatabase)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(cliente.toString());
                                        Thread.Sleep(2000);

                                    }
                                }
                                break;
                            case 1:
                                cadastrarCliente(clienteDatabase);
                                break;
                        }
                        break;
                    case 1:
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
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                }
                                else
                                {
                                    foreach (Servicos servico in servicosDatabase)
                                    {
                                            Console.Clear();
                                            Console.WriteLine(servico.toString());
                                            Thread.Sleep(2000);
                                    }
                                }
                                break;
                            case 1:
                                cadastrarServico(servicosDatabase);
                                break;
                        }
                        break;
                    case 2:
                        if (clienteDatabase.Count == 0 || servicosDatabase.Count == 0)
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

                             Console.WriteLine("Escolha uma das opções do orçamento:");
                            
                            int z = int.Parse(Console.ReadLine());

                            switch (z)
                            {
                                case 0:
                                    if (orcamentosDatabase.Count == 0)
                                    {
                                         Console.Clear();
                                         Console.WriteLine("Não há orçamentos cadastrados.");
                                         Thread.Sleep(2000);
                                         Console.Clear();
                                    }
                                    else
                                    {
                                        foreach (Orcamentario orcamento in orcamentosDatabase)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(orcamento.toString());
                                            Thread.Sleep(2000);                        
                                            
                                        }
                                    }
                                    break;
                                case 1:
                                    cadastrarOrcamento(clienteDatabase, servicosDatabase, orcamentosDatabase);
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }

            }

        }
    public static void cadastrarCliente(List<Cliente> clientes)
    {

        Console.WriteLine("Nome da empresa:");
        String nomeDaEmpresa = Console.ReadLine();

        Console.WriteLine("Nome do responsável:");
        String nome = Console.ReadLine();

        Console.WriteLine("Endereço do cliente por extenso:");
        String endereco = Console.ReadLine();

        Console.WriteLine("CPF/CNPJ:");
        String cpfCnpj = Console.ReadLine();

        Console.WriteLine("Telefone (Ex: 31 98734-9684):");
        String telefone = Console.ReadLine();

        Console.WriteLine("E-mail:");
        String email = Console.ReadLine();

        Console.WriteLine("Distância do cliente relativo a sua localização: (Ex: 14, 20");
        int distancia = int.Parse(Console.ReadLine());

        clientes.Add(new Cliente(nome, nomeDaEmpresa, endereco, cpfCnpj, telefone, email, distancia));
            
            Console.Clear();
            Console.WriteLine("Cliente cadastrado com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();
        }

    public static void cadastrarServico(List<Servicos> servicos)
    {

        Console.WriteLine("Codigo do Serviço:");
        String codigo = Console.ReadLine();

        Console.WriteLine("Nome do Serviço:");
        String nome = Console.ReadLine();

        Console.WriteLine("Valor do Serviço (Ex: 1770.90):");
        double valor = Double.Parse(Console.ReadLine());

        Console.WriteLine("Descrição do Serviço:");
        String descricao = Console.ReadLine();

        Console.WriteLine("Horas de Serviço:");
        int horas = int.Parse(Console.ReadLine());

            
        servicos.Add(new Servicos(codigo, nome, descricao, valor, horas));
        Console.Clear();
        Console.WriteLine("Serviço cadastrado com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        }

    public static void cadastrarOrcamento(List<Cliente> clientes, List<Servicos> servicos, List<Orcamentario> orcamentos)
    {

            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - " + clientes[i].getNome());
            }
            Console.WriteLine("Escolha uma dos clientes:");
            int codCliente = int.Parse(Console.ReadLine());

            for (int i = 0; i < servicos.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - " + servicos[i].getNome());
            }
            Console.WriteLine("Escolha uma dos serviços:");
            int codServico = int.Parse(Console.ReadLine());

            Console.WriteLine("Observações do Serviço:");
            String obs = Console.ReadLine();

            Cliente cli = new Cliente(clientes[codCliente].getNome(), clientes[codCliente].getNomeDaEmpresa(),
                clientes[codCliente].getEndereco(), clientes[codCliente].getCpfCNPJ(), clientes[codCliente].getTelefone(),
                clientes[codCliente].getEmail(), clientes[codCliente].getDistancia());

            Servicos serv = new Servicos(servicos[codServico].getCodigo(), servicos[codServico].getNome(),
                servicos[codServico].getDescricao(), servicos[codServico].getValorDaMateria(), servicos[codServico].getHoraDeTrabalho());

            orcamentos.Add(new Orcamentario(serv, cli, obs));
            Console.Clear();
            Console.WriteLine("Orçamento cadastrado com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();
        }

    }
}
