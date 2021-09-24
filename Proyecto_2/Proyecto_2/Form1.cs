using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_2.Analisis;
using Irony.Parsing;
using System.Threading;
using Proyecto_2.Logica;

namespace Proyecto_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int contador_nuevo = 0; //contador para el titulo de las pestañas
        RichTextBox rich; //variable global de tipo richtextbox que se usa para analizar el contenido de la pestaña activa
        string linea; //variable que guarda el contenido del rich


        public void abrir_archivo()
        {

            //seleccionar el archivo de entrada

            OpenFileDialog abrir_grafo = new OpenFileDialog();
            abrir_grafo.Filter = "Archivos clr|*.clr";
            abrir_grafo.Title = "CRL-Seleccionar archivo";

            if (abrir_grafo.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    System.IO.StreamReader leer_grafo = new System.IO.StreamReader(abrir_grafo.FileName, System.Text.Encoding.Default);
                    //lee el archivo línea a línea hasta el final
                    linea = leer_grafo.ReadToEnd();
                    leer_grafo.Close();
                    //muestra lo que está en el archivo en el richtextbox

                    /////////////////////////////
                    //contador_nuevo++;
                    TabPage nuevo_abrir = new TabPage(abrir_grafo.SafeFileName);
                    //nuevo_abrir.Name = abrir_grafo.FileName;
                    nuevo_abrir.Name = abrir_grafo.FileName;
                    tabControl1.TabPages.Add(nuevo_abrir);

                        

                    //RichTextBox editor_abrir = new RichTextBox();
                    rich = new RichTextBox();
                    rich.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    nuevo_abrir.Controls.Add(rich);
                    rich.AcceptsTab = true;
                    rich.Multiline = true;
                    rich.Size = new Size(nuevo_abrir.Width, nuevo_abrir.Height);

                    

                    tabControl1.SelectedTab = nuevo_abrir;
                    //////////////////////////////

                    rich.Text = linea;
                    //colorear1();
                    //analizador.analizar(linea);

                    //analizador.imprimirValidos();
                    //analizador.imprimirErrores();
                    //analizador.mostrarLista(analizador.lista_token);
                }
                catch
                {
                    MessageBox.Show("Archivo no se pudo leer correctamente, verificar que no contenga errores");
                }
            }

        }



        public void nuevoDocumento()
        {
            contador_nuevo++;
            TabPage nuevo = new TabPage("Archivo" + contador_nuevo); //se crea una nueva pestaña
            tabControl1.TabPages.Add(nuevo); //se agrega al tabControl

            RichTextBox editor = new RichTextBox(); //se crea un richtextbox nuevo para agregar a la pestaña creada antes
            nuevo.Controls.Add(editor); //se agrega a la pestaña el rich
            editor.AcceptsTab = true; //el rich acepta tabulación
            editor.Multiline = true;    //el rich es multilinea
            editor.Size = new Size(nuevo.Width, nuevo.Height);  //el tamaño del rich es del tamaño de la pestaña
            editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            tabControl1.SelectedTab = nuevo;    //indica que la pestaña está activa
        }


        public void guardar_archivo_como()
        {
            SaveFileDialog guardar_grafo = new SaveFileDialog();
            guardar_grafo.Filter = "Archivos clr|*.clr";
            if (guardar_grafo.ShowDialog() == DialogResult.OK && guardar_grafo.FileName.Length > 0)
            {
                try
                {
                    System.IO.StreamWriter nuevo_grafo = System.IO.File.CreateText(guardar_grafo.FileName);

                    //la variable global de tipo rich es la que se utiliza para analizar lo que tenemos en la pestaña
                    rich = (RichTextBox)ActiveControl; //la parte (RichTextBox)ActiveControl indica que analizará el richtext que está activo 
                    linea = rich.Text;  //contenido del rich
                    nuevo_grafo.Write(linea.ToString());
                    nuevo_grafo.Flush();
                    nuevo_grafo.Close();
                }
                catch
                {
                    MessageBox.Show("Archivo no pudo guardarse correctamente, verificar");
                }
            }

        }


        public void guardar()
        {
            //Console.WriteLine(tabControl1.SelectedTab.Name + "full");
            //Console.WriteLine(tabControl1.SelectedTab.Text + "corta");
            
                try
                {
                    System.IO.StreamWriter nuevo_grafo = System.IO.File.CreateText(tabControl1.SelectedTab.Name);

                    //la variable global de tipo rich es la que se utiliza para analizar lo que tenemos en la pestaña
                    rich = (RichTextBox)ActiveControl; //la parte (RichTextBox)ActiveControl indica que analizará el richtext que está activo 
                    linea = rich.Text;  //contenido del rich
                    nuevo_grafo.Write(linea.ToString());
                    nuevo_grafo.Flush();
                    nuevo_grafo.Close();
                }
                catch
                {
                    MessageBox.Show("Archivo no pudo guardarse correctamente, verificar");
                }
            

        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoDocumento();
        }

        
        

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir_archivo();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardar_archivo_como();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Console.WriteLine(tabControl1.SelectedTab.Name + "--full");
            Console.WriteLine(tabControl1.SelectedTab.Text + "--corta");

            //String variable = "   p e r r o";

            //bool b = false;
            //String regreso = "";
            //for (int i = 0; i < variable.Length-1; i++)
            //{
            //    if (!(variable[i] == ' ') || !(variable[i+1] == ' '))
            //    {
            //        b = true;
            //    }

            //    if (variable[i]==' ')
            //    {
            //        if (variable[i + 1] == ' ')
            //        {

            //        }
            //        else if (b)
            //        {

            //        }
            //        else
            //        {
            //            regreso += variable[i].ToString();
            //        }

            //    }else
            //    {
            //        regreso += variable[i].ToString();
            //    }

            //}



            //MessageBox.Show("{0} es de {1}", "hola","perro");
            Console.WriteLine("{0} es de {1} ", "hola", 1+2+3);
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void cerrarPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void ejectuarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            Gramatica grammar = new Gramatica();
            LanguageData lenguaje = new LanguageData(grammar);
            Parser p = new Parser(lenguaje);

            rich = (RichTextBox)ActiveControl;
            linea = rich.Text;  //contenido del rich

            ParseTree arbol = p.Parse(linea);
            if (arbol.Root != null)
            {
                //1 --full
                //2 --larga
                Principal.ruta1 = tabControl1.SelectedTab.Name;
                Principal.ruta2 = tabControl1.SelectedTab.Text;

                MessageBox.Show("Salida...Correcta");
                Principal prin = new Principal(richTextBox1,arbol.Root);
                prin.Genarbol(arbol.Root);
                //prin.generateGraph("Ejemplo.txt");

                //hread.Sleep(2000);
                //System.Diagnostics.Process.Start("C:\\Users\\TAJI\\Documents\\AAAA\\5to\\Ejemplo.jpg");

            }
            else
            {
                MessageBox.Show("Fallo en la interpretacion");
            }

        }

        private void abrirAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Principal.ruta_imagenes);
        }

        private void reporteDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
