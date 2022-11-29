using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
     #region SlowMotion
     // Switch for SlowMotion
     public bool UseSlowMotion = false;
     // Slowmotion effect factor.
     public float slowFactor = 2.0f;
     private float elapsedTime = 0.0f;
     private bool isSlowedDown = false;
     private float rotationPerSecond = 180;

     public void SlowMotion()
     {
          elapsedTime += Time.deltaTime;

          if (isSlowedDown && elapsedTime >= 1.0f * slowFactor)
          {
               elapsedTime = 0.0f;
               isSlowedDown = false;
               rotationPerSecond = 180;
          }
          else if (!isSlowedDown && elapsedTime >= 1.0f)
          {
               elapsedTime = 0.0f;
               isSlowedDown = true;
               rotationPerSecond = 180 / slowFactor;
          }

          transform.Rotate(Vector3.up, rotationPerSecond * Time.deltaTime);
     }
     #endregion

     public float XRotation = 0;
     public float YRotation = 1;
     public float ZRotation = 0;
     public float DegreesPerSecond = 180;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
          if (UseSlowMotion) SlowMotion();

          Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
          //transform.Rotate(axis, DegreesPerSecond * Time.deltaTime);
          transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);
          Debug.DrawRay(this.transform.position, axis, Color.yellow, .1f);
     }
}
