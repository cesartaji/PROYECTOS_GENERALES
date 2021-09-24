/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package matriz;

import java.io.FileWriter;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

/**
 *
 * @author TAJI
 */
public class Matriz {
    
    String escritura="digraph test {   \n rankdir=LR; \n ";
    String escritura_cuerpo="";
    
    String escritura_grafo="graph test {   \n  \n ";
    String escritura_cuerpo_grafo="";

    
    ArrayList<NodoDestinoX> lista_destino = new ArrayList<NodoDestinoX>();
    
    ArrayList<pais_destino> lista_aux = new ArrayList<pais_destino>();
    ArrayList<pais_destino> lista_aux_aux = new ArrayList<pais_destino>();
    
    List<List<String>> vecino_grafo = new ArrayList<List<String>>();
    List<String> nodo_grafo = new ArrayList<String>();
    ArrayList<String> nodo_aux = new ArrayList<String>();
    
    
    
    cabeceraDestinoX cx = new cabeceraDestinoX();
    cabeceraDestinoY cy = new cabeceraDestinoY();
    
    
    public ArrayList<NodoDestinoX> linealizar_cabecera(){
       lista_destino.clear();
       
       NodoDestinoX tmp= cx.primero;
       
       while(tmp!=null){
           lista_destino.add(tmp);
           tmp = tmp.siguiente;
       }
       
       return lista_destino;
   }
    
    public void insertar_destino(NodoDestinoX x){
        
        if(cx.buscar_nodo(x.codigo)==null){
            cx.insertar(x);
            
            NodoDestinoY tmp_y = new NodoDestinoY(x.codigo,x.nombre);
            cy.insertar(tmp_y);
        }
        
        
    }
    
    
    public void llamar_insertar_vuelo(NodoMatriz nm){
        
        if(cx.buscar_nodo(nm.codigo_origen)!= null && cx.buscar_nodo(nm.codigo_destino)!= null){
            insertar_vuelo(nm);
            NodoMatriz tmp = new NodoMatriz(nm.codigo_destino,nm.codigo_origen,nm.costo,nm.tiempo);
            insertar_vuelo(tmp);
        }
    }
    
    public void insertar_vuelo(NodoMatriz nm){
        NodoDestinoX tmp_x = cx.buscar_nodo(nm.codigo_origen);
        NodoMatriz y = new NodoMatriz(nm.codigo_origen,nm.codigo_destino,nm.costo,nm.tiempo);
        
        if(tmp_x.apt_matriz==null){
            tmp_x.apt_matriz = y;
            
        }else{
            NodoMatriz tmp_ant = null;
            NodoMatriz tmp = tmp_x.apt_matriz;            
            while(tmp != null){
                //if(tmp.codigo_origen.compareTo(nm.codigo_origen) > 0){
                if(tmp.codigo_destino.compareTo(nm.codigo_destino) > 0){
                    if(tmp_ant==null){
                        
                        y.abajo = tmp_x.apt_matriz;
                        tmp_x.apt_matriz.arriba = y;
                        tmp_x.apt_matriz = y;
                        break;        
                    }else{
                        
                        tmp_ant.abajo = y;
                        y.arriba = tmp_ant;
                        
                        y.abajo = tmp;
                        tmp.arriba = y;
                        break;
                    }
                    
                }
                
                tmp_ant = tmp;
                tmp = tmp.abajo;
                
                
                if(tmp == null){
                    tmp_ant.abajo = y;
                    y.arriba = tmp_ant;
                }
            }
        }
         
        
        NodoDestinoY tmp_y = cy.buscar_nodo(nm.codigo_destino);
        if(tmp_y.apt_matriz==null){
            tmp_y.apt_matriz = y;
        }else{
            NodoMatriz tmp_ant = null;
            NodoMatriz tmp = tmp_y.apt_matriz;
            
            while(tmp != null){
                //if(tmp.codigo_destino.compareTo(nm.codigo_destino) > 0){
                if(tmp.codigo_origen.compareTo(nm.codigo_origen) > 0){
                    if(tmp_ant==null){
                        
                        y.derecha = tmp_y.apt_matriz;
                        tmp_y.apt_matriz.izquierda = y;
                        tmp_y.apt_matriz = y;
                        break;        
                    }else{
                        
                        tmp_ant.derecha = y;
                        y.izquierda = tmp_ant;
                        
                        y.derecha = tmp;
                        tmp.izquierda = y;
                        break;
                    }
                    
                }
                
                tmp_ant = tmp;
                tmp = tmp.derecha;
                
                
                if(tmp == null){
                    tmp_ant.derecha = y;
                    y.izquierda = tmp_ant;
                }
            }
        }
                 
        
    }
    
    
    
    
    
    //** para graficar
    
        public void recorrer(){
                        String salto = "\\"+"n";
            escritura_cuerpo = " \"origenxy\" [label = \" origen  \", shape=record, group=gfila ]; \n";
            
            NodoDestinoY tmp = cy.arriba;
         
            while(tmp != null){
                String aux=tmp+"";
                String tmp2= aux.replace('@', '1').replace('.', '1');
                escritura_cuerpo += " \""+tmp2+"\" [label = \""+ tmp.codigo+salto + tmp.nombre +"\", shape=record , group=g"+tmp.codigo+"]; \n";
                tmp = tmp.bajar;
            }
            

            tmp = cy.arriba;            
            escritura_cuerpo += "origenxy-> " + tmp.toString().replace('@', '1').replace('.', '1') +";\n";
            while(tmp != null){
                if(tmp.bajar != null){
                
                    escritura_cuerpo += tmp.toString().replace('@', '1').replace('.', '1') +"->"+
                                  tmp.bajar.toString().replace('@', '1').replace('.', '1') + ";\n";
                }

                tmp = tmp.bajar;
            }
        
            tmp = cy.arriba;            
            escritura_cuerpo += "{rank=same;origenxy,";
            while(tmp != null){
             
                if(tmp.bajar != null){
                    escritura_cuerpo += tmp.toString().replace('@', '1').replace('.', '1') + ",";
                }else{
                    escritura_cuerpo += tmp.toString().replace('@', '1').replace('.', '1') + " ";
                }
                tmp = tmp.bajar;
            }
            escritura_cuerpo += "}\n";
            
            
            
             tmp = cy.arriba;            
             while(tmp != null){
                 
                 NodoMatriz mat = tmp.apt_matriz;
                 
                 if(mat != null){
                       escritura_cuerpo += tmp.toString().replace('@', '1').replace('.', '1') +"->"+
                                  mat.toString().replace('@', '1').replace('.', '1') + ";\n";
                     
                 }
                 
                 /*while(mat != null){
                     
                    String tmpp=mat+"";
                    String tmp2= tmpp.replace('@', '1').replace('.', '1');
                    escritura_cuerpo += " \""+tmp2+"\" [label = \"costo :"+ mat.costo + salto +"Tiempo:"+mat.tiempo +"\", shape=record]; \n"; 
                     
                     mat = mat.derecha;
                 }*/
                 
                 mat = tmp.apt_matriz;
                 while(mat != null){
                    if(mat.derecha != null){
                       escritura_cuerpo += mat.toString().replace('@', '1').replace('.', '1') +"->"+
                                  mat.derecha.toString().replace('@', '1').replace('.', '1') + "[dir=\"both\"];\n";
                    } 
                    /*if(mat.arriba != null){
                
                       escritura_cuerpo += mat.toString().replace('@', '1').replace('.', '1') +"->"+
                                  mat.arriba.toString().replace('@', '1').replace('.', '1') + ";\n";
                    }*/   
                                     
                    mat = mat.derecha;
                 }
                 

                tmp = tmp.bajar;
            }
            
            
            ///****************************************
            NodoDestinoX aux = cx.primero;
         
            while(aux != null){
                String tmpp=aux+"";
                String tmp2= tmpp.replace('@', '1').replace('.', '1');
                escritura_cuerpo += " \""+tmp2+"\" [label = \""+ aux.codigo+salto + aux.nombre +"\", shape=record, group=gfila]; \n";
                aux = aux.siguiente;
            }
            
            aux = cx.primero;            
            escritura_cuerpo += "origenxy-> " + aux.toString().replace('@', '1').replace('.', '1') +";\n";
            while(aux != null){
                if(aux.siguiente != null){
                
                    escritura_cuerpo += aux.toString().replace('@', '1').replace('.', '1') +"->"+
                                  aux.siguiente.toString().replace('@', '1').replace('.', '1') + ";\n";
                }

                aux = aux.siguiente;
            }
            
            //*********
             aux = cx.primero;
             while(aux != null){
                 
                 NodoMatriz mat = aux.apt_matriz;
                 
                 if(mat != null){
                       escritura_cuerpo += aux.toString().replace('@', '1').replace('.', '1') +"->"+
                                  mat.toString().replace('@', '1').replace('.', '1') + ";\n";
                     
                 }
                 while(mat != null){
                     
                    String tmpp=mat+"";
                    String tmp2= tmpp.replace('@', '1').replace('.', '1');
                    escritura_cuerpo += " \""+tmp2+"\" [label = \"costo :"+ mat.costo + salto +"Tiempo:"+mat.tiempo +"\", shape=record, group=g"+mat.codigo_destino+"]; \n"; 
                     
                     mat = mat.abajo;
                 }
                 
                 mat = aux.apt_matriz;
                 while(mat != null){
                    if(mat.abajo != null){
                       escritura_cuerpo += mat.toString().replace('@', '1').replace('.', '1') +"->"+
                                  mat.abajo.toString().replace('@', '1').replace('.', '1') + "[dir=\"both\"];\n";
                    } 
                    /*if(mat.arriba != null){
                
                       escritura_cuerpo += mat.toString().replace('@', '1').replace('.', '1') +"->"+
                                  mat.arriba.toString().replace('@', '1').replace('.', '1') + ";\n";
                    }*/   
                  
                    
                    mat = mat.abajo;
                 }
                 
                 mat = aux.apt_matriz;
                 if(mat != null){
                        escritura_cuerpo += "{rank=same;"+aux.toString().replace('@', '1').replace('.', '1') +",";
                        while(mat != null){
             
                            if(mat.abajo != null){
                                escritura_cuerpo += mat.toString().replace('@', '1').replace('.', '1') + ",";
                            }else{
                                escritura_cuerpo += mat.toString().replace('@', '1').replace('.', '1') + " ";
                            }
                        mat = mat.abajo;
                        }
                        escritura_cuerpo += "}\n";
                 }
                 
                
                aux = aux.siguiente;
            }
        }
    
        
        
        public void graficar(){
        try {
      
        String dotPath = "C:\\Users\\TAJI\\Documents\\proyecto_lenguajes\\release\\bin\\dot.exe";

        String fileInputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\matriz.txt";
        String fileOutputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\matriz.jpg";

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

            fichero = new FileWriter("C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\matriz.txt");
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
    
     public void llamar_graficar(){
       
        escritura_cuerpo = "";
                
        recorrer();
        
        escribir_archivo();
        graficar();
    }
     
     
     
    public void llamar_graficar_grafo(){
       
        escritura_cuerpo_grafo = "";
                
        recorrer_grafo();
        
        escribir_archivo_grafo();
        graficar_grafo();
    } 
     
    public void recorrer_grafo(){
        String salto = "\\"+"n";
        lista_aux.clear();
        lista_aux_aux.clear();
        
        nodo_grafo.clear();
        nodo_aux.clear();
        vecino_grafo.clear();
        
        NodoDestinoX tmp_x = cx.primero;
        while(tmp_x!= null){
            if(tmp_x.apt_matriz != null){
                escritura_cuerpo_grafo += " \""+tmp_x.codigo+"\" [label = \""+ tmp_x.nombre  +"\"]; \n"; 
                
                nodo_grafo.add(tmp_x.codigo);
                vecino_grafo.add(new ArrayList<String>());
            }   
            tmp_x= tmp_x.siguiente;
        }
        
        tmp_x = cx.primero;
        while(tmp_x!= null){
            if(tmp_x.apt_matriz != null){
                
                NodoMatriz tmp_m = tmp_x.apt_matriz;
                while(tmp_m!=null){
                    
                    pais_destino pd= new pais_destino();
                    pd.codigo_origen = tmp_m.codigo_origen;
                    pd.codigo_destino = tmp_m.codigo_destino;
                    lista_aux.add(pd);
                    tmp_m= tmp_m.abajo;
                }
            }
            
            tmp_x= tmp_x.siguiente;
        }
        
     
   
        for (int i=0; i<lista_aux.size()-1; i++) { 
        
            for(int j=i+1; j < lista_aux.size(); j++){
                //System.out.println(lista_aux.get(j).codigo_origen + "=" +lista_aux.get(j+1).codigo_destino  +" and " + lista_aux.get(j).codigo_destino +"="+lista_aux.get(j+1).codigo_origen);
                
                if(lista_aux.get(i).codigo_origen.equals(lista_aux.get(j).codigo_destino) &&
                   lista_aux.get(i).codigo_destino.equals(lista_aux.get(j).codigo_origen)){
                    lista_aux_aux.add(lista_aux.get(j));
                    
                }
                
            }
            
        }
        
        
        
        for (int i=0; i<lista_aux_aux.size(); i++) { 
            escritura_cuerpo_grafo += lista_aux_aux.get(i).codigo_destino + " -- " + lista_aux_aux.get(i).codigo_origen
                    +"[label =\"Costo:"+retornar_costo(lista_aux_aux.get(i).codigo_destino, lista_aux_aux.get(i).codigo_origen)+salto+"Tiempo: "+
                     retornar_tiempo(lista_aux_aux.get(i).codigo_destino, lista_aux_aux.get(i).codigo_origen)+ " \"]"+ ";\n";
        }
        
        
    }
     
    
    
    
     
    public void escribir_archivo_grafo(){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try
        {

            fichero = new FileWriter("C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\matriz_grafo.txt");
            pw = new PrintWriter(fichero);

            
            pw.println(escritura_grafo + escritura_cuerpo_grafo+"}");

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
    
    
    
    public void graficar_grafo(){
        try {
      
        String dotPath = "C:\\Users\\TAJI\\Documents\\proyecto_lenguajes\\release\\bin\\dot.exe";

        String fileInputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\matriz_grafo.txt";
        String fileOutputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\matriz_grafo.jpg";

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
    
    
    public void rutas_grafo(String origen, String destino){
        Stack < String > pila = new Stack < String > ();
        Stack < String > path = new Stack < String > ();
        String node;
        Stack < String > next_next = new Stack < String > ();
        recorrer_grafo();
                
        for (int i=0; i<nodo_grafo.size(); i++) { 
            for(int j=0; j<lista_aux.size(); j++){
                
                if(nodo_grafo.get(i).equals(lista_aux.get(j).codigo_origen)){
                        vecino_grafo.get(i).add(lista_aux.get(j).codigo_destino);
                }
            }
        }
        
        
       /* 
        for(int i=0; i<nodo_grafo.size(); i++){
            System.out.println(nodo_grafo.get(i));
        }
        
        
        for (int i = 0; i < vecino_grafo.size() ; i++) {
            for(int j=0; j< vecino_grafo.get(i).size() ; j++){
                System.out.print( vecino_grafo.get(i).get(j) + " " );
            }
            System.out.println();
        }
        */

        
        
        pila.push(origen);
        
        while(!pila.isEmpty()){
            
            String s = pila.pop();
            String[] s1 = s.split(";");
            

            path.clear();
            for(int i=0; i < s1.length ; i++){
                path.push(s1[i]);
            }

            //System.out.println("pila " + pila);
            if(!path.isEmpty()){
                
                node = path.peek();
                //System.out.println("node : " + node);
                int posi_vecino=0;
                
                for(int i=0; i<nodo_grafo.size(); i++){
                   if(nodo_grafo.get(i).equals(node)){
                       posi_vecino=i;
                   }
               }   

                /*for(int j=0; j< vecino_grafo.get(posi_vecino).size() ; j++){
                    System.out.print(vecino_grafo.get(posi_vecino).get(j)+ " ");
                }*/

                
                for(int j=0; j< vecino_grafo.get(posi_vecino).size() ; j++){
                    
                    int repeticion=0;
                    for(int x=0; x< path.size(); x++){     
                        if(path.get(x).equals(vecino_grafo.get(posi_vecino).get(j))){
                            repeticion++;
                        }
                    }   
                    if(repeticion==0){
                            next_next.push(vecino_grafo.get(posi_vecino).get(j));
                    }         
               }   
                
                //System.out.println("path " + path);
                //System.out.println("next " + next_next);
                
                while(!next_next.isEmpty()){
                    if(next_next.peek().equals(destino)){
                        
                        String auxilia = "";
                        String tmp = "";
                        for(int i=0; i<path.size(); i++){
                            auxilia += path.get(i)+",";
                            tmp += retornar_pais(path.get(i)) +" -> ";
                        }
                        tmp += retornar_pais(next_next.peek());
                        auxilia += next_next.pop();
                        System.out.println("Ruta encontrada: " +auxilia);
                        System.out.println("Ruta encontrada: " +tmp);
                        
                    } else{
                        
                        String auxiliar = "";
                        for(int i=0; i<path.size(); i++){
                            auxiliar += path.get(i)+";";
                        }
                        auxiliar += next_next.pop();  
                        pila.push(auxiliar);
                        //System.out.println("stack " +auxiliar);
                    }    
                }
            }
            
        }
        
    }
    
    
    public String retornar_pais(String codigo){
       
        NodoDestinoX tmp= cx.primero;
       
        while(tmp!=null){
           if(tmp.codigo.equals(codigo)){
               return tmp.nombre;
           }
           tmp = tmp.siguiente;
        }
       
       return "";
    }
    
    public String retornar_costo(String origen, String destino){
       
        NodoDestinoX tmp= cx.primero;
       
        while(tmp!=null){
           if(tmp.codigo.equals(origen)){
               
               NodoMatriz nm= tmp.apt_matriz;
               while(nm!=null){
                   if(nm.codigo_destino.equals(destino)){
                       return nm.costo+"";
                   }
                   nm = nm.abajo;
               }
               
               return tmp.nombre;
           }
           tmp = tmp.siguiente;
        }
       
       return "";
    }
    
    public String retornar_tiempo(String origen, String destino){
       
        NodoDestinoX tmp= cx.primero;
       
        while(tmp!=null){
           if(tmp.codigo.equals(origen)){
               
               NodoMatriz nm= tmp.apt_matriz;
               while(nm!=null){
                   if(nm.codigo_destino.equals(destino)){
                       return nm.tiempo+"";
                   }
                   nm = nm.abajo;
               }
               
               return tmp.nombre;
           }
           tmp = tmp.siguiente;
        }
       
       return "";
    }
    
    
     /*
     paginas para graficar
     
     https://graphs.grevian.org/example
     https://stackoverflow.com/questions/5438273/grouping-output-edges-from-graphviz
     https://zhu45.org/posts/2017/May/25/draw-a-neural-network-through-graphviz/
     
     
    
    for(int i=0; i<nodo_grafo.size(); i++){
            System.out.println(nodo_grafo.get(i));
        }
        
        
        for (int i = 0; i < vecino_grafo.size() ; i++) {
            for(int j=0; j< vecino_grafo.get(i).size() ; j++){
                System.out.print( vecino_grafo.get(i).get(j) + " " );
            }
            System.out.println();
        }
    
     */

    
}
