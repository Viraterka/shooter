using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour
{
    private int enemyCount = 0;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public GameObject gamewinscreen;

    void Start()
    {
        // Получаем всех объекты с тегом "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Считаем количество врагов
        enemyCount = enemies.Length;

        Debug.Log("Количество врагов на сцене: " + enemyCount);
    }

    private void Update()
    {
        // Получаем всех объекты с тегом "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Считаем количество врагов
        enemyCount = enemies.Length;

        Debug.Log("Количество врагов на сцене: " + enemyCount);
        if (enemyCount == 0)
        {
            gameplayUI.SetActive(false);
            gamewinscreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            AudioListener.volume = 0f;
        }

    }
}
