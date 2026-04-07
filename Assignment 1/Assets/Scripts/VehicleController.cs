using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float desired_acceleration;
    float desired_rotation;
    public float impulse = -2;
    public float turnrate = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(desired_acceleration*impulse, 0, 0);
        //float dx = (Mouse.current.position.x.value - Screen.width/2) / 200;
        //if(Mathf.Abs(dx) > 0.01f){
        //    transform.Rotate(0, dx/2, 0);
        //}
        // For turning, use the left and right arrow keys
        GetComponent<Rigidbody>().transform.Rotate(0, desired_rotation/turnrate, 0);
    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
        desired_rotation = movement.x;
    }
}
