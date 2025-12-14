%{
#include <stdio.h>
#include <string.h>

int keyword_count = 0;

/* List of keywords we want to recognize */
char *keywords[] = {
    "int", "float", "char", "double", "if", "else", "while", "for",
    "do", "return", "break", "continue", "void", "switch", "case",
    "struct", "typedef", "const", "goto", "default"
};
int n_keywords = 20;   /* total number of keywords in the list */

int is_keyword(char *word) {
    for (int i = 0; i < n_keywords; i++) {
        if (strcmp(word, keywords[i]) == 0)
            return 1;
    }
    return 0;
}
%}

%%

[a-zA-Z_][a-zA-Z0-9_]*   {
                            if (is_keyword(yytext)) {
                                printf("Keyword found: %s\n", yytext);
                                keyword_count++;
                            }
                         }

[ \t\n]+    ;    /* Ignore whitespace */
.           ;    /* Ignore other characters */

%%

int main() {
    printf("Enter input string :\n");
    yylex();
    printf("\nTotal number of keywords: %d\n", keyword_count);
    return 0;
}

int yywrap() { return 1; }
