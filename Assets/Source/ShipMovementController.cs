using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody2D selfRB;
    private Camera mainCamera;

    [SerializeField]
    private float speedFactor;

    [Header("Bullet settings")]
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private SimpleBulletController bullet;
    // Start is called before the first frame update
    void Start()
    {
        selfRB = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);

        Move();
        TryFire();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {

            selfRB.velocity = transform.up * speedFactor;
        }

        if(Input.GetKeyUp(KeyCode.W)){
            selfRB.velocity = Vector2.zero;
        }
    }

    void TryFire(){
        if (Input.GetMouseButtonDown(0)){
            FireMultiple();
        }
    }

    void Fire(){
            SimpleBulletController bulletInstance = GameObject.Instantiate<SimpleBulletController>(bullet);
            bulletInstance.transform.position = firePoint.position;
            bulletInstance.transform.rotation = transform.rotation;
            bulletInstance.transform.eulerAngles += Vector3.forward * UnityEngine.Random.Range(-5f, 5f);

            bulletInstance.Fire(bulletInstance.transform.up, 1000);
    }

    void FireMultiple(){
        for (int i = 0; i < 10; i++){   
            Fire();
        }
    }
}
