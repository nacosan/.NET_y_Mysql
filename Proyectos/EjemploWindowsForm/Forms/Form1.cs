using EmpresaTecnologicaWindowsForm.Forms;

namespace EmpresaTecnologicaWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GestionarProyectos_Click(object sender, EventArgs e)
        {
            FormProyectos fp = new FormProyectos();
            fp.Show();
            this.Hide();
        }

        private void GestionarEmpresas_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void ConsultarConsultores_Click(object sender, EventArgs e)
        {
            FormConsultores fc = new FormConsultores();
            fc.Show();
            this.Hide();
        }
    }
}
