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
    [SerializeField] private float DiffuciltyTimer =0f;
    [SerializeField] private float DifficultyCurveRate = 0.1f;
    [SerializeField] private float MaxDiffSpeed = 20f;
    private float _Time;

    public AudioSource jump;
    public AudioSource Die;
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
        DifficultyCurve();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            ScoreManager.ScoreInstance.GameOver();
            Die.Play();
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            ScoreManager.ScoreInstance.CoinIncrement();
            collision.gameObject.SetActive(false);
        }
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
            transform.rotation = Quaternion.Lerp(Rotation, transform.rotation, 0.95f) ;
        }
    }

    private void RotationVisual()
    {
        transform.Rotate(RotationAngle * speedOfRotation * Time.deltaTime * 50) ;
    }

    private void DifficultyCurve()
    {
        // Cause it would reach a point of painful difcullty
        // increaase the control speed
        // at certain point the ball should have a constant speed which would be around 10
        // the game manager would be referenced with the score point to reduce the space between obstacles
        // nethertheless i should reduced the default speed and distance
        
        if (SpeedOftheBall1 > 0.6 && SpeedOftheBall < MaxDiffSpeed) 
        {
            _Time += Time.deltaTime;
            if (_Time > DiffuciltyTimer)
            {
                if (SpeedOfRotation < 20)
                {
                    SpeedOfRotation += DifficultyCurveRate * 1.35f;
                }
                ControlSpeed += DifficultyCurveRate;
                SpeedOftheBall1 += DifficultyCurveRate;
                _Time = 0f;
            }
        } 
   
    }
}
