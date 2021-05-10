using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    //public GameObject bullet;
    private bool canShoot = true;
    private bool canSpawn = true;
    public float shootingRate = 1.0f;
    public float objectSpawnRate = 1;
    public float enemyDesentSpeed = 2;
    public float sidewingDesentSpeed = 2;
    public float speedUpDesentSpeed = 2;
    public GameObject ship;
    public GameObject sideWing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShipShoot();
        }
        SpawnObject();
        
        
    }
    private void ShipShoot()
    {
        if (!canShoot)
        {
            return;
        }
        GameObject b = Pooler.Instance.Spawn("bullet") as GameObject;
        b.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y + 1.1f, ship.transform.position.z);
        foreach (Transform child in ship.transform)
        {
            Pooler.Instance.Spawn("bullet").transform.position = new Vector3(child.position.x, child.position.y + 1f, child.position.z);
        }
        StartCoroutine(ShootRate());
    }
    IEnumerator ShootRate()
    {
        canShoot = false;
        if (shootingRate < 0.1f)
        {
            shootingRate = 0.1f;
        }
        yield return new WaitForSeconds(shootingRate);
        canShoot = true;
    }
    private void SpawnObject()
    {
        
        if (canSpawn)
        {
            
            GameObject enemy = Pooler.Instance.Spawn("enemy") as GameObject;
            GameObject speedUp = Pooler.Instance.Spawn("SpeedUp") as GameObject;
            if (getChild() < 4)
            {
                Instantiate(sideWing);
            }
            
            StartCoroutine(ObjectSpawningRate());
        }
        
    }
    IEnumerator ObjectSpawningRate()
    {
        canSpawn = false;
        yield return new WaitForSeconds(objectSpawnRate);
        canSpawn = true;
    }
    public int getChild() {
        return ship.transform.childCount;
    }
    


}
