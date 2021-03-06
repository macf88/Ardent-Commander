﻿using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public int shieldHealth = 50;
    public Material shieldOn;
    public Material shieldOff;
    [HideInInspector] public bool shieldActive = true;

    Renderer shieldRenderer;
    int shieldMax;
    float colorLerp = 1.0f;
    float timer;
    float shieldTimer;
    float timeToShieldReharge = 2;
    float shieldAddHealth = .25f;
    bool notInCombat;
    bool fade;
    
	// Use this for initialization
	void Start () {
        shieldRenderer = gameObject.GetComponent<Renderer>();
        shieldRenderer.material = shieldOff;
        shieldMax = shieldHealth;

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        shieldTimer += Time.deltaTime;
        if (timer >= timeToShieldReharge)
        {
            notInCombat = true;
        }
        if(notInCombat == true && shieldTimer >= shieldAddHealth)
        {
            ShieldRecharge();
            shieldTimer = 0;
        }
        if(shieldHealth <= 0)
        {
            shieldActive = false;
        }
        else
        {
            shieldActive = true;
        }
        if (fade == true)
        {
            if (colorLerp > .5f)
            {
                colorLerp -= .025f;
            }
            else if(colorLerp > .1f &&colorLerp < .5f)
            {
                colorLerp -= .03f;
            }
            else
            {
                colorLerp -= .045f;
            }
            shieldRenderer.material.Lerp(shieldOff, shieldOn, colorLerp);
            if (colorLerp <= 0.1f)
            {
                fade = false;
                shieldRenderer.material = shieldOff;
            }
        }
	}
    public void ShieldTakeDamage(int damage)
    {
        fade = true;
        shieldRenderer.material = shieldOn;
        colorLerp = 1.0f;
        notInCombat = false;
        if (damage != 0)
        {
            timer = 0;
        }
        shieldHealth -= damage;
    }
    public int ShieldTakeDamage(int damage, bool happiness)
    {

        if (damage != 0)
        {
            timer = 0;
            fade = true;
            shieldRenderer.material = shieldOn;
            colorLerp = 1.0f;
            notInCombat = false;
        }
        shieldHealth -= damage;
        return shieldHealth;
    }
    void ShieldRecharge()
    {
        if (shieldHealth < shieldMax)
        shieldHealth += 1;
    }
}
