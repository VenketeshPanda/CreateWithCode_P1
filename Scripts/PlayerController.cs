using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    //Inputs
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private float horsePower = 0;
    private Rigidbody playerRb;
    private float turnSpeed = 45;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Update is called once per frame

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    void Update()
    {
        //Controlling the vehicle  by player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnTheGround())
        {
            //We'll move the controller forward
            //transform.Translate(Vector3.forward * Time.deltaTime*speed*forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            //We'll turn the controller
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.37f);
            speedometerText.SetText("Speed:" + speed + "/mph");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM:" + rpm);
        }
    }
    bool IsOnTheGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("End Plane"))
        {
            Debug.Log("Game Over!");
        }
        
    }

   
}
