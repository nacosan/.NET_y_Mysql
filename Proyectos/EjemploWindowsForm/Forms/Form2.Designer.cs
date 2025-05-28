namespace EmpresaTecnologicaWindowsForm
{
    partial class Form2
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            labelMensaje = new Label();
            buttonConfirmar = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(28, 42);
            button1.Name = "button1";
            button1.Size = new Size(260, 42);
            button1.TabIndex = 0;
            button1.Text = "Listar Clientes/Empresas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(28, 106);
            button2.Name = "button2";
            button2.Size = new Size(260, 43);
            button2.TabIndex = 1;
            button2.Text = "Añadir Cliente/Empresa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(28, 167);
            button3.Name = "button3";
            button3.Size = new Size(260, 41);
            button3.TabIndex = 2;
            button3.Text = "Modificar movil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(638, 386);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 3;
            button4.Text = "Volver";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(343, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(410, 169);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(343, 153);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(410, 57);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // labelMensaje
            // 
            labelMensaje.AutoSize = true;
            labelMensaje.Location = new Point(343, 42);
            labelMensaje.Name = "labelMensaje";
            labelMensaje.Size = new Size(76, 15);
            labelMensaje.TabIndex = 6;
            labelMensaje.Text = "labelMensaje";
            labelMensaje.Click += labelMensaje_Click;
            // 
            // buttonConfirmar
            // 
            buttonConfirmar.Location = new Point(343, 237);
            buttonConfirmar.Name = "buttonConfirmar";
            buttonConfirmar.Size = new Size(410, 42);
            buttonConfirmar.TabIndex = 7;
            buttonConfirmar.Text = "Confirmar";
            buttonConfirmar.UseVisualStyleBackColor = true;
            buttonConfirmar.Click += buttonConfirmar_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonConfirmar);
            Controls.Add(labelMensaje);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListBox listBox1;
        private TextBox textBox1;
        private Label labelMensaje;
        private Button buttonConfirmar;
    }
}
