using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, TurretFireSound, jumpSound, PowerUpSound, DashSound;
    static AudioSource audioSrc;

    void Start()
    {
    	playerHitSound = Resources.Load<AudioClip>("playerhit");
    	TurretFireSound = Resources.Load<AudioClip>("turret_bullet");
    	jumpSound = Resources.Load<AudioClip>("jump");
    	PowerUpSound = Resources.Load<AudioClip>("powerup");
    	DashSound = Resources.Load<AudioClip>("dash");   

    	audioSrc = GetComponent<AudioSource>(); 	
    }

    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
    	switch(clip)
    	{
    		case "playerHit":
    			audioSrc.PlayOneShot(playerHitSound);
    			break;
     		case "turretShoot":
    			audioSrc.PlayOneShot(TurretFireSound);
    			break;   			
    		case "jump":
    			audioSrc.PlayOneShot(jumpSound);
    			break;
    		case "powerUp":
    			audioSrc.PlayOneShot(PowerUpSound);
    			break;
    		case "dash":
    			audioSrc.PlayOneShot(DashSound);
    			break;
    	}
    }
}
