using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The target around which the camera will orbit
    public float rotationSpeed = 1.0f;
    public float minPitch = -20.0f; // Minimum pitch angle
    public float maxPitch = 50.0f;  // Maximum pitch angle

    private Vector3 lastMousePosition;
    private bool isRotating = false;
    private float currentPitch = 0.0f;

     [SerializeField]
     Transform vcam;
     [SerializeField]
   GameObject stack1,stack2,stack3;

    Vector3 camdefaultpos;
    private Quaternion camdefaultrot;

   public  Transform vcam2,vcam3;

    int currentcam= 1;

    void Start(){

        camdefaultpos = vcam.transform.position;
        camdefaultrot = vcam.transform.rotation;

         target= stack1.transform;
            vcam.transform.position =  vcam2.position;
        vcam.transform.rotation =  vcam2.rotation;


    }

    void Update()
    {
        if (target == null)
        {
            Debug.LogError("Target is not assigned. Please assign a target in the inspector.");
            return;
        }

         if(Input.GetKeyDown(KeyCode.Space)){

           // Debug.Log("HITTED SPACE");

            currentcam++;
            switchcam();

        }




        if (Input.GetMouseButtonDown(0)) // Right mouse button
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            // Rotate the camera around the target on the Y-axis
            vcam.transform.RotateAround(target.position+ Vector3.up*2f, Vector3.up, mouseDelta.x * rotationSpeed);

            // Calculate the new pitch angle and clamp it within the specified range
            currentPitch -= mouseDelta.y * rotationSpeed;
            currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

            // Apply the pitch rotation
            vcam.transform.rotation = Quaternion.Euler(currentPitch, vcam.transform.eulerAngles.y, vcam.transform.eulerAngles.z);
        }
    }




     void switchcam(){

        if(currentcam>3) currentcam =1;

        switch (currentcam){

            case 1:

            target= stack1.transform;
            vcam.transform.position =  vcam2.position;
        vcam.transform.rotation =  vcam2.rotation;
            
            break;

             case 2:

             target=  stack2.transform;
             vcam.transform.position = camdefaultpos;
        vcam.transform.rotation = camdefaultrot;
           
            break;

             case 3:

             target=  stack3.transform;
             vcam.transform.position = vcam3.position;
        vcam.transform.rotation =  vcam3.rotation;
            
          
            break;
        }

      
        
    }
}