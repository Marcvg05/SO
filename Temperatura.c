#include <stdlib.h> // necesario para atof
#include <stdio.h>
#include <string.h>
#include <ctype.h>
float celsiusAFahrenheit(float celsius) {
	return (celsius * 9 / 5) + 32;
}

float fahrenheitACelsius(float fahrenheit) {
	return (fahrenheit - 32) * 5 / 9;
}

int main() {
	float temperatura;
	char escala[2];
	
	printf("Introduce la temperatura: ");
	scanf("%f", &temperatura);
	printf("Introduce la escala (C o F): ");
	scanf("%s", escala);
	
	// Aquí se llamaría al servidor de conversión de temperaturas
	// Por simplicidad, usamos las funciones directamente
	if (strcmp(escala, "C") == 0) {
		printf("%.2f°C es %.2f°F\n", temperatura, celsiusAFahrenheit(temperatura));
	} else if (strcmp(escala, "F") == 0) {
		printf("%.2f°F es %.2f°C\n", temperatura, fahrenheitACelsius(temperatura));
	} else {
		printf("Escala no reconocida.\n");
	}
	
	return 0;
}
