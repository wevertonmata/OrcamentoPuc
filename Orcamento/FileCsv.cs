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

namespace Orcamento.FileSystemCsv
{
    public  class FileCsv
    {

        public void ReadClienteFile(List<Cliente> clientes)
        {
            try
            {
                var lines = File.ReadAllLines(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoCliente.csv");
                foreach (var line in lines)
                {
                    var values = line.Split(';'); 
                    if (values.Length == 7)
                    {
                        clientes.Add(new Cliente(values[0], values[1], values[2], values[3], values[4], values[5], int.Parse(values[6])));
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Esse arquivo não pode ser lido.");
                Console.WriteLine(e.Message);
            }
        }

        public void AppendToClienteFile(Cliente clientes)
        {
            try
            {
                File.AppendAllText(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoCliente.csv", $"{clientes.getNome()};{clientes.getNomeDaEmpresa()};{clientes.getEndereco()};" +
                    $"{clientes.getCpfCNPJ()};{clientes.getTelefone()};{clientes.getEmail()};{clientes.getDistancia()}\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("Esse arquivo não pode ser escrito.");
                Console.WriteLine(e.Message);
            }

        }

        public void ReadServicoFile(List<Servicos> servicos)
        {
            try
            {
                var lines = File.ReadAllLines(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoServico.csv");
                foreach (var line in lines)
                {
                    var values = line.Split(';');
                    if (values.Length == 5) {
                    
                        servicos.Add(new Servicos(values[0], values[1], values[2], double.Parse(values[3]), int.Parse(values[4])));
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Esse arquivo não pode ser lido.");
                Console.WriteLine(e.Message);
            }
        }

        public void AppendToServicoFile(Servicos servicos)
        {
            try
            {
                File.AppendAllText(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoServico.csv", $"{servicos.getCodigo()};{servicos.getNome()};{servicos.getDescricao()};" +
                    $"{servicos.getValorDaMateria()};{servicos.getHoraDeTrabalho()}\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("Esse arquivo não pode ser escrito.");
                Console.WriteLine(e.Message);
            }

        }
 
        public void ReadOrcamentoFile(List<Cliente> clientes, List<Servicos> servicos, List<Orcamentario> orcamento)
        {
            try
            {
                var lines = File.ReadAllLines(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoOrcamento.csv");
                foreach (var line in lines)
                {
                    var values = line.Split(';');
                    if (values.Length == 5)
                    {

                        Cliente cli;
                        Servicos serv;

                        foreach (var cliente in clientes)
                        {
                            if(cliente.getCpfCNPJ() == values[1])
                            {
                                cli = cliente;

                                foreach (var servico in servicos)
                                {
                                    if (servico.getCodigo() == values[0])
                                    {
                                        serv = servico;
                                        orcamento.Add(new Orcamentario(serv, cli, values[2], double.Parse(values[3]), DateTime.Parse(values[4])));
                                    }
                                }

                            }
                        }    
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Esse arquivo não pode ser lido.");
                Console.WriteLine(e.Message);
            }
        }
 
        public void AppendToOrcamentoFile(Orcamentario orcamento)
        {
            try
            {
                File.AppendAllText(@"C:\Users\wever\source\repos\OrcamentoPuc\Orcamento\bancoOrcamento.csv", $"{orcamento.getProduto().getCodigo()};{orcamento.getCliente().getCpfCNPJ()};{orcamento.getObservacao()};{orcamento.getValorTotal()};{orcamento.getData()}\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("Esse arquivo não pode ser escrito.");
                Console.WriteLine(e.Message);
            }

        }
     

        //
    }
}
