using UnityEngine;

public class CurserManager : MonoBehaviour
{
    public GameObject CurserItem;
    CurserItemManager CIM;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CIM = CurserItem.GetComponent<CurserItemManager>();
        CIM.HideTool();
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        CurserItem.transform.position = mousePos;
        mouseEvents();
    }

    void mouseEvents(){
        if(Input.GetMouseButtonDown(0)){
            CIM.BeginActiveState();
        }
        if(Input.GetMouseButtonUp(0)){
            CIM.EndActiveState();
        }
        if(Input.GetMouseButtonDown(1)){
            Remove();
        }
    }

    public void Switch(int tool){
        CIM.DisplayTool(tool);
        Player.GiveTool(tool);
    }

    public void Remove(){
        CIM.HideTool();
        Player.RemoveTool();
    }
}
