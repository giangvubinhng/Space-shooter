using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private Vector2 screenbounds;
    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > screenbounds.y) {
            Pooler.Instance.destroyObject(this.gameObject, "bullet");
        }
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

}
