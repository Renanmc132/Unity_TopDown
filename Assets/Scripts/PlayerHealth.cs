using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private int currentHealth;
    private int maxHealth = 3;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Image[] hearts;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++) 
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


}
