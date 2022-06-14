// //
// I'm sorry I don't know how half of this works
// //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphicsRaycaster : MonoBehaviour
{
    private GraphicRaycaster _raycaster;
    private PointerEventData _eventData;
    private EventSystem _eventSystem;

    void Start()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _eventData = new PointerEventData(_eventSystem);
            _eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            _raycaster.Raycast(_eventData, results);

            foreach (RaycastResult result in results)
            {
                var i = result.gameObject.GetComponent<ItemTileController>();
                if (i)
                    i.Click();

                var f = result.gameObject.GetComponent<FilePanelController>();
                if (f)
                    f.Click();
            }
        }
    }
}
