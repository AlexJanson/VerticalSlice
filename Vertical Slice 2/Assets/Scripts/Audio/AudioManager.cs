using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip pigOink;

    [SerializeField]
    private AudioClip cowMoo;

    [SerializeField]
    private AudioSource AudioSource;

    private int MaxAmmoAmount;

    private int shootAmount = 30;

    private bool pigNoise = true;

    private bool cowNoise = true;

    private float pigNoiseCounter = 5.0f;

    private float cowNoiseCounter = 10.0f;

    private float timeForCounter;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PigSoundFunction();
        CowSoundFunction();
    }

    private void PigSoundFunction()
    {

        pigNoiseCounter += Time.deltaTime;
        if (pigNoise == true && !AudioSource.isPlaying)
        {
            pigNoise = false;
            timeForCounter = Random.Range(10.5f, 30.5f);
        }

        if (pigNoiseCounter >= timeForCounter && !AudioSource.isPlaying)
        {        
            AudioSource.PlayOneShot(pigOink, 1);
            pigNoise = true;
           pigNoiseCounter = 0;
           
        }

     
    }

    private void CowSoundFunction()
    {
        cowNoiseCounter += Time.deltaTime;
        if (cowNoise == true && !AudioSource.isPlaying)
        {
            cowNoise = false;
            timeForCounter = Random.Range(10.5f, 30.5f);
        }

        if (cowNoiseCounter >= timeForCounter && !AudioSource.isPlaying)
        {
            AudioSource.PlayOneShot(cowMoo, 1);
            cowNoise = true;
            cowNoiseCounter = 0;
        }
    }



}
