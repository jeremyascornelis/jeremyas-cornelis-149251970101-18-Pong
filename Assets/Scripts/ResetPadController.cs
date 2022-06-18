using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPadController : MonoBehaviour
{
    Vector3 resetScale;
    public float timer;

    private void Start() {
        resetScale = transform.localScale;
    }

    private void Update() {
        if(this.transform.localScale.y == 3.6f) {
            timer += Time.deltaTime;
            if(timer >= 5) {
                transform.localScale = resetScale;
                timer = 0;
            }
        }
    }
}
