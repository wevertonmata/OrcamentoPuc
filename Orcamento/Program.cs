using Orcamento.cliente;
using Orcamento.FileSystemCsv;
using Orcamento.orc;
using Orcamento.serv;


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
                Console.WriteLine("=-=-= MENU PRINCIPAL =-=-=");
                Console.WriteLine("  0 - Menu Clientes");
                Console.WriteLine("  1 - Menu Serviços");
                Console.WriteLine("  2 - Menu Orçamentos");
                Console.WriteLine("  3 - Sair do Sistema");
                Console.WriteLine("=-=-=-=-=-==-=-=-=-=-=-=-=");

                Console.WriteLine("--> Escolha uma das opções: ");
                string opstr = Console.ReadLine();

                while (VerificarCampoVazio(opstr))
                {
                    opstr = Console.ReadLine();
                }
                int op = int.Parse(opstr);

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

        public static bool VerificarCPF(List<Cliente> clientes, String cpf)
        {

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

        public static bool VerificarCampoVazio(String value)
        {

            if (value == null || value == "")
            {
                Console.WriteLine("Campo Vazio! Tente novamente:");
                return true;
            }

            return false;
        }

        public static void cadastrarServico(List<Servicos> servicos)
        {
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

        public static void cadastrarCliente(List<Cliente> clientes)
        {
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

        public static void cadastrarOrcamento(List<Cliente> clientes, List<Servicos> servicos, List<Orcamentario> orcamentos)
        {
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
                string opstr = Console.ReadLine();

                while (VerificarCampoVazio(opstr))
                {
                    opstr = Console.ReadLine();
                }

                int z = int.Parse(opstr);

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
                            string op = Console.ReadLine();

                            while (VerificarCampoVazio(op))
                            {
                                op = Console.ReadLine();
                            }

                            int codOrcamento = int.Parse(op);

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
                        DeleteOrcamento(orcamentos);
                        break;
                    case 3:
                        EditarOrcamento(orcamentos);
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
            Console.WriteLine("2 - Excluir Serviços");
            Console.WriteLine("3 - Editar Serviços");


            Console.WriteLine("Escolha uma das opções do serviços:");
            string opstr = Console.ReadLine();

            while (VerificarCampoVazio(opstr))
            {
                opstr = Console.ReadLine();
            }

            int y = int.Parse(opstr);

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
                    DeleteServico(servicosDatabase);
                    break;
                case 3:
                    EditarServico(servicosDatabase);
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
            string opstr = Console.ReadLine();

            while (VerificarCampoVazio(opstr))
            {
                opstr = Console.ReadLine();
            }

            int x = int.Parse(opstr);


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
                    DeleteCliente(clienteDatabase);
                    break;
                case 3:
                    EditarCliente(clienteDatabase);
                    break;
            }
        }

        public static void DeleteOrcamento(List<Orcamentario> orcamentos)
        {

            FileCsv csv = new FileCsv();

            for (int i = 0; i < orcamentos.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - Serviço: " + orcamentos[i].getProduto().getNome() + "| Cliente: " + orcamentos[i].getCliente().getNome() + "| Data: " + orcamentos[i].getData());
            }
            Console.WriteLine("Escolha uma dos orçamentos:");
            int cod = int.Parse(Console.ReadLine());

            orcamentos.RemoveAt(cod);


            File.Delete(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoOrcamento.csv");

            foreach (Orcamentario orcamento in orcamentos)
            {
                csv.AppendToOrcamentoFile(orcamento);
            }
            Console.Clear();
        }

        public static void DeleteServico(List<Servicos> servicos)
        {

            FileCsv csv = new FileCsv();

            for (int i = 0; i < servicos.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - Serviço: " + servicos[i].getNome());
            }
            Console.WriteLine("Escolha uma dos serviços:");
            int cod = int.Parse(Console.ReadLine());

            servicos.RemoveAt(cod);


            File.Delete(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoServico.csv");

            foreach (Servicos servico in servicos)
            {
                csv.AppendToServicoFile(servico);
            }
            Console.Clear();
        }

        public static void DeleteCliente(List<Cliente> clientes)
        {

            FileCsv csv = new FileCsv();

            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - Cliente: " + clientes[i].getNome());
            }
            Console.WriteLine("Escolha uma dos clientes:");
            int cod = int.Parse(Console.ReadLine());

            clientes.RemoveAt(cod);


            File.Delete(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoCliente.csv");

            foreach (Cliente cliente in clientes)
            {
                csv.AppendToClienteFile(cliente);
            }
            Console.Clear();

        }

        public static void EditarCliente(List<Cliente> clientes)
        {

            FileCsv csv = new FileCsv();

            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - Cliente: " + clientes[i].getNome());
            }
            Console.WriteLine("Escolha uma dos clientes:");
            string opstr = Console.ReadLine();

            while (VerificarCampoVazio(opstr))
            {
                opstr = Console.ReadLine();
            }

            int cod = int.Parse(opstr);

            
            Console.WriteLine(">>> 0 - Nome da Empresa: " + clientes[cod].getNomeDaEmpresa());
            Console.WriteLine(">>> 1 - Nome: " + clientes[cod].getNome());
            Console.WriteLine(">>> 2 - Endereço: " + clientes[cod].getEndereco());
            Console.WriteLine(">>> 3 - CPF/CNPJ: " + clientes[cod].getCpfCNPJ());
            Console.WriteLine(">>> 4 - Telefone: " + clientes[cod].getTelefone());
            Console.WriteLine(">>> 5- Email: " + clientes[cod].getEmail());
            Console.WriteLine(">>> 6 - Distância: " + clientes[cod].getDistancia());

            Console.WriteLine("Qual campo deseja editar?");
            string editstr = Console.ReadLine();

            while (VerificarCampoVazio(editstr))
            {
                editstr = Console.ReadLine();
            }
            int edit = int.Parse(editstr);

            switch (edit)
            {
                case 0:
                    Console.WriteLine("Nome da empresa:");
                    String nomeEmp = Console.ReadLine();

                    while (VerificarCampoVazio(nomeEmp))
                    {
                        nomeEmp = Console.ReadLine();
                    }
                    clientes[cod].setNomeDaEmpresa(nomeEmp);
                    break;
                case 1:
                    Console.WriteLine("Nome:");
                    String nome = Console.ReadLine();

                    while (VerificarCampoVazio(nome))
                    {
                        nome = Console.ReadLine();
                    }
                    clientes[cod].setNome(nome);
                    break;
                case 2:
                    Console.WriteLine("Endereço:");
                    String endereco = Console.ReadLine();

                    while (VerificarCampoVazio(endereco))
                    {
                        endereco = Console.ReadLine();
                    }
                    clientes[cod].setEndereco(endereco);
                    break;
                case 3:
                    Console.WriteLine("CPF/CNPJ:");
                    String cpfCnpj = Console.ReadLine();

                    while (VerificarCampoVazio(cpfCnpj))
                    {
                        cpfCnpj = Console.ReadLine();
                    }
                    clientes[cod].setCpfCNPJ(cpfCnpj);
                    break;
                case 4:
                    Console.WriteLine("Telefone:");
                    String telefone = Console.ReadLine();

                    while (VerificarCampoVazio(telefone))
                    {
                        telefone = Console.ReadLine();
                    }
                    clientes[cod].setTelefone(telefone);
                    break;
                case 5:
                    Console.WriteLine("Email:");
                    String email = Console.ReadLine();

                    while (VerificarCampoVazio(email))
                    {
                        email = Console.ReadLine();
                    }
                    clientes[cod].setEmail(email);
                    break;
                case 6:
                    Console.WriteLine("Distância:");
                    String distancia = Console.ReadLine();

                    while (VerificarCampoVazio(distancia))
                    {
                        distancia = Console.ReadLine();
                    }
                    clientes[cod].setDistancia(int.Parse(distancia));
                    break;

            }

            File.Delete(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoCliente.csv");

            foreach (Cliente cliente in clientes)
            {
                csv.AppendToClienteFile(cliente);
            }
            Console.Clear();

        }

        public static void EditarServico(List<Servicos> servicos)
        {

            FileCsv csv = new FileCsv();

            for (int i = 0; i < servicos.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - Serviço: " + servicos[i].getNome());
            }
            Console.WriteLine("Escolha uma dos serviços:");
            string opstr = Console.ReadLine();

            while (VerificarCampoVazio(opstr))
            {
                opstr = Console.ReadLine();
            }

            int cod = int.Parse(opstr);

            Console.WriteLine(">>> 0 - Código: " + servicos[cod].getCodigo());
            Console.WriteLine(">>> 1 - Nome: " + servicos[cod].getNome());
            Console.WriteLine(">>> 2 - Descrição: " + servicos[cod].getDescricao());
            Console.WriteLine(">>> 3 - Valor Da Materia: " + servicos[cod].getValorDaMateria());
            Console.WriteLine(">>> 4 - Horas de Trabalho: " + servicos[cod].getHoraDeTrabalho());

            Console.WriteLine("Qual campo deseja editar?");

            string editstr = Console.ReadLine();

            while (VerificarCampoVazio(editstr))
            {
                editstr = Console.ReadLine();
            }
            int edit = int.Parse(editstr);

            switch (edit)
            {
                case 0:
                    Console.WriteLine("Codigo:");
                    String codigo = Console.ReadLine();

                    while (VerificarCampoVazio(codigo))
                    {
                        codigo = Console.ReadLine();
                    }
                    servicos[cod].setCodigo(codigo);
                    break;
                case 1:
                    Console.WriteLine("Nome:");
                    String nome = Console.ReadLine();

                    while (VerificarCampoVazio(nome))
                    {
                        nome = Console.ReadLine();
                    }
                    servicos[cod].setNome(nome);
                    break;
                case 2:
                    Console.WriteLine("Descrição:");
                    String desc = Console.ReadLine();

                    while (VerificarCampoVazio(desc))
                    {
                        desc = Console.ReadLine();
                    }
                    servicos[cod].setDescricao(desc);
                    break;
                case 3:
                    Console.WriteLine("Valor Da Materia:");
                    String valorMateria = Console.ReadLine();

                    while (VerificarCampoVazio(valorMateria))
                    {
                        valorMateria = Console.ReadLine();
                    }
                    servicos[cod].setValorDaMateria(double.Parse(valorMateria));
                    break;
                case 4:
                    Console.WriteLine("Horas de Trabalho:");
                    String horas = Console.ReadLine();

                    while (VerificarCampoVazio(horas))
                    {
                        horas = Console.ReadLine();
                    }
                    servicos[cod].setHoraDeTrabalho(int.Parse(horas));
                    break;
            }

            File.Delete(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoServico.csv");

            foreach (Servicos servico in servicos)
            {
                csv.AppendToServicoFile(servico);
            }
            Console.Clear();

        }

        public static void EditarOrcamento(List<Orcamentario> orcamentos)
        {

            FileCsv csv = new FileCsv();

            for (int i = 0; i < orcamentos.Count; i++)
            {
                Console.WriteLine(">>> " + i + " - Serviço: " + orcamentos[i].getProduto().getNome() + "| Cliente: " + orcamentos[i].getCliente().getNome() + "| Data: " + orcamentos[i].getData());
            }
            Console.WriteLine("Escolha uma dos orçamentos:");
            string opstr = Console.ReadLine();

            while (VerificarCampoVazio(opstr))
            {
                opstr = Console.ReadLine();
            }

            int cod = int.Parse(opstr);

            Console.WriteLine(">>> 0 - Observação: " + orcamentos[cod].getObservacao());

            Console.WriteLine("Qual campo deseja editar?");

            string editstr = Console.ReadLine();

            while (VerificarCampoVazio(editstr))
            {
                editstr = Console.ReadLine();
            }
            int edit = int.Parse(editstr);

            switch (edit)
            {
                case 0:
                    Console.WriteLine("Observações:");
                    String obs = Console.ReadLine();

                    while (VerificarCampoVazio(obs))
                    {
                        obs = Console.ReadLine();
                    }
                    orcamentos[cod].setObservacao(obs);
                    break;
            }

                    File.Delete(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoOrcamento.csv");

            foreach (Orcamentario orcamento in orcamentos)
            {
                csv.AppendToOrcamentoFile(orcamento);
            }
            Console.Clear();

        }
        
        //
    }
}
