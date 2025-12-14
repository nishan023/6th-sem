
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#define MAX 100

typedef struct {
    char op[5];
    char arg1[20];
    char arg2[20];
    char result[20];
} Quadruple;

typedef struct {
    char op[5];
    char arg1[20];
    char arg2[20];
} Triple;

char stack[MAX][20];
int top = -1;

void push(char* str) {
    strcpy(stack[++top], str);
}

char* pop() {
    return stack[top--];
}

int precedence(char op) {
    if (op == '*' || op == '/') return 2;
    if (op == '+' || op == '-') return 1;
    return 0;
}

int isOperator(char c) {
    return c == '+' || c == '-' || c == '*' || c == '/';
}

int tokenize(char* expr, char tokens[][20]) {
    int i = 0, j = 0, k = 0;
    while (expr[i]) {
        if (isspace(expr[i])) {
            i++;
            continue;
        }
        if (isalnum(expr[i])) {
            j = 0;
            while (isalnum(expr[i])) {
                tokens[k][j++] = expr[i++];
            }
            tokens[k++][j] = '\0';
        } else {
            tokens[k][0] = expr[i++];
            tokens[k++][1] = '\0';
        }
    }
    return k;
}

int infixToPostfix(char tokens[][20], int n, char postfix[][20]) {
    char opStack[MAX][20];
    int top = -1, k = 0;

    for (int i = 0; i < n; i++) {
        if (isalnum(tokens[i][0])) {
            strcpy(postfix[k++], tokens[i]);
        } else if (tokens[i][0] == '(') {
            strcpy(opStack[++top], tokens[i]);
        } else if (tokens[i][0] == ')') {
            while (top != -1 && opStack[top][0] != '(') {
                strcpy(postfix[k++], opStack[top--]);
            }
            top--; // remove '('
        } else if (isOperator(tokens[i][0])) {
            while (top != -1 && precedence(opStack[top][0]) >= precedence(tokens[i][0])) {
                strcpy(postfix[k++], opStack[top--]);
            }
            strcpy(opStack[++top], tokens[i]);
        } else if (tokens[i][0] == '=') {
            // assignment goes at beginning
            strcpy(postfix[k++], tokens[i]);
        }
    }

    while (top != -1) {
        strcpy(postfix[k++], opStack[top--]);
    }

    return k;
}

// === Quadruples and Triples ===
void generateQuadruplesAndTriples(char postfix[][20], int n) {
    Quadruple quad[MAX];
    Triple trip[MAX];
    char lhs[20];
    int q = 0;

    for (int i = 0; i < n; i++) {
        if (strcmp(postfix[i], "=") == 0) {
            strcpy(lhs, pop());
        } else if (isOperator(postfix[i][0])) {
            char arg2[20], arg1[20], temp[10];
            strcpy(arg2, pop());
            strcpy(arg1, pop());
            sprintf(temp, "t%d", q);

            // Quadruples
            strcpy(quad[q].op, postfix[i]);
            strcpy(quad[q].arg1, arg1);
            strcpy(quad[q].arg2, arg2);
            strcpy(quad[q].result, temp);

            // Triples
            strcpy(trip[q].op, postfix[i]);
            strcpy(trip[q].arg1, arg1);
            strcpy(trip[q].arg2, arg2);

            push(temp);
            q++;
        } else {
            push(postfix[i]);
        }
    }

    // Final assignment
    char finalResult[20];
    strcpy(finalResult, pop());

    // Last Quadruple for assignment
    strcpy(quad[q].op, "=");
    strcpy(quad[q].arg1, finalResult);
    strcpy(quad[q].arg2, "-");
    strcpy(quad[q].result, lhs);

    strcpy(trip[q].op, "=");
    strcpy(trip[q].arg1, finalResult);
    strcpy(trip[q].arg2, "-");

    q++;

    // === Print Quadruples ===
printf("\nQuadruples:\n");
printf("%-5s %-10s %-10s %-10s %-10s\n", "Index", "Op", "Arg1", "Arg2", "Result");
for (int i = 0; i < q; i++) {
    printf("%-5d %-10s %-10s %-10s %-10s\n", i, quad[i].op, quad[i].arg1, quad[i].arg2, quad[i].result);
}

// === Print Triples ===
printf("\nTriples:\n");
printf("%-5s %-10s %-10s %-10s\n", "Index", "Op", "Arg1", "Arg2");
for (int i = 0; i < q; i++) {
    printf("%-5d %-10s %-10s %-10s\n", i, trip[i].op, trip[i].arg1, trip[i].arg2);
}

}

// === MAIN ===
int main() {
    char expr[MAX];
    char tokens[MAX][20], postfix[MAX][20];
    int tokenCount, postCount;

    printf("Enter arithmetic expression (e.g., a = b + c * d): ");
    fgets(expr, MAX, stdin);
    expr[strcspn(expr, "\n")] = '\0';

    tokenCount = tokenize(expr, tokens);
    postCount = infixToPostfix(tokens, tokenCount, postfix);

    generateQuadruplesAndTriples(postfix, postCount);

    return 0;
}
