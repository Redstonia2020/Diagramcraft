using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSelectionMenu : MonoBehaviour
{
    [HideInInspector]
    public BlockSelectController Controller;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Controller)
            {
                Controller.ToggleMenu();
            }

            else
            {
                //something goes horribly wrong
            }
        }
    }
}