using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rateiapp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void btnPessoas_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PagePessoas());
        }

        void btnItens_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageProdutos());
        }

        void btnDemo_Clicked(System.Object sender, System.EventArgs e)
        {
            conta.Pessoas.Add(new Pessoa { nomeDaPessoa = "Renato", contaDaPessoa = 0 });
            conta.Pessoas.Add(new Pessoa { nomeDaPessoa = "Monteiro", contaDaPessoa = 0 });
            conta.Pessoas.Add(new Pessoa { nomeDaPessoa = "Batista", contaDaPessoa = 0 });
            conta.Produtos.Add(new Produto { nomeDoProduto = "Cerveja", valorDoProduto = 8, displayNome="Cerveja (R$ 8)" });
            conta.Produtos.Add(new Produto { nomeDoProduto = "Vinho", valorDoProduto = 50, displayNome="Vinho (R$ 50)" });
            conta.Produtos.Add(new Produto { nomeDoProduto = "Rodízio de Pizza", valorDoProduto = 30, displayNome="Rodizio de Pizza (R$ 30)" });
            conta.Produtos.Add(new Produto { nomeDoProduto = "Churrasquinho de gato", valorDoProduto = 7, displayNome="Churrasquinho de Gato (R$ 7)" });
            conta.Produtos.Add(new Produto { nomeDoProduto = "File com Fritas", valorDoProduto = 17, displayNome="File com Fritas (R$ 17)" });
            conta.Produtos.Add(new Produto { nomeDoProduto = "Bauru", valorDoProduto = 12, displayNome="Bauru (R$ 12)" });
            DisplayAlert("Pronto", "Dados de exemplo carregados", "OK");
            btnDemo.IsEnabled = false;
            btnDemo.IsVisible = false;

        }
        protected override void OnAppearing()
        {
            if (conta.total > 0)
            {
                lbTotais.IsVisible = true;
                lbTotalGeral.Text = "Itens R$ "+ conta.total.ToString();
                lbTotalDez.Text = "+10% = R$ " + (conta.total * (decimal)1.1).ToString();
            }
        }
    }
}
