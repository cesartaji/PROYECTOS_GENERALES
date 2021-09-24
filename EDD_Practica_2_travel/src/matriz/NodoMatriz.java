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
public class NodoMatriz {
    String codigo_origen;
    String codigo_destino;
    
    float costo;
    float tiempo;
   
    NodoMatriz arriba;
    NodoMatriz abajo;
    NodoMatriz izquierda;
    NodoMatriz derecha;
    
    
    public NodoMatriz(){
        
    }
    
    public NodoMatriz(String codigo_origen,String codigo_destino,float costo, float tiempo){
  
        this.codigo_origen = codigo_origen;
        this.codigo_destino = codigo_destino;
        this.costo = costo;
        this.tiempo = tiempo;
        
        this.arriba = null;
        this.abajo = null;
        this.izquierda = null;
        this.derecha = null;
        
        
    }
    
    public String getCodigo_origen(){
        return codigo_origen;
    }
    
    public String getCodigo_destino(){
        return codigo_destino;
    }
    
    public float getCosto(){
        return costo;
    }
    
    public float getTiempo(){
        return tiempo;
    }
    
    
    public void setCodigo_origen(String codigo_origen){
        this.codigo_origen = codigo_origen;
    }
    
    public void setCodigo_destino(String codigo_destino){
        this.codigo_origen = codigo_destino;
    }
    
    public void setCosto(float costo){
        this.costo = costo;
    }
    
    public void setTiempo(float tiempo){
        this.tiempo = tiempo;
    }
    
    
}
