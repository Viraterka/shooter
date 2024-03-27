using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granatesoundwhenclick : MonoBehaviour
{
    public AudioClip soundToPlay;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public float clickDelay = 2f; // Задержка между кликами
    private bool canClick = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canClick) 
        { 
            StartCoroutine(ClickDelay());
            if (Input.GetMouseButtonDown(1)) // Правая кнопка мыши
            {
                PlaySound();
            }
        }
    }

    IEnumerator ClickDelay()
    {
        canClick = false;
        yield return new WaitForSeconds(clickDelay);
        canClick = true;
    }



    void PlaySound()
    {
        audioSource.PlayOneShot(soundToPlay);
    }
}
