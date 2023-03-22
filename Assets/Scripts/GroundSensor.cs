using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSensor : MonoBehaviour
{
    private PlayerControler controler;

   public bool isGrounded; 

   SFXManager sfxManager;
   SoundManager soundManager;
   GameManager gameManager;


    void Awake()
    {
        controler = GetComponentInParent<PlayerControler>();

        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            controler.anim.SetBool("IsJumping", false);
        }

        else if(other.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");

            sfxManager.GoombaDeath();
           
           Enemy goomba = other.gameObject.GetComponent<Enemy>();
           goomba.Die();

        }

        if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("estoy muerto");

            soundManager.StopBGM();
            sfxManager.MarioDeath();
            gameManager.GameOver();
            //SceneManager.LoadScene(2);
           



        }
   }

    void OnTriggerStay2D(Collider2D other)
   {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            controler.anim.SetBool("IsJumping", false);
        }

   }

   void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
            controler.anim.SetBool("IsJumping", true);
        }
       
    }
   
}
