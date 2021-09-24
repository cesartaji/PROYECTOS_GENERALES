/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Arbol;

/**
 *
 * @author TAJI
 */
public class NodoAvl {    
    String id;
    String nombre;
    String password;
   
    int equilibrio;
    NodoAvl izq, der;
    
    public NodoAvl(String id,String nombre, String password){
  
        this.id = id;
        this.nombre = nombre;
        this.password = password;
        
        this.equilibrio=0;
        this.izq = null;
        this.der = null;
        
    }
}
