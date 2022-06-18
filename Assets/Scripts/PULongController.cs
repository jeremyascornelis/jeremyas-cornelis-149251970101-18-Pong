using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongController : MonoBehaviour
{
    public PaddleController padelKanan;
    public PaddleController padelKiri;
    public PowerUpManager manager;
    public Collider2D ball;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision == ball) {
            padelKanan.ActivatePULong();
            padelKiri.ActivatePULong();
            manager.RemovePowerUp(gameObject);
        }
    }
}
