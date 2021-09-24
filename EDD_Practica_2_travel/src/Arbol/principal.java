/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Arbol;
//

import matriz.Matriz;
import matriz.NodoDestinoX;
import matriz.NodoDestinoY;
import matriz.NodoMatriz;
import matriz.cabeceraDestinoX;
import matriz.cabeceraDestinoY;
import tabla.NodoReservacion;
import tabla.TablaHash;

/**
 *
 * @author TAJI
 */
public class principal {
    
    public static void main(String[] args){
        ArbolAvl arbolito = new ArbolAvl();
        TablaHash tablex = new TablaHash();
        
        
        /*arbolito.llamar_insertar("shel", "shell");
        arbolito.llamar_insertar("ted", "ted");
        arbolito.llamar_insertar("maos", "maos");
        arbolito.llamar_insertar("linea", "tryoler");
        arbolito.llamar_insertar("wawi", "tryoler");
        arbolito.llamar_insertar("jojoj", "tryoler");
        arbolito.llamar_insertar("dingo", "tryoler");
        arbolito.llamar_insertar("dingo", "tryoler");*/
        
        
        
        
        
        //arbolito.preOrder(arbolito.obtenerRaiz());
       
        
        //System.out.println("----------");
        //arbolito.preOrder(arbolito.obtenerRaiz());
        
        
        
           //NodoAvl n= new NodoAvl("103","linea","linea");
           //arbolito.llamar_modificar(n, arbolito.obtenerRaiz());
        
        
        
        /*arbolito.recorrer(arbolito.obtenerRaiz());
        arbolito.recorrer2(arbolito.obtenerRaiz());
        
        arbolito.escribir_archivo();
        arbolito.graficar();*/
        
        
        /*cabeceraDestinoX cx = new cabeceraDestinoX();
        NodoDestinoX a= new NodoDestinoX("1","111");
        NodoDestinoX b= new NodoDestinoX("2","11");
        NodoDestinoX c= new NodoDestinoX("3","11");
        NodoDestinoX d= new NodoDestinoX("4","11");
        NodoDestinoX e= new NodoDestinoX("5","11");
        NodoDestinoX f= new NodoDestinoX("6","11");
        
        
        cx.insertar(e);
        cx.insertar(c);
        cx.insertar(a);
        cx.insertar(b);
        cx.insertar(d);
        cx.insertar(f);
        
        cx.imprimir_inicio();
        cx.imprimir_fin();
        
        NodoDestinoX jj = cx.buscar_nodo("88");
        System.out.println(jj);*/
        
        
        //*******************************
        
        /*cabeceraDestinoY cy = new cabeceraDestinoY();
        NodoDestinoY a= new NodoDestinoY("1","111");
        NodoDestinoY b= new NodoDestinoY("2","11");
        NodoDestinoY c= new NodoDestinoY("3","11");
        NodoDestinoY d= new NodoDestinoY("4","11");
        NodoDestinoY e= new NodoDestinoY("5","11");
        NodoDestinoY f= new NodoDestinoY("6","11");
        
        
        cy.insertar(e);
        cy.insertar(c);
        cy.insertar(a);
        cy.insertar(b);
        cy.insertar(d);
        cy.insertar(f);
        
        cy.imprimir_arriba();
        cy.imprimir_abajo();
        
        NodoDestinoY jj = cy.buscar_nodo("66");
        System.out.println(jj);*/
        
        
        Matriz ma = new Matriz();
        /*NodoDestinoX a= new NodoDestinoX("7720","Guatemala");
        NodoDestinoX b= new NodoDestinoX("7721","Salvador");
        NodoDestinoX c= new NodoDestinoX("7722","Honduras");
        NodoDestinoX d= new NodoDestinoX("7723","Nicaragua");
        NodoDestinoX e= new NodoDestinoX("7724","Costa Rica");
        NodoDestinoX f= new NodoDestinoX("7725","Panama");
        NodoDestinoX g= new NodoDestinoX("7726","Colombia");
        NodoDestinoX h= new NodoDestinoX("7727","Peru");
        
        

        ma.insertar_destino(a);
        ma.insertar_destino(b);
        ma.insertar_destino(c);
        ma.insertar_destino(d);
        ma.insertar_destino(e);
        ma.insertar_destino(f);
        ma.insertar_destino(g);
        ma.insertar_destino(h);
        

        
        NodoMatriz bb = new NodoMatriz("7720","7723",7720,7723);
        NodoMatriz ee = new NodoMatriz("7720","7724",7720,7724);
        NodoMatriz ff = new NodoMatriz("7720","7725",7720,7725);
        NodoMatriz aa = new NodoMatriz("7720","7721",7720,7721);
        NodoMatriz cc = new NodoMatriz("7720","7722",7720,7722);
        
        NodoMatriz g1 = new NodoMatriz("7721","7724",7721,7724);
        NodoMatriz g2 = new NodoMatriz("7722","7721",7722,7721);
        NodoMatriz g3 = new NodoMatriz("7723","7725",7723,7725);
        NodoMatriz g4 = new NodoMatriz("7724","7725",7724,7725);
        NodoMatriz g5 = new NodoMatriz("7725","7722",7725,7722);
        
        NodoMatriz g6 = new NodoMatriz("7726","7727",10,10);
        
        ma.llamar_insertar_vuelo(aa);
        ma.llamar_insertar_vuelo(bb);
        ma.llamar_insertar_vuelo(cc);
        
        //ma.llamar_insertar_vuelo(dd);
        ma.llamar_insertar_vuelo(ee);
        ma.llamar_insertar_vuelo(ff);
        
        ma.llamar_insertar_vuelo(g1);
        ma.llamar_insertar_vuelo(g2);
        ma.llamar_insertar_vuelo(g3);
        ma.llamar_insertar_vuelo(g4);
        ma.llamar_insertar_vuelo(g5);
        
        ma.llamar_insertar_vuelo(g6);
        
        ma.llamar_graficar();
        ma.llamar_graficar_grafo();
        
        
        
        ma.rutas_grafo("7726","7727");
        System.out.println();
        ma.rutas_grafo("7720","7725");
        System.out.println();
        ma.rutas_grafo("7720","7721");
        */
        NodoReservacion a = new NodoReservacion(1,1,1,"holis","d","Guatemala -> Honduras -> Salvador");
        NodoReservacion b = new NodoReservacion(2,2,2,"holis","d","Guatemala -> Mexico");
        NodoReservacion c = new NodoReservacion(3,3,3,"holis","d","Guatemala -> Honduras -> Salvador -> Mexico");
        NodoReservacion d = new NodoReservacion(4,4,4,"holis","d","Usa -> Guate");
        tablex.llamar_insertar(a);
        tablex.llamar_insertar(b);
        tablex.llamar_insertar(c);
        tablex.llamar_insertar(d);
        tablex.llamar_graficar();

        
    }
    
}
