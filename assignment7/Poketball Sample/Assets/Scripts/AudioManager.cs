using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting.FullSerializer;
using System.Threading;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}

    public static int count = 0;

    [SerializeField] EventReference BGTheme;
    [SerializeField] EventReference BallHitSFX;

    private void Awake() {
        if(instance != null) {
            Debug.LogError("AudioManager > 1 on scene!");
        }
        instance = this;
    }

    public void Start() {
        SoundLoop();
    }

    public void SoundLoop() {
        RuntimeManager.PlayOneShot(BGTheme);
    }

    public void BallHit(float SoundVol) {
        count += 1;
        if(count <= 6) RuntimeManager.PlayOneShot(BallHitSFX);
        count -= 1;
        
    }
}
