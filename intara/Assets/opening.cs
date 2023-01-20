using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour
{
    OscJackServerSample osj;
    public GameObject p1,
        p2,
        p1tex,
        p2tex,
        set1p,
        set2p,
        p1ani,
        p2ani,
        cam;
    public bool playstart = false,
        camcam = false;
    Animator anim1,
        anim2;
    private float waittime;
    public float posx,
        posz;
    public Transform tp1,
        tp2;

    public Vector3 pos;
    public float currenttime = 0f,
        camx = 3f,
        camy = 2f,
        camz = 3f,
        speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        osj = GetComponent<OscJackServerSample>();
        osj.enabled = playstart;
        p1 = GameObject.FindWithTag("1p_right");
        p2 = GameObject.FindWithTag("2p_left");
        p1ani = GameObject.FindWithTag("1panim");
        p2ani = GameObject.FindWithTag("2panim");
        // p1tex=GameObject.FindWithTag("1ptext");
        // p2tex=GameObject.FindWithTag("2ptext");
        set1p = GameObject.FindWithTag("set1p");
        set2p = GameObject.FindWithTag("set2p");
        cam = GameObject.FindWithTag("MainCamera");
        p2tex.SetActive(false);
        p1tex.SetActive(false);
        set2p.SetActive(false);
        anim1 = p1ani.GetComponent<Animator>();
        anim2 = p2ani.GetComponent<Animator>();
        waittime = 6f;
        p1.SetActive(false);
        p2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (camcam == true)
        {
            currenttime += Time.deltaTime;
            if (currenttime > 2f)
            {
                Debug.Log("cange");
                camx = Random.Range(2f, 5f);
                camy = Random.Range(2f, 4f);
                camz = Random.Range(2f, 5f);
                speed = Random.Range(0.2f, 1f);
                currenttime = 0f;
            }
            cam.transform.position = new Vector3(
                camx * Mathf.Sin(Time.time * speed),
                camy,
                camz * Mathf.Cos(Time.time * speed)
            );
            cam.transform.LookAt(new Vector3(0f, 1f, 0f));
        }
        else
        {
            posx = 4f * Mathf.Sin(Time.time * 1 / 3f);
            posz = 4f * Mathf.Cos(Time.time * 1 / 3f);
            pos = new Vector3(posx, 2f, posz);
        }
    }

    public void OK1P()
    {
        StartCoroutine("p1setting");
    }

    public void OK2P()
    {
        StartCoroutine("p2setting");
    }

    IEnumerator ready()
    {
        yield return new WaitForSeconds(1.5f);
        anim1.SetBool("IsReady", true);
        anim2.SetBool("IsReady", true);
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(waittime);
        anim1.SetBool("IsStart", true);
        anim2.SetBool("IsStart", true);
        playstart = true;
        osj.enabled = playstart;
    }

    IEnumerator p1setting()
    {
        p1.SetActive(true);
        anim1.SetBool("IsSet", true);
        set1p.SetActive(false);
        //posx = 2f * Mathf.Sin(Time.time * 1 / 3f);
        //posz = 2f * Mathf.Cos(Time.time * 1 / 3f);
        cam.transform.position = pos;
        cam.transform.LookAt(tp1);
        yield return 3f;
        set2p.SetActive(true);
    }

    IEnumerator p2setting()
    {
        p2.SetActive(true);
        set2p.SetActive(false);
        anim2.SetBool("IsSet", true);
        //posx = 4f * Mathf.Sin(Time.time * 1 / 3f);
        //posz = 4f * Mathf.Cos(Time.time * 1 / 3f);
        cam.transform.position = pos;
        cam.transform.LookAt(tp2);
        yield return 3.5f;
        StartCoroutine("ready");
        StartCoroutine("start");
        yield return 4f;
        camcam = true;
    }
}
