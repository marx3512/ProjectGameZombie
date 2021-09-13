using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private Zombie zombie;

    public float health;

    private void Start(){
        health = zombie.Health;
    }

    private void Update(){
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
}
