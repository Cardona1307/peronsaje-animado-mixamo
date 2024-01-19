using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform objetivo; // El personaje que la c�mara seguir�
    public Vector3 offset = new Vector3(0, 2, -2); // Distancia entre la c�mara y el jugador
    public float sensibilidad = 100f; // Sensibilidad del mouse

    private float xRotacion = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // La posici�n de la c�mara ser� la posici�n del jugador m�s el offset
        transform.position = objetivo.position + offset;

        // Gira la c�mara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -45f, 45f);

        transform.localRotation = Quaternion.Euler(xRotacion, 0f, 0f);
        objetivo.Rotate(Vector3.up * mouseX);
    }
}
