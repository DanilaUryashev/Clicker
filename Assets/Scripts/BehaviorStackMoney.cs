using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BehaviorStackMoney : MonoBehaviour
{
     Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, с чем мы столкнулись
        Debug.Log("Вошли в триггер с: " + other.gameObject.tag);
        if(other.gameObject.name== "TopCollider")
        {
            rigidbody.gravityScale = 1;
        }
        if (other.gameObject.tag == "Destroy")
        {
            Debug.Log("12321edwas " + other.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
 
}
