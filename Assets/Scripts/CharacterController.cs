using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float hoverHeight;
    [SerializeField] private float hoverSpringStrength;
    [SerializeField] private float hoverSpringDamper;
    [SerializeField] private float jumpHeight; 
    [SerializeField] private float moveSpeed;

    Rigidbody rb;

    bool isGrounded;

    Vector3 movementForce = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1), 1.0f);

        
    }

    void FixedUpdate()
    {
        
        RaycastHit hit;

        if(Physics.Raycast(transform.position, new Vector3(0,-1), out hit, hoverHeight))
        {
            Vector3 otherVel = Vector3.zero;
            if (hit.rigidbody) otherVel = hit.rigidbody.velocity;

            float relVel = Vector3.Dot(new Vector3(0, -1), rb.velocity) - Vector3.Dot(new Vector3(0, -1), otherVel);

            float hoverDistLeft = hit.distance - hoverHeight;
            float springForce = (hoverDistLeft * hoverSpringStrength) - (relVel * hoverSpringDamper);

        }
    }
    public void Move(Vector3 direction)
    {
        rb.MovePosition(direction * moveSpeed + transform.position);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(new Vector3(0, 1) * Mathf.Sqrt(2.0f * Physics.gravity.magnitude * jumpHeight), ForceMode.VelocityChange);
        }
    }
}
