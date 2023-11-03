using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;
using TMPro;

public class camerascript : MonoBehaviour
{
    int currentcam= 1;
   // Camera
   [SerializeField]
   CinemachineVirtualCamera vcam;



   [SerializeField]  //for positioning stacks
   GameObject stack1,stack2,stack3;


   [SerializeField] //rotating on update fto follow cam
   GameObject stack1text,stack2text,stack3text;

     [SerializeField]
    TMP_Text text0;

    // Start is called before the first frame update
    void Start()
    {
      //  switchcam();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

            Debug.Log("HITTED SPACE");

            currentcam++;
          //  switchcam();

        }

         if(Input.GetMouseButtonDown(1)){
        // Cast a ray from the mouse cursor to detect objects
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object hit by the ray is the object with this script
            if (hit.collider.gameObject.tag == "block")
            {
                hit.collider.GetComponent<Blockscript>().Selected();

               // Debug.Log(hit.collider.GetComponent<Blockscript>().standarddescription);
                string texto = hit.collider.GetComponent<Blockscript>().domain;
                texto += "  \n \n " + hit.collider.GetComponent<Blockscript>().cluster;
                 texto += "  \n  \n" + hit.collider.GetComponent<Blockscript>().standarddescription;

                 text0.text = texto;
                    text0.transform.position = hit.collider.transform.position;
                    text0.transform.rotation = Camera.main.transform.rotation;

              
                
            }

        }
        }
          if(Input.GetMouseButtonUp(1)){
             text0.text ="";
          }

                //not proper responsabiliyu
            if(Input.GetKeyDown(KeyCode.Return)){
             GetComponent<AudioSource>().Play();
          }

            //sloppy
          stack1text.transform.rotation = Camera.main.transform.rotation;
            stack2text.transform.rotation =  Camera.main.transform.rotation;
              stack3text.transform.rotation =  Camera.main.transform.rotation;

    }


    void switchcam(){

        if(currentcam>3) currentcam =1;

        switch (currentcam){

            case 1:

            vcam.LookAt = stack1.transform;
             vcam.Follow = stack1.transform;
            break;

             case 2:

            vcam.LookAt = stack2.transform;
            vcam.Follow = stack2.transform;
            break;

             case 3:

            vcam.LookAt = stack3.transform;
            vcam.Follow = stack3.transform;
            break;
        }
        
    }

 

}
