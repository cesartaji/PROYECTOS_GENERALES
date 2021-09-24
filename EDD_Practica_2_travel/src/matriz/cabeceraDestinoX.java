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
public class cabeceraDestinoX {
    
    public NodoDestinoX primero;
    public NodoDestinoX ultimo;
    
     public cabeceraDestinoX(){
        primero=null;
        ultimo=null;
    }
     
     public void insertar(NodoDestinoX n){
         NodoDestinoX nuevo = new NodoDestinoX(n.codigo,n.nombre);
         
         if(primero==null){
             primero=nuevo;
             ultimo=nuevo;
         }else{
             
             NodoDestinoX tmpant = null;
             NodoDestinoX tmp = primero;
             
             while(tmp!=null){
                 
                 if(tmp.codigo.compareTo(nuevo.codigo) > 0){
                     if(tmpant==null){
                         
                         nuevo.siguiente = primero;
                         primero.anterior = nuevo;
                         primero = nuevo;
                         
                         return;
                     } else{
                         
                         tmpant.siguiente = nuevo;
                         nuevo.anterior = tmpant;
                         
                         nuevo.siguiente = tmp;
                         tmp.anterior = nuevo;
                         
                         return;
                     }
                     
                 }
                 
                 tmpant = tmp;
                 tmp = tmp.siguiente;
                 
                 if(tmp == null){
                     tmpant.siguiente = nuevo;
                     nuevo.anterior = tmpant;
                     
                     ultimo = nuevo;
                 }
                 
             }
         }
               
     }
     
     
     public void imprimir_inicio(){
         
         NodoDestinoX tmp = primero;
         
         while(tmp != null){
             System.out.println("codigo: " + tmp.codigo );
             tmp = tmp.siguiente;
         }
         
     }
     
     public void imprimir_fin(){
         
         NodoDestinoX tmp = ultimo;
         
         while(tmp != null){
             System.out.println("codigo: " + tmp.codigo );
             tmp = tmp.anterior;
         }
         
     }
     
     public NodoDestinoX buscar_nodo(String codigo){
          NodoDestinoX tmp = primero;
         
         while(tmp != null){
             
             if(tmp.codigo.equals(codigo)){
                 return tmp;
             }
             
             tmp = tmp.siguiente;
         }
         return null;
     }
     
    
}
