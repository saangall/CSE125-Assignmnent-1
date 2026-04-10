using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SocialPlatforms.GameCenter;
using Unity.VisualScripting;

public class VehicleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float desired_acceleration;
    float desired_rotation;
    public float impulse = -6;
    public float turnrate = 5;
    public CheckpointController target;
    float starttime;
    public TextMeshProUGUI timelbl;

    float lap_count = 0;

    float checkpoint_count = 8;
    void Start()
    {
        starttime = Time.time;
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
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
        timelbl.text = string.Format("Current time: {0:F2} seconds\nCurrent lap count: {1:F2}", (Time.time - starttime), (lap_count));
    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
        desired_rotation = movement.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckpointController checkpoint = other.gameObject.GetComponent<CheckpointController>();

        if (checkpoint.CompareTag("Start"))
        {
            if(checkpoint_count == 8)
            {
                lap_count += 1;
                checkpoint_count = 0;
            }
        }

        else if(checkpoint.CompareTag("Standard Check"))
        {
            if(checkpoint.left.materials[0].color == Color.red)
            {
                checkpoint_count += 1;
            }
        }
    }
}
