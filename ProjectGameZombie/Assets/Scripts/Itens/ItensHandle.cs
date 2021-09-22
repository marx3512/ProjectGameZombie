using UnityEngine;

public class ItensHandle : MonoBehaviour
{
    [SerializeField] private ItensStatus itensStatus;
    public Sprite itenIcon;

    private void Start() {
        itenIcon = itensStatus.spriteIten;
    }
    
}
