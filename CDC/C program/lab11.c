#include <stdio.h>
#include <ctype.h>
#include <string.h>

int main() {
    char input[200];
    int i;

    printf("Enter an input string: ");
    fgets(input, sizeof(input), stdin);
    input[strcspn(input, "\n")] = '\0'; // remove newline

    printf("\nLexical Analysis Report:\n");
    printf("------------------------\n");

    for (i = 0; i < strlen(input); i++) {
        char ch = input[i];

        if (isalpha(ch)) {
            printf("'%c' -> Identifier/Keyword\n", ch);
        }
        else if (isdigit(ch)) {
            printf("'%c' -> Number\n", ch);
        }
        else if (ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '=' || ch == '<' || ch == '>') {
            printf("'%c' -> Operator\n", ch);
        }
        else if (ch == ' ' || ch == '\t') {
            // Ignore whitespace
        }
        else {
            printf("'%c' -> Lexical Error (Invalid character)\n", ch);
        }
    }

    return 0;
}
