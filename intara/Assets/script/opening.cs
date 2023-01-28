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
        cam,
        hakke,
        noko;
    public bool playstart,
        camcam;
    Animator anim1,
        anim2;
    private float waittime;
    public float posx,posy,
        posz;
    public Transform tp1,
        tp2;

    public Vector3 pos;
    public float currenttime = 0f,
        camx = 3f,
        camy = 2f,
        camz = 3f,
        speed = 1f;

        public AudioClip p11,p12,p13,p21,p22,p23,st;
        AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio=GetComponent<AudioSource>();
        playstart=false;
        camcam=false;
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
        hakke=GameObject.FindWithTag("hakke");
        noko=GameObject.FindWithTag("noko");
        cam = GameObject.FindWithTag("MainCamera");
        p2tex.SetActive(false);
        p1tex.SetActive(false);
        set2p.SetActive(false);
        hakke.SetActive(false);
        noko.SetActive(false);
        anim1 = p1ani.GetComponent<Animator>();
        anim2 = p2ani.GetComponent<Animator>();
        waittime = 6f;
        p1.SetActive(false);
        p2.SetActive(false);
        //pos=(0f,0f,0f);
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
        pos.x=5f;
        pos.y=1.8f;
        cam.transform.position = pos;
        cam.transform.LookAt(tp1);
        audio.PlayOneShot(p11);
        yield return new WaitForSeconds(3f);
        set2p.SetActive(true);
    }

    IEnumerator p2setting()
    {
        p2.SetActive(true);
        set2p.SetActive(false);
        anim2.SetBool("IsSet", true);
        //posx = 4f * Mathf.Sin(Time.time * 1 / 3f);
        //posz = 4f * Mathf.Cos(Time.time * 1 / 3f);
        pos.y=1.8f;
        cam.transform.position = pos;
        cam.transform.LookAt(tp2);
        audio.PlayOneShot(p21);
        yield return new WaitForSeconds(3.5f);
        cam.transform.position = new Vector3(2.58f,3.76f,-0.12f);
        cam.transform.localEulerAngles = new Vector3(49f,-90f,0f);
        hakke.SetActive(true);
        StartCoroutine("ready");
        StartCoroutine("start");
        yield return new WaitForSeconds(5.5f);
        hakke.SetActive(false);
        noko.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        noko.SetActive(false);
        audio.PlayOneShot(st);
        camcam = true;
    }
}
