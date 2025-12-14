%{
#include <stdio.h>
int ws_count = 0;
%}

%%

[ \t\n]   { ws_count++; }   /* space, tab, newline */
.         ;                 /* ignore everything else */

%%

int main() {
    printf("Enter a string (press Ctrl+D in Linux/Mac or Ctrl+Z in Windows to end):\n");
    yylex();
    printf("\nTotal number of whitespaces: %d\n", ws_count);
    return 0;
}

int yywrap() { return 1; }
