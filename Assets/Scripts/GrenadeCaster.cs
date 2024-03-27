using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;

    public float force = 10;
    void Start()
    {

    }

    public float clickDelay = 2f; // Задержка между кликами
    private bool canClick = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canClick) 
        {
            StartCoroutine(ClickDelay());
            if (Input.GetMouseButtonDown(1))
            {
                var grenade = Instantiate(grenadePrefab);
                grenade.transform.position = grenadeSourceTransform.position;
                grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
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

    

