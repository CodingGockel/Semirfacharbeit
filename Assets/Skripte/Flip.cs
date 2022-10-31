using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public SpriteRenderer mySpriterenderer;
    void Start()
    {
        mySpriterenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if (transform.rotation.z<-0.9 || transform.rotation.z>0.9)
        {
            if (mySpriterenderer != null)
            {
                mySpriterenderer.flipY = true;
 
            }
            
        }
        else
        {
            if (mySpriterenderer != null)
            {
                mySpriterenderer.flipY = false;
             
            }
            
        }
    }
}
