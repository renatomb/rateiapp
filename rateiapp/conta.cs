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
        /*static ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();
        /public static ObservableCollection<Pessoa> Pessoas { get { return pessoas; } }
        static ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();
        public static ObservableCollection<Produto> Produtos { get { return produtos; } }*/
        public static ObservableCollection<Pessoa> Pessoas = new ObservableCollection<Pessoa>();
        public static ObservableCollection<Produto> Produtos = new ObservableCollection<Produto>();
        public static decimal total;
        public static decimal taxa=10;

    }
    public class Pessoa
    {
        public String nomeDaPessoa { get; set; }
        public decimal contaDaPessoa { get; set; }
        public decimal dezPorcento { get; set; }
        public decimal totalPessoa { get; set; }
        public String textTaxa { get; set; }
        public ObservableCollection<String> itens = new ObservableCollection<String>();
        public void AddItem(Produto item, decimal qtd)
        {
            decimal totalDoItem;
            totalDoItem = qtd * item.valorDoProduto;
            itens.Add(qtd.ToString()+"x "+item.nomeDoProduto+" = "+totalDoItem.ToString());
            contaDaPessoa = contaDaPessoa + totalDoItem;
            conta.total += totalDoItem;
            RecalculaTaxa();
        }
        public void RecalculaTaxa()
        {
            decimal fator = 1;
            if (conta.taxa > 0)
            {
                textTaxa = "+"+conta.taxa.ToString() + "%";
                fator = (conta.taxa / 100) + 1;
                dezPorcento = contaDaPessoa * (conta.taxa / 100);
            }
            else
            {
                textTaxa = "Sem taxa";
                dezPorcento = 0;
            }
            totalPessoa = contaDaPessoa * fator;
        }
    }
    public class Produto
    {
        public String nomeDoProduto { get; set; }
        public decimal valorDoProduto { get; set; }
        public String displayNome { get; set; }
    }
}
