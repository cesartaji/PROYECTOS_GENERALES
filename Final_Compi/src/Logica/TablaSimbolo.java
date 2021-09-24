/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logica;

import java.util.ArrayList;
import java.util.List;
import java.util.ListIterator;
import Logica.Simbolo;

/**
 *
 * @author TAJI
 */
public class TablaSimbolo {
 
    public ArrayList<Simbolo> simbolos ;
    
    public TablaSimbolo()
        {
            simbolos = new ArrayList<Simbolo>();
        }
    
    
        public Boolean addSimbolo(Simbolo simbolo)
        {
            if (!existe(simbolo.nombre))
            {
                simbolos.add(simbolo);
                return true;
            }
            return false;
        }    
    
        public Simbolo getSimbolo(String nombre)
        {
            for(int i=0;i<simbolos.size();i++) {
                Simbolo s = simbolos.get(i);
                if (nombre.equals(s.nombre))
                {
                    return s;
                }
          }
            return null;
        }
        
        public Boolean existe(String nombre)
        {
            for(int i=0;i<simbolos.size();i++)
            {
                Simbolo s = simbolos.get(i);
                if (s.nombre.equals(nombre))
                {
                    return true;
                }

            }
            return false;
        }
        
        
         public Boolean asignar(String nombre, String tipo, Object valor)
        {
            for(int i=0;i<simbolos.size();i++)
            {
                Simbolo s = simbolos.get(i);
                if (s.nombre.equals(nombre))
                {
                    s.tipo = tipo;
                    s.valor = valor;
                    return true;
                }

            }
            return false;
        }
         
         
         
}
