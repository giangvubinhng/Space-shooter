using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBehavior : MonoBehaviour, IObjects
{
    // Start is called before the first frame update
    private Vector2 screenbounds;
    public void OnObjectSpawn()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector3(Random.Range(screenbounds.x * -1, screenbounds.x), screenbounds.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < screenbounds.y * -1)
        {
            Pooler.Instance.destroyObject(this.gameObject, "SpeedUp");
        }
        transform.Translate(-1 * transform.up * GameObject.Find("SystemController").GetComponent<SystemController>().speedUpDesentSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ship"))
        {
            Pooler.Instance.destroyObject(this.gameObject, "SpeedUp");
            GameObject.Find("SystemController").GetComponent<SystemController>().shootingRate -= 0.1f;
            if (GameObject.Find("SystemController").GetComponent<SystemController>().shootingRate < 0.1f)
            {
                GameObject.Find("SystemController").GetComponent<SystemController>().shootingRate = 0.1f;
            }
        }

    }
}
