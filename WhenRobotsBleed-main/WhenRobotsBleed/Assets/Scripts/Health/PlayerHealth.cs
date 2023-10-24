using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] int currentHealth; 
    

    private bool dead;

    public GameObject player;
    public Transform respawnPoint; 
    
    [SerializeField]
    private AudioClip _hurtSound;
    private AudioSource _myAudioSource;

    void Awake()
    {
        currentHealth = maxHealth;
        _myAudioSource = GetComponent<AudioSource>();
    }
    //take dmg 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _myAudioSource.PlayOneShot(_hurtSound, 0.2F);
        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    //when player die
    private void Die()
    {
        Debug.Log("player died");
        player.transform.position = respawnPoint.position;
        //player play die anim 
        //disable controle temp 
        // respawn player to last check point 
        currentHealth = maxHealth; 
    }    
    
}
