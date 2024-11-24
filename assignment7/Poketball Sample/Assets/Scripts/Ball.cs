using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager GM;
    AudioManager MyAM;
    
    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        MyAM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


    void OnCollisionEnter(Collision col) {
        //Debug.Log("pf");



        if(col.gameObject.tag == "Ball") {
            float soundVol = Vector3.Magnitude(col.impulse);
            if(soundVol >= 10) {
                soundVol = 10f;
            }
            UnityEngine.Debug.Log(soundVol);
            MyAM.BallHit(soundVol);
        }
    }

    void OnTriggerExit(Collider col)
    {
        // When ball falls through Hole
        if (col.gameObject.tag == "Hole" && transform.position.y < -1f)
        {
            
            GM.Fall(gameObject.name);
            MyAM.BallHit(1);
            Destroy(gameObject);
        }
        
    }
}
