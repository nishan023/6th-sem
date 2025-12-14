%{
#include <stdio.h>
#include <stdlib.h>

int num1, num2;
char op;
%}

%%

[0-9]+      { 
                if(num1 == -1) num1 = atoi(yytext); 
                else num2 = atoi(yytext); 
            }

[+\-*/]     { op = yytext[0]; }

[ \t\n]+    ;  // ignore whitespace

.           { ; }  // ignore other characters

%%

int main() {
    char expr[100];
    printf("Enter an expression (e.g., 5 + 3):\n");

    while(1) {
        num1 = num2 = -1;
        op = 0;

        if(fgets(expr, sizeof(expr), stdin) == NULL) break;
        if(expr[0] == '\n') continue;  // skip empty lines

        YY_BUFFER_STATE bp = yy_scan_string(expr);
        yylex();
        yy_delete_buffer(bp);

        if(num1 != -1 && num2 != -1) {
            switch(op) {
                case '+': printf("%d\n", num1 + num2); break;
                case '-': printf("%d\n", num1 - num2); break;
                case '*': printf("%d\n", num1 * num2); break;
                case '/': 
                    if(num2 != 0) printf("%d\n", num1 / num2);
                    else printf("Error: Division by zero\n");
                    break;
                default: printf("Unknown operator\n");
            }
        } else {
            printf("Invalid expression!\n");
        }
    }
    return 0;
}

int yywrap() { return 1; }