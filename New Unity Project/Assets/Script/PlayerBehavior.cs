using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // 1
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    // 2
    private float vInput;
    private float hInput;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    //3
        vInput = Input.GetAxis("Vertical") * moveSpeed;
    //4
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

    // 5
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
    // 6
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
