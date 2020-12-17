using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{ 
    public InputAction Forward;
    public InputAction SideWays;
    public InputAction Brake;

    //CharacterController controller;
    public float speed = 200000.0f;
    public float throttle;
    public float steer;
    public float brake;
    private bool slip;
    public float brakeStrength;
    public bool boosted;
    public Rigidbody rb;
    private WheelFrictionCurve sFriction;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider>wheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes;
    public float maxTurn = 20.0f;
    public Transform centerMass;
    

   // enum ControllerType { SimpleMove, Move};
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        //rb.transform.parent = null;
        rb = GetComponent<Rigidbody>();
        boosted = false;
       if(centerMass)
        {
            rb.centerOfMass = centerMass.localPosition;
        }
    }

    private void FixedUpdate()
    {
        foreach(WheelCollider wheel in wheels )
        {



            if (brake > 0)
            {
                wheel.brakeTorque = brakeStrength * Time.deltaTime;
            }
            else
            {
                wheel.brakeTorque = 0.0f;
            }
        }

        foreach (WheelCollider wheel in throttleWheels)
        {
            if (slip)
            {
                
            }
            if (brake > 0)
            {
                wheel.motorTorque = 0.0f;
            }
            else
            {
                if (!boosted)
                { 
                    wheel.motorTorque = (speed * Time.deltaTime * throttle) * 2;
                }
                else
                {
                    wheel.motorTorque = (speed * Time.deltaTime * throttle) * 3;
                }

            }
            foreach (GameObject mesh in meshes)
            {

                mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? 1 : -1) / (2 * Mathf.PI * 0.33f), 0.0f, 0.0f);
            }
        }

        foreach (GameObject wheel in steeringWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * steer;
            wheel.transform.localEulerAngles = new Vector3(0.0f, steer * maxTurn, 0.0f);
        }
    }

    void UpdateWheelPos(WheelCollider _collider, Transform _transform)
    {
        
    }


    public IEnumerator Slip()
    {
        foreach (WheelCollider wheel in throttleWheels)
        {
            sFriction = wheel.sidewaysFriction;
            sFriction.extremumSlip = 5;
            wheel.sidewaysFriction = sFriction;
            yield return new WaitForSeconds(5);
            sFriction.extremumSlip = 1;
            wheel.sidewaysFriction = sFriction;

        }
    }

    public void callBoost()
    {
        StartCoroutine(Boost());
    }
    public IEnumerator Boost()
    {
        boosted = true;
        yield return new WaitForSeconds(3);
        boosted = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oil"))
        {
            StartCoroutine(Slip());
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Boost"))
        {
            StartCoroutine(Boost());
            Destroy(other.gameObject);
        }
    }
    void Oil()
    {
        foreach(WheelCollider wheel in wheels)
        {
           
        }
    }


    private void OnEnable()
    {
        Forward.Enable();
        SideWays.Enable();
        Brake.Enable();
    }

    private void OnDisable()
    {
        Forward.Disable();
        SideWays.Disable();
        Brake.Disable();
    }
    // Update is called once per frame
    void Update()
    {
       
        throttle = Forward.ReadValue<float>();
        steer = SideWays.ReadValue<float>();
        brake = Brake.ReadValue<float>();
    }
}
