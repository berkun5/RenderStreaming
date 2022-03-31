using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Unity.RenderStreaming.Samples
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject cube;

        [SerializeField] GameObject player;
        [SerializeField] GameObject cameraPivot;
        [SerializeField] public InputReceiver playerInput;
        [SerializeField] TextMesh label;
        [SerializeField] GameObject captionForMobile;
        [SerializeField] GameObject captionForDesktop;

        [SerializeField] float moveSpeed = 10f;
        [SerializeField] float rotateSpeed = 10f;
        [SerializeField] float jumpSpeed = 500f;

        const float CooldownJump = 1.2f; // second

        Vector2 inputMovement;
        Vector2 inputLook;
        Vector3 initialPosition;
        bool inputJump;
        float cooldownJumpDelta = CooldownJump;

        protected void Awake()
        {
            playerInput.onDeviceChange += OnDeviceChange;
            initialPosition = transform.position;
            _eventSystem = FindObjectOfType<EventSystem>();
        }


        public void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            switch (change)
            {
                case InputDeviceChange.Added:
                    {
                        playerInput.PerformPairingWithDevice(device);
                        CheckPairedDevices();
                        return;
                    }
                case InputDeviceChange.Removed:
                    {
                        playerInput.UnpairDevices(device);
                        CheckPairedDevices();
                        return;
                    }
            }
        }

        public void CheckPairedDevices()
        {
            if (!playerInput.user.valid)
                return;

            bool hasTouchscreenDevice =
                playerInput.user.pairedDevices.Count(_ => _.path.Contains("Touchscreen")) > 0;
            captionForMobile.SetActive(hasTouchscreenDevice);
            captionForDesktop.SetActive(!hasTouchscreenDevice);
        }

        private void Update()
        {
            var forwardDirection = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
            var moveForward = forwardDirection * new Vector3(0f, 0f, inputMovement.y);

            bool isJumping = player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump");
            
            Debug.Log(isJumping);
            if (!isJumping)
            {
                player.transform.position += moveForward * moveSpeed * Time.deltaTime;
            }
            
            if (!isJumping && inputMovement.y > .1f && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run") == false)
            {
                player.GetComponent<Animator>().SetTrigger("Run");
            }
            else if (!isJumping && Mathf.Approximately(inputMovement.y,0f) && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                player.GetComponent<Animator>().SetTrigger("Idle");
            }

            if (inputMovement.x > 0)
            {
                player.transform.RotateAround(player.transform.position,new Vector3(0f,inputMovement.x,0f),360f * Time.deltaTime);
            }
            else if (inputMovement.x < 0)
            {
                player.transform.RotateAround(player.transform.position,new Vector3(0f,inputMovement.x,0f),360f * Time.deltaTime);
            }

            var moveAngles = new Vector3(-inputLook.y, inputLook.x);
            var newAngles = cameraPivot.transform.localEulerAngles + moveAngles * Time.deltaTime * rotateSpeed;
            cameraPivot.transform.localEulerAngles = new Vector3(Mathf.Clamp(newAngles.x, 0, 45), newAngles.y, 0);

            if (inputJump && cooldownJumpDelta <= 0.0f)
            {
                // var jumpForward = forwardDirection * new Vector3(0, 1f, 0);
                // player.GetComponent<Rigidbody>().AddForce(jumpForward * jumpSpeed);
                player.GetComponent<Animator>().SetTrigger("Jump");
                Debug.Log("jumped");
                isJumping = true;
                cooldownJumpDelta = CooldownJump;
            }

            // jump cooldown
            if (cooldownJumpDelta >= 0.0f)
            {
                inputJump = false;
                isJumping = false;
                cooldownJumpDelta -= Time.deltaTime;
            }

            // reset if the ball fall down from the floor
            if (player.transform.position.y < -5)
            {
                player.transform.position = initialPosition;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public void SetLabel(string text)
        {
            label.text = text;
        }

        public void OnControlsChanged()
        {
        }

        public void OnDeviceLost()
        {
        }

        public void OnDeviceRegained()
        {
        }

        Vector2 mousePos;
        public void CubeTog(InputAction.CallbackContext value)
        {

            if (value.performed)
            {
                //IF click position is at right left corner of the screen
                if (cube.activeInHierarchy)
                {
                    cube.SetActive(false);
                }
                else { cube.SetActive(true); }
                //mousePos = value.ReadValue<Vector2>();
            }
            GetRay();
        }

        public void OnMovement(InputAction.CallbackContext value)
        {
            inputMovement = value.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext value)
        {
            inputLook = value.ReadValue<Vector2>();
        }


        public void OnJump(InputAction.CallbackContext value)
        {
            Debug.Log(value.action.id);
            Debug.Log(value.action.GetBindingIndex());
            if (value.performed)
            {
                inputJump = true;
            }
        }

        [SerializeField] private GraphicRaycaster _raycaster;
        private PointerEventData _pointerEventData;
        private List<RaycastResult> _results = new List<RaycastResult>();
        private RaycastResult _raycastResult;
        private EventSystem _eventSystem;
        private void GetRay()
        {
            _pointerEventData = new PointerEventData(_eventSystem);
            //_pointerEventData.position = Input.mousePosition;
            _raycaster.Raycast(_pointerEventData, _results);
            foreach (RaycastResult raycastRes in _results)
            {
                Debug.Log("Raycast Result: " + raycastRes);
            }
        }
    }
}
