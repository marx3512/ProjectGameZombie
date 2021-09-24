using UnityEngine;

public class ItensHandle : MonoBehaviour
{
    [SerializeField] private ItensStatus itensStatus;
    public Sprite itenIcon;
    public string typeItem;

    private void Start() {
        itenIcon = itensStatus.spriteIten;
        typeItem = itensStatus.typeItem;
    }
    
}
