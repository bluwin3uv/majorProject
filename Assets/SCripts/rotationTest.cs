using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationTest : MonoBehaviour {

    public bool invertedControlles;
    public Text text;
    public float mouseSens = 1f;
    public float pitch = 0;
    public float yaw = 0;
    public float theta = 30;
    public float rotSpeed;
    public bool IsPC;
    private Rigidbody rb;
    private Quaternion rotation;

	void Start () 
    {
        Input.gyro.enabled = true;
       // text = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        TiltLock();
        if(IsPC)
        {
            IsInverted();
        }
        else
        {
            GyroRotation();
        }

	}

    void IsInverted()
    {
        if(invertedControlles)
        {
            InvertControlles();
        }
        else
        {
            MouseRotation();
        }
    }

    void GyroRotation()
    {
        float rotX = Input.gyro.rotationRateUnbiased.x;
        float rotY = Input.gyro.rotationRateUnbiased.y;
        pitch -= rotY * mouseSens;
        yaw -= rotX * mouseSens;
        rotation = Quaternion.Lerp(rb.rotation, Quaternion.Euler(new Vector3(yaw, 0, pitch)), rotSpeed * Time.deltaTime);
        rb.MoveRotation(rotation);
        //transform.localEulerAngles = new Vector3(yaw,0,pitch);
        //transform.parent.eulerAngles = new Vector3(pitch, yaw, 0);
        //transform.Rotate(Input.gyro.rotationRateUnbiased.x, Input.gyro.rotationRateUnbiased.y, 0);
    }

    void MouseRotation()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        pitch -= MouseY * mouseSens;
        yaw += MouseX * mouseSens;
        rotation = Quaternion.Lerp(rb.rotation, Quaternion.Euler(new Vector3(pitch, 0, yaw)), rotSpeed *Time.deltaTime);
        rb.MoveRotation(rotation);
       // transform.localEulerAngles = new Vector3(pitch, 0, yaw);

    }

    void InvertControlles()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        pitch += MouseY * mouseSens;
        yaw -= MouseX * mouseSens;
        rotation = Quaternion.Lerp(rb.rotation, Quaternion.Euler(new Vector3(pitch, 0, yaw)), rotSpeed * Time.deltaTime);
        rb.MoveRotation(rotation);
    }

    void TiltLock()
    {
        if (Input.GetMouseButton(1))
        {
            pitch = 0;
            yaw = 0;
        }

        if (pitch > theta)
        {
            pitch = theta;
        }

        if (pitch < -theta)
        {
            pitch = -theta;
        }

        if (yaw > theta)
        {
            yaw = theta;
        }

        if (yaw < -theta)
        {
            yaw = -theta;
        }
    }
}
