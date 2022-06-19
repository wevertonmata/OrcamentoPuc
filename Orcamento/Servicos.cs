using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.serv
{
    public class Servicos
    {
        private static int servicosCriados;
        private String codigo;
        private String nome;
        private String descricao;
        private double valorMateria;
        private int horaDeTrabalho;

        public Servicos(String codigo, String nome, String descricao, double valorMateria, int horaDeTrabalho)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.descricao = descricao;
            this.valorMateria = valorMateria;
            this.horaDeTrabalho = (horaDeTrabalho * 5);
            servicosCriados += 1;
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

        public double getValorDaMateria()
        {
            return valorMateria;
        }

        public void setValorDaMateria(double valor)
        {
            this.valorMateria = valor;
        }

        public static int clienteCriados()
        {
            return servicosCriados;
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
            return "{Codigo = " + codigo + ", Nome='" + nome + ", Descrição='" + descricao + '\'' +
                    ", Valor Da Materia = " + valorMateria + ", Valor da Hora De Trabalho=" + horaDeTrabalho + '}';
        }
    }
}
