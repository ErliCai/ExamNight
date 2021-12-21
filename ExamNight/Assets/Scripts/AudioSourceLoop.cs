using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSourceLoop : MonoBehaviour
{
    public AudioSource happySound;
    public AudioSource tenseSound;
    public static bool changeMusic = false;
    public static bool existed = false;
    public static float volume;

    void Awake()
    {
      // if (Follow.gameTime > 150){
      //   happySound.Play();
      // }
      // else{
      //   tenseSound.Play();
      // }
      if (!existed){
      
      
        happySound.Play();
      
        DontDestroyOnLoad(this.gameObject);
        existed = true;
      }
      else{
         Destroy(this.gameObject);
      }
      
    }


    // void Update(){
    //   if (Follow.gameTime < 150 & !changeMusic){
    //       happySound.Stop();
    //       tenseSound.Play();  
    //       changeMusic = true;    
    //   }
    // }

}