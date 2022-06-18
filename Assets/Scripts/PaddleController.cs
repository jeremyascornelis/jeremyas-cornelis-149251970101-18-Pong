using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public BallController ball;
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    public GameObject padel;
    Vector3 padelScale;
    Vector3 resetScale;
    public float timer;

    private Rigidbody2D rig;
    
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        resetScale = padel.transform.localScale;
    }
 
    private void Update()
    {   
        //ambil input
        Vector2 movement = GetInput();
        //gerakan object dengan input
        MoveObject(movement);
        padelScale = padel.transform.localScale;

        if(speed != 5) {
            timer += Time.deltaTime;
            if(timer >= 5) {
                speed /= 2;
                timer = 0;
            }
        }
    }

    public void resetPad() {
        speed = 5;
        padel.transform.localScale = resetScale;
    }

    private Vector2 GetInput() {

        if(Input.GetKey(upKey)) {
            //gerakan ke atas
            return Vector2.up * speed;
        }
        else if(Input.GetKey(downKey)) {
            //gerakan ke bawah
            return Vector2.down * speed;
        }
        Debug.Log("Paddle Speed: " + speed);
        return Vector2.zero;
        
    }

    private void MoveObject(Vector2 movement) {
        
        rig.velocity = movement;
    }

    public void ActivatePULong() {
        if(padelScale.y < 2.5) {
            padelScale.y *= 2;
            padel.transform.localScale = padelScale;
        }
    }

    public void ActivatePUSpeed() {
        if(speed <= 8) {
            speed *= 2;
        }
    }
}
