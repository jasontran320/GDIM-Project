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
    [SerializeField]
    private Animator anim;
    private float tempspeed;

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
            Respawn();
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        anim.SetTrigger("Hurt");
        AudioManager.instance.Play("Hurt");
    }

    private void Respawn()
    {
        currentHealth = maxHealth;
        this.transform.position = respawn.position;
        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        AudioManager.instance.Play("Death");
        float tempspeed = this.gameObject.GetComponent<PlayerMovement>().speed;
        this.gameObject.GetComponent<PlayerMovement>().speed = 0;
        anim.SetBool("isDead", true);
        this.gameObject.tag = "Invincible";
        yield return new WaitForSeconds(invincibilityLength);
        anim.SetBool("isDead", false);
        this.gameObject.tag = "Player";
        this.gameObject.GetComponent<PlayerMovement>().speed = tempspeed;
        AudioManager.instance.Play("Spawn");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Death")
        {
            Respawn();
            StartCoroutine(Invincibility());
        }

        if(other.tag == "Checkpoint")
        {
            respawn = other.transform;
        }
    }
}