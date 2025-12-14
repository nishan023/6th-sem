%{
#include <stdio.h>
#include <string.h>
%}

%%

[0-9]+   {
            char str[100];
            strcpy(str, yytext);

            int len = strlen(str);
            int is_palindrome = 1;

            for (int i = 0; i < len / 2; i++) {
                if (str[i] != str[len - i - 1]) {
                    is_palindrome = 0;
                    break;
                }
            }

            if (is_palindrome)
                printf("%s is a Palindrome number.\n", str);
            else
                printf("%s is NOT a Palindrome number.\n", str);
         }

\n        ;   /* ignore newline */
.         ;   /* ignore other characters */

%%

int main() {
    printf("Enter a number: ");
    yylex();
    return 0;
}

int yywrap() { return 1; }
