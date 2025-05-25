using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    bool boton = false;
    public Plataforma receptor;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PrecionarBoton();
        }
    }
        public void PrecionarBoton()
    {
        boton = true;
        receptor.RecibirBooleano(boton);
    }
    

    }
