using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float velocidad = 2f; // Velocidad de movimiento
    [SerializeField] private float distancia = 3f; // Distancia de movimiento
    [SerializeField] private float tiempoEspera = 1f; // Tiempo entre cambios de dirección

    private Vector3 posicionInicial;
   // private bool moviendoDerecha = false;
    private bool movimientoActivado = false;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    public void RecibirBooleano(bool valor)
    {
        Debug.Log("Booleano recibido: " + valor);
        if (valor == true && !movimientoActivado)
        {
            movimientoActivado = true;
            StartCoroutine(MoverPlataforma());
        }
    }

    IEnumerator MoverPlataforma()
    {
        while (movimientoActivado)
        {
            // Calcular destinos
            Vector3 destinoIzquierda = posicionInicial + Vector3.left * distancia;
            Vector3 destinoDerecha = posicionInicial + Vector3.right * distancia;

            // Mover a la izquierda
            while (Vector3.Distance(transform.position, destinoIzquierda) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinoIzquierda, velocidad * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(tiempoEspera);

            // Mover a la derecha
            while (Vector3.Distance(transform.position, destinoDerecha) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinoDerecha, velocidad * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(tiempoEspera);

            // Volver al centro (opcional)
            while (Vector3.Distance(transform.position, posicionInicial) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
