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
        private int quantidade;
        private double valorTotal;
        private  DateTime data;
        private String observacao;

        public Orcamentario(Servicos servico, Cliente cliente, String observacao)
        {
            this.servico = servico;
            this.cliente = cliente;
            this.data = DateTime.Now;
            this.observacao = observacao;
            double custoDeInstalacao = cliente.getDistancia() * 3.8;
            double custoDeContas = 480;
            this.valorTotal = custoDeContas + servico.getValorDaMateria() + servico.getHoraDeTrabalho() + custoDeInstalacao;

        }

        public Servicos getIdProduto()
        {
            return servico;
        }

        public void setIdProduto(Servicos servico)
        {
            this.servico = servico;
        }

        public Cliente getIdCliente()
        {
            return cliente;
        }

        public void setIdCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public int getQuantidade()
        {
            return quantidade;
        }

        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
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


        public String toString()
        {
            return "Orçamento [" +
                    "Serviço = {" + servico.toString() +
                    "} , Cliente = {" + cliente.toString() +
                    "} , Valor Total = R$" + valorTotal +
                    ", Data = " + data + '\'' +
                    ", Observacao = " + observacao + '\'' + ']';
        }

    }
}
