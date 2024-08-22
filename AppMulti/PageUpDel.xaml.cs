using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMulti.Controller;
using AppMulti.Models;

namespace AppMulti
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUpDel : ContentPage
    {
        public Pessoa pessoa;

        public PageUpDel()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = this.pessoa;
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.AtualizarPessoa(pessoa);
            DisplayAlert("ATUALIZAÇÃO", "Pessoa atualizada com sucesso!", "Ok");
            Navigation.PopAsync();
        }

        private void btnapagar_Clicked(object sender, EventArgs e)
        {
            if (pessoa.id != 0) 
            {
                MySQLCon.ExcluirPessoa(pessoa);
                DisplayAlert("EXCLUSÃO", "Excluido com sucesso!", "Ok");
                Navigation.PopAsync();
            }

        }
    }
}