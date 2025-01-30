using UnityEngine;

public class CameraMouseFollow : MonoBehaviour
{
    public float sensitivity = 0.1f; //Sensiblidad del movimiento
    public float smoothing = 5f;    //Suavidad al moverse
    public Vector2 movementRange = new Vector2(2f, 2f); //Rango máximo de movimiento en X e Y

    private Vector3 initialPosition; //Vector que guarda la posición inicial de la cámara

    void Start()
    {
        //Guarda la posición inicial de la cámara
        initialPosition = transform.position;
    }

    void Update()
    {
        //Obtenemos la posición del ratón
        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;

        //Movemos la cámara basandonos en la sensiblidad y la posición
        Vector3 targetPosition = initialPosition + new Vector3(mouseX * movementRange.x, mouseY * movementRange.y, 0) * sensitivity;

        //Suavizamos el movimiento de la cámara
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
