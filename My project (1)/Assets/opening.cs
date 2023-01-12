using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour
{
    OscJackServerSample osj;
        public GameObject p1,p2,p1tex,p2tex,set1p,set2p;
        public bool playstart=false;


    // Start is called before the first frame update
    void Start()
    {
        osj=GetComponent<OscJackServerSample>();
        osj.enabled=playstart;  
        p1=GameObject.FindWithTag("1p_right");
        p2=GameObject.FindWithTag("2p_left");
        // p1tex=GameObject.FindWithTag("1ptext");
        // p2tex=GameObject.FindWithTag("2ptext");
        set1p=GameObject.FindWithTag("set1p");
        set2p=GameObject.FindWithTag("set2p");
        p2tex.SetActive(false);
        p1tex.SetActive(false);  
        set2p.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OK1P(){
        set1p.SetActive(false);
        set2p.SetActive(true);
    }

    public void OK2P(){
        set2p.SetActive(false);
    }
}
