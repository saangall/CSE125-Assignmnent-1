using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CheckpointController next;
    public MeshRenderer left;
    public MeshRenderer right;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("Trigger enter" + other.transform.name);
    }
}
