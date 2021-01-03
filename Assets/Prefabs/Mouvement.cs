using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    //Attributs
    public CharacterController controller;
    public float Speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //public float turnSpeed = 15f;
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
        float axisX = Input.GetAxisRaw("Horizontal");
        float axisZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(axisX, 0, axisZ).normalized;

        

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            controller.Move(direction * Speed * Time.deltaTime);
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