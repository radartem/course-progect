using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicText : MonoBehaviour {

    [SerializeField]
    Camera cameraPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(-cameraPos.transform.position);
        Vector3 cameradir = cameraPos.transform.forward.normalized;//узнали направление камеры
        transform.forward = cameradir;
        
	}
}
