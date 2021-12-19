using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSourceLoop : MonoBehaviour
{
    public AudioSource happySound;
    public AudioSource tenseSound;

    void Start()
    {
      if (Follow.gameTime > 150){
        happySound.Play();
      }
      else{
        tenseSound.Play();
      }
    }

}