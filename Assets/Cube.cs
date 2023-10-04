using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public bool isSelected = false;
    private bool wasSelected = false;

    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startScale    = transform.localScale;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected != wasSelected)
        {
            if (isSelected) 
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.white;

                transform.position   = startPosition;
                transform.localScale = startScale;
                transform.rotation   = startRotation;
            }
        }
        wasSelected = isSelected;

        Transform leftHand  = GameObject.Find("LeftHandAnchor").transform;
        Transform rightHand = GameObject.Find("RightHandAnchor").transform;

        if (isSelected)
        {
            transform.position   = new Vector3(transform.position.x, rightHand.position.y, transform.position.z); 
            transform.localScale = new Vector3(leftHand.position.y, leftHand.position.y, leftHand.position.y) * 0.5f;
            transform.rotation   = rightHand.rotation;
        }
    }
}
