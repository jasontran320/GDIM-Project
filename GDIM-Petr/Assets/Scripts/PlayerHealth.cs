using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth, invincibilityLength;
    [SerializeField]
    private Transform respawn;
    [SerializeField]
    private Slider slider;
   // private Animator anim;

    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        if(currentHealth <= 0)
        {
            return;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    private void Respawn()
    {
        //stop movement
        currentHealth = maxHealth;
        this.transform.position = respawn.position;
        StartCoroutine(Invincibility());
        
    }

    private IEnumerator Invincibility()
    {
        //play blinking here
        //change tag to invincible ****Make sure that the enemies can only dmg the player if they are on the "Player" tag****
        yield return new WaitForSeconds(invincibilityLength);
        //stop blinking here
        //change tag back to player
    }
}