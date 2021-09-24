/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logica;

import java.util.ArrayList;
import java.util.List;
import java.util.ListIterator;
import Logica.SimboloError;

/**
 *
 * @author TAJI
 */
public class TablaError {
 
    public ArrayList<SimboloError> simbolos ;
    
    public TablaError()
        {
            simbolos = new ArrayList<SimboloError>();
        }
    
    
        public Boolean addSimbolo(SimboloError simbolo)
        {
                simbolos.add(simbolo);
                return true;
   
        }    
    
        public SimboloError getSimbolo(String nombre)
        {
            for(int i=0;i<simbolos.size();i++) {
                SimboloError s = simbolos.get(i);
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
                SimboloError s = simbolos.get(i);
                if (s.nombre.equals(nombre))
                {
                    return true;
                }

            }
            return false;
        }
         
         
}
