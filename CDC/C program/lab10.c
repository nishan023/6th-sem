#include <stdio.h>
#include <string.h>
#include <ctype.h>

#define MAX 100

// Stack for characters (operators)
char stack[MAX];
int top = -1;

void push(char c) {
    stack[++top] = c;
}

char pop() {
    if (top == -1) return '\0';
    return stack[top--];
}

char peek() {
    if (top == -1) return '\0';
    return stack[top];
}

int precedence(char c) {
    if (c == '+' || c == '-') return 1;
    if (c == '*' || c == '/') return 2;
    return 0;
}

void reverse(char *exp) {
    int len = strlen(exp);
    int i, j;
    char temp;
    for (i = 0, j = len - 1; i < j; i++, j--) {
        temp = exp[i];
        exp[i] = exp[j];
        exp[j] = temp;
    }
}

int isOperator(char c) {
    return (c == '+' || c == '-' || c == '*' || c == '/');
}

// Infix to Prefix conversion
void infixToPrefix(char *infix, char *prefix) {
    int i, j = 0;
    char ch;

    reverse(infix);

    for (i = 0; infix[i] != '\0'; i++) {
        if (infix[i] == '(') infix[i] = ')';
        else if (infix[i] == ')') infix[i] = '(';
    }

    top = -1;  // reset stack
    for (i = 0; infix[i] != '\0'; i++) {
        ch = infix[i];
        if (isdigit(ch)) {
            prefix[j++] = ch;
        } else if (ch == '(') {
            push(ch);
        } else if (ch == ')') {
            while (top != -1 && peek() != '(')
                prefix[j++] = pop();
            pop(); // pop '('
        } else if (isOperator(ch)) {
            while (top != -1 && precedence(peek()) > precedence(ch))
                prefix[j++] = pop();
            push(ch);
        }
    }
    while (top != -1)
        prefix[j++] = pop();

    prefix[j] = '\0';
    reverse(prefix);
}

// Evaluate prefix with detailed step output
int evaluatePrefix(char *prefix) {
    int stackInt[MAX], topInt = -1;
    int i, val;

    printf("\nEvaluation steps:\n");
    printf("-----------------------------------------------------\n");
    printf("| %-4s | %-6s | %-15s | %-15s |\n", 
           "Step", "Symbol", "Operation", "Stack contents");
    printf("-----------------------------------------------------\n");

    int step = 1;
    for (i = strlen(prefix) - 1; i >= 0; i--) {
        char ch = prefix[i];
        char operation[30] = "";

        if (isdigit(ch)) {
            stackInt[++topInt] = ch - '0';
            sprintf(operation, "Push %d", ch - '0');
        } else if (isOperator(ch)) {
            int op1 = stackInt[topInt--];
            int op2 = stackInt[topInt--];
            switch(ch) {
                case '+': val = op1 + op2; break;
                case '-': val = op1 - op2; break;
                case '*': val = op1 * op2; break;
                case '/': val = op1 / op2; break;
            }
            stackInt[++topInt] = val;
            sprintf(operation, "%d %c %d = %d", op1, ch, op2, val);
        } else {
            sprintf(operation, "Invalid symbol");
        }

        // stack as string
        char stackStr[50] = "";
        for (int k = 0; k <= topInt; k++) {
            char buf[10];
            sprintf(buf, "%d ", stackInt[k]);
            strcat(stackStr, buf);
        }

        printf("| %-4d | %-6c | %-15s | %-15s |\n", 
               step++, ch, operation, stackStr);
    }
    printf("-----------------------------------------------------\n");           

    return stackInt[topInt];
}

int main() {
    char infix[MAX], prefix[MAX];

    printf("Enter an infix expression (single digit operands only): ");
    scanf("%s", infix);

    infixToPrefix(infix, prefix);

    printf("Prefix Expression: %s\n", prefix);

    int result = evaluatePrefix(prefix); 
    printf("Evaluated Result: %d\n", result);

    return 0;
}
