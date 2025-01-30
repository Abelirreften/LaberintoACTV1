using UnityEngine;
using UnityEditor;

public class RemoveComponentsEditor : MonoBehaviour
{
    [MenuItem("Tools/Remove All BoxColliders")]
    public static void RemoveAllBoxColliders()
    {
        // Encuentra todos los componentes del tipo especificado en la escena
        BoxCollider[] allBoxColliders = FindObjectsOfType<BoxCollider>();

        if (allBoxColliders.Length == 0)
        {
            Debug.Log("No se encontraron componentes BoxCollider en la escena.");
            return;
        }

        // Inicia la operación de edición
        Undo.RegisterCompleteObjectUndo(allBoxColliders, "Remove All BoxColliders");

        Debug.Log($"Se encontraron {allBoxColliders.Length} componentes BoxCollider. Procediendo a eliminarlos...");

        foreach (BoxCollider collider in allBoxColliders)
        {
            DestroyImmediate(collider);
            Debug.Log($"Componente BoxCollider eliminado del GameObject: {collider.gameObject.name}");
        }
    }
}
