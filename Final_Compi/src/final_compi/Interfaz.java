/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package final_compi;

import Analisis.Lexico;
import Analisis.Sintactico;
import Logica.Simbolo;
import Logica.SimboloError;
import Logica.TablaError;
import Logica.TablaSimbolo;
import Logica.principal;
import arbol.Nodo;
import java.awt.Color;
import java.awt.Desktop;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.StringReader;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author TAJI
 */
public class Interfaz extends javax.swing.JFrame {
        public static Nodo arbol;
        static public TablaSimbolo tablaGlobal = new TablaSimbolo();;
        static public TablaError tablaDeError = new TablaError();;
        
        public static int linea_consola=0;
        static String escritura ="digraph G\n" +"{\n" + "   \n" +"rankdir=TB;\n" +"node [shape = box, style=rounded];";
        public static String escritura_cuerpo="";
        public static String AST="";
        public static String varHtml="";
        
    public Interfaz() {
        initComponents();
        jTextArea1.setBackground(Color.black);
        jTextArea1.setForeground(Color.white);
        jTextArea1.setCaretColor(Color.white);
    
    jTextArea1.addKeyListener(new KeyListener(){
    @Override
    public void keyPressed(KeyEvent e){
        if(e.getKeyCode() == KeyEvent.VK_ENTER){
            
                    //System.out.println("He presionado enter");
                    hola();
                    //e.consume();
        
        }
    }

    @Override
    public void keyTyped(KeyEvent e) {
    }

    @Override
    public void keyReleased(KeyEvent e) {
    }
});
        
        
    }

        public static void calc_ast(String entrada){
         Sintactico sin = new Sintactico(new Lexico(new BufferedReader(new StringReader(entrada))));
        try {
             escritura_cuerpo="";
             sin.parse();
             graficar();   
        } catch (Exception ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
            jTextArea1.setText("Error en el archivo de entrada");
            
        }
    }
    
    void hola(){
        
        // divide en lineas
        String[] lineas;
        lineas =  jTextArea1.getText().split("\n");
        
        //************
                
        //escritura_cuerpo="";
        String entrada=lineas[linea_consola];
        
        Sintactico sin = new Sintactico(new Lexico(new BufferedReader(new StringReader(entrada))));
        try {
             AST= AST + entrada;
             escritura_cuerpo="";
             sin.parse();
             calcular();
             graficar();   
        } catch (Exception ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
            jTextArea1.setText("Error en el archivo de entrada");
            
        }
        
        //**************        
       // if(!lineas[linea_consola].equals("")){
        //System.out.println(lineas[linea_consola]);
        //}

        linea_consola++;
        
    }
    
    void calcular(){
        principal p = new principal();
        p.ejecucion(arbol);
    }
    
    static void graficar(){
        Nodo a = arbol;
        graficos(a);
        graficos_2(a);
        escribir();
        crear_grafo();
        //System.out.println(escritura + escritura_cuerpo);
        
        try {
        Thread.sleep(1000);
    } catch (InterruptedException ex) {
        Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
    }
        
    try {
        Desktop.getDesktop().open(new File("grafo1.jpg"));
    } catch (IOException ex) {
        Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
    }
    }
    
    
    
    
    static void graficos (Nodo aux){
         String g ="";
        if(!aux.valor.equals("-")){
            g ="\n" + " ("+aux.valor.toString().replace('"', ' ') +") ";
        } 
        
        escritura_cuerpo += aux.toString().replace('@', '1').replace('.', '1')+"[label=\""+ aux.etiqueta  + g + "\", fillcolor=\"yellow\", style =\"filled\", shape=\"circle\"];" ;
        
        if(!aux.hijos.isEmpty()){
            for(int i=0;i<aux.hijos.size();i++){
                graficos(aux.hijos.get(i));
            }        
        }
        
    }
    
    static void graficos_2 (Nodo aux){
        
        //System.out.println(aux.etiqueta);
        //System.out.println(aux.valor);
        //System.out.println(aux.toString().replace('@', '1').replace('.', '1'));
        //System.out.println("---");
        
       
        if(aux.hijos.isEmpty()){
            escritura_cuerpo += aux.toString().replace('@', '1').replace('.', '1') + "\n" + " ";
        }     
        if(!aux.hijos.isEmpty()){  
            for(int i=0;i<aux.hijos.size();i++){
                escritura_cuerpo += aux.toString().replace('@', '1').replace('.', '1')+ " -> ";
                graficos_2(aux.hijos.get(i));
            }        
        }
        
    }
    
    
    static void crear_grafo (){
        
         //System.out.println("generando grafo");
         
    try {

        String fileInputPath = "grafo1.txt";
        String fileOutputPath = "grafo1.jpg";        
        ProcessBuilder pbuilder;
        pbuilder = new ProcessBuilder( "dot", "-Tjpg", "-o",fileOutputPath, fileInputPath );
        pbuilder.redirectErrorStream( true );
        //Ejecuta el proceso
        pbuilder.start();
      
    } catch (Exception ex) {
      ex.printStackTrace();
    } finally {
    }

        
    }
    
    
    static void escribir(){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try
        {

            fichero = new FileWriter("grafo1.txt");
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
           } catch (Exception e2) {
              e2.printStackTrace();
           }
        }
    }
    
    public static void crear_tabla(){
        varHtml="<html>\n" +"<head>\n" + "<title>Tabla de Simbolos</title>\n" +"</head>\n" +"<body>"+"<h1> Tabla de Simbolos </h1>";
        
        varHtml+= "<table style=\"width:100%\" >" + "<tr>  <th>TIPO</th>  <th>NOMBRE</th>  <th>FILA</th>  <th>COLUMNA</th>  <th>AMBITO</th> "
                + " <th>DIMENSION</th>  <th>TAMANO</th>  <th>VALOR</th></tr> ";
        
        TablaSimbolo tabla = tablaGlobal;

        
        for(int i=0; i<tabla.simbolos.size();i++){
            
            Simbolo s = tabla.simbolos.get(i);
            varHtml+= "<tr>  <td>"+s.tipo+"</td>  <td>"+s.nombre+"</td>  <td>"+s.fila+"</td>  <td>"+s.columna+"</td>  <td>"+s.ambito+"</td> "
                + " <td>"+s.dimension+"</td>  <td>"+s.tamaño+"</td>  <td>"+s.valor+"</td></tr> ";
            System.out.println(s.tipo + s.nombre +s.fila + s.columna +s.ambito + s.dimension +s.tamaño + s.valor );
           
        }
        
        varHtml+= "</table> </body> </html>" ;
        escribir_html();
        
        try {
        Thread.sleep(500);
        } catch (InterruptedException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try {
            Desktop.getDesktop().open(new File("tabla.html"));
        } catch (IOException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);

        }
        
        
    }
    
    static void escribir_html(){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try
        {

            fichero = new FileWriter("tabla.html");
            pw = new PrintWriter(fichero);

            
                pw.println(varHtml);

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
           try {
           // Nuevamente aprovechamos el finally para 
           // asegurarnos que se cierra el fichero.
           if (null != fichero)
              fichero.close();
           } catch (Exception e2) {
              e2.printStackTrace();
           }
        }
    }
    
    //...............................................>
    public static void crear_tabla_error(){
        varHtml="<html>\n" +"<head>\n" + "<title>Tabla de Errores</title>\n" +"</head>\n" +"<body>"+"<h1> Tabla de Errores </h1>";
        
        varHtml+= "<table style=\"width:100%\" >" + "<tr>  <th>TIPO DE DATO</th>  <th>VALOR</th> <th>TIPO DE ERROR</th>  </tr> ";
        
        TablaError tabla_error = tablaDeError;

        
        for(int i=0; i<tabla_error.simbolos.size();i++){
            
            SimboloError s = tabla_error.simbolos.get(i);
            varHtml+= "<tr>  <td>"+s.tipo+"</td>  <td>"+s.nombre+"</td> <td>"+s.fila+"</td> </tr> ";
            
           
        }
        
        varHtml+= "</table> </body> </html>" ;
        escribir_html_error();
        
        try {
        Thread.sleep(500);
        } catch (InterruptedException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try {
            Desktop.getDesktop().open(new File("tabla_error.html"));
        } catch (IOException ex) {
            Logger.getLogger(Interfaz.class.getName()).log(Level.SEVERE, null, ex);

        }
        
        
    }
    
    static void escribir_html_error(){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try
        {

            fichero = new FileWriter("tabla_error.html");
            pw = new PrintWriter(fichero);

            
                pw.println(varHtml);

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
           try {
           // Nuevamente aprovechamos el finally para 
           // asegurarnos que se cierra el fichero.
           if (null != fichero)
              fichero.close();
           } catch (Exception e2) {
              e2.printStackTrace();
           }
        }
    }
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        jTextArea1 = new javax.swing.JTextArea();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Consola");

        jTextArea1.setColumns(20);
        jTextArea1.setFont(new java.awt.Font("Consolas", 1, 18)); // NOI18N
        jTextArea1.setRows(5);
        jScrollPane1.setViewportView(jTextArea1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 622, Short.MAX_VALUE)
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 323, Short.MAX_VALUE)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Interfaz.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Interfaz().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JScrollPane jScrollPane1;
    public static javax.swing.JTextArea jTextArea1;
    // End of variables declaration//GEN-END:variables
}
