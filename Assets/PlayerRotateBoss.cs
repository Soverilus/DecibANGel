using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateBoss : MonoBehaviour {
    public bool takeMouseInputs = false;
    public bool takeControllerInputs = false;
    public bool takeKeyboardInputs = false;

    float mouseMultiplier = 1f;
    float controllerMultiplier = 2f;
    float keyboardMultiplier = 2f;
    Vector2 myInputs;
    public float rotSpeed = 10f;
    float actualRotSpeed;
    public float boostMult;
    public float boostCooldown;
    public float boostDuration;
    float timer = 0;
    public float maxRotSpeed = 50;
    int myShields;
    public int maxShields;
    public ParticleSystem myPS;
    int myEmissionsMax;

    bool isAxisInUse = false;

    private void Start() {
        myEmissionsMax = myPS.main.maxParticles;
        myShields = maxShields;
        boostDuration *= -1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        CheckInputs();
        DoRotation();
    }

    void CheckInputs() {
        actualRotSpeed = rotSpeed;
        if (takeControllerInputs) {
            myInputs = new Vector2(Input.GetAxis("Controller X"), Input.GetAxis("Controller Y")) * controllerMultiplier;
            if (timer >= boostCooldown) {
                if (Input.GetAxis("Fire1") != 0) {
                    if (!isAxisInUse) {
                        timer = boostDuration;
                        isAxisInUse = true;
                    }
                }
                else {
                    isAxisInUse = false;
                }
            }
            else {
                timer += Time.deltaTime;
            }
        }
        else if (takeMouseInputs) {
            myInputs = new Vector2(Mathf.Clamp(myInputs.x,-maxRotSpeed,maxRotSpeed), Mathf.Clamp(myInputs.y, -maxRotSpeed, maxRotSpeed)) + new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseMultiplier;
            if (timer >= boostCooldown) {
                if (Input.GetAxis("Fire1") != 0) {
                    if (!isAxisInUse) {
                        timer = boostDuration;
                        isAxisInUse = true;
                    }
                }
                else {
                    isAxisInUse = false;
                }
            }
            else {
                timer += Time.deltaTime;
            }
        }
        else if (takeKeyboardInputs) {
            myInputs = new Vector2(Input.GetAxis("Keyboard X"), Input.GetAxis("Keyboard Y")) * keyboardMultiplier;
            if (timer >= boostCooldown) {
                if (Input.GetAxis("Fire1") != 0) {
                    if (!isAxisInUse) {
                        timer = boostDuration;
                        isAxisInUse = true;
                    }
                }
                else {
                    isAxisInUse = false;
                }
            }
            else {
                timer += Time.deltaTime;
            }
        }

        if (timer < 0) {
            actualRotSpeed *= boostMult;
        }
    }

    void DoRotation() {
        float rotX = Mathf.Clamp(myInputs.x * actualRotSpeed * Mathf.Deg2Rad, -maxRotSpeed, maxRotSpeed);
        float rotY = Mathf.Clamp(myInputs.y * actualRotSpeed * Mathf.Deg2Rad, -maxRotSpeed, maxRotSpeed);

        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, rotY);
    }

    void ShieldHandler() {
        
    }

    public void OnShieldHit() {
        if (myShields > 0) {
            myShields = -1;
        }
        else {
            //kill the player
        }
    }
}
