using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;
    
    private List<GameObject> powerUpList;

    private float timer;

    private void Start() {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    //Mengatur dimana dia men-generate dirinya sendiri
    private void Update() {
        timer += Time.deltaTime;

        if(timer > spawnInterval) {
            if(powerUpList.Count == maxPowerUpAmount) {
                RemovePowerUp(powerUpList[0]);
            }
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp() {
        //posisi random
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position) {

        if(powerUpList.Count >= maxPowerUpAmount) {
            return;
        }

        //supaya tidak melebihi area
        if  (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y) {
                return; //tidak akan men-generate apapun
            }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        //membuat Game Object dari sebuah Game Object yang lain
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        //aktifkan Game Object sebelum digunakan
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp) {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    //maybe for error handling
    public void RemoveAllPowerUp() {
        while(powerUpList.Count > 0) {
            //hapus power up list pertama (diulang-ulang sampai habis)
            RemovePowerUp(powerUpList[0]);
        }
    }
}
