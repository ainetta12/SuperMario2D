using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private AudioSource bgmSource;
    private AudioSource sfxSource;

    private void Awake() 
    {
        bgmSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("SFXManager").GetComponent<AudioSource>();
    }
    
    public void Play() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }

    public void MusicVolume(float value)
    {
        bgmSource.volume = value;
    }
     
    public void SFXVolume(float value)
    {
        sfxSource.volume = value;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
   
}
