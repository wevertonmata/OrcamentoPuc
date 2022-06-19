using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.cliente
{
    public class Cliente
    {
        private String nome;
        private String nomeDaEmpresa;
        private String endereco;
        private String cpfCnpj;
        private String telefone;
        private String email;
        private int distancia;

        public Cliente(String nome, String nomeDaEmpresa, String endereco, String cpfCnpj, String telefone, String email, int distancia)
        {
            this.nome = nome;
            this.nomeDaEmpresa = nomeDaEmpresa;
            this.endereco = endereco;
            this.cpfCnpj = cpfCnpj;
            this.telefone = telefone;
            this.email = email;
            this.distancia = distancia;
        }

        public String getNome()
        {
            return nome;
        }

        public void setNome(String nome)
        {
            this.nome = nome;
        }

        public String getCpfCNPJ()
        {
            return cpfCnpj;
        }

        public void setCpfCNPJ(String cpfCnpj)
        {
            this.cpfCnpj = cpfCnpj;
        }

        public String getTelefone()
        {
            return telefone;
        }

        public void setTelefone(String telefone)
        {
            this.telefone = telefone;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public int getDistancia()
        {
            return distancia;
        }

        public void setDistancia(int distancia)
        {
            this.distancia = distancia;
        }

        public String getNomeDaEmpresa()
        {
            return nomeDaEmpresa;
        }

        public void setNomeDaEmpresa(String nomeDaEmpresa)
        {
            this.nomeDaEmpresa = nomeDaEmpresa;
        }

        public String getEndereco()
        {
            return endereco;
        }

        public void setEndereco(String endereco)
        {
            this.endereco = endereco;
        }

        public String toString()
        {
            return "{" + "Nome = " + nome + ", Empresa = " + nomeDaEmpresa + ", CPF/CNPJ = " + cpfCnpj +
                    ", Telefone = " + telefone + ", E-mail = " + email + ", Endereço = " + endereco + ", Distância = " + distancia + "km }";
        }

    }
}
