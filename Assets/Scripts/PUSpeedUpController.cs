using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision == ball) {
            //yg bisa mempercepat gerakan bola adalah bola itu sendiri
            ball.GetComponent<BallController>().ActivatePUSpeedUP(magnitude);
            //hapus gameObject itu sendiri
            manager.RemovePowerUp(gameObject);
        }
    }
}
