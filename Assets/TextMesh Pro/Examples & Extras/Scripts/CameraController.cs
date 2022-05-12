using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
    public class CameraController : MonoBehaviour
    {
        public enum CameraModes { Follow, Isometric, Free }

        private Transform cameraTransform;
        private Transform dummyTarget;

<<<<<<< HEAD
        [FormerlySerializedAs("CameraTarget")] public Transform cameraTarget;

        [FormerlySerializedAs("FollowDistance")] public float followDistance = 30.0f;
        [FormerlySerializedAs("MaxFollowDistance")] public float maxFollowDistance = 100.0f;
        [FormerlySerializedAs("MinFollowDistance")] public float minFollowDistance = 2.0f;

        [FormerlySerializedAs("ElevationAngle")] public float elevationAngle = 30.0f;
        [FormerlySerializedAs("MaxElevationAngle")] public float maxElevationAngle = 85.0f;
        [FormerlySerializedAs("MinElevationAngle")] public float minElevationAngle = 0f;

        [FormerlySerializedAs("OrbitalAngle")] public float orbitalAngle = 0f;

        [FormerlySerializedAs("CameraMode")] public CameraModes cameraMode = CameraModes.Follow;

        [FormerlySerializedAs("MovementSmoothing")] public bool movementSmoothing = true;
        [FormerlySerializedAs("RotationSmoothing")] public bool rotationSmoothing = false;
        private bool previousSmoothing;

        [FormerlySerializedAs("MovementSmoothingValue")] public float movementSmoothingValue = 25f;
        [FormerlySerializedAs("RotationSmoothingValue")] public float rotationSmoothingValue = 5.0f;

        [FormerlySerializedAs("MoveSensitivity")] public float moveSensitivity = 2.0f;
=======
        public Transform CameraTarget;

        public float FollowDistance = 30.0f;
        public float MaxFollowDistance = 100.0f;
        public float MinFollowDistance = 2.0f;

        public float ElevationAngle = 30.0f;
        public float MaxElevationAngle = 85.0f;
        public float MinElevationAngle = 0f;

        public float OrbitalAngle = 0f;

        public CameraModes CameraMode = CameraModes.Follow;

        public bool MovementSmoothing = true;
        public bool RotationSmoothing = false;
        private bool previousSmoothing;

        public float MovementSmoothingValue = 25f;
        public float RotationSmoothingValue = 5.0f;

        public float MoveSensitivity = 2.0f;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

        private Vector3 currentVelocity = Vector3.zero;
        private Vector3 desiredPosition;
        private float mouseX;
        private float mouseY;
        private Vector3 moveVector;
        private float mouseWheel;

        // Controls for Touches on Mobile devices
        //private float prev_ZoomDelta;


<<<<<<< HEAD
        private const string EVENT_SMOOTHING_VALUE = "Slider - Smoothing Value";
        private const string EVENT_FOLLOW_DISTANCE = "Slider - Camera Zoom";
=======
        private const string event_SmoothingValue = "Slider - Smoothing Value";
        private const string event_FollowDistance = "Slider - Camera Zoom";
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


        void Awake()
        {
            if (QualitySettings.vSyncCount > 0)
                Application.targetFrameRate = 60;
            else
                Application.targetFrameRate = -1;

            if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
                Input.simulateMouseWithTouches = false;

            cameraTransform = transform;
<<<<<<< HEAD
            previousSmoothing = movementSmoothing;
=======
            previousSmoothing = MovementSmoothing;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }


        // Use this for initialization
        void Start()
        {
<<<<<<< HEAD
            if (cameraTarget == null)
            {
                // If we don't have a target (assigned by the player, create a dummy in the center of the scene).
                dummyTarget = new GameObject("Camera Target").transform;
                cameraTarget = dummyTarget;
=======
            if (CameraTarget == null)
            {
                // If we don't have a target (assigned by the player, create a dummy in the center of the scene).
                dummyTarget = new GameObject("Camera Target").transform;
                CameraTarget = dummyTarget;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }
        }

        // Update is called once per frame
        void LateUpdate()
        {
            GetPlayerInput();


            // Check if we still have a valid target
<<<<<<< HEAD
            if (cameraTarget != null)
            {
                if (cameraMode == CameraModes.Isometric)
                {
                    desiredPosition = cameraTarget.position + Quaternion.Euler(elevationAngle, orbitalAngle, 0f) * new Vector3(0, 0, -followDistance);
                }
                else if (cameraMode == CameraModes.Follow)
                {
                    desiredPosition = cameraTarget.position + cameraTarget.TransformDirection(Quaternion.Euler(elevationAngle, orbitalAngle, 0f) * (new Vector3(0, 0, -followDistance)));
=======
            if (CameraTarget != null)
            {
                if (CameraMode == CameraModes.Isometric)
                {
                    desiredPosition = CameraTarget.position + Quaternion.Euler(ElevationAngle, OrbitalAngle, 0f) * new Vector3(0, 0, -FollowDistance);
                }
                else if (CameraMode == CameraModes.Follow)
                {
                    desiredPosition = CameraTarget.position + CameraTarget.TransformDirection(Quaternion.Euler(ElevationAngle, OrbitalAngle, 0f) * (new Vector3(0, 0, -FollowDistance)));
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }
                else
                {
                    // Free Camera implementation
                }

<<<<<<< HEAD
                if (movementSmoothing == true)
                {
                    // Using Smoothing
                    cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, desiredPosition, ref currentVelocity, movementSmoothingValue * Time.fixedDeltaTime);
=======
                if (MovementSmoothing == true)
                {
                    // Using Smoothing
                    cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, desiredPosition, ref currentVelocity, MovementSmoothingValue * Time.fixedDeltaTime);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    //cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, Time.deltaTime * 5.0f);
                }
                else
                {
                    // Not using Smoothing
                    cameraTransform.position = desiredPosition;
                }

<<<<<<< HEAD
                if (rotationSmoothing == true)
                    cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.LookRotation(cameraTarget.position - cameraTransform.position), rotationSmoothingValue * Time.deltaTime);
                else
                {
                    cameraTransform.LookAt(cameraTarget);
=======
                if (RotationSmoothing == true)
                    cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.LookRotation(CameraTarget.position - cameraTransform.position), RotationSmoothingValue * Time.deltaTime);
                else
                {
                    cameraTransform.LookAt(CameraTarget);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }

            }

        }



        void GetPlayerInput()
        {
            moveVector = Vector3.zero;

            // Check Mouse Wheel Input prior to Shift Key so we can apply multiplier on Shift for Scrolling
            mouseWheel = Input.GetAxis("Mouse ScrollWheel");

            float touchCount = Input.touchCount;

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || touchCount > 0)
            {
                mouseWheel *= 10;

                if (Input.GetKeyDown(KeyCode.I))
<<<<<<< HEAD
                    cameraMode = CameraModes.Isometric;

                if (Input.GetKeyDown(KeyCode.F))
                    cameraMode = CameraModes.Follow;

                if (Input.GetKeyDown(KeyCode.S))
                    movementSmoothing = !movementSmoothing;
=======
                    CameraMode = CameraModes.Isometric;

                if (Input.GetKeyDown(KeyCode.F))
                    CameraMode = CameraModes.Follow;

                if (Input.GetKeyDown(KeyCode.S))
                    MovementSmoothing = !MovementSmoothing;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


                // Check for right mouse button to change camera follow and elevation angle
                if (Input.GetMouseButton(1))
                {
                    mouseY = Input.GetAxis("Mouse Y");
                    mouseX = Input.GetAxis("Mouse X");

                    if (mouseY > 0.01f || mouseY < -0.01f)
                    {
<<<<<<< HEAD
                        elevationAngle -= mouseY * moveSensitivity;
                        // Limit Elevation angle between min & max values.
                        elevationAngle = Mathf.Clamp(elevationAngle, minElevationAngle, maxElevationAngle);
=======
                        ElevationAngle -= mouseY * MoveSensitivity;
                        // Limit Elevation angle between min & max values.
                        ElevationAngle = Mathf.Clamp(ElevationAngle, MinElevationAngle, MaxElevationAngle);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    }

                    if (mouseX > 0.01f || mouseX < -0.01f)
                    {
<<<<<<< HEAD
                        orbitalAngle += mouseX * moveSensitivity;
                        if (orbitalAngle > 360)
                            orbitalAngle -= 360;
                        if (orbitalAngle < 0)
                            orbitalAngle += 360;
=======
                        OrbitalAngle += mouseX * MoveSensitivity;
                        if (OrbitalAngle > 360)
                            OrbitalAngle -= 360;
                        if (OrbitalAngle < 0)
                            OrbitalAngle += 360;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    }
                }

                // Get Input from Mobile Device
                if (touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;

                    // Handle elevation changes
                    if (deltaPosition.y > 0.01f || deltaPosition.y < -0.01f)
                    {
<<<<<<< HEAD
                        elevationAngle -= deltaPosition.y * 0.1f;
                        // Limit Elevation angle between min & max values.
                        elevationAngle = Mathf.Clamp(elevationAngle, minElevationAngle, maxElevationAngle);
=======
                        ElevationAngle -= deltaPosition.y * 0.1f;
                        // Limit Elevation angle between min & max values.
                        ElevationAngle = Mathf.Clamp(ElevationAngle, MinElevationAngle, MaxElevationAngle);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    }


                    // Handle left & right 
                    if (deltaPosition.x > 0.01f || deltaPosition.x < -0.01f)
                    {
<<<<<<< HEAD
                        orbitalAngle += deltaPosition.x * 0.1f;
                        if (orbitalAngle > 360)
                            orbitalAngle -= 360;
                        if (orbitalAngle < 0)
                            orbitalAngle += 360;
=======
                        OrbitalAngle += deltaPosition.x * 0.1f;
                        if (OrbitalAngle > 360)
                            OrbitalAngle -= 360;
                        if (OrbitalAngle < 0)
                            OrbitalAngle += 360;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    }

                }

                // Check for left mouse button to select a new CameraTarget or to reset Follow position
                if (Input.GetMouseButton(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 300, 1 << 10 | 1 << 11 | 1 << 12 | 1 << 14))
                    {
<<<<<<< HEAD
                        if (hit.transform == cameraTarget)
                        {
                            // Reset Follow Position
                            orbitalAngle = 0;
                        }
                        else
                        {
                            cameraTarget = hit.transform;
                            orbitalAngle = 0;
                            movementSmoothing = previousSmoothing;
=======
                        if (hit.transform == CameraTarget)
                        {
                            // Reset Follow Position
                            OrbitalAngle = 0;
                        }
                        else
                        {
                            CameraTarget = hit.transform;
                            OrbitalAngle = 0;
                            MovementSmoothing = previousSmoothing;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                        }

                    }
                }


                if (Input.GetMouseButton(2))
                {
                    if (dummyTarget == null)
                    {
                        // We need a Dummy Target to anchor the Camera
                        dummyTarget = new GameObject("Camera Target").transform;
<<<<<<< HEAD
                        dummyTarget.position = cameraTarget.position;
                        dummyTarget.rotation = cameraTarget.rotation;
                        cameraTarget = dummyTarget;
                        previousSmoothing = movementSmoothing;
                        movementSmoothing = false;
                    }
                    else if (dummyTarget != cameraTarget)
                    {
                        // Move DummyTarget to CameraTarget
                        dummyTarget.position = cameraTarget.position;
                        dummyTarget.rotation = cameraTarget.rotation;
                        cameraTarget = dummyTarget;
                        previousSmoothing = movementSmoothing;
                        movementSmoothing = false;
=======
                        dummyTarget.position = CameraTarget.position;
                        dummyTarget.rotation = CameraTarget.rotation;
                        CameraTarget = dummyTarget;
                        previousSmoothing = MovementSmoothing;
                        MovementSmoothing = false;
                    }
                    else if (dummyTarget != CameraTarget)
                    {
                        // Move DummyTarget to CameraTarget
                        dummyTarget.position = CameraTarget.position;
                        dummyTarget.rotation = CameraTarget.rotation;
                        CameraTarget = dummyTarget;
                        previousSmoothing = MovementSmoothing;
                        MovementSmoothing = false;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                    }


                    mouseY = Input.GetAxis("Mouse Y");
                    mouseX = Input.GetAxis("Mouse X");

                    moveVector = cameraTransform.TransformDirection(mouseX, mouseY, 0);

                    dummyTarget.Translate(-moveVector, Space.World);

                }

            }

            // Check Pinching to Zoom in - out on Mobile device
            if (touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);

                Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

                float prevTouchDelta = (touch0PrevPos - touch1PrevPos).magnitude;
                float touchDelta = (touch0.position - touch1.position).magnitude;

                float zoomDelta = prevTouchDelta - touchDelta;

                if (zoomDelta > 0.01f || zoomDelta < -0.01f)
                {
<<<<<<< HEAD
                    followDistance += zoomDelta * 0.25f;
                    // Limit FollowDistance between min & max values.
                    followDistance = Mathf.Clamp(followDistance, minFollowDistance, maxFollowDistance);
=======
                    FollowDistance += zoomDelta * 0.25f;
                    // Limit FollowDistance between min & max values.
                    FollowDistance = Mathf.Clamp(FollowDistance, MinFollowDistance, MaxFollowDistance);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                }


            }

            // Check MouseWheel to Zoom in-out
            if (mouseWheel < -0.01f || mouseWheel > 0.01f)
            {

<<<<<<< HEAD
                followDistance -= mouseWheel * 5.0f;
                // Limit FollowDistance between min & max values.
                followDistance = Mathf.Clamp(followDistance, minFollowDistance, maxFollowDistance);
=======
                FollowDistance -= mouseWheel * 5.0f;
                // Limit FollowDistance between min & max values.
                FollowDistance = Mathf.Clamp(FollowDistance, MinFollowDistance, MaxFollowDistance);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
            }


        }
    }
}