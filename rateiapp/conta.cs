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

    }
    public class Pessoa
    {
        public String nomeDaPessoa { get; set; }
        public double contaDaPessoa { get; set; }
    }
    public class Produto
    {
        public String nomeDoProduto { get; set; }
        public double valorDoProduto { get; set; }
    }
}
