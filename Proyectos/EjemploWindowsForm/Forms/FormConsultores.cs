using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionEmpresaTecnologica.Controlador;
using GestionEmpresaTecnologica.Modelos;

namespace EmpresaTecnologicaWindowsForm.Forms
{
    public partial class FormConsultores : Form
    {
        public FormConsultores()
        {
            InitializeComponent();
            this.Load += FormConsultores_Load;
        }

        private void FormConsultores_Load(object sender, EventArgs e)
        {
            GestionConsultores gc = new GestionConsultores();
            List<Consultor> consultores = gc.GetListaConsultores();

            listBox1.Items.Clear();

            foreach (Consultor c in consultores)
            {
                listBox1.Items.Add(
                    $"Nombre: {c.Nombre} | Categoria: {c.Categoria} | Sueldo actual: {c.Sueldo_actual} | Salario recomendado: {c.Salario_recomendado} | Número de proyectos: {c.NumeroProyectos}"
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
