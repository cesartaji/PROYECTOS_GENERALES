using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_2.Logica;

namespace Proyecto_2.Logica
{
    public class OpAritmetica
    {

        public OpAritmetica()
        {

        }

        String ope = "";
        double ident = 0;
        public Resultado operar(ParseTreeNode raiz)
        {
            Resultado resultado1 = null;
            Resultado resultado2 = null;
            
            System.Diagnostics.Debug.WriteLine("Entre al metodo operar");

            String tipoAccion = raiz.Term.Name;
            switch (tipoAccion)
            {
                case "EXPRESION":
                    System.Diagnostics.Debug.WriteLine("ENTRE A EXPRESION");
                    return operar(raiz.ChildNodes[0]);

                //case "lista_E":
                //    System.Diagnostics.Debug.WriteLine("ENTRE A LISTA_E");

                //    if (raiz.ChildNodes.Count == 3)
                //    {
                //        return operar(raiz.ChildNodes[0]);
                //    }
                //    else
                //    {

                //        return operar(raiz.ChildNodes[0]);
                //    }

                case "E":
                    if (raiz.ChildNodes.Count == 3)
                    {
                        System.Diagnostics.Debug.WriteLine("Entre a la produccion E DE 3");
                        resultado1 = operar(raiz.ChildNodes[0]);
                        resultado2 = operar(raiz.ChildNodes[2]);
                        ope = raiz.ChildNodes[1].Token.Text;
                        break;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Entre a la produccion E DE 1");
                        return operar(raiz.ChildNodes[0]);

                    }


                case "T":
                    return operar(raiz.ChildNodes[0]);

                case "identificadores":

                    if (raiz.ChildNodes.Count == 1)
                    {
                        return operar(raiz.ChildNodes[0]);
                    }
                    else
                    {
                        
                        Resultado r1 = operar(raiz.ChildNodes[0]); //id 
                        Resultado r2 = operar(raiz.ChildNodes[1]); // ++ --
                        Casteo cast = new Casteo();
                        Resultado r3 = cast.castear_iteradores(r1, r2);
                        
                        return r3;
                    }


                case "++":
                    return new Resultado("Double", 1);

                case "--":
                    return new Resultado("Double", -1);


                case "EnParentesis":
                    if (raiz.ChildNodes[1].ChildNodes.Count == 1)
                    {
                        return operar(raiz.ChildNodes[1]);

                    } else //else if (raiz.ChildNodes[1].ChildNodes.Count == 3)
                    {
                        OpRelacional opR = new OpRelacional();
                        Resultado resultado = opR.relacionar(raiz.ChildNodes[1]);
                        return new Resultado(resultado.tipo,resultado.valor);
                    }


                case "COND":
                    return operar(raiz.ChildNodes[0]);


                case "Double":
                    return new Resultado("Double", raiz.Token.Text);

                case "String":
                    String cadena = raiz.Token.Text.Replace("\"", "");
                    return new Resultado("String", cadena);

                case "cadena_char":
                    String cadena_c = raiz.Token.Text.Replace("'", "");
                    return new Resultado("Char", cadena_c);

                case "true":
                    return new Resultado("Bool", raiz.Token.Text);

                case "false":
                    return new Resultado("Bool", raiz.Token.Text); 

                case "id":
                    //acceder a la tabla de simbolo para tomar el valor y el tipo del id
                    System.Diagnostics.Debug.WriteLine("Entre a la produccion de id");

                    if (Principal.tablaGlobal.existe(raiz.Token.Text))
                    {
                        Simbolo aux = Principal.tablaGlobal.getSimbolo(raiz.Token.Text);                    
                        return new Resultado(aux.tipo,aux.valor);
                    }
                    else if (Principal.tablaLocal.existe(raiz.Token.Text))
                    {

                        Simbolo aux = Principal.tablaLocal.getSimbolo(raiz.Token.Text);
                        return new Resultado(aux.tipo, aux.valor);
                    }

                break;
                case "LlamarMetodo":
                    //enviar como parametro la raiz al metodo ejecutar para obtener el valor de la funcion

                    if (raiz.ChildNodes[2].ChildNodes.Count == 1 && raiz.ChildNodes[2].ChildNodes[0].Term.Name == "EPSILON")
                    {

                        Funcion a = Principal.buscarFuncion(raiz.ChildNodes[0].Token.Text, "vacio");
                        //resultado = opA.operar(nodo.ChildNodes[1]);
                        //return new Resultado(resultado.tipo, resultado.valor);

                        TablaSimbolo aux = Principal.tablaLocal;
                        //creo una nueva tabla para cambiar 
                        Principal.tablaLocal = new TablaSimbolo();
                        Principal.tablaLocal.cambiarAmbito(aux);
                        //******

                        Principal ax = new Principal(null,null);
                        Resultado res = ax.ejecutar(a.raiz.ChildNodes[6].ChildNodes[0]);
                        //Principal.ejecutar(a.raiz.ChildNodes[6].ChildNodes[0]);

                        //********
                        Principal.tablaLocal = aux;
                        return res;
                    }
                    else
                    {
                        //String concatenacion = "";
                        //// con este voy a concatenar los tipos de la lista E
                        //for (int i = 0; i < nodo.ChildNodes[2].ChildNodes.Count; i++)
                        //{

                        //    opA = new OpAritmetica();
                        //    resultado = opA.operar(nodo.ChildNodes[2].ChildNodes[i]);
                        //    if (i == 0)
                        //    {
                        //        concatenacion += resultado.tipo;
                        //    }
                        //    else
                        //    {
                        //        concatenacion += "," + resultado.tipo;
                        //    }

                        //}
                        ////consola.Text = consola.Text + "\n" + concatenacion;

                        //Funcion a = buscarFuncion(nodo.ChildNodes[0].Token.Text, concatenacion);
                        //TablaSimbolo aux = tablaLocal;
                        ////creo una nueva tabla para cambiar al ambito 
                        //tablaLocal = new TablaSimbolo();
                        //tablaLocal.cambiarAmbito(aux);
                        ////******

                        //for (int i = 0; i < a.para.ChildNodes.Count; i++)
                        //{
                        //    tipo = a.para.ChildNodes[i].ChildNodes[0].ChildNodes[0].Token.Text;
                        //    nombre = a.para.ChildNodes[i].ChildNodes[1].Token.Text;
                        //    ambito = pilaAmbito.Peek();


                        //    opA = new OpAritmetica();
                        //    resultado = opA.operar(nodo.ChildNodes[2].ChildNodes[i]);
                        //    consola.Text = consola.Text + "\n" + nombre + " " + resultado.valor;
                        //    Simbolo simbolo = new Simbolo(resultado.tipo, nombre, ambito, resultado.valor);
                        //    Boolean estado = tablaLocal.addSimbolo(simbolo);
                        //}

                        //ejecutar(a.raiz.ChildNodes[6].ChildNodes[0]);

                        ////********
                        //tablaLocal = aux;


                    }


                    ////
                    break;
            }


            //String operacion = raiz.Token.Text;
            String tipo1;
            String tipo2;

            switch (ope)
            {
                case "+":
                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                case "String":
                                    return new Resultado("String", Double.Parse(resultado1.valor + "") + (String)resultado2.valor);

                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") + 1);
                                    }
                                    else
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") + 0);
                                    }
                                case "Char":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") + Char.Parse(resultado2.valor + ""));

                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("String", (String)resultado1.valor + Double.Parse(resultado2.valor + ""));

                                case "String":
                                    return new Resultado("String", (String)resultado1.valor + (String)resultado2.valor);

                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("String", (String)resultado1.valor + "1");
                                    }
                                    else
                                    {
                                        return new Resultado("String", (String)resultado1.valor + "0");
                                    }
                                case "Char":
                                    return new Resultado("String", (String)resultado1.valor + (String)resultado2.valor);

                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        return new Resultado("Double",1 + Double.Parse(resultado2.valor + ""));
                                    }
                                    else
                                    {
                                        return new Resultado("Double", 0 + Double.Parse(resultado2.valor + ""));
                                    }
                                    

                                case "String":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        return new Resultado("String","1" + (String)resultado2.valor);
                                    }
                                    else
                                    {
                                        return new Resultado("String", "0" + (String)resultado2.valor);
                                    }

                                case "Bool":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Double", 1 + 1);
                                        }
                                        else
                                        {
                                            return new Resultado("Double", 1 + 0);
                                        }
                                    }
                                    else
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Double", 0 + 1);
                                        }
                                        else
                                        {
                                            return new Resultado("Double", 0 + 0);
                                        }
                                    }
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Char":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") + Double.Parse(resultado2.valor + ""));

                                case "String":
                                    return new Resultado("String", (String)resultado1.valor + (String)resultado2.valor);

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") + Char.Parse(resultado2.valor + ""));

                            }
                            break;
                    }

                    break;
                case "*":
                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") * 1);
                                    }
                                    else
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") * 0);
                                    }
                                case "Char":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") * Char.Parse(resultado2.valor + ""));
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico,linea y columna
                                    break;
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Char":
                                    //Reportar error semantoco, linea y columna
                                    break;

                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", 1 * Double.Parse(resultado2.valor + ""));
                                    }
                                    else
                                    {
                                        return new Resultado("Double", 0 * Double.Parse(resultado2.valor + ""));
                                    }


                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Char":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") * Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") * Char.Parse(resultado2.valor + ""));

                            }
                            break;


                    }
                    break;
                case "-":
                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") - 1);
                                    }
                                    else
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") - 0);
                                    }
                                case "Char":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") - Char.Parse(resultado2.valor + ""));

                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico,linea y columna
                                    break;
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Char":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", 1 - Double.Parse(resultado2.valor + ""));
                                    }
                                    else
                                    {
                                        return new Resultado("Double", 0 - Double.Parse(resultado2.valor + ""));
                                    }

                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Char":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") - Char.Parse(resultado2.valor + ""));

                            }
                            break;

                    }
                    break;

                case "/":
                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") / 1);
                                    }
                                    else
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") / 0);
                                    }
                                case "Char":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") / Char.Parse(resultado2.valor + ""));
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico,linea y columna
                                    break;
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Char":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", 1 / Double.Parse(resultado2.valor + ""));
                                    }
                                    else
                                    {
                                        return new Resultado("Double", 0 / Double.Parse(resultado2.valor + ""));
                                    }

                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Char":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") / Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") / Char.Parse(resultado2.valor + ""));

                            }
                            break;
                    }
                    break;

                case "^":
                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    double resp;
                                    resp = Math.Pow(Double.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + ""));
                                    return new Resultado("Double", resp);

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        resp = Math.Pow(Double.Parse(resultado1.valor + ""), 1);
                                        return new Resultado("Double", resp);
                                    }
                                    else
                                    {
                                        resp = Math.Pow(Double.Parse(resultado1.valor + ""), 0);
                                        return new Resultado("Double", resp);
                                    }
                                case "Char":
                                    resp = Math.Pow(Double.Parse(resultado1.valor + ""), Char.Parse(resultado2.valor + ""));
                                    return new Resultado("Double", resp);
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico,linea y columna
                                    break;
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Char":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        Double resp = Math.Pow(1,Double.Parse(resultado2.valor + ""));
                                        return new Resultado("Double", resp);
                                    }
                                    else
                                    {
                                        Double resp = Math.Pow(0, Double.Parse(resultado2.valor + ""));
                                        return new Resultado("Double", resp);
                                    }

                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Char":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    Double resp;
                                    resp = Math.Pow(Char.Parse(resultado1.valor + ""), Double.Parse(resultado2.valor + ""));
                                    return new Resultado("Double", resp);

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    resp = Math.Pow(Char.Parse(resultado1.valor + ""), Char.Parse(resultado2.valor + ""));
                                    return new Resultado("Double", resp);

                            }
                            break;

                    }
                    break;

                

                case "%":
                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") % 1);
                                    }
                                    else
                                    {
                                        return new Resultado("Double", Double.Parse(resultado1.valor + "") % 0);
                                    }
                                case "Char":
                                    return new Resultado("Double", Double.Parse(resultado1.valor + "") % Char.Parse(resultado2.valor + ""));
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico,linea y columna
                                    break;
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Char":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        return new Resultado("Double", 1 % Double.Parse(resultado2.valor + ""));
                                    }
                                    else
                                    {
                                        return new Resultado("Double", 0 % Double.Parse(resultado2.valor + ""));
                                    }

                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;

                                case "Bool":
                                    //Reportar error semantoco, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Char":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") % Double.Parse(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    return new Resultado("Double", Char.Parse(resultado1.valor + "") % Char.Parse(resultado2.valor + ""));

                            }
                            break;
                    }
                    break;







                case "id":
                    break;
                case "LLAMADAMETODO":
                    break;
                case "Double":
                    return new Resultado("Double", raiz.Token.Text);
                case "cadena":
                    return new Resultado("String", raiz.Token.Text);

            }
            
           return null;

        }



    }

    
}
