using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
     /// <summary>
     /// Slowmotion effect factor.
     /// </summary>
     public float slowFactor = 2.0f;

     public float elapsedTime = 0.0f;
     public bool isSlowMotion = false;
     public float rotation = 180;

     // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          elapsedTime += Time.deltaTime;

          if (isSlowMotion && elapsedTime >= 1.0f * slowFactor)
          {
               elapsedTime = 0.0f;
               isSlowMotion = false;
               rotation = 180;
          }
          else if (!isSlowMotion && elapsedTime >= 1.0f)
          {
               elapsedTime = 0.0f;
               isSlowMotion = true;
               rotation = 180 / slowFactor;
          }

          transform.Rotate(Vector3.up, rotation * Time.deltaTime);
    }
}
