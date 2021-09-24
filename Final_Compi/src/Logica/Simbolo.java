/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logica;

/**
 *
 * @author TAJI
 */
public class Simbolo {
    
        
        public String tipo;
        public String nombre;
        public String fila;
        public String columna;
        public String ambito;
        public String dimension;
        public String tamaño;
        public Object valor;
        

        public Simbolo(String tipo, String nombre,String fila, String columna, String ambito, String dimension, String tamaño, Object valor)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.fila = fila;
            this.columna = columna;
            this.ambito = ambito;
            this.dimension = dimension;
            this.tamaño = tamaño;
            this.valor = valor;
        }
    
}
