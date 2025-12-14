%{
#include <stdio.h>

int balance = 0;   /* counter for parentheses */
int error = 0;
%}

%%

"("     { balance++; }
")"     {
           balance--;
           if (balance < 0) {
               error = 1;   /* more closing than opening */
           }
        }

.|\n    ;   /* ignore all other characters */

%%

int main() {
    printf("Enter an arithmetic expression: ");
    yylex();

    if (error == 0 && balance == 0)
        printf("\nParentheses are BALANCED.\n");
    else
        printf("\nParentheses are NOT balanced.\n");

    return 0;
}

int yywrap() { return 1; }
