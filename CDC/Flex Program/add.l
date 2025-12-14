%{
#include <stdio.h>
int num1, num2;
%}

%%
[0-9]+   {
            if(num1 == 0) 
                num1 = atoi(yytext);
            else 
                num2 = atoi(yytext);
          }
[\n]      { printf("Sum = %d\n", num1 + num2); num1 = num2 = 0; }
.         ;   /* Ignore other characters */
%%

int main() {
    printf("Enter two numbers: ");
    yylex();
    return 0;
}
