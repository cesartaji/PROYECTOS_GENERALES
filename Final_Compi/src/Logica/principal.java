/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logica;

import arbol.Nodo;
import final_compi.Interfaz;
import static final_compi.Interfaz.tablaGlobal;

/**
 *
 * @author TAJI
 */
public class principal {
    
    
    
    
    public void ejecucion(Nodo arbol){
   
        for(int i=0;i<arbol.hijos.size();i++) {
             
            String tipoAccion = arbol.hijos.get(i).etiqueta;
            
            switch(tipoAccion){
                
                case "DECLARACION \n DE \n VARIABLES":
                     Resultado resultado;
                     
                     String tipo = arbol.hijos.get(i).hijos.get(0).valor.toString();
                     String nombre;
                     String fila;
                     String columna;
                     String ambito;
                     String dimension;
                     String tamaño;
                     
                     
                     if(arbol.hijos.get(i).hijos.get(1).hijos.size()==1){
                         nombre = arbol.hijos.get(i).hijos.get(1).hijos.get(0).valor.toString();
                         fila = arbol.hijos.get(i).hijos.get(1).hijos.get(0).linea+"";
                         columna = arbol.hijos.get(i).hijos.get(1).hijos.get(0).columna+"";
                         ambito = "variable";
                         dimension ="0";
                         tamaño = "0";
                         
                         if(arbol.hijos.get(i).hijos.get(2).hijos.get(0).etiqueta.toString().equals("EPSILON")){
                             
                                Simbolo sim = new Simbolo(tipo,nombre,fila,columna,ambito,dimension,tamaño,null);
                                System.out.println("Agre un simbolo con un id de nombre " + nombre +" " + tipo );
                             
                                boolean estado = tablaGlobal.addSimbolo(sim);
                                if (!estado)
                                {
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                    String seguro = final_compi.Interfaz.jTextArea1.getText();
                                    final_compi.Interfaz.jTextArea1.setText(seguro +"\n"+ "variable " + nombre + " repetida");
                                    final_compi.Interfaz.linea_consola++;
                                }
                                
                         }else {
                             OpAritmetica opA = new OpAritmetica();
                             resultado = opA.operar(arbol.hijos.get(i).hijos.get(2).hijos.get(0).hijos.get(0));
                             System.out.println("resultado.valor--->  " + resultado.valor);
                             Simbolo sim = new Simbolo(tipo,nombre,fila,columna,ambito,dimension,tamaño,resultado.valor);
                         
                             boolean estado = tablaGlobal.addSimbolo(sim);
                                if (!estado)
                                {
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                    String seguro = final_compi.Interfaz.jTextArea1.getText();
                                    final_compi.Interfaz.jTextArea1.setText(seguro +"\n"+ "variable " + nombre + " repetida");
                                    final_compi.Interfaz.linea_consola++;
                                }
                         }
                         
                         
                     } else{
                         
                          for(int a=0;a<arbol.hijos.get(i).hijos.get(1).hijos.size();a++){
                          
                              nombre = arbol.hijos.get(i).hijos.get(1).hijos.get(a).valor.toString();
                              fila = arbol.hijos.get(i).hijos.get(1).hijos.get(a).linea+"";
                              columna = arbol.hijos.get(i).hijos.get(1).hijos.get(a).columna+"";
                              ambito = "variable";
                              dimension ="0";
                              tamaño = "0";
                         
                         if(arbol.hijos.get(i).hijos.get(2).hijos.get(0).etiqueta.toString().equals("EPSILON")){
                             
                                Simbolo sim = new Simbolo(tipo,nombre,fila,columna,ambito,dimension,tamaño,null);
                                System.out.println("Agre un simbolo con un id de nombre " + nombre +" " + tipo );
                             
                                boolean estado = tablaGlobal.addSimbolo(sim);
                                if (!estado)
                                {
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                    String seguro = final_compi.Interfaz.jTextArea1.getText();
                                    final_compi.Interfaz.jTextArea1.setText(seguro +"\n"+ "variable " + nombre + " repetida");
                                    final_compi.Interfaz.linea_consola++;
                                }
                                
                         }else {
                             OpAritmetica opA = new OpAritmetica();
                             resultado = opA.operar(arbol.hijos.get(i).hijos.get(2).hijos.get(0).hijos.get(0));
                             System.out.println("resultado.valor--->  " + resultado.valor);
                             Simbolo sim = new Simbolo(tipo,nombre,fila,columna,ambito,dimension,tamaño,resultado.valor);
                         
                             boolean estado = tablaGlobal.addSimbolo(sim);
                                if (!estado)
                                {
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                    String seguro = final_compi.Interfaz.jTextArea1.getText();
                                    final_compi.Interfaz.jTextArea1.setText(seguro +"\n"+ "variable " + nombre + " repetida");
                                    final_compi.Interfaz.linea_consola++;
                                }
                         }
                         }
                         
                     }
                     
                    
                    
                    break;
                    
                case"DECLARACION \n DE \n VECTORES":
                        
                     tipo = arbol.hijos.get(i).hijos.get(0).valor.toString();
                     nombre = arbol.hijos.get(i).hijos.get(1).valor.toString(); ;
                     fila = arbol.hijos.get(i).hijos.get(1).linea+"";
                     columna = arbol.hijos.get(i).hijos.get(1).columna+"";
                     ambito = "vector";
                     dimension =(arbol.hijos.get(i).hijos.get(2).hijos.size()/2)+"";;
                     
                     
                     int aux =arbol.hijos.get(i).hijos.get(2).hijos.size();
                     int tama =1;
                     for(int m=aux/2;m<aux;m++ ){
                         
                          OpAritmetica opA = new OpAritmetica();
                          resultado = opA.operar(arbol.hijos.get(i).hijos.get(2).hijos.get(m).hijos.get(0));
                          tama = tama * Integer.parseInt(resultado.valor+"");
                     }
                        tamaño = tama+"";
                             
                             //System.out.println("resultado.valor--->  " + resultado.valor);
                             Simbolo sim = new Simbolo(tipo,nombre,fila,columna,ambito,dimension,tamaño,null);
                         
                             boolean estado = tablaGlobal.addSimbolo(sim);
                                if (!estado)
                                {
                                    System.out.println("Variable repetida men: " + nombre +" " + tipo );
                                }
                     
                    break;
                    
                case"ASIGNACION \n EN \n VARIABLES":
                        if(final_compi.Interfaz.tablaGlobal.existe(arbol.hijos.get(i).hijos.get(0).valor.toString())){
                              System.out.println("ENCONTRE LA VAR" );
                            //Simbolo r = final_compi.Interfaz.tablaGlobal.getSimbolo(arbol.valor.toString());
                            
                            OpAritmetica opA = new OpAritmetica();
                            resultado = opA.operar(arbol.hijos.get(i).hijos.get(1).hijos.get(0));
                            tablaGlobal.asignar(arbol.hijos.get(i).hijos.get(0).valor.toString(), resultado.tipo,resultado.valor);
                            
                        }
                    break;    
                case"ASIGNACION \n EN \n VECTORES":
                        
                    break;
                case"FUN \n NATIVAS":
                        
                        String nativas = arbol.hijos.get(i).hijos.get(0).etiqueta;
            
                    switch(nativas){
                        
                        case "PRINT":
                            String seguro = final_compi.Interfaz.jTextArea1.getText();
                            OpAritmetica opA = new OpAritmetica();
                            resultado = opA.operar(arbol.hijos.get(i).hijos.get(0).hijos.get(0));    
                            final_compi.Interfaz.jTextArea1.setText(seguro +"\n"+ resultado.valor);
                            final_compi.Interfaz.linea_consola++;
                            break;
                            
                        case "DIBUJAR":
                             final_compi.Interfaz.calc_ast(final_compi.Interfaz.AST);
                            break;
                            
                        case "ERRORES":
                            final_compi.Interfaz.crear_tabla_error();
                            break;
                            
                        case "TABLA":
                            final_compi.Interfaz.crear_tabla();
                            break;
                            
                        case "CLEAN":
                                
                                final_compi.Interfaz.jTextArea1.setText("");
                                final_compi.Interfaz.linea_consola = 0;
                            break;    
                    }
                
                
                    
            }
                    
                    
                    
            //System.out.println("tiene hijos");
            
            
        }
    }
    
}
