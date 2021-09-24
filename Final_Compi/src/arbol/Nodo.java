/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package arbol;

import java.util.ArrayList;

/**
 *
 * @author TAJI
 */
public class Nodo {
    
    public String etiqueta;
    public int linea;
    public int columna;
    public Object valor;
    //public ArrayList<Nodo> hijos;
    public ArrayList<Nodo> hijos = new ArrayList();
    
    public Nodo(String etiqueta, int linea, int columna, Object valor){
        this.etiqueta = etiqueta;
        this.linea = linea;
        this.columna = columna;
        this.valor = valor;
        
    }
    
    public Nodo(String etiqueta, int linea, int columna){
        this.etiqueta = etiqueta;
        this.linea = linea;
        this.columna = columna;
        
    }
    
    
}
