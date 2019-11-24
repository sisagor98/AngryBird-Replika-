using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SecneManager;

public class Enemy : MonoBehaviour
{
    public float health= 4f;

     public static int EnemyCount= 0;

    private void Start() {
        EnemyCount++;
    }
     private void OnCollisionEnter2D(Collision2D other) {

         //Debug.Log(other.relativeVelocity.magnitude);

          if(other.relativeVelocity.magnitude > health ){
              Die();
          }
            
     }

     void Die(){
         EnemyCount--;
         if(EnemyCount<=0)
         {
             Debug.Log("Level win");
         }
         Destroy(this.gameObject);
     }

}
