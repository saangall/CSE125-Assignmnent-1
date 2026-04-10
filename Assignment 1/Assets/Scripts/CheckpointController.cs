using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CheckpointController next;
    public MeshRenderer left;
    public MeshRenderer right;
    public Color original_color;
    void Start()
    {

        original_color = left.materials[0].color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        VehicleController vehicle = other.gameObject.GetComponent<VehicleController>();
        if(vehicle != null){
            if(left.materials[0].color != Color.white && left.materials[0].color != original_color){
                next.left.materials[0].color = Color.red;
                next.right.materials[0].color = Color.red;
            }
            if(left.materials[0].color != original_color){
                left.materials[0].color = Color.white;
                right.materials[0].color = Color.white;
            }
        }
    }
}
