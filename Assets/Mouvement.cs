using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    //Attributs
    public float Speed = 5.0f;

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
    }
}
