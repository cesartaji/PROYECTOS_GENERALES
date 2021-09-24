/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logica;

import arbol.Nodo;
import static final_compi.Interfaz.tablaDeError;
import static final_compi.Interfaz.tablaGlobal;
/**
 *
 * @author TAJI
 */
public class OpAritmetica {
    
    public Resultado operar(Nodo arbol){
        
        Resultado resultado1=null;
        Resultado resultado2=null;
        
        
        String tipoAccion = arbol.etiqueta;
        
        switch(tipoAccion){
                
                case "Double":
                    return new Resultado("Double",arbol.valor);
                
                case "String":
                    return new Resultado("String",arbol.valor.toString().replaceAll("\"", ""));

                case "ID":
                    
                    if(final_compi.Interfaz.tablaGlobal.existe(arbol.valor.toString())){
                        Simbolo r = final_compi.Interfaz.tablaGlobal.getSimbolo(arbol.valor.toString());
                        return new Resultado(r.tipo, r.valor);
                    }
                    
                    break;
                   
                    
                case "LLAMAR \n VECTOR":
                    
                    break;
                    
                case "Mas":
                        resultado1 = operar(arbol.hijos.get(0));
                        resultado2 = operar(arbol.hijos.get(1));
                        
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
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor + "") + Double.parseDouble(resultado2.valor + ""));

                                case "String":
                                    return new Resultado("String", Double.parseDouble(resultado1.valor + "") + (String)resultado2.valor);

                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("String", (String)resultado1.valor + Double.parseDouble(resultado2.valor + ""));

                                case "String":
                                    return new Resultado("String", (String)resultado1.valor + (String)resultado2.valor);

                            }
                            break;

                    }
                    break;
                    
                case "Menos":
                        resultado1 = operar(arbol.hijos.get(0));
                        resultado2 = operar(arbol.hijos.get(1));
                        
                         
                    tipo1 = resultado1.tipo;
                    
                        switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor + "") - Double.parseDouble(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    SimboloError sim = new SimboloError("String",resultado2.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor + "") - (0.0));
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico, linea y columna
                                    SimboloError sim = new SimboloError("String",resultado1.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado2.valor + "") - (0.0));
                                    
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                    }
                    
                    break;
                    
                case "Multi":
                        resultado1 = operar(arbol.hijos.get(0));
                        resultado2 = operar(arbol.hijos.get(1));
                        
                         //String tipo1;
                         //String tipo2;
                         
                    tipo1 = resultado1.tipo;
                    
                        switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor + "") * Double.parseDouble(resultado2.valor + ""));

                                case "String":
                                    //reportar error semantico, linea y columna
                                    SimboloError sim = new SimboloError("String",resultado2.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor + "") * (1.0));
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                   //reportar error semantico, linea y columna
                                    SimboloError sim = new SimboloError("String",resultado1.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado2.valor + "") * (1.0));
                                    
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                    }
                    
                    
                    break;
                
                case "Div":
                        resultado1 = operar(arbol.hijos.get(0));
                        resultado2 = operar(arbol.hijos.get(1));
                        
                         //String tipo1;
                         //String tipo2;
                         
                    tipo1 = resultado1.tipo;
                    
                        switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor + "") / Double.parseDouble(resultado2.valor + ""));

                                case "String":
                                                   SimboloError sim = new SimboloError("String",resultado2.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor + "") / (1.0));
                                    
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    //reportar error semantico,linea y columna
                                    SimboloError sim = new SimboloError("String",resultado1.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado2.valor + "") / (1.0));
                                    
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                    }
                    
                    
                    break;
                    
                case "Poten":
                    resultado1 = operar(arbol.hijos.get(0));
                        resultado2 = operar(arbol.hijos.get(1));
                        
                         //String tipo1;
                         //String tipo2;
                         
                    tipo1 = resultado1.tipo;
                    
                        switch (tipo1)
                    {
                        case "Double":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    double resp =Math.pow(Double.parseDouble(resultado1.valor+""), Double.parseDouble(resultado2.valor + ""));
                                    return new Resultado("Double", resp);

                                case "String":
                                    //reportar error semantico, linea y columna
                                    SimboloError sim = new SimboloError("String",resultado2.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado1.valor+""));
                                    
                            }
                            break;
                        case "String":
                            tipo2 = resultado2.tipo;
                            switch (tipo2)
                            {
                                case "Double":
                                    SimboloError sim = new SimboloError("String",resultado1.valor.toString(),"Semantico, Se esperaba un valor Double","0");
                                    tablaDeError.addSimbolo(sim);
                                    return new Resultado("Double", Double.parseDouble(resultado2.valor + ""));
                                    
                                case "String":
                                    //Reportar error semantoco, linea y columna
                                    break;
                            }
                            break;

                    }
                    break;    
                    
        }
        
        return null;
    }
    
}
