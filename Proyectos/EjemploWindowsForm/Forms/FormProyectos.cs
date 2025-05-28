using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionEmpresaTecnologica.Controlador;
using GestionEmpresaTecnologica.Modelos;

namespace EmpresaTecnologicaWindowsForm.Forms
{
    public partial class FormProyectos : Form
    {
        // Variables para el alta de proyecto
        private int pasoAltaProyecto = 0;
        private int idEmpresaProyecto = 0;
        private int idConsultorProyecto = 0;
        private string descripcionProyecto = "";
        private double costeProyecto = 0;
        private double precioProyecto = 0;
        private List<Empresas> listaEmpresas = null;
        private List<Consultor> listaConsultores = null;

        public FormProyectos()
        {
            InitializeComponent();
            this.Load += FormProyectos_Load;
            textBox1.KeyDown += textBox1_KeyDown;
        }

        // Al cargar el formulario, lista los proyectos
        private void FormProyectos_Load(object sender, EventArgs e)
        {
            ListarProyectos();
            textBox1.Visible = false;
            labelMensaje.Visible = false;
            buttonConfirmar.Visible = false;
        }

        private void ListarProyectos()
        {
            GestionProyectos gp = new GestionProyectos();
            List<Proyectos> proyectos = gp.GetListaProyectos();

            listBox1.Items.Clear();

            foreach (Proyectos p in proyectos)
            {
                listBox1.Items.Add(
                    $"Id: {p.Id} | Descripción: {p.Descripcion} | Coste: {p.Coste} | Precio: {p.Precio} | Consultor: {p.Id_consultor.Nombre} | Empresa: {p.Id_empresa.Nombre}"
                );
            }
            listBox1.Visible = true;

            // Scrollbars:
            listBox1.ScrollAlwaysVisible = true;      // Vertical siempre visible
            listBox1.HorizontalScrollbar = true;      // Habilita horizontal

            // Ajusta HorizontalExtent para el scroll horizontal
            using (Graphics g = listBox1.CreateGraphics())
            {
                int maxWidth = 0;
                foreach (var item in listBox1.Items)
                {
                    int itemWidth = (int)g.MeasureString(item.ToString(), listBox1.Font).Width;
                    if (itemWidth > maxWidth)
                        maxWidth = itemWidth;
                }
                listBox1.HorizontalExtent = maxWidth;
            }
        }

        // Botón 1: Listar proyectos
        private void button1_Click(object sender, EventArgs e)
        {
            pasoAltaProyecto = 0; // Salir de cualquier alta en curso
            textBox1.Visible = false;
            labelMensaje.Visible = false;
            buttonConfirmar.Visible = false;
            ListarProyectos();
        }

        // Botón 2: Añadir proyecto (inicia flujo interactivo)
        private void button2_Click(object sender, EventArgs e)
        {
            pasoAltaProyecto = 1;
            idEmpresaProyecto = idConsultorProyecto = 0;
            descripcionProyecto = "";
            costeProyecto = precioProyecto = 0;
            listBox1.Visible = false;
            textBox1.Visible = true;
            textBox1.Text = "";
            textBox1.Focus();
            labelMensaje.Visible = true;
            buttonConfirmar.Visible = true;

            // Carga consultores y muestra el listado
            GestionConsultores gc = new GestionConsultores();
            listaConsultores = gc.GetListaConsultores();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CONSULTORES DISPONIBLES:");
            foreach (var c in listaConsultores)
            {
                sb.AppendLine($"Id: {c.Id} | Nombre: {c.Nombre}");
            }
            labelMensaje.Text = sb.ToString() + "\nSeleccione el Id del consultor y pulsa Enter o Confirmar:";
        }


        // Proceso paso a paso para alta de proyecto
        private void ProcesarPasoAltaProyecto()
        {
            switch (pasoAltaProyecto)
            {
                case 1:
                    // Pide el Id del consultor
                    GestionConsultores gc = new GestionConsultores();
                    listaConsultores = gc.GetListaConsultores();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("CONSULTORES DISPONIBLES:");
                    foreach (var c in listaConsultores)
                    {
                        sb.AppendLine($"Id: {c.Id} | Nombre: {c.Nombre}");
                    }
                    labelMensaje.Text = sb.ToString() + "\nSeleccione el Id del consultor y pulsa Enter o Confirmar:";
                    textBox1.Text = "";
                    textBox1.Focus();
                    pasoAltaProyecto = 2;
                    break;
                case 2:
                    if (!int.TryParse(textBox1.Text.Trim(), out idConsultorProyecto) ||
                        !listaConsultores.Any(c => c.Id == idConsultorProyecto))
                    {
                        labelMensaje.Text = "Id no válido. Introduce un Id de consultor existente:";
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;
                    }
                    pasoAltaProyecto = 3;
                    textBox1.Text = "";
                    labelMensaje.Text = "Descripción del proyecto:";
                    textBox1.Focus();
                    break;
                case 3:
                    descripcionProyecto = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(descripcionProyecto))
                    {
                        labelMensaje.Text = "La descripción no puede estar vacía. Inténtalo de nuevo:";
                        textBox1.Focus();
                        return;
                    }
                    pasoAltaProyecto = 4;
                    textBox1.Text = "";
                    labelMensaje.Text = "Coste:";
                    textBox1.Focus();
                    break;
                case 4:
                    if (!double.TryParse(textBox1.Text.Trim(), out costeProyecto))
                    {
                        labelMensaje.Text = "Coste no válido. Introduzca un número:";
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;
                    }
                    pasoAltaProyecto = 5;
                    textBox1.Text = "";
                    labelMensaje.Text = "Precio de venta:";
                    textBox1.Focus();
                    break;
                case 5:
                    if (!double.TryParse(textBox1.Text.Trim(), out precioProyecto))
                    {
                        labelMensaje.Text = "Precio no válido. Introduzca un número:";
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;
                    }
                    // Guardar el proyecto (el Id se autoincrementa en la base de datos)
                    Proyectos nuevoProyecto = new Proyectos
                    {
                        Descripcion = descripcionProyecto,
                        Coste = costeProyecto,
                        Precio = precioProyecto,
                        Id_consultor = new Consultor { Id = idConsultorProyecto }
                        // No necesitas asignar Id ni Id_empresa si no lo pides
                    };
                    GestionProyectos gp = new GestionProyectos();
                    gp.InsertarProyecto(nuevoProyecto);

                    labelMensaje.Text = "¡Proyecto añadido correctamente!";
                    textBox1.Visible = false;
                    buttonConfirmar.Visible = false;
                    pasoAltaProyecto = 0;
                    // Refresca la lista de proyectos
                    ListarProyectos();
                    break;
            }
        }


        // Avanzar con Enter en el textbox
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (pasoAltaProyecto > 0)
                {
                    ProcesarPasoAltaProyecto();
                }
            }
        }

        // Avanzar con el botón Confirmar
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (pasoAltaProyecto > 0)
            {
                ProcesarPasoAltaProyecto();
            }
        }

        // Puedes dejar estos vacíos si no los necesitas
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
