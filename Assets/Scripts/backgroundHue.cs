using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHue : MonoBehaviour {
    

    Camera cam;
    int index = 0;
    bool isGoingDark = false;
    Color[] colorParam = { new Color(4f, 4f, 0f, 0f), new Color(0f, 4f, 4f, 0f), new Color(4f, 0f, 4f, 0f)};


    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        index = index % 3;

        if (cam.backgroundColor.r >= 59f / 255f || cam.backgroundColor.g >= 59f / 255f || cam.backgroundColor.b >= 59f / 255f)
            isGoingDark = true;

        if(!isGoingDark)
            cam.backgroundColor = cam.backgroundColor + (colorParam[index] / 4080);

        if (cam.backgroundColor.r <= 35f / 255f && cam.backgroundColor.g <= 35f / 255f && cam.backgroundColor.b <= 35f / 255f)
        {
            isGoingDark = false;
            index++;
        }

        if(isGoingDark)
            cam.backgroundColor = cam.backgroundColor - (colorParam[index] / 4080);
 
    }
}
