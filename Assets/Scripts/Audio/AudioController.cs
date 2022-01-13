using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {
  public AudioMixer mixer;
  public Slider sliderMusic;
  public Slider sliderSFX;


  void Start() {

    sliderMusic.value = PlayerPrefs.GetFloat("MusicVol", 0.75f);
    sliderSFX.value = PlayerPrefs.GetFloat("SFXVol", 0.75f);
  }

  public void SetVolume(float sliderValue) {
    //Set nilai slider ke nilai logaritma
    mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    //Menyimpan nilai slider setiap kali di ubah    
    PlayerPrefs.SetFloat("MusicVol", sliderValue);


  }
  public void SetVolumeSFX(float sliderValue) {
    //Set nilai slider ke nilai logaritma
    mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    //Menyimpan nilai slider setiap kali di ubah    
    PlayerPrefs.SetFloat("SFXVol", sliderValue);
  }
}
