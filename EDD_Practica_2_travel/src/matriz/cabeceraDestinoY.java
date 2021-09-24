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
public class cabeceraDestinoY {
    
    public NodoDestinoY arriba;
    public NodoDestinoY abajo;
    
     public cabeceraDestinoY(){
        arriba=null;
        abajo=null;
    }
    
     
    public void insertar(NodoDestinoY n){
         NodoDestinoY nuevo = new NodoDestinoY(n.codigo,n.nombre);
         
         if(arriba==null){
             arriba=nuevo;
             abajo=nuevo;
         }else{
             
             NodoDestinoY tmpant = null;
             NodoDestinoY tmp = arriba;
             
             while(tmp!=null){
                 
                 if(tmp.codigo.compareTo(nuevo.codigo) > 0){
                     if(tmpant==null){
                         
                         nuevo.bajar = arriba;
                         arriba.subir = nuevo;
                         arriba = nuevo;
                         
                         return;
                     } else{
                         
                         tmpant.bajar = nuevo;
                         nuevo.subir = tmpant;
                         
                         nuevo.bajar = tmp;
                         tmp.subir = nuevo;
                         
                         return;
                     }
                     
                 }
                 
                 tmpant = tmp;
                 tmp = tmp.bajar;
                 
                 if(tmp == null){
                     tmpant.bajar = nuevo;
                     nuevo.subir = tmpant;
                     
                     abajo = nuevo;
                 }
                 
             }
         }
               
     }
     
     
     public void imprimir_arriba(){
         
         NodoDestinoY tmp = arriba;
         
         while(tmp != null){
             System.out.println("codigo: " + tmp.codigo );
             tmp = tmp.bajar;
         }
         
     }
     
     public void imprimir_abajo(){
         
         NodoDestinoY tmp = abajo;
         
         while(tmp != null){
             System.out.println("codigo: " + tmp.codigo );
             tmp = tmp.subir;
         }
         
     }
     
     public NodoDestinoY buscar_nodo(String codigo){
          NodoDestinoY tmp = arriba;
         
         while(tmp != null){
             
             if(tmp.codigo.equals(codigo)){
                 return tmp;
             }
             
             tmp = tmp.bajar;
         }
         return null;
     }
    
}
