using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public Rigidbody rigidbdy;
    bool isflat = true;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public float horizontalInput;
    private float verticalInput;
    public float currentbreakforce;
    private bool isBreaking;
    private bool isacc;
    private bool isdeacc;
    public float currentsteeringangle;
    public float maxspped;
    public float minspeed;
    public float sensitivity;
    public float verticalsenstivity;


    [SerializeField] public float motorforce;
    [SerializeField] public float breakingforce;
    [SerializeField] public float maxsteeringangle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    public GameObject bodygreen;
    public GameObject bodyblack;
    public GameObject bodywhite;
    public GameObject bodyblue;
    public GameObject bodyyellow;

    GameObject body;
    GameObject newbody;

    private void Start()
    {
        rigidbdy = GetComponent<Rigidbody>();
        isacc = false;
        isdeacc = false;

        body = getchild(gameObject, "body");

        Transform bodytranform = body.transform;
        Destroy(body);
        maxspped = 100;
        switch (Showcar.currentindex) {

            case 0:
                newbody = Instantiate(bodyblack, bodytranform.position, bodytranform.rotation);
                newbody.transform.parent = transform;
                maxspped = 100;
                
                break;

            case 1:
                newbody = Instantiate(bodyblue, bodytranform.position, bodytranform.rotation);
                newbody.transform.parent = transform;
                maxspped = 105;
                break;

            case 2:
                newbody = Instantiate(bodygreen, bodytranform.position, bodytranform.rotation);
                newbody.transform.parent = transform;
                maxspped = 110;
                break;

            case 3:
                newbody = Instantiate(bodywhite, bodytranform.position, bodytranform.rotation);
                newbody.transform.parent = transform;
                maxspped = 115;
                break;

            case 4:
                newbody = Instantiate(bodyyellow, bodytranform.position, bodytranform.rotation);
                newbody.transform.parent = transform;
                maxspped = 120;
                break;

            default:
                break;


        }
        
        
    }

    private void FixedUpdate()
    {
        Debug.Log(verticalInput);
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        
        

        
    }


    public void accelerate() {
        isacc = true;
        
        
    }

    public void resetacc() {
        isacc = false;
      
    }

    public void deaccelerate()
    {
        isdeacc = true;
        

    }

    public void resetdeacc()
    {
        isdeacc = false;
      
    }


    private void GetInput() {
        /* if (Input.touchCount > 0)
         {
             float t;
             var touchpos = Input.GetTouch(0).position;
             if (touchpos.x > Screen.width / 2)
             {
                 t = 1;
             }
             else
             {
                 t = -1;
             }
             //horizontalInput = Mathf.MoveTowards(horizontalInput, t, sensitivity * Time.deltaTime);
         }
         else {
             //horizontalInput = 0;
         }
        */

        if (isacc)
        {
            verticalInput = Mathf.MoveTowards(verticalInput, 1, verticalsenstivity * Time.deltaTime);
        }
        
        if (isdeacc)
        {
            verticalInput = Mathf.MoveTowards(verticalInput, -1, verticalsenstivity * 3 * Time.deltaTime);
        }
        if (!isacc && !isdeacc) {
            verticalInput = Mathf.MoveTowards(verticalInput, 0, verticalsenstivity * Time.deltaTime);
        }


        //horizontalInput = Input.GetAxis(HORIZONTAL);
     
        Vector3 tilt = Input.acceleration;
        if (isflat) {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        horizontalInput = tilt.x;
        //verticalInput = Input.GetAxis(VERTICAL);
        if (verticalInput < 0)
        {
            isBreaking = true;
        }
        else {
            isBreaking = false;
        }
    }

    private void HandleMotor() {
        currentbreakforce = breakingforce;
        if (rigidbdy.velocity.sqrMagnitude < maxspped)
        {
            frontLeftWheelCollider.motorTorque = motorforce * verticalInput;
            frontRightWheelCollider.motorTorque = motorforce * verticalInput;
            if (rigidbdy.velocity.sqrMagnitude < minspeed)
            {
                frontLeftWheelCollider.motorTorque = motorforce ;
                frontRightWheelCollider.motorTorque = motorforce;
                currentbreakforce = 0;
                ApplyBreak();
                isBreaking = false;
            }
        }
        else {
            
            frontLeftWheelCollider.motorTorque = 0;
            frontRightWheelCollider.motorTorque = 0;
            

        }

        

        if (isBreaking) {
            ApplyBreak();
        }

    }

    private void ApplyBreak() {
        frontRightWheelCollider.brakeTorque = currentbreakforce;
        backRightWheelCollider.brakeTorque = currentbreakforce;
        backLeftWheelCollider.brakeTorque = currentbreakforce;
        frontLeftWheelCollider.brakeTorque = currentbreakforce;
    }

    private void HandleSteering() {
        currentsteeringangle = maxsteeringangle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentsteeringangle;
        frontRightWheelCollider.steerAngle = currentsteeringangle;
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {

        Vector3 pos;
        Quaternion rot = wheelTransform.rotation;
        wheelCollider.GetWorldPose(out pos, out rot);
        
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public GameObject getchild(GameObject fromobject, string name)
    {
        Transform[] ts = fromobject.transform.GetComponentsInChildren<Transform>();

        foreach (Transform t in ts)
        {
            if (t.gameObject.name == name)
            {
                return t.gameObject;
            }

        }
        return null;
    }

}
