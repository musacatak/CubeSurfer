using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController _instance;

    [Header("General Variables")]
    public bool useFOVChange = true;
    public bool useCameraRotateWhenFinish = true;
    public float cubeCountFOVMultiplier;
    public float fovSmoothDampValue;
    float defFOVAmount, targetFOVamount;
    Vector3 offsetToPlayer;

    [Header("References")]
    public Transform playerTransform;
    public Collector playerCubeScript;
    Camera cam;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        cam = GetComponent<Camera>();
        offsetToPlayer = transform.position - playerTransform.position;
        defFOVAmount = cam.fieldOfView;
        targetFOVamount = defFOVAmount;
    }


    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, playerTransform.position.y + offsetToPlayer.y, playerTransform.position.z + offsetToPlayer.z);

    }
    

}
