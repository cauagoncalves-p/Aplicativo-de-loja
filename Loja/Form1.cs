using Loja.clienteDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Loja.clienteDataSet;

namespace Loja
{
    public partial class Form1 : Form
    {

        private void atualizarLista()
        {
            lboDados.Items.Clear();
            FuncionariosTableAdapter funcionarios = new FuncionariosTableAdapter();
            var dados = from linha in funcionarios.GetData()
                        select linha;
            foreach (var linha in dados)
            {
                lboDados.Items.Add(linha);
            }
        }

        public Form1()
        {
            InitializeComponent();
            atualizarLista();
        }

      
        private void lboDados_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lboDados.SelectedItem == null)
            {
                return;
            }

            btnLimpar.Enabled = true;
            FuncionariosRow item = lboDados.SelectedItem as FuncionariosRow;
            txtID.Text = item.Codigo.ToString();
            txtNome.Text = item.Nome;
            txtEndereco.Text = item.Endereco;   
            txtBairro.Text = item.Bairro;   
            txtCidade.Text = item.Cidade;
            txtEstado.Text = item.Estado;
            txtCep.Text = item.CEP;
            txtTelefone.Text = item.Telefone.ToString();
            txtObservacao.Text = item.Observacao;
            dtpDataCadastro.Value = item.DataCadastro;
        }

        private void LimparTela() 
        {
            txtID.Clear();
            txtNome.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtObservacao.Clear();
            txtTelefone.Clear();
            txtCep.Clear();
            txtEndereco.Clear();
            dtpDataCadastro.Value = DateTime.Now;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == null || txtCidade.Text == "" || txtCidade.Text == ""
                || txtCep.Text == "" || txtEndereco.Text == "" || txtTelefone.Text == "" || txtEstado.Text == "" || dtpDataCadastro.Value == null) return;

            FuncionariosTableAdapter novosDados = new FuncionariosTableAdapter();
            string nome = txtNome.Text;
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string cep = txtCep.Text;
            string endereco = txtEndereco.Text;
            string bairro = txtBairro.Text;
            int telefone = int.Parse(txtTelefone.Text);
            DateTime cadastro = dtpDataCadastro.Value;

            novosDados.Insert(nome, endereco, bairro, cidade, estado, cep, telefone, "" ,cadastro);
            atualizarLista();
            LimparTela();


        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (lboDados.SelectedItem == null) return; //fimalgoritmo
                                                        // obtendo o elemento selecionado
            FuncionariosRow dadoParaAtualizacao = lboDados.SelectedItem as FuncionariosRow;
            FuncionariosTableAdapter dados = new FuncionariosTableAdapter();
            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string cidade = txtCidade.Text;
            string bairro = txtBairro.Text;
            string cep = txtCep.Text;
            string estado = txtEstado.Text;
            int telefone = int.Parse(txtTelefone.Text);
            DateTime dateTime = dtpDataCadastro.Value;
            string observacao = txtObservacao.Text;
            dadoParaAtualizacao.Nome = nome;
            dadoParaAtualizacao.Endereco = endereco;
            dadoParaAtualizacao.Bairro = bairro;
            dadoParaAtualizacao.Cidade = cidade;
            dadoParaAtualizacao.Estado = estado;
            dadoParaAtualizacao.CEP = cep;
            dadoParaAtualizacao.Telefone = telefone;
            dadoParaAtualizacao.Observacao = observacao;
            dadoParaAtualizacao.DataCadastro = dateTime;
            dados.Update(dadoParaAtualizacao);
            atualizarLista();
            LimparTela();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (lboDados.SelectedItem == null) return;

            FuncionariosRow dadosParaExcluir = lboDados.SelectedItem as FuncionariosRow;
            FuncionariosTableAdapter dados = new FuncionariosTableAdapter();

            dados.Delete(dadosParaExcluir.Codigo, dadosParaExcluir.Nome, dadosParaExcluir.Telefone, dadosParaExcluir.DataCadastro);
            atualizarLista();
            LimparTela();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            atualizarLista();
            LimparTela();
        }


    }
}
