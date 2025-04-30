#include <stdio.h>
#include <string.h>
#include <pthread.h>
#include <unistd.h>


void TomarNotaClienteConectado (ListaClientes *lista, char nombre[20], int socket)
void TomarNotaClienteDesconectado (ListaClientes *lista, int socket)
int DameSaldoCliente (ListaClientes *lista, char nombre[20])
void HacerIngreso (ListaClientes *lista, int cantidad, char nombre[20])
void HacerCargoCliente (ListaClientes *lista, int cantidad, char nombre[20])
void HacerCargoComision (ListaClientes *lista, int cantidad)
int DameSocketsConectados (ListaClientes *lista, int sockets[100])


// Estructura global
extern ListaClientes lista;
pthread_mutex_t mutex_lista = PTHREAD_MUTEX_INITIALIZER;

// Función para atender a un cliente
void *AtenderCliente(void *arg) {
    int socket = *(int *)arg;
    char buffer[256];
    char nombre[20];
    int conectado = 1;

    while (conectado) {
        // Leer comando del cliente
        int bytes_leidos = read(socket, buffer, sizeof(buffer) - 1);
        if (bytes_leidos <= 0) {
            break; // Error o desconexión
        }
        buffer[bytes_leidos] = '\0';

        // Parsear comando
        char comando[20];
        sscanf(buffer, "%s", comando);

        if (strcmp(comando, "LOGIN") == 0) {
            sscanf(buffer, "%*s %s", nombre);
            pthread_mutex_lock(&mutex_lista);
            TomarNotaClienteConectado(&lista, nombre, socket);
            pthread_mutex_unlock(&mutex_lista);
            write(socket, "OK\n", 3);

        } else if (strcmp(comando, "SALDO") == 0) {
            pthread_mutex_lock(&mutex_lista);
            int saldo = DameSaldoCliente(&lista, nombre);
            pthread_mutex_unlock(&mutex_lista);
            sprintf(buffer, "SALDO %d\n", saldo);
            write(socket, buffer, strlen(buffer));

        } else if (strcmp(comando, "INGRESO") == 0) {
            int cantidad;
            sscanf(buffer, "%*s %d", &cantidad);
            pthread_mutex_lock(&mutex_lista);
            HacerIngreso(&lista, cantidad, nombre);
            pthread_mutex_unlock(&mutex_lista);
            write(socket, "OK\n", 3);

        } else if (strcmp(comando, "LOGOUT") == 0) {
            pthread_mutex_lock(&mutex_lista);
            TomarNotaClienteDesconectado(&lista, socket);
            pthread_mutex_unlock(&mutex_lista);
            conectado = 0;
            write(socket, "OK\n", 3);

        } else if (strcmp(comando, "CARGO") == 0 && strcmp(nombre, "Admin") == 0) {
            char cliente[20];
            int cantidad;
            sscanf(buffer, "%*s %s %d", cliente, &cantidad);
            pthread_mutex_lock(&mutex_lista);
            HacerCargoCliente(&lista, cantidad, cliente);
            pthread_mutex_unlock(&mutex_lista);
            write(socket, "OK\n", 3);

        } else if (strcmp(comando, "COMISION") == 0 && strcmp(nombre, "Admin") == 0) {
            int cantidad;
            sscanf(buffer, "%*s %d", &cantidad);
            pthread_mutex_lock(&mutex_lista);
            HacerCargoComision(&lista, cantidad);
            int sockets[100];
            int num_conectados = DameSocketsConectados(&lista, sockets);
            pthread_mutex_unlock(&mutex_lista);

            // Notificar a todos los clientes conectados
            for (int i = 0; i < num_conectados; i++) {
                sprintf(buffer, "NOTIFICACION Se ha aplicado una comisión de %d\n", cantidad);
                write(sockets[i], buffer, strlen(buffer));
            }
            write(socket, "OK\n", 3);

        } else {
            write(socket, "ERROR Comando no reconocido\n", 28);
        }
    }

    close(socket);
    return NULL;
}