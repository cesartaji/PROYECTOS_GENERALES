package Analisis;

/**
 *
 * @author esvux
 */
public class GeneradorDeCompiladores {

    public static void main(String[] args) {
        generarCompilador();
    }

    private static void generarCompilador() {
        try {
            String ruta = "src/Analisis/";
            String opcFlex[] = {ruta + "Lexico.jflex", "-d", ruta};
            jflex.Main.generate(opcFlex);
            
            String opcCUP[] = {"-destdir", ruta, "-parser", "Sintactico", ruta + "Sintactico.cup"};
            java_cup.Main.main(opcCUP);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

}
