using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementArrowKeys : MonoBehaviour
{
    public float maxSpeed = 1;
    public float accelerationTime = 1;
    public float decelerationTime = 1;

    float acceleration, deceleration;
    float previous_X_velocity, previous_Y_velocity;
    float displacement_X, displacement_Y;

    void Update()
    {

        // < LEFT / RIGHT Movement >

        // Right
        if (Input.GetAxis("Horizontal2") > 0)
        {
            // (1) Calculate acceleration based on: final velocity and final time
            acceleration = maxSpeed / accelerationTime;
            // (2) Increase velocity based on: acceleration and elapsed time (last frame) -- Velocity is constrained to MaxSpeed
            previous_X_velocity = Mathf.Clamp(previous_X_velocity + (acceleration * Time.deltaTime), -maxSpeed, maxSpeed);
            // (3) Determine how much to move the ship based on its velocity and time that has elapsed (last frame)
            displacement_X = previous_X_velocity * Time.deltaTime;
            //Debug.Log ("Accelerating(+X) ---> Displacement = " + displacement_X + ", Velocity = " + prevVelocity_X + "u/s, Time = " + Time.time + "s");

        }
        else if (Input.GetAxis("Horizontal2") < 0)
        {
            // Left
            acceleration = maxSpeed / accelerationTime;
            previous_X_velocity = Mathf.Clamp(previous_X_velocity + (-acceleration * Time.deltaTime), -maxSpeed, maxSpeed);
            displacement_X = previous_X_velocity * Time.deltaTime;
            //Debug.Log ("Accelerating(-X) ---> Displacement = " + displacement_X + ", Velocity = " + prevVelocity_X + "u/s, Time = " + Time.time + "s");


        }
        else // Pressing neither Left or Right
        {
            // If player still has momentum
            if (previous_X_velocity != 0)
            {

                if (previous_X_velocity > 0) // --->
                {
                    deceleration = -maxSpeed / decelerationTime;
                    previous_X_velocity = Mathf.Clamp(previous_X_velocity + (deceleration * Time.deltaTime), 0, maxSpeed); //Should be getting closer to zero
                    displacement_X = previous_X_velocity * Time.deltaTime;
                    //Debug.Log ("Decelerating(X) <--- Displacement = " + displacement_X + ", Velocity = " + prevVelocity_X + "u/s, Time = " + Time.time + "s");

                }
                else // <----
                {
                    deceleration = -maxSpeed / decelerationTime;
                    previous_X_velocity = Mathf.Clamp(previous_X_velocity + (-deceleration * Time.deltaTime), -maxSpeed, 0); //Should be getting closer to zero
                    displacement_X = previous_X_velocity * Time.deltaTime;
                    //Debug.Log ("Decelerating(X) <--- Displacement = " + displacement_X + ", Velocity = " + prevVelocity_X + "u/s, Time = " + Time.time + "s");
                }

            }
        }

        // < UP / DOWN Movement >

        if (Input.GetAxis("Vertical2") > 0) //Holding the UP
        {

            acceleration = maxSpeed / accelerationTime;
            previous_Y_velocity = Mathf.Clamp(previous_Y_velocity + (acceleration * Time.deltaTime), -maxSpeed, maxSpeed);
            displacement_Y = previous_Y_velocity * Time.deltaTime;
            //Debug.Log ("Accelerating(+Y) ---> Displacement = " + displacement_Y + ", Velocity = " + prevVelocity_Y + "u/s, Time = " + Time.time + "s");

            // DOWN
        }
        else if (Input.GetAxis("Vertical2") < 0) //Holding the DOWN
        {

            acceleration = maxSpeed / accelerationTime;
            previous_Y_velocity = Mathf.Clamp(previous_Y_velocity + (-acceleration * Time.deltaTime), -maxSpeed, maxSpeed);
            displacement_Y = previous_Y_velocity * Time.deltaTime;
            //Debug.Log ("Accelerating(-Y) ---> Displacement = " + displacement_Y + ", Velocity = " + prevVelocity_Y + "u/s, Time = " + Time.time + "s");

            // Pressing neither UP or DOWN
        }
        else
        {
            // If player still has momentum
            if (previous_Y_velocity != 0)
            {

                if (previous_Y_velocity > 0) // --->
                {
                    deceleration = -maxSpeed / decelerationTime;
                    previous_Y_velocity = Mathf.Clamp(previous_Y_velocity + (deceleration * Time.deltaTime), 0, maxSpeed); //Should be getting closer to zero
                    displacement_Y = previous_Y_velocity * Time.deltaTime;
                    //Debug.Log ("Decelerating(Y) <--- Displacement = " + displacement_Y + ", Velocity = " + prevVelocity_Y + "u/s, Time = " + Time.time + "s");

                }
                else // <---
                {
                    deceleration = -maxSpeed / decelerationTime;
                    previous_Y_velocity = Mathf.Clamp(previous_Y_velocity + (-deceleration * Time.deltaTime), -maxSpeed, 0); //Should be getting closer to zero
                    displacement_Y = previous_Y_velocity * Time.deltaTime;
                    //Debug.Log ("Decelerating(Y) <--- Displacement = " + displacement_Y + ", Velocity = " + prevVelocity_Y + "u/s, Time = " + Time.time + "s");
                }

            }
        }

        transform.Translate(displacement_X, displacement_Y, 0);

    }
}
