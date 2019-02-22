using System.Collections;
using System.Collections.Generic;
using GamepadInput;
using UnityEngine;
using UnityEngine.Serialization;

public class GirlController : MonoBehaviour
{
    [FormerlySerializedAs("Head")] public GameObject head;
    [FormerlySerializedAs("Face")] public GameObject face;
    [FormerlySerializedAs("HeadPhone")] public GameObject headPhone;
    [FormerlySerializedAs("Body")] public GameObject body;
    [FormerlySerializedAs("LShoulder")] public GameObject lShoulder;
    [FormerlySerializedAs("LWrist")] public GameObject lWrist;
    [FormerlySerializedAs("LHand")] public GameObject lHand;
    [FormerlySerializedAs("RShoulder")] public GameObject rShoulder;
    [FormerlySerializedAs("RWrist")] public GameObject rWrist;
    [FormerlySerializedAs("RHand")] public GameObject rHand;

    [FormerlySerializedAs("Face1")] public Sprite face1;
    [FormerlySerializedAs("Face2")] public Sprite face2;
    [FormerlySerializedAs("Face3")] public Sprite face3;
    [FormerlySerializedAs("Face4")] public Sprite face4;

    [FormerlySerializedAs("HeadPositionRate")]
    public float headPositionRate = 1.0f;

    [FormerlySerializedAs("BodyPositionRate")]
    public float bodyPositionRate = 0.5f;

    [FormerlySerializedAs("WristPositionRate")]
    public float wristPositionRate = 0.9f;

    [FormerlySerializedAs("HandDistance")] public float handDistance = 5f;

    private PixelObjectBase _head;
    private PixelObjectBase _headPhone;
    private PixelObjectBase _face;
    private PixelObjectBase _body;
    private PixelObjectBase _lWrist;
    private PixelObjectBase _lHand;
    private PixelObjectBase _rWrist;
    private PixelObjectBase _rHand;

    // Start is called before the first frame update
    private void Start()
    {
        _head = head.GetComponent<PixelObjectBase>();
        _headPhone = headPhone.GetComponent<PixelObjectBase>();
        _face = face.GetComponent<PixelObjectBase>();
        _body = body.GetComponent<PixelObjectBase>();
        _lWrist = lWrist.GetComponent<PixelObjectBase>();
        _lHand = lHand.GetComponent<PixelObjectBase>();
        _rWrist = rWrist.GetComponent<PixelObjectBase>();
        _rHand = rHand.GetComponent<PixelObjectBase>();
    }

    // Update is called once per frame
    private void Update()
    {
        // 左手
        var left = new Vector3(
            Input.GetAxis("LStickX"),
            Input.GetAxis("LStickY"),
            0
        );
        _lHand.transform.localPosition = left * handDistance;
        _lHand.LastUpdate();

        var lHandPosition = lHand.transform.position;
        var lShoulderPosition = lShoulder.transform.position;
        _lWrist.transform.position = (lHandPosition - lShoulderPosition) * wristPositionRate + lShoulderPosition;
        _lWrist.LastUpdate();

        // 右手
        var right = new Vector3(
            Input.GetAxis("RStickX"),
            Input.GetAxis("RStickY"),
            0
        );
        _rHand.transform.localPosition = right * handDistance;
        _rHand.LastUpdate();

        var rHandPosition = rHand.transform.position;
        var rShoulderPosition = rShoulder.transform.position;
        _rWrist.transform.position = (rHandPosition - rShoulderPosition) * wristPositionRate + rShoulderPosition;
        _rWrist.LastUpdate();

        // 頭
        var headPosition = (right + left) * headPositionRate;
        _head.transform.localPosition = headPosition;
        _headPhone.transform.localPosition = headPosition;
        _face.transform.localPosition = headPosition;
        _head.LastUpdate();
        _headPhone.LastUpdate();
        _face.LastUpdate();

        // 体
        var bodyPosition = (right + left) * bodyPositionRate;
        _body.transform.localPosition = bodyPosition;
        _body.LastUpdate();

        if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.One))
        {
            face.GetComponent<SpriteRenderer>().sprite = face1;
        }
        
        if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.One))
        {
            face.GetComponent<SpriteRenderer>().sprite = face2;
        }
        
        if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.One))
        {
            face.GetComponent<SpriteRenderer>().sprite = face3;
        }
        
        if (GamePad.GetButtonDown(GamePad.Button.Y, GamePad.Index.One))
        {
            face.GetComponent<SpriteRenderer>().sprite = face4;
        }
    }

    private void OnRenderObject()
    {
        _head.OnRenderObject();
        _headPhone.OnRenderObject();
        _face.OnRenderObject();
        _body.OnRenderObject();
        _lWrist.OnRenderObject();
        _lHand.OnRenderObject();
        _rWrist.OnRenderObject();
        _rHand.OnRenderObject();
    }
}