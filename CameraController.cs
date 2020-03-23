using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public bool userOffsetValues;
    public float rotateSpeed;
    public Transform pivot;



    void Start()
    {
        
        if (!userOffsetValues)
        {
            offset = player.position - transform.position;
        }

        pivot.transform.position = player.transform.position;
        pivot.transform.parent = player.transform;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        if (pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 315f)
        {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);
        }


        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = player.position - (rotation * offset);

        if (transform.position.y < player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }

        transform.LookAt(player);
    }



}