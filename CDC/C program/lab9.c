#include <stdio.h>
#include <string.h>
#include <ctype.h>

#define MAX 100

// Operator stack
char opStack[MAX];
int top = -1;

// Operand stack (strings)
char operands[MAX][MAX];
int opdTop = -1;

int tempCount = 1;

// Operator precedence
int precedence(char op) {
    if (op == '+' || op == '-') return 1;
    if (op == '*' || op == '/') return 2;
    return 0;
}

void pushOp(char op) {
    opStack[++top] = op;
}

char popOp() {
    if (top == -1) return '\0';
    return opStack[top--];
}

char peekOp() {
    if (top == -1) return '\0';
    return opStack[top];
}

void pushOperand(char *s) {
    strcpy(operands[++opdTop], s);
}

void popOperand(char *res) {
    strcpy(res, operands[opdTop--]);
}

void getTemp(char *temp) {
    sprintf(temp, "t%d", tempCount++);
}

void generateTAC(char *op1, char operator, char *op2, char *result) {
    printf("%s = %s %c %s\n", result, op1, operator, op2);
}

void generateMachineCode(char *result, char *op1, char operator, char *op2) {
    printf("LOAD %s\n", op1);
    switch(operator) {
        case '+': printf("ADD %s\n", op2); break;
        case '-': printf("SUB %s\n", op2); break;
        case '*': printf("MUL %s\n", op2); break;
        case '/': printf("DIV %s\n", op2); break;
    }
    printf("STORE %s\n", result);
}

int main() {
    char expr[MAX], lhs[20], rhs[MAX];
    char token[20];
    int i = 0, j = 0;

    printf("Enter an expression (e.g., a = b + c * d): ");
    fgets(expr, sizeof(expr), stdin);
    expr[strcspn(expr, "\n")] = 0;  // remove trailing newline

    // Parse lhs
    i = 0;
    while(expr[i] != '=' && expr[i] != '\0') {
        lhs[i] = expr[i];
        i++;
    }
    lhs[i] = '\0';

    if(expr[i] != '=') {
        printf("Invalid expression. No '=' found.\n");
        return 1;
    }

    i++;  // skip '='

    // Parse rhs
    j = 0;
    while(expr[i] != '\0') {
        rhs[j++] = expr[i++];
    }
    rhs[j] = '\0';

    // Remove spaces from rhs
    char rhsNoSpace[MAX];
    j = 0;
    for(i=0; rhs[i] != '\0'; i++) {
        if(rhs[i] != ' ')
            rhsNoSpace[j++] = rhs[i];
    }
    rhsNoSpace[j] = '\0';

    // Clear stacks and temp counter
    top = -1;
    opdTop = -1;
    tempCount = 1;

    // Shunting Yard + TAC generation
    // We'll store generated TAC in arrays to use them for machine code generation
    char tacLHS[50][20];
    char tacOp1[50][20];
    char tacOp[50];
    char tacOp2[50][20];
    int tacCount = 0;

    i = 0;
    while(rhsNoSpace[i] != '\0') {
        if(isalnum(rhsNoSpace[i])) {
            // Read full variable/number
            j = 0;
            while(isalnum(rhsNoSpace[i])) {
                token[j++] = rhsNoSpace[i++];
            }
            token[j] = '\0';
            pushOperand(token);
        } else {
            // Operator
            while(top != -1 && precedence(peekOp()) >= precedence(rhsNoSpace[i])) {
                char op = popOp();
                char op2[20], op1[20], temp[20];
                popOperand(op2);
                popOperand(op1);
                getTemp(temp);

                // Save TAC line
                strcpy(tacLHS[tacCount], temp);
                strcpy(tacOp1[tacCount], op1);
                tacOp[tacCount] = op;
                strcpy(tacOp2[tacCount], op2);
                tacCount++;

                generateTAC(op1, op, op2, temp);
                pushOperand(temp);
            }
            pushOp(rhsNoSpace[i]);
            i++;
        }
    }

    while(top != -1) {
        char op = popOp();
        char op2[20], op1[20], temp[20];
        popOperand(op2);
        popOperand(op1);
        getTemp(temp);

        strcpy(tacLHS[tacCount], temp);
        strcpy(tacOp1[tacCount], op1);
        tacOp[tacCount] = op;
        strcpy(tacOp2[tacCount], op2);
        tacCount++;

        generateTAC(op1, op, op2, temp);
        pushOperand(temp);
    }

    // Final assignment
    char finalTemp[20];
    popOperand(finalTemp);
    printf("%s = %s\n", lhs, finalTemp);

    // Generate machine code
    printf("\nMachine Code:\n");
    for(i = 0; i < tacCount; i++) {
        generateMachineCode(tacLHS[i], tacOp1[i], tacOp[i], tacOp2[i]);
    }
    // Finally, assign result to lhs variable
    printf("LOAD %s\nSTORE %s\n", finalTemp, lhs);

    return 0;
}
