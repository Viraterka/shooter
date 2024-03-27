using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
    
{
    public float value = 100;
    public float Enemies = 0f;
    public GameObject gamewinscreen;
    public GameObject gameplayUI;

    public void DealDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            Enemies += 1f;
            Destroy(gameObject);
            
        }
    }

    private void GameWinScreen()
    {
        if (Enemies == 5)
        {
            gameplayUI.SetActive(false);
            gamewinscreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        GameWinScreen();
    }
   
}
