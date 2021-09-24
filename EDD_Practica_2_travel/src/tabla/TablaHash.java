/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tabla;

import java.io.FileWriter;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 *
 * @author TAJI
 */
public class TablaHash {
    int tamanio;
    String escritura_cuerpo="";
    String escritura="digraph test {   \n rankdir=LR; \n ";
    
    NodoReservacion[] ArrayHash;
    List<NodoReservacion> lista_reservacion = new ArrayList();
    
    public TablaHash() {
        tamanio = 43;
        ArrayHash = new NodoReservacion[tamanio];
    }
    
    public List<NodoReservacion> recorrer_tabla(){
    	lista_reservacion.clear();
        for(int i=0; i<ArrayHash.length;i++){
            if(ArrayHash[i]!=null){
               lista_reservacion.add(ArrayHash[i]);
            }
        }
        return lista_reservacion;
    }
    
    
    public void llamar_insertar(NodoReservacion r) {
        insertar(r);
    }
     
    public void insertar(NodoReservacion r) {
        Random n_random=new Random();
        int n_reser=n_random.nextInt(450);
        System.out.println(n_reser);
        r.numeroReserva= n_reser;
        System.out.println("claves generadas: "+n_reser);
        
        int a = funcionHash(n_reser);
        ArrayHash[a]= r;
    }
    
    public int funcionHash(int k){
        
        int h = k % 43;
        
        if(ArrayHash[h]!=null){
            for(int i=h; i < ArrayHash.length ; i++){
               
                if(ArrayHash[i]==null){
                    return i;
                }
                
            }
        }
        
        if(ArrayHash[h]!=null){
            for(int i=0; i < ArrayHash.length ; i++){
               
                if(ArrayHash[i]==null){
                    return i;
                }
                
            }
        }
        
        return h;
    }
    
     public void llamar_graficar(){
       
        escritura_cuerpo = "";
                
        recorrer();
        
        escribir_archivo();
        graficar();
    }
     
     public void recorrer(){
         System.out.println(ArrayHash.length);
         for(int i=0; i<ArrayHash.length ; i++){
             escritura_cuerpo += " \""+"ve"+i+"\" [label = \" id"+i+"  \", shape=record, group=g"+i+" ]; \n";
         }
         
          for (int i = 0; i < (ArrayHash.length - 1); i++) {
          escritura_cuerpo += "ve" + i + "->" + "ve" + (i + 1) + ";  \n";
          }
          
          
          
            escritura_cuerpo += "{rank=same;";
            for(int i=0; i<ArrayHash.length ; i++){
             
                if(i<ArrayHash.length - 1){
                    escritura_cuerpo += "ve"+i + ",";
                }else{
                    escritura_cuerpo += "ve"+i + "";
                }
                
            }
            escritura_cuerpo += "}\n";
 
          for(int i=0; i<ArrayHash.length ; i++){
              if(ArrayHash[i]!=null){
                  escritura_cuerpo += " \""+"nr"+i+ "\"" +"[ label= \"No. Reserva: " + ArrayHash[i].numeroReserva + " \nNombre Cliente: " +
                     ArrayHash[i].nombreCliente+"\nCosto total: "+ArrayHash[i].costoViaje+"\nTiempo: "+ArrayHash[i].tiempoVuelo+ " \",shape = box3d ,group=g"+i+"];\n";
              }   
          }
    
          for(int i=0; i<ArrayHash.length ; i++){
              if(ArrayHash[i]!=null){
                  
                  String [] a = ArrayHash[i].planVuelo.split("->");
                  
                  for(int x=0; x<a.length;x++){
                      escritura_cuerpo += " \""+"nr"+i+x+"\" [label = \""+a[x]+"  \", shape=record, group=g"+i+" ]; \n";
                  }
                  
                  for(int x=0; x<a.length-1;x++){
                      escritura_cuerpo += "nr"+i+x+ "->" + "nr" + i+(x+1) + ";  \n";
                  }
                  
                      escritura_cuerpo += "nr"+i+ "->" + "nr" + i+0 + ";  \n";
              }   
          }
          
          
         /* for(int i=0; i<ArrayHash.length ; i++){
              if(ArrayHash[i]!=null){
                  
                  String [] a = ArrayHash[i].planVuelo.split("->");
                         
                  
                  
                  
              }   
          }*/
          
          
          
          for(int i=0; i<ArrayHash.length ; i++){
              if(ArrayHash[i]!=null){
                    escritura_cuerpo += "ve" + i + "->" + "nr" + i + ";  \n";
              }   
         }
            
            
     }
   
        
        public void graficar(){
        try {
      
        String dotPath = "C:\\Users\\TAJI\\Documents\\proyecto_lenguajes\\release\\bin\\dot.exe";

        String fileInputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\tabla.txt";
        String fileOutputPath = "C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\tabla.jpg";

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

            fichero = new FileWriter("C:\\Users\\TAJI\\Documents\\usac\\estructuras de datos\\galeria\\tabla.txt");
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
