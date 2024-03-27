using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    public AudioSource fireballSound;
    void Start()
    {
        
    }
    public float clickDelay = 1f; // Задержка между кликами
    private bool canClick = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick) // Левая кнопка мыши
        {
            StartCoroutine(ClickDelay());
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            }
        }
    }
    IEnumerator ClickDelay()
    {
        canClick = false;
        yield return new WaitForSeconds(clickDelay);
        canClick = true;
    }
}
