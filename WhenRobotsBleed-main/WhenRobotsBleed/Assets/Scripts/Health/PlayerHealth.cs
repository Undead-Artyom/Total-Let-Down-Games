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
    public Transform lastCheckPont;

    [SerializeField]
    private AudioClip _hurtSound;
    private AudioSource _myAudioSource;
    //for gameMenu
    public GameOverMenu gameOver;

    //healthbar
    public HealthBar healthBar;

    void Awake()
    {
        gameOver = FindAnyObjectByType<GameOverMenu>();
        healthBar = FindAnyObjectByType<HealthBar>();
        currentHealth = maxHealth;
        _myAudioSource = GetComponent<AudioSource>();
        lastCheckPont = GetComponent<Transform>();
        healthBar.SetMaxHealth(currentHealth);
        //pauseMenu = gameObject.GetComponent<PauseMenu>();  
    }
    //take dmg 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        _myAudioSource.PlayOneShot(_hurtSound, 0.8F);
        print("Current HP = " + currentHealth);
        if (currentHealth <= 0)
        {
            gameOver.GameOver();
        }
        
    }
    private void Update()
    {
        respawnPoint = lastCheckPont;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {

            lastCheckPont = other.transform;
            print(respawnPoint.name);
        }
    }

    //when player die
    private void Die()
    {
        
    }

    public void RespawnCheckPoint()
    {
        Debug.Log("player died");
        player.transform.position = respawnPoint.position;
        //player play die anim 
        //disable controle temp 
        // respawn player to last check point 
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        gameOver.GameOverStop();
    }

}
