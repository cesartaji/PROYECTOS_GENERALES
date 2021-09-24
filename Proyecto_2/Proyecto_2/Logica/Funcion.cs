using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2.Logica
{
    public class Funcion
    {
        public String tipo;
        public String nombre;
        public String ambito="";
        public ParseTreeNode raiz;
        public ParseTreeNode para;//cuando hay sobrecarga el id es importante y para generarlo se concatena el nombre del metodo con todos los tipos de los parametros
        

        public Funcion(String tipo, String nombre, String ambito, ParseTreeNode raiz, ParseTreeNode para)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            
            this.raiz = raiz;
            this.para = para;

            this.ambito = generarId(para);
            System.Diagnostics.Debug.WriteLine("---->" + this.ambito);

        }

        public string generarId(ParseTreeNode parametros)
        {
            String returno = "";
            String primero = "true";
            //aqui es donde se recorre la lista de parametros y se concatena el tipo de cada uno
            foreach (ParseTreeNode nodo in parametros.ChildNodes)
            {
                
                String tipoAccion = nodo.Term.Name;

                switch (tipoAccion)
                {

                    case "DEF_PARAMETROS":

                        if (nodo.ChildNodes.Count > 1) { 

                        if (primero.Equals("true")) { 
                        String td = nodo.ChildNodes[0].ChildNodes[0].Token.Text;
                        String id = nodo.ChildNodes[1].Token.Text;
                            returno += td ;
                                //returno += td + ":" + id;
                                primero = "false";
                        } else  if (primero.Equals("false"))
                        {            
                            String td = nodo.ChildNodes[0].ChildNodes[0].Token.Text;
                            String id = nodo.ChildNodes[1].Token.Text;
                            returno += ","+ td ;
                                //returno += ";" + td + ":" + id;
                            }

                        }
                        else
                        {
                            returno += "vacio";
                        }

                        break;
                        
                }
            }

                        return returno;
        }
    }
}
