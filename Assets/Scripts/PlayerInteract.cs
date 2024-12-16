using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerInteract : MonoBehaviour
{
    //Asignamos la cámara principal y la distancia de interacción
    public Camera mainCam;
    public float interactionDistance = 2f;

    //Asignamos la UI y el texto
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;


    private void Update()
    {
        //Por cada frame lanzamos un ray
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable2 interactable2 = hit.collider.GetComponent<IInteractable2>();

            if (interactable2 != null) {
                hitSomething = true;
                interactionText.text = interactable2.getDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable2.interact();
                }
            }
        }

        interactionUI.SetActive(hitSomething);
    }
}
