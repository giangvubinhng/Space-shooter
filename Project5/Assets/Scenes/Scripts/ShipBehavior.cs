using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;
    public GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        transform.position = new Vector2(target.x, target.y);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(GameObject.Find("SystemController").GetComponent<SystemController>().getChild() < 4)
        {
            if (other.CompareTag("sidewing"))
            {
                
                other.transform.parent = this.transform;
                if (GameObject.Find("SystemController").GetComponent<SystemController>().getChild() == 1)
                {
                    other.transform.position = new Vector3(transform.position.x + 1.3f, transform.position.y - 1f, transform.position.z);
                }
                else if (GameObject.Find("SystemController").GetComponent<SystemController>().getChild() == 2)
                {
                    other.transform.position = new Vector3(transform.position.x - 1.3f, transform.position.y - 1f, transform.position.z);
                }
                else if (GameObject.Find("SystemController").GetComponent<SystemController>().getChild() == 3)
                {
                    other.transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y - 1f, transform.position.z);
                }
                else if (GameObject.Find("SystemController").GetComponent<SystemController>().getChild() == 4)
                {
                    other.transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y - 1f, transform.position.z);
                }
                other.gameObject.tag = "ship";
            }
        }
    }
}
