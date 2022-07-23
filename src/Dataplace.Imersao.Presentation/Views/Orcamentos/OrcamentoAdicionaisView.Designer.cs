using dpLibrary05.Infrastructure.Controls;

namespace Dataplace.Imersao.Presentation.Views.Orcamentos
{
    partial class OrcamentoAdicionaisView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.seqTabela = new System.Windows.Forms.TextBox();
            this.cdTabela = new DPTextBox();
            this.SuspendLayout();
            // 
            // seqTabela
            // 
            this.seqTabela.Location = new System.Drawing.Point(118, 18);
            this.seqTabela.Name = "seqTabela";
            this.seqTabela.Size = new System.Drawing.Size(50, 20);
            this.seqTabela.TabIndex = 0;
            // 
            // cdTabela
            // 
            this.cdTabela.Location = new System.Drawing.Point(12, 18);
            this.cdTabela.Name = "cdTabela";
            this.cdTabela.Size = new System.Drawing.Size(100, 20);
            this.cdTabela.TabIndex = 0;
            // 
            // OrcamentoAdicionaisView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cdTabela);
            this.Controls.Add(this.seqTabela);
            this.Name = "OrcamentoAdicionaisView";
            this.Size = new System.Drawing.Size(907, 261);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox seqTabela;
        private DPTextBox cdTabela;
    }
}
