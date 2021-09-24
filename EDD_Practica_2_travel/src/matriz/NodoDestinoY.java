/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package matriz;

/**
 *
 * @author TAJI
 */
public class NodoDestinoY {
    String codigo;
    String nombre;
   
    NodoDestinoY subir;
    NodoDestinoY bajar;
    
    NodoMatriz apt_matriz;
    
    public NodoDestinoY(){
        
    }
    
    public NodoDestinoY(String codigo,String nombre){
  
        this.codigo = codigo;
        this.nombre = nombre;
        
        this.subir = null;
        this.bajar = null;
        
    }
    
    public String getCodigo(){
        return codigo;
    }
    
    public String getNombre(){
        return nombre;
    }
    
     public void setCodigo(String codigo){
        this.codigo = codigo;
    }
    
    public void setNombre(String nombre){
        this.nombre=nombre;
    }
}
