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
            if (enProduto.Text == null)
            {
                DisplayAlert("ERRO", "Por gentileza informe um nome para o produto.", "OK");
            }
            else
            {
                if (Convert.ToDecimal(enValor.Text) > 0)
                {
                    Produto novo = new Produto { nomeDoProduto = enProduto.Text, valorDoProduto = Convert.ToDecimal(enValor.Text), displayNome = enProduto.Text + " (R$ " + enValor.Text + ")" };
                    conta.Produtos.Add(novo);
                    enProduto.Text = null;
                    enValor.Text = null;
                    if (cbTodos.IsChecked)
                    {
                        foreach (var data in conta.Pessoas)
                        {
                            data.AddItem(novo, (decimal)1);
                            Console.WriteLine(data);
                        }
                    }
                    cbTodos.IsChecked = false;
                    LoadProdutos();
                }
                else
                {
                    DisplayAlert("ERRO", "Por gentileza informe um valor unitário do produto", "OK");
                }
            }
        }
    }
}
