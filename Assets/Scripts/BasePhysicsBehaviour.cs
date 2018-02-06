using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BasePhysicsBehaviour : MonoBehaviour {
    public bool UseGravity = true;
    public float AirFadeout = 0.1f;
    public float GroundFadeout = 5f;

    float gap = 0.01f;

    private Vector3 gravity;
    private BoxCollider boxCollider;
    private Vector3 momentum;
    private bool IsGrounded;

    // Use this for initialization
    void Start () {
        gravity = Physics.gravity;
        momentum = new Vector3();
        boxCollider = GetComponent<BoxCollider>();
        //AddForce(Vector3.right * 0.5f);
    }
	
	void Update () {
        IsGrounded = false;

        if (UseGravity)
            HandleGravity();

        HandleCollisions();

        HandleFadeout();

        transform.Translate(momentum);
    }

    public void AddForce(Vector3 force)
    {
        momentum += force;
    }

    private void HandleFadeout()
    {
        momentum = Vector3.MoveTowards(momentum, new Vector3(), (IsGrounded ? GroundFadeout : AirFadeout) * Time.deltaTime);
    }

    private void HandleGravity()
    {
        momentum += Time.deltaTime * gravity / 8;
    }

    private void HandleCollisions()
    {
        if (momentum.x != 0)
        {
            var hit = DetectCollisionInDirection(new Vector3(momentum.x > 0 ? 1 : -1, 0, 0), Mathf.Abs(momentum.x));

            if(hit.distance > 0)
            {
                var sign = 1;

                if (momentum.x < 0)
                    sign = -1;

                momentum.x = 0;
                transform.Translate(Vector3.right * (hit.distance - gap) * sign);
            }
        }

        if (momentum.y != 0)
        {
            var hit = DetectCollisionInDirection(new Vector3(0, momentum.y > 0 ? 1 : -1, 0), Mathf.Abs(momentum.y));

            if (hit.distance > 0)
            {
                var sign = 1;

                if (momentum.y < 0)
                    sign = -1;

                momentum.y = 0;
                transform.Translate(Vector3.up * (hit.distance - gap) * sign);
                IsGrounded = true;
            }
        }

        if (momentum.z != 0)
        {
            var hit = DetectCollisionInDirection(new Vector3(0, 0, momentum.z > 0 ? 1 : -1), Mathf.Abs(momentum.z));

            if (hit.distance > 0)
            {
                var sign = 1;

                if (momentum.z < 0)
                    sign = -1;

                momentum.z = 0;
                transform.Translate(Vector3.forward * (hit.distance - gap) * sign);
            }
        }
    }

    private RaycastHit DetectCollisionInDirection(Vector3 direction, float maxDistance)
    {
        RaycastHit result = new RaycastHit();
        var disposition = boxCollider.size / 2;
        var startPosition = new Vector3(disposition.x * direction.x, disposition.y * direction.y, disposition.z * direction.z);

        var layerMask = 1 << LayerMask.NameToLayer("Ground");

        Physics.Raycast(transform.position + startPosition, direction, out result, maxDistance + gap, layerMask);

        return result;
    }
}
