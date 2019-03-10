using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PenController : Singleton<PenController>
{
    public bool DisableShakes = false;
    public GameObject Tip;
    public float MovementSpeed = 2;
    public float BaseSpeed = 0.3f;
    public float HorizontalShakiness = 1;
    public float VerticalShakiness = 1;
    public float MovmentBias = 1;

    private Vector2 perlinNoiseCoordinate = Vector2.zero;
    public float DistanceMoved { get; private set; }

    public void Start()
    {
        perlinNoiseCoordinate = Vector2.one * Random.value * 100;
        RandomPosition();

        ShapeManager.Instance.NewShape += RandomPosition;
    }

    public Vector3 GetTipPosition()
    {
        return Tip.transform.position;
    }

    public void RandomPosition()
    {
        var x = Random.Range(-3, 3);
        var y = Random.Range(-2, 2);
        transform.position = new Vector3(x, y, -7);
    }

    public void Update()
    {
        float perlinNoise = Mathf.PerlinNoise(perlinNoiseCoordinate.x, perlinNoiseCoordinate.y);
        float perlinNoiseRange = perlinNoise * 2 - 1;
        var movement =
            transform.forward * InputManager.Devices[1].RightStick.Y * MovementSpeed * Time.deltaTime +
            transform.right * InputManager.Devices[1].LeftStick.X * MovementSpeed * Time.deltaTime +
            transform.up * InputManager.Devices[1].LeftStick.Y * MovementSpeed * Time.deltaTime;
        if (!DisableShakes)
            movement += transform.forward * BaseSpeed * Time.deltaTime +
            ((transform.up * (1 - perlinNoise)) + (transform.right * perlinNoise)).normalized * perlinNoiseRange * MovmentBias * Time.deltaTime +
            transform.forward * Random.Range(-0.9f, 1) * HorizontalShakiness * Time.deltaTime +
            transform.up * Random.Range(-0.9f, 1) * VerticalShakiness * Time.deltaTime;

        DistanceMoved = movement.sqrMagnitude;
        transform.position += movement;
        perlinNoiseCoordinate.x += 0.5f * Time.deltaTime;
    }

}