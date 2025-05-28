namespace EmpresaTecnologicaWindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConsultarProgramadores = new Button();
            GestionarClientes = new Button();
            GestionarProyectos = new Button();
            SuspendLayout();
            // 
            // ConsultarProgramadores
            // 
            ConsultarProgramadores.Location = new Point(231, 86);
            ConsultarProgramadores.Name = "ConsultarProgramadores";
            ConsultarProgramadores.Size = new Size(318, 54);
            ConsultarProgramadores.TabIndex = 0;
            ConsultarProgramadores.Text = "Consultar Programadores";
            ConsultarProgramadores.UseVisualStyleBackColor = true;
            ConsultarProgramadores.Click += ConsultarConsultores_Click;
            // 
            // GestionarClientes
            // 
            GestionarClientes.Location = new Point(231, 189);
            GestionarClientes.Name = "GestionarClientes";
            GestionarClientes.Size = new Size(318, 54);
            GestionarClientes.TabIndex = 1;
            GestionarClientes.Text = "Gestionar clientes";
            GestionarClientes.UseVisualStyleBackColor = true;
            GestionarClientes.Click += GestionarEmpresas_Click;
            // 
            // GestionarProyectos
            // 
            GestionarProyectos.Location = new Point(231, 304);
            GestionarProyectos.Name = "GestionarProyectos";
            GestionarProyectos.Size = new Size(318, 54);
            GestionarProyectos.TabIndex = 2;
            GestionarProyectos.Text = "Gestionar Proyectos";
            GestionarProyectos.UseVisualStyleBackColor = true;
            GestionarProyectos.Click += GestionarProyectos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GestionarProyectos);
            Controls.Add(GestionarClientes);
            Controls.Add(ConsultarProgramadores);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ConsultarProgramadores;
        private Button GestionarClientes;
        private Button GestionarProyectos;
    }
}
