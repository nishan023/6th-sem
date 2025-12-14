%{
#include <stdio.h>
int vowels = 0, consonants = 0;
%}

%%

[aeiouAEIOU]   { vowels++; }
[a-zA-Z]       { consonants++; }
.|\n           ;   /* ignore everything else */

%%

int main() {
    printf("Enter a string: ");
    yylex();
    printf("\nNumber of vowels: %d", vowels);
    printf("\nNumber of consonants: %d\n", consonants);
    return 0;
}

int yywrap() { return 1; }
