using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform obj;

    private float cx,
        cz;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        cx = 6f * Mathf.Sin(Time.time * 0.3f);
        cz = 6f * Mathf.Cos(Time.time * 0.3f);
        Vector3 pos = new Vector3(cx, 1f, cz);
        transform.position = pos;
        transform.LookAt(obj);
    }
}
