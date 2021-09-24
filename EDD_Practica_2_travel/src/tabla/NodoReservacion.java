/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tabla;

/**
 *
 * @author TAJI
 */
public class NodoReservacion {
    boolean  estado;
    float costoViaje;
    float tiempoVuelo;
    int numeroReserva;
    String nombreCliente;
    String codigoCliente;
    String planVuelo;
    
    //NodoDestino apt_lista;

    public NodoReservacion() {
    }

    public NodoReservacion(float costoViaje, float tiempoVuelo, int numeroReserva, String nombreCliente, String codigoCliente,String planVuelo) {
        this.costoViaje = costoViaje;
        this.tiempoVuelo = tiempoVuelo;
        this.numeroReserva = numeroReserva;
        this.nombreCliente = nombreCliente;
        this.codigoCliente = codigoCliente;
        this.planVuelo = planVuelo;
        estado = true;
        //apuntador nulo perro
    }
    
     public float getCostoViaje() {
        return costoViaje;
    }

    public void setCostoViaje(float costoViaje) {
        this.costoViaje = costoViaje;
    }

    public float getTiempoVuelo() {
        return tiempoVuelo;
    }

    public void setTiempoVuelo(float tiempoVuelo) {
        this.tiempoVuelo = tiempoVuelo;
    }

    public int getNumeroReserva() {
        return numeroReserva;
    }

    public void setNumeroReserva(int numeroReserva) {
        this.numeroReserva = numeroReserva;
    }

    public String getNombreCliente() {
        return nombreCliente;
    }

    public void setNombreCliente(String nombreCliente) {
        this.nombreCliente = nombreCliente;
    }
    
    public String getCodigoCliente() {
        return codigoCliente;
    }

    public void setCodigoCliente(String codigoCliente) {
        this.codigoCliente = codigoCliente;
    }
    
    public String getPlanVuelo() {
        return planVuelo;
    }

    public void setPlanVuelo(String planVuelo) {
        this.planVuelo = planVuelo;
    }

}
