
package Analisis;
import java_cup.runtime.Symbol;
import final_compi.*;

%%
%cupsym sym
%class Lexico
%cup
%public
%unicode
%line
%column
%char
%ignorecase

//------------------------------------------------------------------------
//EXPRESIONES REGULARES
Comentario1 = "//"[^\r\n]*
//Comentario2 = "/*"[^"*/"]*"*/" 
Comentario2 = {Comen}|{Comentdoc}

Comen = "/*" [^*] ~"*/" | "/*" "*" +"/"
Comentdoc = "/**" {contecoment} "*"+ "/"
contecoment = ([^*]| \* + [^/*])*

entero =("-"|"+")?[0-9]+ 
decimal =("-"|"+")?[0-9]+ "."? [0-9]*
cadena =[\"] [^\"\n]* [\"\n]
letra =[a-zA-ZÑñ]+
iden ={letra}({letra}|{entero}|"_")*
caracter="'"[^]"'"
//bool=("verdadero"|"falso"|"1"|"0")



//-------------------------------------------------------------------------

%{
    //codigo de java
    String nombre;
    public void imprimir(String dato,String cadena){
    	//System.out.println(dato+" : "+cadena);
    }
    public void imprimir(String cadena){
    	//System.out.println(cadena+" soy reservada");
    }
%}

%%

//RESERVADAS

"Print"                 {return new Symbol(sym.resPrint,yycolumn,yyline,yytext());} 
"DibujarAST"            {return new Symbol(sym.resDibujar,yycolumn,yyline,yytext());} 
"VerErrores"            {return new Symbol(sym.resErrores,yycolumn,yyline,yytext());} 
"VerTablaSimbolos"      {return new Symbol(sym.resTabla,yycolumn,yyline,yytext());} 
"Clean"                 {return new Symbol(sym.resClean,yycolumn,yyline,yytext());} 


"import"            {return new Symbol(sym.resImport,yycolumn,yyline,yytext());} 
"class"             {return new Symbol(sym.resClass,yycolumn,yyline,yytext());} 
"extends"           {return new Symbol(sym.resExtends,yycolumn,yyline,yytext());} 
"new"               {return new Symbol(sym.resNew,yycolumn,yyline,yytext());} 

"public"           {return new Symbol(sym.resPublic,yycolumn,yyline,yytext());} 
"private"          {return new Symbol(sym.resPrivate,yycolumn,yyline,yytext());} 
"protected"        {return new Symbol(sym.resProtected,yycolumn,yyline,yytext());}
"final"            {return new Symbol(sym.resFinal,yycolumn,yyline,yytext());}  

"boolean"          {return new Symbol(sym.resBoolean,yycolumn,yyline,yytext());}
"char"             {return new Symbol(sym.resChar,yycolumn,yyline,yytext());}
"double"           {return new Symbol(sym.resDouble,yycolumn,yyline,yytext());}
"int"              {return new Symbol(sym.resInt,yycolumn,yyline,yytext());}
"String"           {return new Symbol(sym.resString,yycolumn,yyline,yytext());}

"void"              {return new Symbol(sym.resVoid,yycolumn,yyline,yytext());}
"@Override"         {return new Symbol(sym.resOverride,yycolumn,yyline,yytext());}
"return"            {return new Symbol(sym.resReturn,yycolumn,yyline,yytext());}
"break"             {return new Symbol(sym.resBreak,yycolumn,yyline,yytext());}
"continue"          {return new Symbol(sym.resContinue,yycolumn,yyline,yytext());}  


"while"        {return new Symbol(sym.resWhile,yycolumn,yyline,yytext());}
"do"           {return new Symbol(sym.resDo,yycolumn,yyline,yytext());}
"if"           {return new Symbol(sym.resIf,yycolumn,yyline,yytext());}
"else"         {return new Symbol(sym.resElse,yycolumn,yyline,yytext());}
"for"          {return new Symbol(sym.resFor,yycolumn,yyline,yytext());}

"switch"       {return new Symbol(sym.resSwitch,yycolumn,yyline,yytext());}
"case"         {return new Symbol(sym.resCase,yycolumn,yyline,yytext());}
"default"      {return new Symbol(sym.resDefault,yycolumn,yyline,yytext());}

//SIMBOLOS
"+"              {return new Symbol(sym.mas,yycolumn,yyline,yytext());}     

"++"              {return new Symbol(sym.masmas,yycolumn,yyline,yytext());}     
"--"              {return new Symbol(sym.menosmenos,yycolumn,yyline,yytext());}     

"-"              {return new Symbol(sym.menos,yycolumn,yyline,yytext());}     
"*"              {return new Symbol(sym.mul,yycolumn,yyline,yytext());}     
"/"              {return new Symbol(sym.div,yycolumn,yyline,yytext());}     
"%"              {return new Symbol(sym.mod,yycolumn,yyline,yytext());}     
"^"              {return new Symbol(sym.pot,yycolumn,yyline,yytext());}

"="              {return new Symbol(sym.igual,yycolumn,yyline,yytext());} 
";"              {return new Symbol(sym.puntoComa,yycolumn,yyline,yytext());}  
","              {return new Symbol(sym.coma,yycolumn,yyline,yytext());}  
"."              {return new Symbol(sym.punto,yycolumn,yyline,yytext());}  
":"              {return new Symbol(sym.dosPuntos,yycolumn,yyline,yytext());}  

"["              {return new Symbol(sym.cora,yycolumn,yyline,yytext());}
"]"              {return new Symbol(sym.corc,yycolumn,yyline,yytext());}
"("              {return new Symbol(sym.para,yycolumn,yyline,yytext());}
")"              {return new Symbol(sym.parc,yycolumn,yyline,yytext());}
"{"              {return new Symbol(sym.llavea,yycolumn,yyline,yytext());}
"}"              {return new Symbol(sym.llavec,yycolumn,yyline,yytext());}

"&&"             {return new Symbol(sym.simAnd,yycolumn,yyline,yytext());}
"||"             {return new Symbol(sym.simOr,yycolumn,yyline,yytext());}
"!"              {return new Symbol(sym.simNot,yycolumn,yyline,yytext());}

">"               {return new Symbol(sym.mayor,yycolumn,yyline,yytext());}
"<"               {return new Symbol(sym.menor,yycolumn,yyline,yytext());}
">="              {return new Symbol(sym.mayorigual,yycolumn,yyline,yytext());}
"<="              {return new Symbol(sym.menorigual,yycolumn,yyline,yytext());}
"=="              {return new Symbol(sym.igualigual,yycolumn,yyline,yytext());} 
"!="              {return new Symbol(sym.diferente,yycolumn,yyline,yytext());}



{entero}         {return new Symbol(sym.entero,yycolumn,yyline,yytext());}
{decimal}        {return new Symbol(sym.decimal,yycolumn,yyline,yytext());}
{cadena}         {return new Symbol(sym.cadena,yycolumn,yyline,yytext());}
//{bool}           {return new Symbol(sym.bool,yycolumn,yyline,yytext());}
{iden}           {return new Symbol(sym.iden,yycolumn,yyline,yytext());}
{caracter}       {return new Symbol(sym.caracter,yycolumn,yyline,yytext());}


/* COMENTARIOS */
{Comentario1}     {return new Symbol(sym.comLin,yycolumn,yyline,yytext());}
{Comentario2}     {return new Symbol(sym.comMul,yycolumn,yyline,yytext());}

/* BLANCOS */
[\n\t\r\f]+     {/* Se ignoran */}
(" ")+          {/* Se ignoran */}         


/* Cualquier Otro   ERROR LEXICO*/
.   {
	//errores ee=new errores("Error de tipo lexico",yytext(),yyline,yycolumn);
        //Interfaz.lista_error.add(ee);
	System.err.println("Error lexico--------------------------: "+yytext()+ " Linea:"+(yyline+1)+" Columna:"+(yycolumn+1));
    }



