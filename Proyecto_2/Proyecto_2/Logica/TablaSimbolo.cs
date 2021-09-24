using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2.Logica
{
    public class TablaSimbolo
    {

        public List<Simbolo> simbolos;

        public TablaSimbolo()
        {
            simbolos = new List<Simbolo>();
        }

        public Boolean addSimbolo(Simbolo simbolo)
        {
            if (!existe(simbolo.nombre))
            {
                simbolos.Add(simbolo);
                return true;
            }
            return false;
        }

        public Simbolo getSimbolo(String nombre)
        {
            foreach (Simbolo s in simbolos)
            {
                if (nombre == s.nombre)
                {
                    return s;
                }
            }
            return null;
        }

        //verifica primero si existe el simbolo en la tabla local, si no existe se va a la tabla global a verificar
        public Simbolo getSimbolo(String nombre, TablaSimbolo global)
        {
            Boolean estado = false;
            Simbolo simbolo = null;
            foreach (Simbolo s in simbolos)
            {
                if (nombre == s.nombre)
                {
                    simbolo = s;
                    estado = true;
                }
            }
            if (estado)
            {
                return simbolo;
            }
            else
            {
                foreach (Simbolo s in global.simbolos)
                {
                    if (nombre == s.nombre)
                    {
                        return s;
                    }
                }
            }
            return null;
        }

        public Boolean existe(String nombre)
        {
            foreach (Simbolo s in simbolos)
            {
                if (s.nombre == nombre)
                {

                    return true;
                }

            }
            return false;
        }


        public Boolean asignar(String nombre, String tipo, Object valor)
        {
            foreach (Simbolo s in simbolos)
            {
                if (s.nombre == nombre)
                {
                    s.tipo = tipo;
                    s.valor = valor;
                    return true;
                }

            }
            return false;
        }

        public void cambiarAmbito(TablaSimbolo principal)
        {
            foreach (Simbolo s in principal.simbolos)
            {
                simbolos.Add(s);
            }
        }

    }

}
