using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEP
{
    public partial class frmCEP : Form
    {
        public frmCEP()
        {
            InitializeComponent();
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCEP.Text))
            {
                if (Regex.IsMatch(txtCEP.Text, @"^\d+$"))
                {
                    if(txtCEP.Text.Replace("-", "").Replace(".", "").TrimEnd().TrimStart().Length == 8)
                    {
                        CAMPOS cAMPOS = new CAMPOS();

                        cAMPOS = clCEP.GetCEP(txtCEP.Text.Replace("-", "").Replace(".", "").TrimEnd().TrimStart());

                        txtLogradouro.Text = cAMPOS.logradouro;
                        txtComplemento.Text = cAMPOS.complemento;
                        txtBairro.Text = cAMPOS.bairro;
                        txtLocalidade.Text = cAMPOS.localidade;
                        txtUF.Text = cAMPOS.uf;
                        txtUnidade.Text = cAMPOS.unidade;
                        txtIBGE.Text = cAMPOS.ibge;
                        txtGIA.Text = cAMPOS.gia;
                    }
                    else
                    {
                        MessageBox.Show("Campo de CEP tem que ter 8 digitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Cep no formado inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Cep é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
