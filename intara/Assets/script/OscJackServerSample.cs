using UnityEngine;
using OscJack;
using System.Collections;
using System.Collections.Generic;

public class OscJackServerSample : MonoBehaviour
{
    public string scene;
    private int figure1,figure2;
    public float v1,
        v2,
        v3,
        v4,
        v5,
        v6,
        v7,
        v8,
        v9,
        v10,
        v11,
        v12,
        v13,
        v14,
        v15,
        v16,
        v17,
        v18,
        v19,
        v20,
        v21;
    public float l1,
        l2,
        l3,
        l4,
        l5,
        l6,
        l7,
        l8,
        l9,
        l10,
        l11,
        l12,
        l13,
        l14,
        l15,
        l16,
        l17,
        l18,
        l19,
        l20,
        l21;
    public float xbalanceR,
        ybalanceR,
        xbalanceL,
        ybalanceL,
        moveb,
        p1pos,
        p2pos;
    public GameObject p1,
        p2,
        p1tex,
        p2tex,
        p1ani,
        p2ani,
        cam,
        top;
    Animator anim1,
        anim2;

    [SerializeField]
    int port = 1111;
    OscServer server;

    Transform t1p,t2p;
    opening op;
    private bool p1w,p2w;
    public AudioClip p11,p12,p13,p21,p22,p23;
    AudioSource audio;

    void Start()
    {
        audio=GetComponent<AudioSource>();
        xbalanceR = 0.02f;
        ybalanceR = 0.2f;
        xbalanceL = 0.015f;
        ybalanceL = 0.11f;
        moveb = 50f;
        p1 = GameObject.FindWithTag("1p_right");
        p2 = GameObject.FindWithTag("2p_left");
        p1ani = GameObject.FindWithTag("1panim");
        p2ani = GameObject.FindWithTag("2panim");
        p1tex = GameObject.FindWithTag("1ptext");
        p2tex = GameObject.FindWithTag("2ptext");
        cam=GameObject.FindWithTag("MainCamera");
        top=GameObject.FindWithTag("top");
        p2tex.SetActive(false);
        p1tex.SetActive(false);
        top.SetActive(false);
        anim1 = p1ani.GetComponent<Animator>();
        anim2 = p2ani.GetComponent<Animator>();
        op=this.GetComponent<opening>();
        p1w=false;
        p2w=false;
        figure1=0;
        figure2=0;
    }

    void OnEnable()
    {
        server = new OscServer(port);
        server.MessageDispatcher.AddCallback(
            "/RIGHT/sensorValues",
            (string address, OscDataHandle data) =>
            {
                /* var stringValue = data.GetElementAsString(0);
                 var floatValue = data.GetElementAsFloat(1);
                 var intValue = data.GetElementAsFloat(2);
                 Debug.Log($"OscJack receive: {address} {stringValue} {floatValue} {intValue}");*/

                // v1 = data.GetElementAsFloat(0);
                // v2 = data.GetElementAsFloat(1);
                // v3 = data.GetElementAsFloat(2);
                // v4 = data.GetElementAsFloat(3);
                v5 = data.GetElementAsFloat(4);
                v6 = data.GetElementAsFloat(5);
                v7 = data.GetElementAsFloat(6);
                // v8 = data.GetElementAsFloat(7);
                // v9 = data.GetElementAsFloat(8);
                // v10 = data.GetElementAsFloat(9);
                // v11 = data.GetElementAsFloat(10);
                // v12 = data.GetElementAsFloat(11);
                // v13 = data.GetElementAsFloat(12);
                // v14 = data.GetElementAsFloat(13);
                // v15 = data.GetElementAsFloat(14);
                // v16 = data.GetElementAsFloat(15);
                // v17 = data.GetElementAsFloat(16);
                // v18 = data.GetElementAsFloat(17);
                // v19 = data.GetElementAsFloat(18);
                // v20 = data.GetElementAsFloat(19);
                // v21 = data.GetElementAsFloat(20);
            }
        );

        server.MessageDispatcher.AddCallback(
            "/LEFT/sensorValues",
            (string address, OscDataHandle data) =>
            {
                /* var stringValue = data.GetElementAsString(0);
                 var floatValue = data.GetElementAsFloat(1);
                 var intValue = data.GetElementAsFloat(2);
                 Debug.Log($"OscJack receive: {address} {stringValue} {floatValue} {intValue}");*/

                // l1 = data.GetElementAsFloat(0);
                // l2 = data.GetElementAsFloat(1);
                // l3 = data.GetElementAsFloat(2);
                // l4 = data.GetElementAsFloat(3);
                l5 = data.GetElementAsFloat(4);
                l6 = data.GetElementAsFloat(5);
                l7 = data.GetElementAsFloat(6);
                // l8 = data.GetElementAsFloat(7);
                // l9 = data.GetElementAsFloat(8);
                // l10 = data.GetElementAsFloat(9);
                // l11 = data.GetElementAsFloat(10);
                // l12 = data.GetElementAsFloat(11);
                // l13 = data.GetElementAsFloat(12);
                // l14 = data.GetElementAsFloat(13);
                // l15 = data.GetElementAsFloat(14);
                // l16 = data.GetElementAsFloat(15);
                // l17 = data.GetElementAsFloat(16);
                // l18 = data.GetElementAsFloat(17);
                // l19 = data.GetElementAsFloat(18);
                // l20 = data.GetElementAsFloat(19);
                // l21 = data.GetElementAsFloat(20);
            }
        );
    }

    void OnDisable()
    {
        server.Dispose();
        server = null;
    }

    void Update()
    {
        //RIGHT 1p
        float v16a = (v16 - xbalanceR);
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 rot = new Vector3(0, 0, 0);
        //rot.x=-90f;
        rot.y = -v7;
        if ((Mathf.Abs(v5) < 3f && Mathf.Abs(v6) < 90f || Mathf.Abs(v5) < 26f && Mathf.Abs(v6) > 90f)&&p1w==false)
        {
            Debug.Log("2pwin");
            // p2tex.SetActive(true);
            //StartCoroutine("win2p");
            p2w=true;
            figure2++;
            if(figure2==1){
                StartCoroutine("win2p");
            }
        }
        if (Mathf.Abs(v5) < 3f)
        {
            pos.y = 2f;
            if (v6 < -70f)
            {
                //rot.z=90f;
                anim1.SetBool("left", true);
            }
            else if (v6 > 70f)
            {
                //rot.z=-90f;
                anim1.SetBool("right", true);
            }
            else if (Mathf.Abs(v6) < 5f)
            {
                //rot.x=-90f;
                anim1.SetBool("front", true);
            }
        }
        else
            rot.z = transform.eulerAngles.z;

        if (Mathf.Abs(v5) < 30f && Mathf.Abs(v5) > 5f)
        {
            // pos.y=2f;
            //rot.x=90f;
            anim1.SetBool("back", true);
        }


        //LEFT 2p

        float l16a = (l16 - xbalanceL);
        Vector3 pos2 = new Vector3(0, 0, 0);
        Vector3 rot2 = new Vector3(0, 0, 0);
        //rot.x=-90f;
        rot2.y = -l7;
        if ((Mathf.Abs(l5) < 3f && Mathf.Abs(l6) < 90f || Mathf.Abs(l5) < 26f && Mathf.Abs(l6) > 90f)&&p2w==false)
        {
            Debug.Log("1pwin");
            //p1tex.SetActive(true);
            //StartCoroutine("win1p");
            p1w=true;
            figure1++;
            if(figure1==1){
                StartCoroutine("win1p");
            }
        }
        if (Mathf.Abs(l5) < 3f)
        {
            pos2.y = 2f;
            if (l6 < -70f)
            {
                //rot2.z = 90f;
                anim2.SetBool("left", true);
            }
            else if (l6 > 70f)
            {
                //rot2.z = -90f;
                anim2.SetBool("right", true);
            }
            else if (Mathf.Abs(l6) < 5f)
            {
                //rot2.x = -90f;
                anim2.SetBool("back", true);
            }
        }
        else
            rot2.z = transform.eulerAngles.z;

        if (Mathf.Abs(l5) < 30f && Mathf.Abs(l5) > 5f)
        {
            // pos2.y = 2f;
            // rot2.x = 90f;
            anim2.SetBool("front", true);
        }
    }

    IEnumerator win1p(){
        Time.timeScale = 0.5f;
        audio.PlayOneShot(p22);
        yield return new WaitForSeconds (3f);
        Time.timeScale = 1f;
        op.camcam=false;
        p2.SetActive(false);
        op.enabled=false;
        cam.transform.position=new Vector3(0f,1.2f,2f);
        cam.transform.eulerAngles=new Vector3(12f,-180f,0f);
        //op.cam.transform.LookAt(t1p);
        anim1.SetBool("IsWin",true);
        audio.PlayOneShot(p13);
        p1tex.SetActive(true);
        yield return new WaitForSeconds(2f);
        top.SetActive(true);
        yield break;

    }
    IEnumerator win2p(){
        Time.timeScale = 0.5f;
        audio.PlayOneShot(p12);
        yield return new WaitForSeconds (3f);
        Time.timeScale = 1f;
        op.camcam=false;
        p1.SetActive(false);
        op.enabled=false;
        cam.transform.position=new Vector3(0f,1.2f,-2f);
        cam.transform.eulerAngles= new Vector3(12f,0f,0f);
        //op.cam.transform.LookAt(t2p);
        anim2.SetBool("IsWin",true);
        audio.PlayOneShot(p23);
        p2tex.SetActive(true);
        yield return new WaitForSeconds(2f);
        top.SetActive(true);
        yield break;

    }

    public void ss()
    {
        Initiate.Fade(scene, Color.black, 1.0f);
    }
}
