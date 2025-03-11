#include <stdlib.h> // necesario para atof
#include <stdio.h>
#include <string.h>
#include <ctype.h>

int esPalindromo(char *nombre) {
	int longitud = strlen(nombre);
	for (int i = 0; i < longitud / 2; i++) {
		if (tolower(nombre[i]) != tolower(nombre[longitud - i - 1])) {
			return 0;
		}
	}
	return 1;
}

void convertirMayusculas(char *nombre) {
	for (int i = 0; nombre[i]; i++) {
		nombre[i] = toupper(nombre[i]);
	}
}

int main(int argc, char *argv[]) {
	char peticion[100];
	char resultado[100];
	
	strcpy(peticion, "Miguel/47/Juan/12/Maria/22/Marcos/19");
	// Resultado: "Miguel *47-Maria *22-Marcos*19"
	
	char nombre[20];
	int edad;
	char *p = strtok(peticion, "/");
	
	while (p != NULL) {
		strcpy(nombre, p);
		p = strtok(NULL, "/");
		edad = atoi(p);
		if (edad > 18) {
			sprintf(resultado, "%s%s*%d-", resultado, nombre, edad);
		}
		
		p = strtok(NULL, "/");
	}
	resultado[strlen(resultado) - 1] = '\0';
	
	printf("Resultado: %s\n", resultado);
	
	// Nuevos servicios
	char nombrePrueba[] = "Ana";
	if (esPalindromo(nombrePrueba)) {
		printf("%s es un palíndromo.\n", nombrePrueba);
	} else {
		printf("%s no es un palíndromo.\n", nombrePrueba);
	}
	
	char nombrePrueba2[] = "Luis";
	if (esPalindromo(nombrePrueba2)) {
		printf("%s es un palíndromo.\n", nombrePrueba2);
	} else {
		printf("%s no es un palíndromo.\n", nombrePrueba2);
	}
	
	convertirMayusculas(nombrePrueba);
	printf("Nombre en mayúsculas: %s\n", nombrePrueba);
	convertirMayusculas(nombrePrueba2);
	printf("Nombre en mayúsculas: %s\n", nombrePrueba2);
	
	return 0;
}
