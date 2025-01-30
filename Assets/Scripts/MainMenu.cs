using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : LevelLoader
{
    //Referencias al audio Mixel y al audio Source
    public AudioMixer audioMixer;
    public GameObject audioSource;

    public void Play()
    {
        //Al darle Play, suena y carga la siguiente escena
        PlayClickSound();
        LoadNextLevel();
    }

    public void Quit()
    {
        //Al darle Quit, suena y se quita el juego
        PlayClickSound();
        Application.Quit();
    }

    //Método para actualizar la música
    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    //Método para actualizar el sonido
    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    //Método para reproducir el sonido de click
    public void PlayClickSound()
    {
        audioSource.GetComponent<AudioSource>().Play();
    }
}
