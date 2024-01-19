using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f; // Fuerza del salto
    private Rigidbody rb; // Referencia al Rigidbody
    public Transform camara; // Referencia a la cámara

    void Start()
    {
        // Obtiene la referencia al Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal y vertical con WASD
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        // Calcula la dirección de movimiento basada en la rotación de la cámara
        Vector3 direccion = (camara.forward * movimientoVertical + camara.right * movimientoHorizontal).normalized;
        direccion.y = 0f; // Ignora la rotación de la cámara alrededor del eje X

        // Aplica la velocidad de movimiento
        rb.velocity = new Vector3(direccion.x * velocidad, rb.velocity.y, direccion.z * velocidad);

        // Controla el salto
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
        }
    }
}
