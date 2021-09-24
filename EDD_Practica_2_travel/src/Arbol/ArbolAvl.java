/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Arbol;

import java.io.FileWriter;
import java.io.PrintWriter;

/**
 *
 * @author TAJI
 */
public class ArbolAvl {
    String escritura="digraph test {";
    String escritura_cuerpo="";
            
    private NodoAvl raiz;
    private NodoAvl modificar;
    private int id_numerico= 10000;
    
    public int get_id(){
        
        id_numerico++;
        return id_numerico;
        
    }
            
    public ArbolAvl(){
        raiz=null;
        modificar=null;
    }

    public NodoAvl obtenerRaiz(){
        return raiz;
    }
    
    public String llamar_modificar(NodoAvl n, NodoAvl raiz){
        modificar = null;
        buscar(n.id,raiz);
        if(modificar!=null){
            modificar(n,raiz);
            return "true";
        }      
        return "null";
    }
    
   
    public void buscar(String id, NodoAvl aux){
        if(aux==null){
            //return;
        }else{
             buscar(id,aux.der);
            
             if(aux.id.compareTo(id)== 0){
                    modificar = aux;
             }
            buscar(id,aux.izq);
        }
    }
    
    public void modificar(NodoAvl remplazo, NodoAvl aux){
        if(aux==null){
            //return;
        }else{
             modificar(remplazo,aux.der);
            
             if(aux.id.compareTo(remplazo.id)== 0){
                    aux.nombre = remplazo.nombre;
                    aux.password = remplazo.password;
             }
            modificar(remplazo,aux.izq);
        }
    }
    
    
    
    public int obtener_equilibrio(NodoAvl aux){
        if(aux==null){
            return -1;
        } else{
            return aux.equilibrio;
        }
    }
            
    public NodoAvl rotacionIzquierda(NodoAvl N){
        NodoAvl aux = N.izq;
        N.izq = aux.der;
        aux.der= N;
        N.equilibrio = Math.max(obtener_equilibrio(N.izq), obtener_equilibrio(N.der))+1;
        aux.equilibrio = Math.max(obtener_equilibrio(aux.izq), obtener_equilibrio(aux.der))+1;
        
        return aux;
    }        
            
            
    public NodoAvl rotacionDerecha(NodoAvl N){
        NodoAvl aux = N.der;
        N.der = aux.izq;
        aux.izq= N;
        N.equilibrio = Math.max(obtener_equilibrio(N.izq), obtener_equilibrio(N.der))+1;
        aux.equilibrio = Math.max(obtener_equilibrio(aux.izq), obtener_equilibrio(aux.der))+1;
        
        return aux;
    }        
            
           
    public NodoAvl rotacionDobleIzquierda(NodoAvl N){
       NodoAvl tmp;
       N.izq = rotacionDerecha(N.izq);
       tmp = rotacionIzquierda(N);
       return tmp;
    }
    
    
    public NodoAvl rotacionDobleDerecha(NodoAvl N){
       NodoAvl tmp;
       N.der = rotacionIzquierda(N.der);
       tmp = rotacionDerecha(N);
       return tmp;
    }
    
    public NodoAvl insertar(NodoAvl nuevo, NodoAvl subArbol){
        NodoAvl nuevo_padre = subArbol;
        //nuevo.id<subArbol.id
        if(nuevo.id.compareTo(subArbol.id) < 0){
            if(subArbol.izq==null){
                subArbol.izq = nuevo;
            }else {
                subArbol.izq = insertar(nuevo,subArbol.izq);
                if((obtener_equilibrio(subArbol.izq) - obtener_equilibrio(subArbol.der))==2){
                    //nuevo.telefono<subArbol.izq.telefono
                    if(nuevo.id.compareTo(subArbol.izq.id)<0){
                        nuevo_padre=rotacionIzquierda(subArbol);
                    }else{
                        nuevo_padre=rotacionDobleIzquierda(subArbol);
                    }
                }
            } 
        } else if(nuevo.id.compareTo(subArbol.id)>0){ //nuevo.telefono>subArbol.telefono
            if(subArbol.der==null){
                subArbol.der = nuevo;
            } else{
                subArbol.der = insertar(nuevo,subArbol.der);
                if((obtener_equilibrio(subArbol.der) - obtener_equilibrio(subArbol.izq))==2){
                    if(nuevo.id.compareTo(subArbol.der.id)>0){//nuevo.telefono>subArbol.der.telefono
                        nuevo_padre=rotacionDerecha(subArbol);
                    }else{
                        nuevo_padre=rotacionDobleDerecha(subArbol);
                    }
                }
            }
        } else {
            System.out.println("duplicated");
        }
        
        if((subArbol.izq == null) && (subArbol.der != null) ){
            subArbol.equilibrio = subArbol.der.equilibrio+1;
            System.out.println(subArbol.equilibrio);
        }else if((subArbol.der == null) && (subArbol.izq != null)){
            subArbol.equilibrio = subArbol.izq.equilibrio+1;
        }else{
            subArbol.equilibrio = Math.max(obtener_equilibrio(subArbol.izq), obtener_equilibrio(subArbol.der))+1;;
        }
        return nuevo_padre;
    }
    
    public void llamar_insertar(String nombre, String password){
        NodoAvl nuevo = new NodoAvl(get_id()+"",nombre,password);
        if(raiz==null){
            raiz=nuevo;
        } else{
            raiz=insertar(nuevo,raiz);
        }
    }
    
    // recorridos en el arbol
    public void inOrder(NodoAvl n){
        if(n!=null){
            inOrder(n.izq);
            System.out.println(n.id + " ");
            inOrder(n.der);
        }
    }
    
    public void preOrder(NodoAvl n){
        if(n!=null){
            System.out.println(n.id + " ");
            preOrder(n.izq);
            preOrder(n.der);
        }
    }
    
    public void postOrder(NodoAvl n){
        if(n!=null){
            postOrder(n.izq);
            postOrder(n.der);
            System.out.println(n.id + " ");
        }
    }
    
    
    
   /* public void carga_masiva(String datos){
        String[] cadena = datos.split("\n");
        for(int i=0; i<cadena.length ;i++){
            
            String[] sub_cadena = cadena[i].split(",");  
            llamar_insertar(sub_cadena[0],sub_cadena[1],sub_cadena[2]);
            
        }    
    }*/
 
    
    // para graficar
    public void recorrer(NodoAvl n){
        if(n!=null){
            
            //System.out.println(n + "----");
            String tmp=n+"";
            String tmp2= tmp.replace('@', '1').replace('.', '1') + 
         " [shape=record  label = \"<P0>|{"+n.id+"|{"+n.nombre+"|"+n.password+"|"+n.equilibrio+"}}|<P1>"+ "\"]; ";
            escritura_cuerpo +=tmp2;
          //node_A [shape=record    label="|{telefono|{nombre|apellido|correo}}|"];
            
            recorrer(n.izq);
            recorrer(n.der);
            
        }
    }
    
    
    public void recorrer2(NodoAvl n){
        if(n!=null){
            recorrer2(n.izq);
            recorrer2(n.der);
            
            String tmp=n+"";
            
            String iz="";
            String de="";
            
            if(n.izq!=null){
                String aux=n.izq+"";
                iz= tmp.replace('@', '1').replace('.', '1') + ":P0 ->" + aux.replace('@', '1').replace('.', '1')+";";
                
            }
            if(n.der!=null){
                String aux=n.der+"";
                de= tmp.replace('@', '1').replace('.', '1') + ":P1 ->" + aux.replace('@', '1').replace('.', '1')+";";
            }
            escritura_cuerpo +=iz +" \n "+ de;
        }
    }
    
    
    public void graficar(){
        try {
      
        String dotPath = "C:\\Users\\TAJI\\Documents\\proyecto_lenguajes\\release\\bin\\dot.exe";

        String fileInputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\prueba.txt";
        String fileOutputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\grafo1.jpg";

        String tParam = "-Tjpg";
        String tOParam = "-o";

        String[] cmd = new String[5];
        cmd[0] = dotPath;
        cmd[1] = tParam;
        cmd[2] = fileInputPath;
        cmd[3] = tOParam;
        cmd[4] = fileOutputPath;

        Runtime rt = Runtime.getRuntime();

        rt.exec( cmd );
      
        } catch (Exception ex) {
            ex.printStackTrace();
        } finally {
        }
    }
    
    
    public void escribir_archivo(){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try
        {

            fichero = new FileWriter("C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\prueba.txt");
            pw = new PrintWriter(fichero);

            
            pw.println(escritura + escritura_cuerpo+"}");

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
           try {
           // Nuevamente aprovechamos el finally para 
           // asegurarnos que se cierra el fichero.
           if (null != fichero)
              fichero.close();
           Thread.sleep(1000);
           } catch (Exception e2) {
              e2.printStackTrace();
           }
        }
    }
    
}



