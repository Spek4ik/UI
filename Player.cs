using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 10;
    public int maxHealth = 10;
    public GameObject fireballPrefab;
    public Transform attackPoint;
    public int coins;
    public AudioSource audioSource;
    public AudioClip damageSound;
    public TextMeshProUGUI coinText;

    //Метод, понижающий здоровье игрока
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health > 0)
        {
            audioSource.PlayOneShot(damageSound);
        }
        else
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, attackPoint.position, attackPoint.rotation);
        }
    }
    public void CollectCoins()
    {
        coins++;
        print("Собранные монетки: " + coins);
        coinText.text = coins + "";
    }
}
