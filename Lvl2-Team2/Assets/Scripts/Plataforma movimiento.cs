using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [Header("Configuración Movimiento")]
    [SerializeField] private float velocidad = 2f;       // Velocidad de movimiento
    [SerializeField] private float distancia = 5f;       // Distancia máxima de movimiento
    [SerializeField] private bool empezarDerecha = true; // Dirección inicial

    private Vector3 puntoInicial;
    private Vector3 puntoFinal;
    private bool moviendoADerecha;

    void Start()
    {
        // Guardar posición inicial
        puntoInicial = transform.position;

        // Calcular punto final (derecha o izquierda según configuración)
        if (empezarDerecha)
        {
            puntoFinal = puntoInicial + Vector3.right * distancia;
            moviendoADerecha = true;
        }
        else
        {
            puntoFinal = puntoInicial + Vector3.left * distancia;
            moviendoADerecha = false;
        }
    }

    void Update()
    {
        // Mover la plataforma
        if (moviendoADerecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidad * Time.deltaTime);

            // Cambiar dirección si llega al punto final
            if (transform.position == puntoFinal)
            {
                moviendoADerecha = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoInicial, velocidad * Time.deltaTime);

            // Cambiar dirección si llega al punto inicial
            if (transform.position == puntoInicial)
            {
                moviendoADerecha = true;
            }
        }
    }

    // Dibujar Gizmos en el Editor para visualizar los puntos de movimiento
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * distancia);
            Gizmos.DrawWireSphere(transform.position + Vector3.right * distancia, 0.5f);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(puntoInicial, puntoFinal);
            Gizmos.DrawWireSphere(puntoInicial, 0.5f);
            Gizmos.DrawWireSphere(puntoFinal, 0.5f);
        }
    }
}