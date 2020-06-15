using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace rateiapp
{
    public partial class PagePessoas : ContentPage
    {
        public PagePessoas()
        {
            InitializeComponent();
            LoadPessoas();
        }

        public void LoadPessoas()
        {
            lvPessoas.ItemsSource = null;
            lvPessoas.ItemsSource = conta.Pessoas;
        }

        void btAddPessoa_Clicked(System.Object sender, System.EventArgs e)
        {
            conta.Pessoas.Add(new Pessoa { nomeDaPessoa = enPessoa.Text, contaDaPessoa = 0 });
            enPessoa.Text = "";
            LoadPessoas();
        }

        void lvPessoas_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Pessoa selecionado;
            selecionado = (Pessoa)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new PageVerPessoa(selecionado));
            //DisplayAlert("Item Tapped", "An item was tapped." + selecionado.nomeDaPessoa + selecionado.contaDaPessoa.ToString(), "OK");
            ((ListView)sender).SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadPessoas();
        }
    }
}
