using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    //Attributs
    public float Speed = 3.0f;
    public float turnSpeed = 15f;
    private Animator anim;
    private Rigidbody rb;
    AudioSource Jump;
    [SerializeField] AudioClip sndJump;

    public void PlaySoundJump()
        {
            Jump.volume = 0.15f;
            Jump.pitch = 1f;
            Jump.PlayOneShot(sndJump);
        }

    private void Awake()
    {
        Jump = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
     void Update() 
    {
        float axisZ = Input.GetAxis("Vertical");
        float axisX = Input.GetAxis("Horizontal");
        
        // Marche avant
        if (axisZ > 0)
        {
            transform.Translate(transform.forward * Speed * axisZ * Time.deltaTime);
            Debug.Log("Touche Z detectée.");
            Jump.PlayOneShot(sndJump);
        }
        // Marche arrière
        if (axisZ < 0)
        {
            transform.Translate(transform.forward * Speed * axisZ * Time.deltaTime);
            Debug.Log("Touche S detectée.");
            Jump.PlayOneShot(sndJump);
        }
        // Droite
        if (axisX > 0)
        {
            transform.Translate(transform.right * Speed * axisX * Time.deltaTime);
            Debug.Log("Touche D detectée.");
            Jump.PlayOneShot(sndJump);  
        }
        //Gauche
        if (axisX < 0)
        {
            transform.Translate(transform.right * Speed * axisX * Time.deltaTime);
            Debug.Log("Touche Q detectée.");
            Jump.PlayOneShot(sndJump);
        }

        //Animation Idle to Run

        if (axisZ != 0 || axisX != 0)
        {
            anim.SetFloat("Speed", 1);
        }
        else 
        {
            anim.SetFloat("Speed", 0);
        }
    }
}