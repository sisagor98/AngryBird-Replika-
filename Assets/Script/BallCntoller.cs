using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallCntoller : MonoBehaviour
{
    public Rigidbody2D hook;
    public float maxDragDistance = 2f;

    public float releageTime = .15f;
    public Rigidbody2D rigidbody;
    private bool isPressed = false;


   public GameObject Nextboll;

    private void Update() {

        if(isPressed){
            Vector2 mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos,hook.position) > maxDragDistance){
                rigidbody.position = hook.position + (mousePos -hook.position).normalized * maxDragDistance;
            }
            else{
                 rigidbody.position  = mousePos;
            }
        }
           
    }

    void OnMouseDown() {
        isPressed =true;
        rigidbody.isKinematic = true;
    }
    private void OnMouseUp() {

        isPressed = false;
        rigidbody.isKinematic = false;

        StartCoroutine(Release());
    }


    IEnumerator Release(){
        yield return new WaitForSeconds(releageTime);
        GetComponent<SpringJoint2D>().enabled = false ;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if(Nextboll != null){
            Nextboll.SetActive(true);
        }
        else{
            Enemy.EnemyCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
