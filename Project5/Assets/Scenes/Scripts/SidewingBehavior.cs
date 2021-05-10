using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewingBehavior : MonoBehaviour
{
    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector3(Random.Range(screenbounds.x * -1, screenbounds.x), screenbounds.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.parent == null)
        {
            if (transform.position.y < screenbounds.y * -1)
            {
                Destroy(this.gameObject);
            }
            transform.Translate(-1 * transform.up * GameObject.Find("SystemController").GetComponent<SystemController>().sidewingDesentSpeed * Time.deltaTime, Space.World);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ship"))
        {
            GameObject.Find("Ship").GetComponent<ShipBehavior>().OnTriggerEnter(this.GetComponent<Collider>());
        }
    }
}
