using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;


    private void Update()
    {
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
