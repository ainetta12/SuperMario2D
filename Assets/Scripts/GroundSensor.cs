using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerControler controler;

   public bool isGrounded; 

    void Awake()
    {
        controler = GetComponentInParent<PlayerControler>();
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
           
           Enemy goomba = other.gameObject.GetComponent<Enemy>();
           goomba.Die();

        }

        if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("estoy muerto");
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
