#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>

#define MAX_CLIENTES 5
#define PUERTO 5000

int contador;

// Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

void *AtenderCliente(void *socket)
{
    int sock_conn;
    int *s;
    s = (int *)socket;
    sock_conn = *s;

    // int socket_conn = * (int *) socket;

    char peticion[512];
    char respuesta[512];
    int ret;

    int terminar = 0;
     while (terminar == 0)
     {
        ret = read(sock_conn,peticion,sizeof(peticion));
        printf ("Recibido\n");

        peticion[ret]='\0';

        printf ("Petición: %s\n",peticion);

        char *p = strtok(peticion,"/");
        int codigo = atoi(p);

        char nombre[20];

        if ((codigo != 0)&&(codigo != 4)){
            p = strtok(NULL, "/");
            strcpy(nombre,p);
            printf("Codigo: %d, Nombre: %s\n",codigo, nombre);
        }
        
        if (codigo==0)
            terminar=1;
        else if (codigo==4)
            sprintf(respuesta,"%d",contador);
        else if (codigo==1)
            sprintf(respuesta,"%d",strlen(nombre));
        else if (codigo==2)
            if ((nombre[0]== 'M')||(nombre[0]=='S'))
                strcpy (respuesta,"SI");
            else
                strcpy(respuesta, "NO");
            else // quiere saber si es alto
            {
                p = strtok(NULL, "/ ");
                float altura = atof(p);
                if (altura > 1.70)
                    sprintf(respuesta, "%s: eres alto", nombre);
                else
                    sprintf(respuesta, "%s: eres bajo", nombre);
            }
            
            if (codigo != 0)
            {
                printf("Respuesta: %s\n", respuesta);
                // Enviamos respuesta
                write(sock_conn, respuesta, strlen(respuesta));
            }
            if ((codigo == 1) || (codigo == 2) || (codigo == 3))
            {
                pthread_mutex_lock(&mutex); // No me interrumpas ahora
                contador = contador + 1;
                pthread_mutex_unlock(&mutex); // ya puedes interrumpirme
            }
     }
     close(sock_conn);
}

int main() {
    int sock_escucha, sock_conn;
    struct sockaddr_in serv_addr, cliente_addr;
    socklen_t long_cliente;
    pthread_t hilo;

    // Inicializar contador
    contador = 0;

    // Crear socket de escucha
    sock_escucha = socket(AF_INET, SOCK_STREAM, 0);
    if (sock_escucha < 0) {
        perror("Error al crear socket");
        exit(1);
    }

    // Configurar dirección del servidor
    memset(&serv_addr, 0, sizeof(serv_addr));
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = INADDR_ANY;
    serv_addr.sin_port = htons(PUERTO);

    // Enlazar socket
    if (bind(sock_escucha, (struct sockaddr *)&serv_addr, sizeof(serv_addr)) < 0) {
        perror("Error en bind");
        exit(1);
    }

    // Escuchar conexiones
    listen(sock_escucha, MAX_CLIENTES);
    printf("Servidor iniciado en el puerto %d. Esperando conexiones...\n", PUERTO);

    // Bucle principal del servidor
    while (1) {
        long_cliente = sizeof(cliente_addr);
        
        // Aceptar nueva conexión
        sock_conn = accept(sock_escucha, (struct sockaddr *)&cliente_addr, &long_cliente);
        if (sock_conn < 0) {
            perror("Error en accept");
            continue;
        }

        printf("Nueva conexión aceptada de %s:%d\n", 
               inet_ntoa(cliente_addr.sin_addr), ntohs(cliente_addr.sin_port));

        // Crear hilo para atender al cliente
        int *sock_cliente = malloc(sizeof(int));
        *sock_cliente = sock_conn;
        
        if (pthread_create(&hilo, NULL, AtenderCliente, (void *)sock_cliente) != 0) {
            perror("Error al crear hilo");
            close(sock_conn);
            free(sock_cliente);
        }

        // Desvincular el hilo para que se limpie automáticamente al terminar
        pthread_detach(hilo);
    }

    // Cerrar socket de escucha (aunque en este código nunca se alcanza)
    close(sock_escucha);
    return 0;
}