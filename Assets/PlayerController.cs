using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private GameObject panel;
    //public GameObject particles;
    public Letter letter;
    int i;
    bool isDrawing = false;
    //public Letter letter;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit raycastHit;
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0) && i<letter.lines.Count)
        {
            if (Physics.Raycast(raycast, out raycastHit, Mathf.Infinity))
            {
                Debug.Log(raycastHit.point);
                //particles.transform.position = Input.mousePosition;
                if (Mathf.Abs(raycastHit.point.x - letter.lines[0].startPoint.position.x) < 0.2 && Mathf.Abs(raycastHit.point.y - letter.lines[i].startPoint.position.y) < 0.5)
                {
                    
                    isDrawing = true;
                    Debug.Log(isDrawing);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)&& Physics.Raycast(raycast, out raycastHit, Mathf.Infinity))
        {
            Debug.Log(raycastHit.point);
                          
            if (Mathf.Abs(raycastHit.point.x - letter.lines[i].endPoint.position.x) < 0.2 && Mathf.Abs(raycastHit.point.y - letter.lines[i].endPoint.position.y) < 0.5 && isDrawing)
                {
                    letter.lines[i].mesh.enabled = true;
                    i++;
                }
        }
        if(i==letter.lines.Count)  
        {
            ActivatePanel();
        }   
    }

    async private void ActivatePanel()
    {
        await new WaitForSeconds(2);
        panel.SetActive(true);
    }
}
       

    
