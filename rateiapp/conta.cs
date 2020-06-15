using System;
using System.Collections.ObjectModel;

namespace rateiapp
{
    public static class conta
    {
        /*
         * Universidade Potiguar
         * CST em Análises e Desenvolvimento de Sistemas
         * Computação para Dispositivos Móveis - Avaliação A5
         * Renato Monteiro Batista - 201816437 <rmb@unp.edu.br>
         * ----------------------------------------------------
         * Esta classe contém objetos que serão acessíveis em todas
         * as telas do aplicativo.
         */
        static ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();
        public static ObservableCollection<Pessoa> Pessoas { get { return pessoas; } }
        static ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();
        public static ObservableCollection<Produto> Produtos { get { return produtos; } }
        public static decimal total;

    }
    public class Pessoa
    {
        public String nomeDaPessoa { get; set; }
        public decimal contaDaPessoa { get; set; }
        public decimal dezPorcento { get; set; }
        public decimal totalPessoa { get; set; }
        public ObservableCollection<String> itens = new ObservableCollection<String>();
        public void AddItem(Produto item, decimal qtd)
        {
            decimal totalDoItem;
            totalDoItem = qtd * item.valorDoProduto;
            itens.Add(qtd.ToString()+"x "+item.nomeDoProduto+" = "+totalDoItem.ToString());
            contaDaPessoa = contaDaPessoa + totalDoItem;
            conta.total += totalDoItem;
            dezPorcento = contaDaPessoa * (decimal)0.1;
            totalPessoa = contaDaPessoa * (decimal)1.1;
          
        }
    }
    public class Produto
    {
        public String nomeDoProduto { get; set; }
        public decimal valorDoProduto { get; set; }
        public String displayNome { get; set; }
    }
}
