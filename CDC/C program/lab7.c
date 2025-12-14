#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#define MAX 100

typedef struct {
    char items[MAX][MAX];
    int top;
} Stack;

void push(Stack *s, char *item) {
    strcpy(s->items[++(s->top)], item);
}

char* pop(Stack *s) {
    return s->items[(s->top)--];
}

int isOperator(char c) {
    return c == '+' || c == '-' || c == '*' || c == '/';
}

int precedence(char op) {
    if (op == '+' || op == '-') return 1;
    if (op == '*' || op == '/') return 2;
    return 0;
}

// Convert infix expression to postfix
void infixToPostfix(char *infix, char postfix[][MAX], int *postfixLen) {
    Stack opStack;
    opStack.top = -1;
    int i = 0, k = 0;
    char token[MAX];

    while (infix[i] != '\0') {
        if (isspace(infix[i])) {
            i++;
            continue;
        }

        if (isalpha(infix[i]) || isdigit(infix[i])) {
            // Operand (variable or digit)
            int j = 0;
            while (isalnum(infix[i])) {
                token[j++] = infix[i++];
            }
            token[j] = '\0';
            strcpy(postfix[k++], token);
        } else if (isOperator(infix[i])) {
            while (opStack.top != -1 && precedence(opStack.items[opStack.top][0]) >= precedence(infix[i])) {
                strcpy(postfix[k++], pop(&opStack));
            }
            char op[2];
            op[0] = infix[i];
            op[1] = '\0';
            push(&opStack, op);
            i++;
        } else if (infix[i] == '(') {
            char op[2] = "(";
            push(&opStack, op);
            i++;
        } else if (infix[i] == ')') {
            while (opStack.top != -1 && strcmp(opStack.items[opStack.top], "(") != 0) {
                strcpy(postfix[k++], pop(&opStack));
            }
            if (opStack.top != -1 && strcmp(opStack.items[opStack.top], "(") == 0)
                opStack.top--; // pop '('
            i++;
        } else {
            // Invalid char
            i++;
        }
    }

    while (opStack.top != -1) {
        strcpy(postfix[k++], pop(&opStack));
    }
    *postfixLen = k;
}

int tempCount = 0;

void newTemp(char *temp) {
    sprintf(temp, "t%d", ++tempCount);
}

// Generate three-address code from postfix expression
void generateTAC(char postfix[][MAX], int len, char *resultVar) {
    Stack tempStack;
    tempStack.top = -1;

    char op1[MAX], op2[MAX], temp[MAX];

    for (int i = 0; i < len; i++) {
        if (!isOperator(postfix[i][0]) || strlen(postfix[i]) > 1) {
            // Operand
            push(&tempStack, postfix[i]);
        } else {
            // Operator
            strcpy(op2, pop(&tempStack));
            strcpy(op1, pop(&tempStack));

            newTemp(temp);
            printf("%s = %s %c %s\n", temp, op1, postfix[i][0], op2);
            push(&tempStack, temp);
        }
    }

    // Final result assign to resultVar
    if (tempStack.top == 0) {
        char *final = pop(&tempStack);
        printf("%s = %s\n", resultVar, final);
    }
}

int main() {
    char expression[200];
    char lhs[50];
    char rhs[150];

    printf("Enter an arithmetic expression (e.g. a = b + c * d):\n");
    fgets(expression, sizeof(expression), stdin);

    // Remove newline
    expression[strcspn(expression, "\n")] = 0;

    // Remove spaces from expression
    char exprNoSpaces[200];
    int j = 0;
    for (int i = 0; expression[i]; i++) {
        if (expression[i] != ' ')
            exprNoSpaces[j++] = expression[i];
    }
    exprNoSpaces[j] = '\0';

    // Separate LHS and RHS
    char *eqPos = strchr(exprNoSpaces, '=');
    if (!eqPos) {
        printf("Invalid expression: No '=' found.\n");
        return 1;
    }

    int lhsLen = eqPos - exprNoSpaces;
    strncpy(lhs, exprNoSpaces, lhsLen);
    lhs[lhsLen] = '\0';

    strcpy(rhs, eqPos + 1);

    // Convert RHS infix to postfix
    char postfix[100][MAX];
    int postfixLen = 0;
    tempCount = 0;

    infixToPostfix(rhs, postfix, &postfixLen);

    // Generate TAC
    generateTAC(postfix, postfixLen, lhs);

    return 0;
}
