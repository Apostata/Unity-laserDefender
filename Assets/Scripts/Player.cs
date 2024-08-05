using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    
    Dictionary<string, float> playerPadding;
    [SerializeField] int paddingBottomForUI = 1;
    [SerializeField] float speed = 5f;
    [SerializeField] int paddingTop = 5;

    Shooter shooter;

    void  Awake() {
        shooter = GetComponent<Shooter>();
    }


    void Start()
    {
        InitBounds();
        
    }

    void Update()
    {
        MoveShip();
    }

    void InitBounds () {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0)); // bottom left
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1)); // top right
        playerPadding = new Dictionary<string, float>
        {
            { "left", minBounds.x + gameObject.transform.localScale.x / 2 },
            { "right", maxBounds.x - gameObject.transform.localScale.x / 2 },
            { "top", maxBounds.y - paddingTop - gameObject.transform.localScale.y / 2 },
            { "bottom", minBounds.y + paddingBottomForUI + gameObject.transform.localScale.y / 2 }
        };
    }

    void MoveShip(){
        Vector3 delta = speed * Time.deltaTime * rawInput;
        Vector3 newPos = new Vector3
        {
            x = Mathf.Clamp(transform.position.x + delta.x, playerPadding["left"], playerPadding["right"]),
            y = Mathf.Clamp(transform.position.y + delta.y,playerPadding["bottom"], playerPadding["top"]),
        };
        transform.position = newPos;
    }

    void OnMove(InputValue value)

    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
