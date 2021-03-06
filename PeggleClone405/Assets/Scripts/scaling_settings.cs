﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that saves the variables between game scenes so that rewards can be scaled
public class scaling_settings : MonoBehaviour {

    public float slow_mo_scale = 0.1f;
    public float explosion_size = 1.0f;
    public float max_zoom = 1F;
    public bool anticipation_and_victory_audio = true;

    private static scaling_settings instance = null;

    void Awake()
    {

        //checks if there is already an instance of settings, 
        //and if there is, then the variables
        //are copied over and then the script is deleted
        if (!instance)
        {
            Debug.Log("new instance of settings");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("repeat instance of settings - saving variables and deleting old instance");

            slow_mo_scale = instance.slow_mo_scale;
            explosion_size = instance.explosion_size;
            max_zoom = instance.max_zoom;
            anticipation_and_victory_audio = instance.anticipation_and_victory_audio;

            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }
 
    //methods for UI to call
    public void AdjustSlowMo(float new_speed)
    {
        Debug.Log("setting slowmo to: " + new_speed);
        slow_mo_scale = new_speed;
    }
    public void Adjustexplosion(float new_size)
    {
        Debug.Log("setting explosion size to: " + new_size);
        explosion_size = new_size;
    }
    public void AdjustZoom(float new_zoom)
    {
        Debug.Log("setting max zoom to: " + new_zoom);
        max_zoom = new_zoom;
    }
    public void AudioToggle()
    {
        if (anticipation_and_victory_audio)
        {
            anticipation_and_victory_audio = false;
        }
        else
        {
            anticipation_and_victory_audio = true;
        }
    }

}
