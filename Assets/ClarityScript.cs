using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ClarityScript : MonoBehaviour
{

    public GameObject[] pointsOfClarity;
    public float distance = 100;
    public float minBlurDistance;
    public float maxBlurDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        distance = 100;
        foreach (var point in pointsOfClarity)
        {
            float newDistance = Vector3.Distance(point.transform.position, transform.position);
            distance = newDistance < distance ? newDistance : distance;
        }

        Renderer blurValue = GameObject.Find("Quad").GetComponent<Renderer>();
       if (distance <= maxBlurDistance)
        {
            if (distance > minBlurDistance)
            {
                float a = ((distance - minBlurDistance)/ (maxBlurDistance - minBlurDistance))/100;
                float aClamp = Mathf.Clamp(a, 0.002f, 0.01f);
                blurValue.material.SetFloat("_BlurValue", aClamp);
            }
            else
            {
                blurValue.material.SetFloat("_BlurValue", 0.002f);
            }
            
        }
        else
        {
            blurValue.material.SetFloat("_BlurValue", 0.01f);
        }
        
        
    }

 
}
