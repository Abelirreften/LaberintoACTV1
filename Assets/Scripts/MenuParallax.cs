using UnityEngine;

public class MouseParallaxEffect : MonoBehaviour
{

    //NO SE USA, CAMIBÉ EL PARALLAX EFFECT A LA CÁMARA Y NO A LOS OBJETOS (Script CameraMenuSmooth)

    public Transform[] layers; //Lista de los objetos 3D que se moverán para crear el efecto
    public float[] parallaxFactors; //Valor de parallax para cada capa
    public float smoothing = 5f; //Suavidad del movimiento

    private Vector3 previousMousePosition;

    void Start()
    {
        //Inicia con el ratón en el centro de la pantalla
        previousMousePosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    void Update()
    {
        //Calcula el movimiento del ratón desde la última posición registrada
        Vector3 mouseDelta = Input.mousePosition - previousMousePosition;

        //Aplica el movimiento del ratón a las capas
        for (int i = 0; i < layers.Length; i++)
        {
            //Calcula el desplazamiento basado en el valor de parallax
            Vector3 targetPosition = layers[i].position + new Vector3(mouseDelta.x * parallaxFactors[i], mouseDelta.y * parallaxFactors[i], 0);

            //Suaviza el movimiento
            layers[i].position = Vector3.Lerp(layers[i].position, targetPosition, smoothing * Time.deltaTime);
        }

        //Actualiza la posición previa del ratón
        previousMousePosition = Input.mousePosition;
    }
}