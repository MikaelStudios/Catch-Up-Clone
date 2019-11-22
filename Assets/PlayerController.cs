using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float SpeedOftheBall = 0f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float ControlSpeed;
    [SerializeField] private float speedOfRotation;
    private Vector3 RotationAngle =new Vector3(1,0,0);
    private Rigidbody rb;
    Quaternion Rotation;

    public float SpeedOftheBall1 { get => SpeedOftheBall; set => SpeedOftheBall = value; }
    public float SpeedOfRotation { get => speedOfRotation; set => speedOfRotation = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RotationVisual();
        float horizontal = Input.GetAxis("Horizontal");
        RotateOnZ(horizontal);
        AutoMoveAndControl(horizontal);
        GravityModifier();
    }

    private void GravityModifier()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier + 1) * Time.deltaTime;
        }
    }

    private void AutoMoveAndControl(float horizontal)
    {
        rb.MovePosition(transform.position + new Vector3(horizontal * ControlSpeed, 0, 1 * SpeedOftheBall1) * Time.deltaTime);
    }

    private void RotateOnZ(float horizontal)
    {
        if (horizontal > 0)
        {
            RotationAngle.z = 0.5f;
        }
        else if (horizontal < 0)
        {
            RotationAngle.z = -0.5f;
        }
        else
        {
            RotationAngle.z = 0f;
            //transform.rotation = new Quaternion(transform.rotation.x, 0, 0, transform.rotation.w);
            Rotation = new Quaternion(transform.rotation.x, 0, 0, transform.rotation.w);
            transform.rotation = Quaternion.Lerp(Rotation, transform.rotation, 0.95f);
        }
    }

    private void RotationVisual()
    {
        transform.Rotate(RotationAngle * speedOfRotation);
    }
}
