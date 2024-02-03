using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    [SerializeField] public GameObject Blood;
    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }


   private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == triggeringTag && enabled) {
            Instantiate(Blood,transform.position,Quaternion.identity);
            ReturnToStart();
        }
    }

    private void ReturnToStart() {
        transform.position = startPosition;
    }
    private void Update() {

    }
}