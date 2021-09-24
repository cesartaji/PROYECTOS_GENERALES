using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2.Logica
{
    class Principal
    {
        int contador = 0;
        int contador2 = 0;
        String graph = "";
        String graphe = "";
        String ruta = "C:/Users/TAJI/Documents/AAAA/5to/";
        public static List<Funcion> funcion;
        static public TablaSimbolo tablaGlobal;
        static public TablaSimbolo tablaLocal;
        public RichTextBox consola;
        public Stack<String> pilaAmbito;

        public static double incerteza = 0.5;
        public static string ruta_imagenes = "C:/Users/TAJI/Pictures/Imagenes_compiladores/";

        public static String ruta1= "";
        public static String ruta2 = "";


        //operaciones arimeticas, relacionales y logicas
        OpAritmetica opA;
        OpRelacional opR;
        public Principal(RichTextBox consola, ParseTreeNode raiz)
        {
            this.consola = consola;
            funcion = new List<Funcion>();
            tablaGlobal = new TablaSimbolo();
            pilaAmbito = new Stack<String>();

            //Encontrando cabezas()
            primeraEjecucion(raiz.ChildNodes[0]);
            Funcion principal = buscarPrincipal();
            tablaLocal = new TablaSimbolo();
            pilaAmbito.Push("principal");
            ejecutar(principal.raiz.ChildNodes[5].ChildNodes[0]);
            pilaAmbito.Pop();

        }


        public void primeraEjecucion(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            Resultado resultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                switch (tipoAccion)
                {

                    case "PRINCIPAL":
                        ambito = "global";
                        //--------------------------->consola.Text = consola.Text + "\n" + "Entre a principal ";
                        Funcion p = new Funcion("Vacio", "Principal", ambito, nodo, nodo.ChildNodes[3]);
                        if (!existeFuncion("principal"))
                        {
                            funcion.Add(p);
                            //consola.Text = consola.Text + "\n" + "El metodo " + "principal" + " fue agregado";
                        }
                        else
                        {
                            //consola.Text = consola.Text + "\n" + "El metodo " + "principal" + " ya existe";
                        }

                        break;
                    case "FUNCIONES":
                        tipo = nodo.ChildNodes[0].ChildNodes[0].Token.Text;
                        nombre = nodo.ChildNodes[1].Token.Text;
                        ambito = "global";

                        Funcion m = new Funcion(tipo, nombre, ambito, nodo, nodo.ChildNodes[3]);
                        //if (!existeFuncion(nombre))
                        //{
                            funcion.Add(m);
                            //consola.Text = consola.Text + "\n" + "El metodo " + nombre + " fue agregado";
                        //}
                        //else
                        //{
                        //    consola.Text = consola.Text + "\n" + "El metodo " + nombre + " ya existe";
                        //}

                        break;

                    case "ENCABEZADO":

                        if (nodo.ChildNodes.Count == 3)
                        {
                            if (nodo.ChildNodes[0].Token.Text.Equals("Definir") && nodo.ChildNodes[1].Term.Name.Equals("Double"))
                            {
                                incerteza = Double.Parse(nodo.ChildNodes[1].Token.Text);
                            }
                            else 
                            {
                                String Path  = nodo.ChildNodes[1].Token.Text.Replace("\"", "");
                                if (Directory.Exists(Path)){
                                    ruta_imagenes = Path;
                                }
                                else
                                {
                                    MessageBox.Show("La ruta no existe " + Path);
                                }
                            }
                        }
                        else
                        {
                            String rute = nodo.ChildNodes[1].Token.Text + "." + nodo.ChildNodes[3].Token.Text;
                            MessageBox.Show("importar " + rute);
                            int a = ruta1.Length - ruta2.Length;

                            //String maos = ruta1.ToCharArray(0, a) + "";

                            //MessageBox.Show("importar " + maos);
                        }


                        //opR = new OpRelacional();
                        //resultado = opR.relacionar(nodo.ChildNodes[2]);
                        //consola.Text = consola.Text + "\n" + "Resutado de condicion";
                        //consola.Text = consola.Text + "\n" + "--->" + resultado.valor;

                        break;

                    case "DECLARACION":

                        if (nodo.ChildNodes[1].ChildNodes.Count == 1)
                        {

                            tipo = nodo.ChildNodes[0].ChildNodes[0].Token.Text;
                            nombre = nodo.ChildNodes[1].ChildNodes[0].Token.Text;
                            ambito = "global";

                            if (nodo.ChildNodes[2].ChildNodes.Count == 2)
                            {

                                opR = new OpRelacional();
                                resultado = opR.relacionar(nodo.ChildNodes[2].ChildNodes[1]);
                                //antes de agregar el simbolo a la tabla se debe coparar si
                                //el tipo de la variable es igual al tipo del valor
                                //Si los tipos no son iguales se debe hacer un casteo implicito si aplica


                                if (tipo == resultado.tipo)
                                {
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                    //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + resultado.valor + "  " + resultado.tipo;
                                    Boolean estado = tablaGlobal.addSimbolo(simbolo);

                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }

                                }
                                else
                                {
                                    Casteo cast = new Casteo();
                                    Resultado res = cast.castear(tipo, resultado);

                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, res.valor);
                                    //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + res.valor + "  " + res.tipo;
                                    Boolean estado = tablaGlobal.addSimbolo(simbolo);

                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }
                                }





                            }
                            else
                            {

                                Simbolo simbolo = new Simbolo(tipo, nombre, ambito, null);
                               // consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + tipo + " nulo:vacio";

                                Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                if (!estado)
                                {
                                    consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                    //se debe incluir el tipo de error, linea y columna
                                }


                            }


                        }
                        else
                        {
                            for (int i = 0; i < nodo.ChildNodes[1].ChildNodes.Count; i++)
                            {
                                tipo = nodo.ChildNodes[0].ChildNodes[0].Token.Text;
                                nombre = nodo.ChildNodes[1].ChildNodes[i].Token.Text;
                                ambito = "global";

                                if (nodo.ChildNodes[2].ChildNodes.Count == 2)
                                {

                                    opR = new OpRelacional();
                                    resultado = opR.relacionar(nodo.ChildNodes[2].ChildNodes[1]);
                                    //antes de agregar el simbolo a la tabla se debe coparar si
                                    //el tipo de la variable es igual al tipo del valor
                                    //Si los tipos no son iguales se debe hacer un casteo implicito si aplica


                                    if (tipo == resultado.tipo)
                                    {
                                        Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                       // consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + resultado.valor + "  " + resultado.tipo;
                                        Boolean estado = tablaGlobal.addSimbolo(simbolo);

                                        if (!estado)
                                        {
                                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                            //se debe incluir el tipo de error, linea y columna
                                        }

                                    }
                                    else
                                    {
                                        Casteo cast = new Casteo();
                                        Resultado res = cast.castear(tipo, resultado);

                                        Simbolo simbolo = new Simbolo(tipo, nombre, ambito, res.valor);
                                        //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + res.valor + "  " + res.tipo;
                                        Boolean estado = tablaGlobal.addSimbolo(simbolo);

                                        if (!estado)
                                        {
                                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                            //se debe incluir el tipo de error, linea y columna
                                        }
                                    }



                                }
                                else
                                {
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, null);
                                   // consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + tipo + " nulo:vacio";

                                    Boolean estado = tablaGlobal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }
                                }


                            }
                        }


                        break;
                }
            }
        }


        public Resultado ejecutar(ParseTreeNode raiz)
        {
            String tipoAccion = "";
            String tipo;
            String nombre;
            String ambito;
            Resultado resultado;
            foreach (ParseTreeNode nodo in raiz.ChildNodes)
            {
                tipoAccion = nodo.Term.Name;
                //consola.Text = consola.Text + "\n" + "tipo accion " + tipoAccion;
                switch (tipoAccion)
                {

                    case "CUERPO_SENTENCIAS":
                        ejecutar(nodo);
                        break;

                    case "DECLARACION":

                        if (nodo.ChildNodes[1].ChildNodes.Count == 1)
                        {
                            tipo = nodo.ChildNodes[0].ChildNodes[0].Token.Text;
                            nombre = nodo.ChildNodes[1].ChildNodes[0].Token.Text;
                            ambito = pilaAmbito.Peek();

                            if (nodo.ChildNodes[2].ChildNodes.Count == 2)
                            {

                                opR = new OpRelacional();
                                resultado = opR.relacionar(nodo.ChildNodes[2].ChildNodes[1]);
                                //antes de agregar el simbolo a la tabla se debe coparar si
                                //el tipo de la variable es igual al tipo del valor
                                //Si los tipos no son iguales se debe hacer un casteo implicito si aplica


                                if (tipo == resultado.tipo)
                                {
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                    //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + resultado.valor + "  " + resultado.tipo;
                                    Boolean estado = tablaLocal.addSimbolo(simbolo);

                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }

                                }
                                else
                                {
                                    Casteo cast = new Casteo();
                                    Resultado res = cast.castear(tipo, resultado);

                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, res.valor);
                                    //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + res.valor + "  " + res.tipo;
                                    Boolean estado = tablaLocal.addSimbolo(simbolo);

                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }
                                }

                            }
                            else
                            {

                                Simbolo simbolo = new Simbolo(tipo, nombre, ambito, null);
                                //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + tipo + " nulo:vacio";

                                Boolean estado = tablaLocal.addSimbolo(simbolo);
                                if (!estado)
                                {
                                    consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                    //se debe incluir el tipo de error, linea y columna
                                }


                            }


                        }
                        else
                        {

                            for (int i = 0; i < nodo.ChildNodes[1].ChildNodes.Count; i++)
                            {
                                tipo = nodo.ChildNodes[0].ChildNodes[0].Token.Text;
                                nombre = nodo.ChildNodes[1].ChildNodes[i].Token.Text;
                                ambito = pilaAmbito.Peek();

                                if (nodo.ChildNodes[2].ChildNodes.Count == 2)
                                {

                                    opR = new OpRelacional();
                                    resultado = opR.relacionar(nodo.ChildNodes[2].ChildNodes[1]);
                                    //antes de agregar el simbolo a la tabla se debe coparar si
                                    //el tipo de la variable es igual al tipo del valor
                                    //Si los tipos no son iguales se debe hacer un casteo implicito si aplica


                                    if (tipo == resultado.tipo)
                                    {
                                        Simbolo simbolo = new Simbolo(tipo, nombre, ambito, resultado.valor);
                                        //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + resultado.valor + "  " + resultado.tipo;
                                        Boolean estado = tablaLocal.addSimbolo(simbolo);

                                        if (!estado)
                                        {
                                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                            //se debe incluir el tipo de error, linea y columna
                                        }

                                    }
                                    else
                                    {
                                        Casteo cast = new Casteo();
                                        Resultado res = cast.castear(tipo, resultado);

                                        Simbolo simbolo = new Simbolo(tipo, nombre, ambito, res.valor);
                                       // consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + res.valor + "  " + res.tipo;
                                        Boolean estado = tablaLocal.addSimbolo(simbolo);

                                        if (!estado)
                                        {
                                            consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                            //se debe incluir el tipo de error, linea y columna
                                        }
                                    }



                                }
                                else
                                {
                                    Simbolo simbolo = new Simbolo(tipo, nombre, ambito, null);
                                    //consola.Text = consola.Text + "\n" + "El resultado de la variable " + nombre + ": " + tipo + " nulo:vacio";

                                    Boolean estado = tablaLocal.addSimbolo(simbolo);
                                    if (!estado)
                                    {
                                        consola.Text = consola.Text + "\n" + "La variable " + nombre + " ya existe.";
                                        //se debe incluir el tipo de error, linea y columna
                                    }
                                }

                            }

                        }


                        break;

                    case "ASIGNACION":

                            if (tablaLocal.existe(nodo.ChildNodes[0].Token.Text))
                            {
                            Simbolo aux = Principal.tablaLocal.getSimbolo(nodo.ChildNodes[0].Token.Text);

                            opR = new OpRelacional();
                            resultado = opR.relacionar(nodo.ChildNodes[2]);

                            

                            if (aux.tipo == resultado.tipo)
                            {
                                tablaLocal.asignar(nodo.ChildNodes[0].Token.Text, resultado.tipo, resultado.valor);
                                //consola.Text = consola.Text + "\n" + "local" + resultado.valor;
                            }
                            else
                            {
                                Casteo cast = new Casteo();
                                Resultado res = cast.castear(aux.tipo, resultado);
                                tablaLocal.asignar(nodo.ChildNodes[0].Token.Text, res.tipo, res.valor);
                                //consola.Text = consola.Text + "\n" + "local" + res.valor;
                            }
                            
                         
                        }
                        else
                        {
                            Simbolo aux = Principal.tablaGlobal.getSimbolo(nodo.ChildNodes[0].Token.Text);

                            opR = new OpRelacional();
                            resultado = opR.relacionar(nodo.ChildNodes[2]);



                            if (aux.tipo == resultado.tipo)
                            {
                                tablaGlobal.asignar(nodo.ChildNodes[0].Token.Text, resultado.tipo, resultado.valor);
                                //consola.Text = consola.Text + "\n" + "global" + resultado.valor;
                            }
                            else
                            {
                                Casteo cast = new Casteo();
                                Resultado res = cast.castear(aux.tipo, resultado);
                                tablaGlobal.asignar(nodo.ChildNodes[0].Token.Text, res.tipo, res.valor);
                                //consola.Text = consola.Text + "\n" + "global" + res.valor;
                            }

                        }

                        break;

                    case "NATIVAS":
                        
                            
                        /// Console.WriteLine("{0} es de {1} ", "hola", "w2");
                        if (nodo.ChildNodes[0].Token.Text.Equals("Mostrar"))
                        {

                            

                            if (nodo.ChildNodes[2].ChildNodes.Count ==1)
                            {
                                opR = new OpRelacional();
                                resultado = opR.relacionar(nodo.ChildNodes[2].ChildNodes[0]);
                                consola.Text = consola.Text + "\n" +  resultado.valor;
                            }
                            else
                            {
                                opR = new OpRelacional();
                                resultado = opR.relacionar(nodo.ChildNodes[2].ChildNodes[0]);

                                //String aa = resultado.valor.ToString().Insert(0, "\"");
                                //int largo = aa.Length;
                                //String aaa = aa.Insert(largo, "\"");
                                
                                String a = resultado.valor.ToString();

                                Object[] misObjetos = new Object[nodo.ChildNodes[2].ChildNodes.Count-1];

                                for (int i=1; i< nodo.ChildNodes[2].ChildNodes.Count; i++)
                                {
                                    opR = new OpRelacional();
                                    resultado = opR.relacionar(nodo.ChildNodes[2].ChildNodes[i]);
                                    misObjetos[i-1] = resultado.valor;
                                }
                                
                                string perro = "";
                                //perro = String.Format("dd {0} {1} ", 10, 15);
                                perro = String.Format(a,misObjetos);

                                consola.Text = consola.Text + "\n" +  perro;

                            }

                        }


                        else if (nodo.ChildNodes[0].Token.Text.Equals("DibujaEXP"))
                        {
                            contador++;
                            //Casteo a = new Casteo();
                            //ParseTreeNode exp = a.DibujarEXP(nodo.ChildNodes[2]);

                            GenarbolExp(nodo.ChildNodes[2]);
                            generateGraphExp("Ejemplo"+contador+ ".txt");

                        }

                        else if (nodo.ChildNodes[0].Token.Text.Equals("DibujarTS"))
                        {
                            contador2++;
                            String j3 = "\"]}";
                            String j2 = "";
                            String j1 = "digraph models_diagram {" +
                            "graph[rankdir = LR, overlap = false, splines = true]"
                            + "struct1[shape = record, label = \"Variable                Valor";
                      
                            //+"|<f0> ID: integer|<f1> TABLE_1_ID: integer\"]"
                      

                            TablaSimbolo tabla = tablaLocal;
                                 foreach (Simbolo s in tabla.simbolos)
                                 {
                                    j2 += "| Variable: "+  s.nombre + ",      Tipo: " + s.tipo + ",         Valor:" + s.valor;
                                }
                               
                            
                            System.IO.StreamWriter f = new System.IO.StreamWriter(ruta_imagenes + "tabla"+contador2+".txt");
                            f.Write(j1 + j2 +j3 );
                            f.Close();
                            generateGraphExp("tabla"+contador2+".txt");
                        }
                        

                        

                        break;

                    case "retornar":
                        

                        if (nodo.ChildNodes[2].ChildNodes.Count == 3)
                        {
                            opR = new OpRelacional();
                            resultado = opR.relacionar(nodo.ChildNodes[1]);

                            return resultado;
                        }
                        else
                        {
                            break;
                        }


                    case "OpId":

                        // este es para llamar funciones
                        if (nodo.ChildNodes.Count == 5)
                        {
                            
                            if (nodo.ChildNodes[2].ChildNodes.Count == 1 && nodo.ChildNodes[2].ChildNodes[0].Term.Name == "EPSILON")
                            {
                                Funcion a = buscarFuncion(nodo.ChildNodes[0].Token.Text, "vacio");
                                //resultado = opA.operar(nodo.ChildNodes[1]);
                                //return new Resultado(resultado.tipo, resultado.valor);

                                TablaSimbolo aux = tablaLocal;
                                //creo una nueva tabla para cambiar 
                                tablaLocal = new TablaSimbolo();
                                tablaLocal.cambiarAmbito(aux);
                                //******

                                ejecutar(a.raiz.ChildNodes[6].ChildNodes[0]);

                                //********
                                tablaLocal = aux;

                            }
                            else
                            {
                                String concatenacion = "";
                                // con este voy a concatenar los tipos de la lista E
                                for (int i = 0; i < nodo.ChildNodes[2].ChildNodes.Count; i++) {

                                    opA = new OpAritmetica();
                                    resultado = opA.operar(nodo.ChildNodes[2].ChildNodes[i]);
                                    if (i==0)
                                    {
                                        concatenacion += resultado.tipo;
                                    }
                                    else
                                    {
                                        concatenacion += ","+resultado.tipo;
                                    }
                                    
                                }
                                //consola.Text = consola.Text + "\n" + concatenacion;

                                Funcion a = buscarFuncion(nodo.ChildNodes[0].Token.Text,concatenacion);
                                TablaSimbolo aux = tablaLocal;
                                //creo una nueva tabla para cambiar al ambito 
                                tablaLocal = new TablaSimbolo();
                                tablaLocal.cambiarAmbito(aux);
                                //******
                                        
                                        for (int i = 0; i < a.para.ChildNodes.Count; i++)
                                        {
                                            tipo = a.para.ChildNodes[i].ChildNodes[0].ChildNodes[0].Token.Text;
                                            nombre = a.para.ChildNodes[i].ChildNodes[1].Token.Text;
                                            ambito = pilaAmbito.Peek();


                                            opA = new OpAritmetica();
                                            resultado = opA.operar(nodo.ChildNodes[2].ChildNodes[i]);
                                            //consola.Text = consola.Text + "\n" + nombre + " " + resultado.valor;
                                            Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                                            Boolean estado = tablaLocal.addSimbolo(simbolo);
                                        }
                                        
                                        ejecutar(a.raiz.ChildNodes[6].ChildNodes[0]);

                                //********
                                tablaLocal = aux;


                            }



                        }


                        break;

                    case "SENTENCIAS_CONTROL":
                        ejecutar(nodo);
                        break;

                    case "IF_IF":

                        if (nodo.ChildNodes.Count == 8)
                        {
                            opR = new OpRelacional();
                            resultado = opR.relacionar(nodo.ChildNodes[2]);
                            TablaSimbolo aux2 = tablaLocal;
                            //creo una nueva tabla para cambiar al ambito if
                            tablaLocal = new TablaSimbolo();
                            tablaLocal.cambiarAmbito(aux2);
                            if (Boolean.Parse(resultado.valor + ""))
                            {
                                ejecutar(nodo.ChildNodes[5].ChildNodes[0]);
                            }
                            else
                            {
                                ejecutar(nodo.ChildNodes[7].ChildNodes[2].ChildNodes[0]);
                            }

                            //regreso al ambito anterior
                            tablaLocal = aux2;

                        }
                        else
                        {

                            opR = new OpRelacional();
                            resultado = opR.relacionar(nodo.ChildNodes[2]);
                            TablaSimbolo aux2 = tablaLocal;
                            //creo una nueva tabla para cambiar al ambito if
                            tablaLocal = new TablaSimbolo();
                            tablaLocal.cambiarAmbito(aux2);
                            if (Boolean.Parse(resultado.valor + ""))
                            {
                                ejecutar(nodo.ChildNodes[5].ChildNodes[0]);
                            }
                            

                            //regreso al ambito anterior
                            tablaLocal = aux2;


                        }

                        break;

                    case "do_while":


                        break;

                }
            }



            return null;
        }



        public static Funcion buscarFuncion(String nombre, String parametros)
        {
            foreach (Funcion m in funcion)
            {
                if (m.nombre == nombre && m.ambito == parametros)
                {
                    //consola.Text = consola.Text + "\n" + "Encontre el metodo/funcion" + nombre + " "+ parametros;
                    return m;
                }

            }

            return null;
        }


        public Funcion buscarPrincipal()
        {
            foreach (Funcion m in funcion)
            {
                if (m.nombre == "Principal")
                {
                     //consola.Text = consola.Text + "\n" + "Encontre a principal ";
                    return m;
                }

            }

            return null;
        }

        public Boolean existeFuncion(String nombre )
        {
            foreach (Funcion m in funcion)
            {
                if (nombre == m.nombre)
                {
                    
                    return true;
                }
            }

            return false;

        }


        //*****************************************Generar grafo
        public void Genarbol(ParseTreeNode raiz)
        {
            System.IO.StreamWriter f = new System.IO.StreamWriter(ruta + "Ejemplo.txt");
            f.Write("digraph lista{ rankdir=TB;node [shape = box, style=rounded]; ");
            graph = "";
            Generar(raiz);
            f.Write(graph);
            f.Write("}");
            f.Close();

        }
        public void Generar(ParseTreeNode raiz)
        {
            graph = graph + "nodo" + raiz.GetHashCode() + "[label=\"" + raiz.ToString().Replace("\"", "\\\"") + " \", fillcolor=\"yellow\", style =\"filled\", shape=\"circle\"]; \n";
            if (raiz.ChildNodes.Count > 0)
            {
                ParseTreeNode[] hijos = raiz.ChildNodes.ToArray();
                for (int i = 0; i < raiz.ChildNodes.Count; i++)
                {
                    Generar(hijos[i]);
                    graph = graph + "\"nodo" + raiz.GetHashCode() + "\"-> \"nodo" + hijos[i].GetHashCode() + "\" \n";
                }
            }
        }


        public void generateGraph(string fileName)
        {
            try
            {
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(ruta, fileName), Path.Combine(ruta, fileName.Replace(".txt", ".jpg")));
                //String command = "dot -Tjpg " + fileName + " -o " + fileName.Replace(".txt", ".jpg");
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {

            }
        }

        //***********************

        public void GenarbolExp(ParseTreeNode raiz)
        {
            System.IO.StreamWriter f = new System.IO.StreamWriter(ruta_imagenes + "Ejemplo"+contador+".txt");
            f.Write("digraph lista{node [shape = record,height=.1]; ");
            graphe = "";
            GenerarExp(raiz);
            f.Write(graphe);
            f.Write("}");
            f.Close();

        }
        public void GenerarExp(ParseTreeNode raiz)
        {
            graphe = graphe + "nodo" + raiz.GetHashCode() + "[label=\"" + raiz.ToString().Replace("\"", "\\\"") + " \", fillcolor=\"gray\", style =\"filled\", shape=\"record\"]; \n";
            if (raiz.ChildNodes.Count > 0)
            {
                ParseTreeNode[] hijos = raiz.ChildNodes.ToArray();
                for (int i = 0; i < raiz.ChildNodes.Count; i++)
                {
                    GenerarExp(hijos[i]);
                    graphe = graphe + "\"nodo" + raiz.GetHashCode() + "\"-> \"nodo" + hijos[i].GetHashCode() + "\" \n";
                }
            }
        }


        public void generateGraphExp(string fileName)
        {
            try
            {
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(ruta_imagenes, fileName), Path.Combine(ruta_imagenes, fileName.Replace(".txt", ".jpg")));
                //String command = "dot -Tjpg " + fileName + " -o " + fileName.Replace(".txt", ".jpg");
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {

            }
        }





    }
}
