using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.serv
{
    public class Servicos
    {
        
        private String codigo;
        private String nome;
        private String descricao;
        private int valorMateria;
        private int horaDeTrabalho;

        public Servicos(String codigo, String nome, String descricao, int valorMateria, int horaDeTrabalho)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.descricao = descricao;
            this.valorMateria = valorMateria;
            this.horaDeTrabalho = horaDeTrabalho;
        }

        public String getCodigo()
        {
            return codigo;
        }

        public void setCodigo(String codigo)
        {
            this.codigo = codigo;
        }

        public String getNome()
        {
            return nome;
        }

        public void setNome(String nome)
        {
            this.nome = nome;
        }

        public String getDescricao()
        {
            return descricao;
        }

        public void setDescricao(String descricao)
        {
            this.descricao = descricao;
        }

        public int getValorDaMateria()
        {
            return valorMateria;
        }

        public void setValorDaMateria(int valor)
        {
            this.valorMateria = valor;
        }

     
        public int getHoraDeTrabalho()
        {
            return horaDeTrabalho;
        }

        public void setHoraDeTrabalho(int horaDeTrabalho)
        {
            this.horaDeTrabalho = horaDeTrabalho;
        }

        public String toString()
        {
            return "<=-=- Serviço -=-=> \nCódigo: " + codigo + "\nNome: " + nome + "\nDescrição: " + descricao +"\nValor Da Materia: R$" + valorMateria.ToString() + "\nValor da Hora De Trabalho: " + horaDeTrabalho;
        }
    }
}
