using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firesoundwhenclick : MonoBehaviour
{
    public AudioClip soundToPlay;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public float clickDelay = 1f; // Задержка между кликами
    private bool canClick = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick) // Левая кнопка мыши
        {
            StartCoroutine(ClickDelay());
            if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
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
