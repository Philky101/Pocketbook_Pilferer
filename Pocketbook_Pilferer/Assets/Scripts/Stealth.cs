using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : MonoBehaviour
{
    private float noise;
    private float radius;
    private const float maxRadius = 5.5f;
    private bool isMoving;
    private bool isWalking;
    private bool isSprinting;
    
    // Start is called before the first frame update
    void Start()
    {
        noise = 0f;
        radius = .5f;
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isPlayerMoving(bool moving, bool walking, bool sprinting)
    {
        isMoving = moving;
        isWalking = walking;
        isSprinting = sprinting;

        if (isMoving == true && isWalking == true && isSprinting == false)
        {
            if (radius < maxRadius)
            {
                noise += 0.005f;
                radius = noise;
                setNoiseRadius();
            }
        }
        else if (isMoving == true && isWalking == false && isSprinting == true)
        {
            if (radius < maxRadius)
            {
                noise += 0.025f;
                radius = noise;
                setNoiseRadius();
            }
        }
        else if (isMoving == false)
        {
            if (radius > 0)
            {
                noise -= .5f;
                radius = noise;
                setNoiseRadius();
            }
            else if (radius < 0)
            {
                radius = 0;
                setNoiseRadius();
            }
        }

    }
    public void setNoiseRadius()
    {
        transform.localScale = Vector3.one * radius;
    }
}
