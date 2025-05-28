using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using GestionEmpresaTecnologica.Controlador;
using GestionEmpresaTecnologica.Modelos;

namespace EmpresaTecnologicaWindowsForm
{
    public partial class Form2 : Form
    {
        GestionProyectos gp = new GestionProyectos();

        public Form2()
        {
            InitializeComponent();

            listBox1.Visible = false;
            listBox1.HorizontalScrollbar = true;
            textBox1.Visible = false;
            labelMensaje.Visible = false;
            buttonConfirmar.Visible = false;
            SendMessage(listBox1.Handle, LB_SETHORIZONTALEXTENT, 2000, 0);

            textBox1.KeyDown += textBox1_KeyDown;
        }





        private const int LB_SETHORIZONTALEXTENT = 0x0194;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            labelMensaje.Visible = false;
            listBox1.Visible = true;
            // Limpia el ListBox antes de llenarlo
            listBox1.Items.Clear();

            // Obtén la lista de proyectos
            List<Proyectos> proyectos = gp.GetListaProyectos();

            // Agrega cada proyecto como un ítem en el ListBox
            foreach (Proyectos p in proyectos)
            {
                listBox1.Items.Add(
                    $"Id: {p.Id} | Descripción: {p.Descripcion} | Coste: {p.Coste} | Precio: {p.Precio} | Consultor: {p.Id_consultor.Nombre} | Empresa: {p.Id_empresa.Nombre}"
                );
            }
        }

        private int pasoAltaEmpresa = 0;
        private string nombreEmpresa = "", cifEmpresa = "", direccionEmpresa = "", telefonoEmpresa = "";

        private void button2_Click(object sender, EventArgs e)
        {
            pasoAltaEmpresa = 1;
            nombreEmpresa = cifEmpresa = direccionEmpresa = telefonoEmpresa = "";
            listBox1.Visible = false;
            textBox1.Visible = true;
            textBox1.Text = "";
            textBox1.Focus();
            labelMensaje.Visible = true;
            labelMensaje.Text = "Introduce el nombre de la empresa y pulsa Enter:";
            buttonConfirmar.Visible = true;
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (pasoActualizarTelefono > 0)
                {
                    ProcesarPasoActualizarTelefono();
                    return;
                }
                if (pasoAltaEmpresa > 0)
                {
                    ProcesarPasoEmpresa();
                }
            }
        }

        private void ProcesarPasoEmpresa()
        {
            switch (pasoAltaEmpresa)
            {
                case 1:
                    nombreEmpresa = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(nombreEmpresa))
                    {
                        labelMensaje.Text = "El nombre no puede estar vacío. Inténtalo de nuevo:";
                        textBox1.Focus();
                        return;
                    }
                    pasoAltaEmpresa = 2;
                    textBox1.Text = "";
                    labelMensaje.Text = "Introduce el CIF de la empresa y pulsa Enter:";
                    textBox1.Focus();
                    break;
                case 2:
                    cifEmpresa = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(cifEmpresa))
                    {
                        labelMensaje.Text = "El CIF no puede estar vacío. Inténtalo de nuevo:";
                        textBox1.Focus();
                        return;
                    }
                    pasoAltaEmpresa = 3;
                    textBox1.Text = "";
                    labelMensaje.Text = "Introduce la dirección de la empresa y pulsa Enter:";
                    textBox1.Focus();
                    break;
                case 3:
                    direccionEmpresa = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(direccionEmpresa))
                    {
                        labelMensaje.Text = "La dirección no puede estar vacía. Inténtalo de nuevo:";
                        textBox1.Focus();
                        return;
                    }
                    pasoAltaEmpresa = 4;
                    textBox1.Text = "";
                    labelMensaje.Text = "Introduce el teléfono de la empresa y pulsa Enter:";
                    textBox1.Focus();
                    break;
                case 4:
                    telefonoEmpresa = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(telefonoEmpresa))
                    {
                        labelMensaje.Text = "El teléfono no puede estar vacío. Inténtalo de nuevo:";
                        textBox1.Focus();
                        return;
                    }
                    GuardarEmpresa();
                    break;
            }
        }

        

        private void GuardarEmpresa()
        {
            Empresas nuevaEmpresa = new Empresas
            {
                Nombre = nombreEmpresa,
                Cif = cifEmpresa,
                Direccion = direccionEmpresa,
                Telefono = telefonoEmpresa
            };
            GestionEmpresas ge = new GestionEmpresas();
            ge.InsertarEmpresas(nuevaEmpresa);

            labelMensaje.Text = "¡Empresa añadida correctamente!";
            textBox1.Visible = false;
            buttonConfirmar.Visible = false; 
            pasoAltaEmpresa = 0;
        }

        private void ProcesarPasoActualizarTelefono()
        {
            switch (pasoActualizarTelefono)
            {
                case 1:
                    // Leer el Id de la empresa
                    if (!int.TryParse(textBox1.Text.Trim(), out idEmpresaActualizar) ||
                        !listaEmpresas.Any(e => e.Id == idEmpresaActualizar))
                    {
                        labelMensaje.Text = "Id no válido. Introduce un Id de empresa existente:";
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;
                    }
                    pasoActualizarTelefono = 2;
                    textBox1.Text = "";
                    labelMensaje.Text = "Introduce el nuevo teléfono y pulsa Enter o Confirmar:";
                    textBox1.Focus();
                    break;
                case 2:
                    nuevoTelefono = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(nuevoTelefono))
                    {
                        labelMensaje.Text = "El teléfono no puede estar vacío. Inténtalo de nuevo:";
                        textBox1.Focus();
                        return;
                    }
                    // Actualizar el teléfono
                    GestionEmpresas ge = new GestionEmpresas();
                    ge.ActualizarTelefonoEmpresa(idEmpresaActualizar, nuevoTelefono);

                    labelMensaje.Text = "¡Teléfono actualizado correctamente!";
                    textBox1.Visible = false;
                    buttonConfirmar.Visible = false;
                    pasoActualizarTelefono = 0;
                    break;

            }
        }

        private int pasoActualizarTelefono = 0;
        private int idEmpresaActualizar = 0;
        private string nuevoTelefono = "";
        private List<Empresas> listaEmpresas = null;


        private void button3_Click(object sender, EventArgs e)
        {
            // Prepara el proceso
            pasoActualizarTelefono = 1;
            idEmpresaActualizar = 0;
            nuevoTelefono = "";
            textBox1.Visible = true;
            textBox1.Text = "";
            textBox1.Focus();
            labelMensaje.Visible = true;
            buttonConfirmar.Visible = true;

            // Carga las empresas y muestra el listado en el label
            GestionEmpresas ge = new GestionEmpresas();
            listaEmpresas = ge.GetListaEmpresas();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Empresas disponibles:");
            foreach (var emp in listaEmpresas)
            {
                sb.AppendLine($"Id: {emp.Id} | Nombre: {emp.Nombre} | Teléfono: {emp.Telefono}");
            }
            labelMensaje.Text = sb.ToString() + "\nIntroduce el Id de la empresa a modificar y pulsa Enter o Confirmar:";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            labelMensaje.Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelMensaje_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (pasoActualizarTelefono > 0)
            {
                ProcesarPasoActualizarTelefono();
                return;
            }
            if (pasoAltaEmpresa > 0)
            {
                ProcesarPasoEmpresa();
            }
        }

    }
}

