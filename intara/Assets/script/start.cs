using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public string scene;

    public AudioClip bgm=null;
    AudioSource audio;

    // Start is called before the first frame update
    void Start() {
        audio=GetComponent<AudioSource>();
     }

    // Update is called once per frame
    void Update() { }

    public void ss()
    {
        audio.PlayOneShot(bgm);
        Initiate.Fade(scene, Color.black, 1.0f);
    }
}
