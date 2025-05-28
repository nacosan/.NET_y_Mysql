namespace EmpresaTecnologicaWindowsForm.Forms
{
    partial class FormProyectos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonConfirmar = new Button();
            labelMensaje = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            listBox1 = new ListBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // buttonConfirmar
            // 
            buttonConfirmar.Location = new Point(353, 237);
            buttonConfirmar.Name = "buttonConfirmar";
            buttonConfirmar.Size = new Size(410, 42);
            buttonConfirmar.TabIndex = 15;
            buttonConfirmar.Text = "Confirmar";
            buttonConfirmar.UseVisualStyleBackColor = true;
            buttonConfirmar.Click += buttonConfirmar_Click;
            // 
            // labelMensaje
            // 
            labelMensaje.AutoSize = true;
            labelMensaje.Location = new Point(353, 42);
            labelMensaje.Name = "labelMensaje";
            labelMensaje.Size = new Size(76, 15);
            labelMensaje.TabIndex = 14;
            labelMensaje.Text = "labelMensaje";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(353, 153);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(410, 57);
            textBox1.TabIndex = 13;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(38, 106);
            button2.Name = "button2";
            button2.Size = new Size(260, 43);
            button2.TabIndex = 9;
            button2.Text = "Añadir Proyecto";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(38, 42);
            button1.Name = "button1";
            button1.Size = new Size(260, 42);
            button1.TabIndex = 8;
            button1.Text = "Listar Proyectos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(353, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(410, 169);
            listBox1.TabIndex = 12;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(645, 372);
            button3.Name = "button3";
            button3.Size = new Size(100, 36);
            button3.TabIndex = 16;
            button3.Text = "Volver";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FormProyectos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(buttonConfirmar);
            Controls.Add(labelMensaje);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "FormProyectos";
            Text = "FormProyectos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonConfirmar;
        private Label labelMensaje;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private ListBox listBox1;
        private Button button3;
    }
}