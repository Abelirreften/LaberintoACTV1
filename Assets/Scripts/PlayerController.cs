using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Controles para la sensibilidad del Player, el control de la cámara, el bloqueo del cursor y la velocidad.
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSens = 3.5f;
    [SerializeField] bool lockCursor = true;
    [SerializeField] float walkSpeed = 3.0f;

    // Control para la gravedad.
    [SerializeField] float gravity = -13.0f;

    // Un control para hacer el movimiento y la cámara más suaves.
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] bool smoothMovement = false;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.01f;
    [SerializeField] bool smoothCamera = false;

    // Anota la rotación actual de la cámara en el eje X.
    float cameraPitch = 0.0f;
    // Añadir la velocidad al componente "Character Controller", que también maneja el movimiento y las colisiones.
    CharacterController controller = null;
    // Anota la velocidad actual en Y.
    float velocityY = 0.0f;

    // Vectores que guardan la dirección y la velocidad actual.
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Si el cursor está bloqueado se centra en la pantalla y se hace invisible.
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    void Update()
    {
        // Actualizamos la posición del mouse y del personaje en cada frame.
   
        if (smoothCamera)
        {
            UpdateMouseLookSmooth();
        }
        else
        {
            UpdateMouseLook();
        }

        if (smoothMovement)
        {
            UpdateMovementSmooth();
        }
        else
        {
            UpdateMovement();
        }

    }

    void UpdateMouseLookSmooth()
    {
        // Obtenemos el input del ratón en ambos ejes.
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Suavizamos el movimiento de la cámara usando SmoothDamp
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, moveSmoothTime);

        //Invertimos con -= la rotación Delta para que la rotación del mouse y de la cámara tengan los mismos valores.
        cameraPitch -= currentMouseDelta.y * mouseSens;

        // Capamos la rotación de la cámara entre 90º y -90º para evitar que de la vuelta al mirar hacia arriba o abajo.
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        // Añadimos a la cámara los ángulos Euler Locales para que rote sobre el eje X
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        // Rotamos el Player según el movimiento de la cámara en el eje X
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSens);
    }

    void UpdateMouseLook()
    {
        // Obtenemos el input del ratón en ambos ejes.
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //Invertimos con -= la rotación Delta para que la rotación del mouse y de la cámara tengan los mismos valores.
        cameraPitch -= mouseDelta.y * mouseSens;

        // Capamos la rotación de la cámara entre 90º y -90º para evitar que de la vuelta al mirar hacia arriba o abajo.
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        // Añadimos a la cámara los ángulos Euler Locales para que rote sobre el eje X
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        // Rotamos el Player según el movimiento de la cámara en el eje X
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSens);
    }


    void UpdateMovementSmooth()
    {
        // Actualizamos el movimiento en ambos vectores.
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Normalizamos el vector diagonal para no ir más rápido en direcciones diagonales.
        targetDir.Normalize();

        // Usamos SmoothDamp para suavizar el movimiento.
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // Verificamos si el Player está en el suelo.
        if(controller.isGrounded)
        {
            velocityY = 0.0f;
        }
        velocityY += gravity * Time.deltaTime;

        // Añadimos un vector velocidad
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateMovement()
    {
        // Actualizamos el movimiento en ambos vectores.
        Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Normalizamos el vector diagonal para no ir más rápido en direcciones diagonales.
        inputDir.Normalize();

        // Verificamos si el Player está en el suelo.
        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }
        velocityY += gravity * Time.deltaTime;

        // Añadimos un vector velocidad
        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

}
