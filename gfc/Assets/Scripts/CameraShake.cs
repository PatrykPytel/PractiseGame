using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Myinstance;
    public AnimationCurve curve;
    public float ShakeTime = 1f;
    public GameObject player;
    public float cooldown;
    void Update() {
        if(player.GetComponent<Attacking>().timepassed>=cooldown) {
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                StartCoroutine(Shake());
            }
        }
    }
    private void Awake() {
        Myinstance = this;
    }
    public IEnumerator Shake() {
        Vector3 Startposition = transform.position;
        float TimeUsed = 0f;

        while(TimeUsed < ShakeTime) {
            TimeUsed += Time.deltaTime;
            float strength = curve.Evaluate (TimeUsed / ShakeTime);
            transform.position = Startposition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = Startposition;
    } 

}
