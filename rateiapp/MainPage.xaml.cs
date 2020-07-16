using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            ExibeTotais();
        }
        void ExibeTotais()
        {
            if (conta.total > 0)
            {
                lbTotais.IsVisible = true;
                lbTotalGeral.IsVisible = true;
                lbTotalGeral.Text = "Itens R$ " + conta.total.ToString();
                if (conta.taxa > 0)
                {
                    lbTotalDez.IsVisible = true;
                    decimal fator;
                    fator = (conta.taxa / 100) + 1;
                    lbTotalDez.Text = "+" + conta.taxa.ToString() + "% = R$ " + (conta.total * fator).ToString();
                }
                else
                {
                    lbTotalDez.IsVisible = false;
                }
            }
            else
            {
                lbTotais.IsVisible = false;
                lbTotalDez.IsVisible = false;
                lbTotalGeral.IsVisible = false;
            }
        }

        async void btnLimpar_Clicked(System.Object sender, System.EventArgs e)
        {
            bool limpar = await DisplayAlert("Deseja limpar a conta?", "A conta será zerada, todas as pessoas e produtos cadastrados serão apagados.", "Sim", "Não");
            if (limpar)
            {
                conta.Pessoas = new ObservableCollection<Pessoa>();
                conta.Produtos = new ObservableCollection<Produto>();
                conta.total = 0;
                ExibeTotais();
            }
        }

        async void btServico_Clicked(System.Object sender, System.EventArgs e)
        {
            var taxa = await DisplayPromptAsync("Informe a taxa de serviço", "Informe a taxa de serviço que será adicionada aos ítens desta conta", "OK", null,null,2,Keyboard.Numeric,conta.taxa.ToString());
            if ((Convert.ToDecimal(taxa) != conta.taxa) && (conta.Pessoas.Count > 0))
            {
                conta.taxa = Convert.ToDecimal(taxa);
                await DisplayAlert("A taxa foi alterada", "Existem pessoas na conta, os valores da taxa de serviço serão recalculados.", "OK");
                foreach (var pax in conta.Pessoas)
                {
                    pax.RecalculaTaxa();
                }
                ExibeTotais();
            }
        }
    }
}
