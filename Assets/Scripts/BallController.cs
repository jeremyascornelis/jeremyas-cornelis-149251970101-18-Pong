using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    private Rigidbody2D rig;
    
    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    public void ResetBall() {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = speed;
    }

    public void ActivatePUSpeedUp(float magnitude){
        rig.velocity *= magnitude;
    }

    // Update is called once per frame
    // void Update()
    // {   
         //Time.deltaTime => waktu yg dibutuhkan untuk pergerakan satu frame
        //transform.position = transform.position + (new Vector3(1f, 0, 0) * Time.deltaTime);
        //pada transform ada fungsi untuk menggerakan karakter
        
    // }

    
}
