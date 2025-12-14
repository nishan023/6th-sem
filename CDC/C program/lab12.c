#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>

#define MAX 100

typedef struct {
    char result[10];
    char arg1[10];
    char op[2];
    char arg2[10];
} TAC;

// Function to check if string is numeric
int isNumeric(char *str) {
    for (int i = 0; str[i]; i++) {
        if (!isdigit(str[i])) return 0;
    }
    return 1;
}

// Function to evaluate constant expression
int evaluate(int a, char op, int b) {
    switch(op) {
        case '+': return a + b;
        case '-': return a - b;
        case '*': return a * b;
        case '/': return a / b;
    }
    return 0;
}

int main() {
    int n;
    printf("Enter number of TAC statements: ");
    scanf("%d", &n);
    getchar(); // consume newline

    TAC tac[MAX];
    printf("Enter TAC statements in format (result = arg1 op arg2):\n");

    for(int i=0;i<n;i++){
        char line[50];
        fgets(line, sizeof(line), stdin);
        sscanf(line, "%s = %s %s %s", tac[i].result, tac[i].arg1, tac[i].op, tac[i].arg2);
    }

    // Perform constant folding and propagation
    for(int i=0;i<n;i++){
        // Constant Folding
        if(isNumeric(tac[i].arg1) && isNumeric(tac[i].arg2)) {
            int val = evaluate(atoi(tac[i].arg1), tac[i].op[0], atoi(tac[i].arg2));
            sprintf(tac[i].arg1, "%d", val);
            strcpy(tac[i].op, "");
            strcpy(tac[i].arg2, "");
        }

        // Constant Propagation
        for(int j=i+1;j<n;j++){
            if(strcmp(tac[j].arg1, tac[i].result) == 0) strcpy(tac[j].arg1, tac[i].arg1);
            if(strcmp(tac[j].arg2, tac[i].result) == 0) strcpy(tac[j].arg2, tac[i].arg1);
        }
    }

    // Display optimized TAC
    printf("\nOptimized TAC:\n");
    for(int i=0;i<n;i++){
        if(strlen(tac[i].op) > 0)
            printf("%s = %s %s %s\n", tac[i].result, tac[i].arg1, tac[i].op, tac[i].arg2);
        else
            printf("%s = %s\n", tac[i].result, tac[i].arg1);
    }

    return 0;
}
