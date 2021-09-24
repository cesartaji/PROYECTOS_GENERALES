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
public class SimboloError {
    
        
        public String tipo;
        public String nombre;
        public String fila;
        public String columna;
        

        public SimboloError(String tipo, String nombre,String fila, String columna)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.fila = fila;
            this.columna = columna;
        }
    
}
