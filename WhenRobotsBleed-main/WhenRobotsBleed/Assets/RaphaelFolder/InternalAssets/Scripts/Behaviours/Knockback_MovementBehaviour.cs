using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback_MovementBehaviour : MovementBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private int _kbForce; //350
    //private float _kbCounter;
    [SerializeField]
    private float _kbDur; //0.02f
    private bool _knockFromRight;

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector2 knockbackDir){
      float timer = 0;
      while(knockDur > timer){
          timer+=Time.deltaTime;
          rb.AddForce(new Vector2(knockbackDir.x * -100, knockbackDir.y * knockbackPwr));
      }
      yield return 0;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnEnable()
    {
        StartCoroutine(Knockback(_kbDur, _kbForce, transform.position));
    }

    void Update()
    {
        
    }
    
}
