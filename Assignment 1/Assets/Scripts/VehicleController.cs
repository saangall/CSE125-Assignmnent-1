using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float desired_acceleration;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(desired_acceleration*2, 0, 0);
        float dx = (Mouse.current.position.x.value - Screen.width/2) / 200;
        if(Mathf.Abs(dx) > 0.01f){
            transform.Rotate(0, dx, 0);
        }
    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
    }
}
