using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;
    public GameObject bullet;
    private bool canShoot = true;
    public float shootingRate = 1.0f;
    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        transform.position = new Vector2(target.x, target.y);
        if (Input.GetMouseButtonDown(0))
        {
            ShipShoot();
        }
    }
    private void ShipShoot() {
        if (!canShoot)
        {
            return;
        }
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.1f, this.transform.position.z);
        b.SetActive(true);
        StartCoroutine(ShootRate());
    }
    IEnumerator ShootRate() {
        canShoot = false;
        if (shootingRate < 0.1f)
        {
            shootingRate = 0.1f;
        }
        yield return new WaitForSeconds(shootingRate);
        canShoot = true;
    }
}
