using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMulti.Controller;

namespace AppMulti
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.InserirPessoa(txtNome.Text, txtIdade.Text);
            DisplayAlert("CADASTRO", "Pessoa, cadastrada com sucesso!", "OK");
            Navigation.PushAsync(new PageListar());
        }
    }
}