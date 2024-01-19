using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform objetivo; // El personaje que la cámara seguirá
    public Vector3 offset = new Vector3(0, 2, -2); // Distancia entre la cámara y el jugador
    public float sensibilidad = 100f; // Sensibilidad del mouse

    private float xRotacion = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // La posición de la cámara será la posición del jugador más el offset
        transform.position = objetivo.position + offset;

        // Gira la cámara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -45f, 45f);

        transform.localRotation = Quaternion.Euler(xRotacion, 0f, 0f);
        objetivo.Rotate(Vector3.up * mouseX);
    }
}
