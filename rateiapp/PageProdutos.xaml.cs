using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rateiapp
{
    public partial class PageProdutos : ContentPage
    {
        public PageProdutos()
        {
            InitializeComponent();
            LoadProdutos();
        }

        public void LoadProdutos()
        {
            lvProdutos.ItemsSource = null;
            lvProdutos.ItemsSource = conta.Produtos;
        }

        void btAddProduto_Clicked(System.Object sender, System.EventArgs e)
        {
            conta.Produtos.Add(new Produto { nomeDoProduto = enProduto.Text, valorDoProduto = Convert.ToDecimal(enValor.Text), displayNome=enProduto.Text+" (R$ "+enValor.Text+")" });
            enProduto.Text = "";
            enValor.Text = "";
            LoadProdutos();
        }

    }
}
