using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{
    public static CheckWinner instance;
    public Camera defaultCamera;
    public Camera winnerCamera;
    public bool isWinner = false;

    public Transform target;
    public float smoothSpeed = 1.0f;

    public float zPosition;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        defaultCamera.enabled = true;
        winnerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isWinner)
        {
            defaultCamera.enabled = false;
            winnerCamera.enabled = true;
        }
    }
    private void LateUpdate()
    {
     
        if (target != null && isWinner)
        {
            Vector3 desiredPostion = new Vector3(target.position.x,target.position.y,target.position.z+zPosition);

            Vector3 smoothedPosition = Vector3.Lerp(winnerCamera.transform.position, desiredPostion, smoothSpeed*Time.deltaTime);
            winnerCamera.transform.position = smoothedPosition;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")&&playerController.instance.groundedPlayer)
        {
            isWinner = true;
        }
    }
}
