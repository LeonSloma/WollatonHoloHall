using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private Cube currentlySelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
    
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            Cube cube = hit.collider.gameObject.GetComponent<Cube>();
            if (cube == null) return;
        
            if (currentlySelected != null)
            {
                currentlySelected.isSelected = false;
            }
            cube.isSelected = true;

            currentlySelected = cube;
            return;
        }
        
        if (currentlySelected != null)
        {
            currentlySelected.isSelected = false;
        }
    }
}
