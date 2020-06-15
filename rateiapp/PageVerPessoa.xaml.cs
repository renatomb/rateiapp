using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rateiapp
{
    public partial class PageVerPessoa : ContentPage
    {
        private Pessoa atual;
        private Produto qual;
        public PageVerPessoa(Pessoa selecao)
        {
            InitializeComponent();
            atual = selecao;
            CarregaPagina();
            CarregaContaIndividual();
        }

        public void CarregaPagina()
        {
            pagina.Title = "Conta de " + atual.nomeDaPessoa;
            lbAdd.Text = "Adicionar itens a conta de " + atual.nomeDaPessoa;
            pkProduto.ItemsSource = conta.Produtos;
        }
        public void CarregaContaIndividual()
        {
            lvConta.ItemsSource = null;
            lvConta.ItemsSource = atual.itens;
            lbTotalItens.Text = atual.nomeDaPessoa + " R$ " + atual.contaDaPessoa.ToString();
            lbDezPorcento.Text = "10% = " + atual.dezPorcento.ToString();
            lbTotalIndiv.Text = "R$ "+ atual.totalPessoa.ToString();

        }
        void pkProduto_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (pkProduto.SelectedIndex >= 0)
            {
                enQtd.IsEnabled = true;
                btAddConta.IsEnabled = true;
            }
            else
            {
                enQtd.IsEnabled = false;
                btAddConta.IsEnabled = false;
            }

        }

        void btAddConta_Clicked(System.Object sender, System.EventArgs e)
        {
            qual = (Produto)pkProduto.SelectedItem;
            atual.AddItem(qual,Convert.ToDecimal(enQtd.Text));
            enQtd.Text = "";
            pkProduto.SelectedIndex = -1;
            CarregaContaIndividual();
        }
    }
}
