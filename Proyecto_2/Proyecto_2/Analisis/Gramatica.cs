using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using Irony.Ast;

namespace Proyecto_2.Analisis
{
    class Gramatica : Grammar
    {

        public Gramatica()  //: base(caseSensitive: true)
        {
            CommentTerminal comentario2 = new CommentTerminal("comentario2", "<<", ">>");//acepta comentarios de varias lineas
            CommentTerminal comentario1 = new CommentTerminal("comentario1", "!!", "\n", "\r\n");//hacepta comentarios que terminan en una sola linea
            base.NonGrammarTerminals.Add(comentario2);
            base.NonGrammarTerminals.Add(comentario1);

            IdentifierTerminal id = new IdentifierTerminal("id");
            StringLiteral cadena = new StringLiteral("String", "\"");
            NumberLiteral numero = new NumberLiteral("Double");
            
            StringLiteral cadena_char = new StringLiteral("cadena_char", "'", StringOptions.IsTemplate);
            StringLiteral cabeza = new StringLiteral("cabeza", "[a-zA-ZÑñ][a-zA-ZÑñ]+[.][a-zA-ZÑñ]+");



            NonTerminal INICIO = new NonTerminal("INICIO"),// ACEPTACIOM
               CODIGO = new NonTerminal("CODIGO"),
               CUERPO_CODIGO = new NonTerminal("CUERPO_CODIGO"),
               ENCABEZADO = new NonTerminal("ENCABEZADO"),
               DECLARACION = new NonTerminal("DECLARACION"),
               TIPO_DATO = new NonTerminal("TIPO_DATO"),
               LISTA_ID = new NonTerminal("LISTA_ID"),
               ASIGNACION_DECLARACION = new NonTerminal("ASIGNACION_DECLARACION"),
               EXPRESION = new NonTerminal("EXPRESION"),
               EPSILON = new NonTerminal("EPSILON"),
               CONDICION = new NonTerminal("CONDICION"),
               COND = new NonTerminal("COND"),
               EnParentesis = new NonTerminal("EnParentesis"),
               PRINCIPAL = new NonTerminal("PRINCIPAL"),
               SENTENCIAS = new NonTerminal("SENTENCIAS"),
               CUERPO_SENTENCIAS = new NonTerminal("CUERPO_SENTENCIAS"),
               ASIGNACION = new NonTerminal("ASIGNACION"),
               FUNCIONES = new NonTerminal("FUNCIONES"),
               PARAMETROS = new NonTerminal("PARAMETROS"),
               DEF_PARAMETROS = new NonTerminal("DEF_PARAMETROS"),
               NATIVAS = new NonTerminal("NATIVAS"),
               SENTENCIAS_CONTROL = new NonTerminal("SENTENCIAS_CONTROL"),

               IF_IF = new NonTerminal("IF_IF"),
               ELSE_IF = new NonTerminal("ELSE_IF"),

               LlamarMetodo = new NonTerminal("LlamarMetodo"),
               identificadores = new NonTerminal("identificadores"),
               RETORNAR = new NonTerminal("RETORNAR"),
               OpId = new NonTerminal("OpId"),

               LISTA_E = new NonTerminal("LISTA_E"),
                E = new NonTerminal("E"),
               T = new NonTerminal("T");
               


            var verdadero = ToTerm("true");
            var falso = ToTerm("false");



            INICIO.Rule = CODIGO;

            CODIGO.Rule = MakeStarRule(CODIGO, CUERPO_CODIGO);

            CUERPO_CODIGO.Rule = ENCABEZADO
                               | comentario1
                               | comentario2
                               | DECLARACION
                               | PRINCIPAL
                               | FUNCIONES
                               | EPSILON;
            

            ENCABEZADO.Rule = ToTerm("Importar") + id + "." + id + ";"
                            | ToTerm("Definir") + numero + ";"
                            | ToTerm("Definir") + cadena + ";"
                            //| ToTerm("Condicion ") + "("+ CONDICION +  ")" + ";"
                            ;


            DECLARACION.Rule = TIPO_DATO + LISTA_ID + ASIGNACION_DECLARACION + ";";
            
            ASIGNACION_DECLARACION.Rule = ToTerm("=") + CONDICION
                                        | EPSILON;


            LISTA_ID.Rule = MakeListRule(LISTA_ID, ToTerm(","), id);

            TIPO_DATO.Rule = ToTerm("Int")
                            | ToTerm("Double")
                            | ToTerm("Bool")
                            | ToTerm("String")
                            | ToTerm("Char")
                            | ToTerm("Vacio");



            PRINCIPAL.Rule = ToTerm("Vacio") + "Principal" + "(" + ")" + "{" + SENTENCIAS + "}";

            FUNCIONES.Rule = TIPO_DATO + id + "(" + PARAMETROS + ")" + "{" + SENTENCIAS + "}";

            PARAMETROS.Rule = MakeListRule(PARAMETROS, ToTerm(","), DEF_PARAMETROS);


            DEF_PARAMETROS.Rule = TIPO_DATO + id
                                | EPSILON;




            SENTENCIAS.Rule = MakeStarRule(SENTENCIAS, CUERPO_SENTENCIAS);

            CUERPO_SENTENCIAS.Rule = comentario1
                                    | comentario2
                                    | SENTENCIAS_CONTROL
                                    | DECLARACION
                                    | ASIGNACION
                                    | NATIVAS
                                    | RETORNAR
                                    | OpId
                                    | EPSILON;

            SENTENCIAS_CONTROL.Rule = IF_IF
                                    //| while_while
                                    //| do_while
                                    //| switch_switch
                                    ;

            IF_IF.Rule = ToTerm("Si") + "(" + CONDICION + ")" + "{" + SENTENCIAS + "}"
                       | ToTerm("Si") + "(" + CONDICION + ")" + "{" + SENTENCIAS + "}" + ELSE_IF;

            ELSE_IF.Rule = ToTerm("Sino") + "{" + SENTENCIAS + "}";


            ASIGNACION.Rule = id + ToTerm("=") + CONDICION + ";";

            NATIVAS.Rule = ToTerm("Mostrar") + "(" + LISTA_E + ")" + ";"
                         | ToTerm("DibujarAST") + "(" + LlamarMetodo +  ")" + ";" 
                         | ToTerm("DibujaEXP") + "(" + CONDICION + ")" + ";"
                         | ToTerm("DibujarTS") + "(" + ")" + ";";

            RETORNAR.Rule = ToTerm("Retorno") + CONDICION + ";"              
                          | ToTerm("Retorno") + ";";


            OpId.Rule = id + ToTerm("++") + ";"
                      | id + ToTerm("--") + ";"
                      | id + ToTerm("(") + LISTA_E + ")" + ";";

            EXPRESION.Rule = E;

            CONDICION.Rule = COND;

            EPSILON.Rule = Empty;

                                                                    //Condicion ( 1 > 3 || 1 > 3 |& 1 < 3 && 1 < 3 );            //Condicion ( 1==2);
            COND.Rule =
                       COND + "||" + COND  //verdadero cuando A o B son verdaderos
                      |COND + "&&" + COND  //verdadero cuando A y B son verdaderos.
                      | COND + "|&" + COND  //verdadero cuando A y B son diferentes
                      | ToTerm("!") + COND  //verdadero si A es falso.
                      | E + ">" + E
                      | E + "<" + E
                      | E + "<=" + E
                      | E + ">=" + E
                      | E + "==" + E
                      | E + "!=" + E
                      | E + "~" + E
                      | E;

            E.Rule = E + "+" + E
                   | E + "-" + E
                   | E + "*" + E
                   | E + "/" + E
                   | E + "^" + E
                   | E + "%" + E
                   | T;


            T.Rule =  numero
                    | verdadero
                    | falso
                    | cadena
                    | cadena_char
                    | EnParentesis
                    | identificadores
                    | LlamarMetodo;

            LlamarMetodo.Rule = id + "(" + LISTA_E + ")";
            
            LISTA_E.Rule = MakeListRule(LISTA_E, ToTerm(","), COND)
                         | EPSILON;

            identificadores.Rule =  id
                                  | id + ToTerm("++")
                                  | id + ToTerm("--");

            EnParentesis.Rule = ToTerm("(") + COND + (")");


            this.Root = INICIO;
            MarkTransient(INICIO, CODIGO, CUERPO_CODIGO);
            RegisterOperators(1, Associativity.Left, "+", "-");
            RegisterOperators(2, Associativity.Left, "*", "/", "%");
            RegisterOperators(3, Associativity.Right, "^");
            RegisterOperators(4, "==", "!=", "<", ">", "<=", ">=", "~");
            RegisterOperators(5, Associativity.Left, "||");
            RegisterOperators(6, Associativity.Left, "|&");
            RegisterOperators(7, Associativity.Left, "&&");
            RegisterOperators(8, Associativity.Left, "!");
            RegisterOperators(9, Associativity.Left, "(", ")");


           

        }


    }
}
