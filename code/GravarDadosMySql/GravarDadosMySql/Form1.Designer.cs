namespace GravarDadosMySql
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            txtNome = new TextBox();
            label2 = new Label();
            TxtTelefone = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            button1 = new Button();
            lst_Contatos = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            CMS_excluir_contato = new ToolStripMenuItem();
            label4 = new Label();
            txt_BuscarContato = new TextBox();
            button2 = new Button();
            btn_limpar = new Button();
            btn_excluir = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            label1.UseWaitCursor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 27);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(409, 23);
            txtNome.TabIndex = 1;
            txtNome.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Telefone:";
            label2.UseWaitCursor = true;
            // 
            // TxtTelefone
            // 
            TxtTelefone.Location = new Point(12, 71);
            TxtTelefone.Name = "TxtTelefone";
            TxtTelefone.Size = new Size(409, 23);
            TxtTelefone.TabIndex = 3;
            TxtTelefone.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "E-Mail:";
            label3.UseWaitCursor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 115);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(409, 23);
            txtEmail.TabIndex = 5;
            txtEmail.UseWaitCursor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 154);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Salvar";
            button1.UseVisualStyleBackColor = true;
            button1.UseWaitCursor = true;
            button1.Click += button1_Click;
            // 
            // lst_Contatos
            // 
            lst_Contatos.ContextMenuStrip = contextMenuStrip1;
            lst_Contatos.Location = new Point(465, 53);
            lst_Contatos.MultiSelect = false;
            lst_Contatos.Name = "lst_Contatos";
            lst_Contatos.Size = new Size(409, 124);
            lst_Contatos.TabIndex = 7;
            lst_Contatos.UseCompatibleStateImageBehavior = false;
            lst_Contatos.UseWaitCursor = true;
            lst_Contatos.ItemSelectionChanged += lst_Contatos_ItemSelectionChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { CMS_excluir_contato });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(156, 26);
            // 
            // CMS_excluir_contato
            // 
            CMS_excluir_contato.Name = "CMS_excluir_contato";
            CMS_excluir_contato.Size = new Size(155, 22);
            CMS_excluir_contato.Text = "Excluit Contato";
            CMS_excluir_contato.Click += CMS_excluir_contato_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(465, 6);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 8;
            label4.Text = "Buscar Contato:";
            label4.UseWaitCursor = true;
            // 
            // txt_BuscarContato
            // 
            txt_BuscarContato.Location = new Point(465, 24);
            txt_BuscarContato.Name = "txt_BuscarContato";
            txt_BuscarContato.Size = new Size(324, 23);
            txt_BuscarContato.TabIndex = 9;
            txt_BuscarContato.UseWaitCursor = true;
            // 
            // button2
            // 
            button2.Location = new Point(799, 23);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Buscar";
            button2.UseVisualStyleBackColor = true;
            button2.UseWaitCursor = true;
            button2.Click += button2_Click;
            // 
            // btn_limpar
            // 
            btn_limpar.Location = new Point(346, 154);
            btn_limpar.Name = "btn_limpar";
            btn_limpar.Size = new Size(75, 23);
            btn_limpar.TabIndex = 11;
            btn_limpar.Text = "Limpar";
            btn_limpar.UseVisualStyleBackColor = true;
            btn_limpar.UseWaitCursor = true;
            btn_limpar.Click += btn_limpar_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.Location = new Point(169, 154);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 23);
            btn_excluir.TabIndex = 12;
            btn_excluir.Text = "Excuir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.UseWaitCursor = true;
            btn_excluir.Visible = false;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(907, 180);
            Controls.Add(btn_excluir);
            Controls.Add(btn_limpar);
            Controls.Add(button2);
            Controls.Add(txt_BuscarContato);
            Controls.Add(label4);
            Controls.Add(lst_Contatos);
            Controls.Add(button1);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(TxtTelefone);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda";
            UseWaitCursor = true;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private Label label2;
        private TextBox TxtTelefone;
        private Label label3;
        private TextBox txtEmail;
        private Button button1;
        private ListView lst_Contatos;
        private Label label4;
        private TextBox txt_BuscarContato;
        private Button button2;
        private Button btn_limpar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem CMS_excluir_contato;
        private Button btn_excluir;
    }
}