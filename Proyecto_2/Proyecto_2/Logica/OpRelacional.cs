using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2.Logica
{
    public class OpRelacional
    {

        private OpAritmetica opA;
        public OpRelacional()
        {

        }

        String operar(String variable)
        {
            String regreso = "0";
            for (int i=0; i<variable.Length; i++)
            {

            }
            char a = variable[1];
            return null;
        }

        String ope = "";
        public Resultado relacionar(ParseTreeNode raiz)
        {
            Resultado resultado1 = null;
            Resultado resultado2 = null;

            

            String tipoAccion = raiz.Term.Name;
            switch (tipoAccion)
            {
                case "CONDICION":

                    return relacionar(raiz.ChildNodes[0]);


                case "COND":
                    if (raiz.ChildNodes.Count == 3)
                    {

                        resultado1 = relacionar(raiz.ChildNodes[0]);
                        resultado2 = relacionar(raiz.ChildNodes[2]);
                        ope = raiz.ChildNodes[1].Token.Text;

                    }
                    else if (raiz.ChildNodes.Count == 2)
                    {
                        ope = raiz.ChildNodes[0].Token.Text;
                        resultado2 = relacionar(raiz.ChildNodes[1]);
                        //
                        resultado1 = relacionar(raiz.ChildNodes[1]);
                    }
                    else
                    {
                        //aqui debo mandar a llamar a a la proudccion e)
                        if (raiz.ChildNodes[0].ChildNodes.Count == 1)
                        {
                            return relacionar(raiz.ChildNodes[0]);
                        }
                        else
                        {
                            opA = new OpAritmetica();
                            Resultado resul = opA.operar(raiz.ChildNodes[0]);
                            return resul;

                        }
                        
                    }

                    break;
                case "E":
                    opA = new OpAritmetica();
                    Resultado resultado = opA.operar(raiz.ChildNodes[0]);
                    return  resultado;
                    

            }



            //falta verificar tipos, deben tomar la idea de la operacion arimetica para este caso
            String tipo1=resultado1.tipo;
            String tipo2=resultado2.tipo;
            switch (ope)
            {
                ///1
                case "==":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (resultado1.valor.ToString() == resultado2.valor.ToString())
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Double.Parse(resultado1.valor + "") == Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                    
                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "String":
                                    int a = String.Compare(resultado1.valor.ToString(),resultado2.valor.ToString());
                                    if (a == 0)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                    
                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    if (resultado1.valor.ToString() == resultado2.valor.ToString())
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
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
                                    if (Char.Parse(resultado1.valor + "") == Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Char.Parse(resultado1.valor + "") == Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                    

                            }
                            break;

                    }

                    break;

                    //2
                case ">":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (Double.Parse(resultado1.valor + "") > Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Double.Parse(resultado1.valor + "") > Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                    
                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "String":
                                    int a = String.Compare(resultado1.valor.ToString(), resultado2.valor.ToString());
                                    if (a == 1)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                        case "Bool":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", false);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", true);
                                        }
                                    }
                                    else
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", false);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", false);
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
                                    if (Char.Parse(resultado1.valor + "") > Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Char.Parse(resultado1.valor + "") > Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                            }
                            break;

                    }

                    break;


                //3
                case "<":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (Double.Parse(resultado1.valor + "") < Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }


                                case "String":
                                    break;

                                case "Bool":
                                    break;
                                case "Char":
                                    if (Double.Parse(resultado1.valor + "") < Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

                                case "String":
                                    int a = String.Compare(resultado1.valor.ToString(), resultado2.valor.ToString());
                                    if (a == -1)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", false);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", false);
                                        }
                                    }
                                    else
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", true);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", false);
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

                                    if (Char.Parse(resultado1.valor + "") < Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Char.Parse(resultado1.valor + "") < Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                            }
                            break;

                    }

                    break;

                //4
                case "<=":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (Double.Parse(resultado1.valor + "") <= Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    break;
                                case "Char":
                                    if (Double.Parse(resultado1.valor + "") <= Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                    
                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

                                case "String":
                                    int a = String.Compare(resultado1.valor.ToString(), resultado2.valor.ToString());
                                    if (a == -1 || a == 0)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", true);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", false);
                                        }
                                    }
                                    else
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", true);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", true);
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
                                    if (Char.Parse(resultado1.valor + "") <= Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Char.Parse(resultado1.valor + "") <= Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                            }
                            break;

                    }

                    break;

                //5

                case ">=":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    if (Double.Parse(resultado1.valor + "") >= Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    break;
                                case "Char":
                                    if (Double.Parse(resultado1.valor + "") >= Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

                                case "String":
                                    int a = String.Compare(resultado1.valor.ToString(), resultado2.valor.ToString());
                                    if (a == 1 || a == 0)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    if (resultado1.valor.Equals("true"))
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", true);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", true);
                                        }
                                    }
                                    else
                                    {
                                        if (resultado2.valor.Equals("true"))
                                        {
                                            return new Resultado("Bool", false);
                                        }
                                        else
                                        {
                                            return new Resultado("Bool", true);
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
                                    if (Char.Parse(resultado1.valor + "") >= Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Char.Parse(resultado1.valor + "") >= Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                            }
                            break;

                    }

                    break;

                //6
                case "!=":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":

                                    if (Double.Parse(resultado1.valor + "") != Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                    

                                case "String":
                                    break;

                                case "Bool":
                                    break;
                                case "Char":
                                    if (Double.Parse(resultado1.valor + "") != Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

                                case "String":
                                    int a = String.Compare(resultado1.valor.ToString(), resultado2.valor.ToString());
                                    if (a != 0)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    if (resultado1.valor.ToString() != resultado2.valor.ToString())
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
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
                                    if (Char.Parse(resultado1.valor + "") != Double.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    if (Char.Parse(resultado1.valor + "") != Char.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                            }
                            break;

                    }

                    break;

                // 7 ~
                case "~":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    Double resp = Math.Abs(Double.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));
                                    if (resp <= Principal.incerteza)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }


                                case "String":
                                    break;

                                case "Bool":
                                    break;
                                case "Char":
                                    resp = Math.Abs(Double.Parse(resultado1.valor + "") - Char.Parse(resultado2.valor + ""));
                                    if (resp <= Principal.incerteza)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }
                            }
                            break;

                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

                                case "String":
                                    String a1 =operar(resultado1.valor.ToString());
                                    String a2 = operar(resultado2.valor.ToString());
                                    int a = String.Compare(a1,a2 , StringComparison.OrdinalIgnoreCase);
                                    if (a == 0)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
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
                                    Double resp = Math.Abs(Char.Parse(resultado1.valor + "") - Double.Parse(resultado2.valor + ""));
                                    if (resp <= Principal.incerteza)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    resp = Math.Abs(Char.Parse(resultado1.valor + "") - Char.Parse(resultado2.valor + ""));
                                    if (resp <= Principal.incerteza)
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
                                    }

                            }
                            break;

                    }

                    break;


                // And or xor not

                case "&&":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

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
                                    break;

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    if (bool.Parse(resultado1.valor + "") && bool.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    break;

                            }
                            break;

                    }

                    break;

                case "||":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

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
                                    break;

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":

                                    if (bool.Parse(resultado1.valor + "") || bool.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    break;

                            }
                            break;

                    }

                    break;


                case "|&":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

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
                                    break;

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    if (bool.Parse(resultado1.valor + "") != bool.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", true);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", false);
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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    break;

                            }
                            break;

                    }

                    break;


                case "!":

                    tipo1 = resultado1.tipo;
                    switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    break;

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
                                    break;

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
                                    break;

                                case "String":
                                    break;

                                case "Bool":
                                    if (bool.Parse(resultado2.valor + ""))
                                    {
                                        return new Resultado("Bool", false);
                                    }
                                    else
                                    {
                                        return new Resultado("Bool", true);
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
                                    //reportar error semantico, linea y columna
                                    break;

                                case "String":
                                    //reportar error semantico, linea y columna
                                    break;

                                case "Bool":
                                    //reportar error semantico, linea y columna
                                    break;
                                case "Char":
                                    //reportar error semantico, linea y columna
                                    break;

                            }
                            break;

                    }

                    break;

            }


            return null;
        }

    }
}
