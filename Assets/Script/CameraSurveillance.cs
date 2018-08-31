using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSurveillance : MonoBehaviour
{
    public Camera[] cameras; //array of cameras to switch
    public KeyCode prevkey = KeyCode.Q; //filter back to previous cam
    public KeyCode nextkey = KeyCode.E; //filter forward to next cam

    private int camIndex; //current cam index from array
    private int CamMax; //max amount of cams in array
    private Camera current; //current camera selected

    void Start ()
    {
        //get all Camera children and store into array
        cameras = GetComponentsInChildren<Camera>();
        //last index of array = Array.Length
        CamMax = cameras.Length -1;
        //Activate the default camera;
        ActivateCamera(camIndex);
	}
    void ActivateCamera(int camIndex)
    {
        //loop through all surveilance cameras
        for (int i = 0; i < cameras.Length; i++)
        {
            Camera cam = cameras[i];
            //if the current index matches the argument camIndex
            if(i == camIndex)
            {
                //enable this camera
                cam.gameObject.SetActive(true);
            }
            else//...otherwise
            {
                //disable camera
                cam.gameObject.SetActive(false);
            }
        }
    }
    void Update ()
    {
		/*4 types of loops
         * FOR LOOP you need to know the length
         * FOR EACH you need to know the type
         * WHILE has a minimum run of zero, checks before it runs
         * DO WHILE has a minimum run one,runs before it checks
          */

        // if the next key is pressed
        if(Input.GetKeyDown(nextkey))
        {
            //increase index 
            camIndex++;
            if(camIndex > CamMax)
            {
                camIndex = 0;
            }
            ActivateCamera(camIndex);
        }
        if (Input.GetKeyDown(prevkey))
        {
            //decrease index 
            camIndex--;
            if (camIndex < CamMax)
            {
                camIndex = CamMax;
            }
            ActivateCamera(camIndex);
        }
    }
}//as many point lights as you want if you use differed
