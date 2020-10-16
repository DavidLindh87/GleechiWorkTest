using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TankMoveScript : MonoBehaviour
{
    private Vector3 start_Position;
    private Quaternion start_Rotation;
    public TrackScript trackLeft;
    public TrackScript trackRight;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyTurnRight;
    public string keyTurnLeft;

    bool moveForward = false;
    bool moveBackward = false;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAcceleration = 0.1f;
    float moveDeceleration = 0.2f;
    float moveSpeedMax = 2.5f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 4f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 130f;
    //save initial transform
    void Start()
    {
       start_Position = this.transform.position;
       start_Rotation = this.transform.rotation;
    }

    public void Reset()
    {
        this.transform.position = start_Position;
        this.transform.rotation = start_Rotation;
        gameObject.GetComponent<Enemy>().Reset();
    }

    // Update is called once per frame
    void Update()
    {
        rotateLeft = (Input.GetKeyDown(keyTurnLeft)) ? true : rotateLeft;
        rotateLeft = (Input.GetKeyUp(keyTurnLeft)) ? false : rotateLeft;
        if (rotateLeft)
        {
            rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        rotateRight = (Input.GetKeyDown(keyTurnRight)) ? true : rotateRight;
        rotateRight = (Input.GetKeyUp(keyTurnRight)) ? false : rotateRight;

        if (rotateRight)
        {
            rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
        moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
        if (moveForward)
        {
            moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax;
        }
        else
        {
            moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeed*Time.deltaTime, 0f);

        moveBackward = (Input.GetKeyDown(keyMoveReverse)) ? true : moveBackward;
        moveBackward = (Input.GetKeyUp(keyMoveReverse)) ? false : moveBackward;
        if (moveBackward)
        {
            moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax;
        }
        else
        {
            moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveAcceleration : 0;
        }
        transform.Translate(0f, moveSpeedReverse * Time.deltaTime*-1f, 0f);

        if(moveForward | moveBackward | rotateRight | rotateLeft)
        {
            trackStart();
        }
        else
        {
            trackStop();
        }
    }

    void trackStart()
    {
        trackLeft.animator.SetBool("isMoving", true);
        trackRight.animator.SetBool("isMoving", true);
    }

    void trackStop()
    {
        trackLeft.animator.SetBool("isMoving", false);
        trackRight.animator.SetBool("isMoving", false);
    }
}
