using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColor : MonoBehaviour
{
    
    public Material initialMaterial;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
           return;
        }
        
        GetComponent<Renderer>().material.color = Color.red;
        
    }
    
    // on collision exit change the color back to the previous color
    private void OnCollisionExit(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("Ground"))
        {
           return;
        }
        GetComponent<Renderer>().material = initialMaterial;
        
    }

    private IEnumerable<WaitForSeconds> Wait()
    {
        yield return new WaitForSeconds(0.4f);
    }
}
