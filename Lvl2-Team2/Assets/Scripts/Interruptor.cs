using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    bool boton = false;
    public Plataforma receptor;
    private bool jugadorEnTrigger = false;

    // Variables para el cambio de sprite
    public Sprite spriteActivado;    // Sprite cuando el interruptor est� ON
    public Sprite spriteDesactivado; // Sprite cuando el interruptor est� OFF
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer

    // Variable para el sonido
    public AudioClip sonidoBoton;    // Clip de audio que se reproducir� al presionar el bot�n
    private AudioSource audioSource; // Referencia al componente AudioSource

    private void Start()
    {
        // Obtener el componente SpriteRenderer al inicio
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Asegurarse de que el sprite inicial sea el desactivado
        if (spriteRenderer != null && spriteDesactivado != null)
        {
            spriteRenderer.sprite = spriteDesactivado;
        }

        // Obtener o a�adir el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTrigger = true;
            Debug.Log("Jugador entr� en el trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTrigger = false;
            Debug.Log("Jugador sali� del trigger");
        }
    }

    public void PrecionarBoton()
    {
        if (jugadorEnTrigger)
        {
            boton = !boton; // Alternar estado (ON/OFF)
            receptor.RecibirBooleano(boton);
            Debug.Log("Bot�n presionado correctamente");

            // Cambiar el sprite seg�n el estado del bot�n
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = boton ? spriteActivado : spriteDesactivado;
            }

            // Reproducir el sonido si existe el clip
            if (sonidoBoton != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoBoton);
            }
            else
            {
                Debug.LogWarning("No hay clip de audio asignado o no hay AudioSource");
            }
        }
        else
        {
            Debug.LogWarning("No se puede activar: El jugador no est� en el trigger");
        }
    }
}