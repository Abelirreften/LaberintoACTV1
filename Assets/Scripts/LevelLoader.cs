using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    //Asignamos el objeto transición y el tiempo de la transición
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        /*
         Cargamos la escena añadiendo 1 al índice de escena.
         Así podemos ascender por las escenas sin tener que cargar cada escena por separado
         */
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Activamos la transición
        transition.SetTrigger("Start");

        //Esperamos el tiempo de la transición
        yield return new WaitForSeconds(transitionTime);

        //Cargamos la siguiente escena
        SceneManager.LoadScene(levelIndex);
    }

}
