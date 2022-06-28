using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orcamento.serv;
using Orcamento.cliente;

namespace Orcamento.orc
{
    public class Orcamentario
    {
        private Servicos servico;
        private Cliente cliente;
        private String observacao;
        private double valorTotal;
        private DateTime data;

        public Orcamentario(Servicos servico, Cliente cliente, String observacao)
        {
            this.servico = servico;
            this.cliente = cliente;
            this.data = DateTime.Now;
            this.observacao = observacao;
            double custoDeInstalacao = ((double)cliente.getDistancia()) * 3.8;
            double custoDeContas = 200.90;
            this.valorTotal = custoDeContas + ((double)servico.getValorDaMateria()) + ((double)(servico.getHoraDeTrabalho())*5.0) + custoDeInstalacao;

        }

        public Orcamentario(Servicos servico, Cliente cliente, String observacao, double valorTotal, DateTime data)
        {
            this.servico = servico;
            this.cliente = cliente;
            this.data = data;
            this.observacao = observacao;
            double custoDeInstalacao = ((double)cliente.getDistancia()) * 3.8;
            double custoDeContas = 480.00;
            this.valorTotal = valorTotal;

        }

        public Servicos getProduto()
        {
            return servico;
        }

        public void setProduto(Servicos servico)
        {
            this.servico = servico;
        }

        public Cliente getCliente()
        {
            return cliente;
        }

        public void setCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public double getValorTotal()
        {
            return valorTotal;
        }

        public void setValorTotal(double valorTotal)
        {
            this.valorTotal = valorTotal;
        }

        public String getObservacao()
        {
            return observacao;
        }

        public void setObservacao(String observacao)
        {
            this.observacao = observacao;
        }

        public DateTime getData()
        {
            return data;
        }

        public void setData(DateTime date)
        {
            this.data = data;
        }

        public String toString()
        {
            return "Orçamento [" +
                    "Serviço = {" + servico.toString() +
                    "} , Cliente = {" + cliente.toString() +
                    "} , Valor Total = R$" +  valorTotal.ToString() +
                    ", Data = " + data + '\'' +
                    ", Observacao = " + observacao + '\'' + ']';
        }

    }
}
