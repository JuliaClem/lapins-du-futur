using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    //Attributs
    public float Speed = 3.0f;
    public float turnSpeed = 15f;
    float Xangle = 90f;
    float Yangle = 90f;
    float Zangle = 90f;
    private Animator anim;
    private Rigidbody rb;

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
        }
        // Marche arrière
        if (axisZ < 0)
        {
            transform.Translate(transform.forward * Speed * axisZ * Time.deltaTime);
            Debug.Log("Touche S detectée.");
        }
        // Droite
        if (axisX > 0)
        {
            transform.Translate(transform.right * Speed * axisX * Time.deltaTime);
            Debug.Log("Touche D detectée.");  
        }
        //Gauche
        if (axisX < 0)
        {
            transform.Translate(transform.right * Speed * axisX * Time.deltaTime);
            Debug.Log("Touche Q detectée.");
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