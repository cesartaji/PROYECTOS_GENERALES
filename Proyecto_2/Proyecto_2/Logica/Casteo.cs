using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2.Logica
{
    public class Casteo
    {

        public Resultado castear(String resultado1 ,Resultado resultado2)
        {


            String tipo1;
            String tipo2;

              
                    tipo1 = resultado1;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                        break;

                                case "String":
                                    return new Resultado("Error", null);

                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("Double",1);
                                    }
                                    else
                                    {
                                        return new Resultado("Double",0);
                                    }
                                case "Char":
                                    return new Resultado("Double", Char.Parse(resultado2.valor + "")+0);

                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("String",Double.Parse(resultado2.valor + ""));

                                case "String":
                                    break;

                                case "Bool":
                                    if (resultado2.valor.Equals("true"))
                                    {
                                        return new Resultado("String",1);
                                    }
                                    else
                                    {
                                        return new Resultado("String", 0);
                                    }
                                case "Char":
                                    return new Resultado("String",(String)resultado2.valor);

                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                        return new Resultado("Error", null);

                                case "String":
                                        return new Resultado("Error", null);

                                case "Bool":
                                        break;
                                case "Char":
                                        return new Resultado("Error", null);

                    }
                            break;

                        case "Char":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":

                                    try {
                                        int cc =Int32.Parse(resultado2.valor.ToString());
                                        return new Resultado("Char", (char)cc);
                                    }
                                    catch
                                    {
                                        return new Resultado("Error", null);
                                    }
                            
                                case "String":
                                    return new Resultado("Error", null);

                                case "Bool":
                                    return new Resultado("Error", null);

                                case "Char":
                                    break;

                            }
                            break;

                case "Int":
                    tipo2 = resultado2.tipo;
                    switch (tipo2)
                    {
                        case "Double":
                                return new Resultado("Double", Convert.ToInt32(Double.Parse(resultado2.valor + "")));

                        case "String":
                                return new Resultado("Error", null);

                        case "Bool":
                            if (resultado2.valor.Equals("true"))
                            {
                                return new Resultado("Double", 1);
                            }
                            else
                            {
                                return new Resultado("Double", 0);
                            }
                        case "Char":
                            return new Resultado("Double", Char.Parse(resultado2.valor + "") + 0);

                    }
                    break;


            }
            return null;
        

                    
        }


        // otro metodo para castear
                                            //        id               ++ --
        public Resultado castear_iteradores(Resultado resultado1, Resultado resultado2)
        {


            String tipo1;
            String tipo2;


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
                            break;

                        case "Bool":
                            break;
                        case "Char":
                            break;

                    }
                    break;

                case "String":
                    tipo2 = resultado2.tipo;
                    switch (tipo2)
                    {
                        case "Double":
                            //return new Resultado("String", Double.Parse(resultado2.valor + ""));

                        case "String":
                            break;

                        case "Bool":
                            break;
                        case "Char":
                            break;

                    }
                    break;

                case "Bool":
                    tipo2 = resultado2.tipo;
                    switch (tipo2)
                    {
                        case "Double":
                            //return new Resultado("Error", null);

                        case "String":
                            break;

                        case "Bool":
                            break;
                        case "Char":
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
                            break;

                        case "Bool":
                            break;

                        case "Char":
                            break;

                    }
                    break;


            }
            return null;
        }

        // para dibujar el arbol
        String afuera = "";

        public String DibujarEXP(ParseTreeNode raiz)
        {
            //raiz.ChildNodes.Remove


            //String tipoAccion = raiz.Term.Name;
            //switch (tipoAccion)
            //{
            //    case "EXPRESION":
            //        DibujarEXP(raiz.ChildNodes[0]);
            //        break;

            //    case "E":
            //        if (raiz.ChildNodes.Count == 3)
            //        {

            //            DibujarEXP(raiz.ChildNodes[0]);
            //            DibujarEXP(raiz.ChildNodes[2]);
            //            afuera = "Aritmentica |" + raiz.ChildNodes[1].Token.Text;
            //            break;
            //        }
            //        else
            //        {

            //            DibujarEXP(raiz.ChildNodes[0]);

            //        }
            //        break;

            //    case "T":
            //        return operar(raiz.ChildNodes[0]);
            //        break;

            //    case "CONDICION":
            //        DibujarEXP(raiz.ChildNodes[0]);
            //        break;

            //    case "COND":
            //        DibujarEXP(raiz.ChildNodes[0]);
            //        break;


            return "";

        }

                  
        }
        




    }

