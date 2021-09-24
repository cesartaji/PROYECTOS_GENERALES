namespace Proyecto_2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pestañasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejectuarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.pestañasToolStripMenuItem,
            this.proyectoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarToolStripMenuItem1});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar como";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem1
            // 
            this.guardarToolStripMenuItem1.Name = "guardarToolStripMenuItem1";
            this.guardarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem1.Text = "Guardar";
            this.guardarToolStripMenuItem1.Click += new System.EventHandler(this.guardarToolStripMenuItem1_Click);
            // 
            // pestañasToolStripMenuItem
            // 
            this.pestañasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarPestañaToolStripMenuItem,
            this.ejectuarArchivoToolStripMenuItem});
            this.pestañasToolStripMenuItem.Name = "pestañasToolStripMenuItem";
            this.pestañasToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.pestañasToolStripMenuItem.Text = "Pestañas";
            // 
            // cerrarPestañaToolStripMenuItem
            // 
            this.cerrarPestañaToolStripMenuItem.Name = "cerrarPestañaToolStripMenuItem";
            this.cerrarPestañaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cerrarPestañaToolStripMenuItem.Text = "Cerrar Pestaña";
            this.cerrarPestañaToolStripMenuItem.Click += new System.EventHandler(this.cerrarPestañaToolStripMenuItem_Click);
            // 
            // ejectuarArchivoToolStripMenuItem
            // 
            this.ejectuarArchivoToolStripMenuItem.Name = "ejectuarArchivoToolStripMenuItem";
            this.ejectuarArchivoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ejectuarArchivoToolStripMenuItem.Text = "Ejectuar Archivo";
            this.ejectuarArchivoToolStripMenuItem.Click += new System.EventHandler(this.ejectuarArchivoToolStripMenuItem_Click);
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeErroresToolStripMenuItem,
            this.abrirAlbumToolStripMenuItem});
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // reporteDeErroresToolStripMenuItem
            // 
            this.reporteDeErroresToolStripMenuItem.Name = "reporteDeErroresToolStripMenuItem";
            this.reporteDeErroresToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.reporteDeErroresToolStripMenuItem.Text = "Reporte de Errores";
            this.reporteDeErroresToolStripMenuItem.Click += new System.EventHandler(this.reporteDeErroresToolStripMenuItem_Click);
            // 
            // abrirAlbumToolStripMenuItem
            // 
            this.abrirAlbumToolStripMenuItem.Name = "abrirAlbumToolStripMenuItem";
            this.abrirAlbumToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.abrirAlbumToolStripMenuItem.Text = "Abrir album";
            this.abrirAlbumToolStripMenuItem.Click += new System.EventHandler(this.abrirAlbumToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 343);
            this.tabControl1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(766, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 412);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(865, 150);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 590);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CRL";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pestañasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejectuarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirAlbumToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

