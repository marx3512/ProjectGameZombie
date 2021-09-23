using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{   
    [SerializeField] private Button btn;

    private Grid grid;

    private void Start(){
        grid = new Grid(4, 2, 10f);

        
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            btn.onClick.AddListener(SpeakSmothing);
        }

        if(Input.GetMouseButtonDown(1)) Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
    }

    void SpeakSmothing(){
        Debug.Log("Eaw man");
    }
}
