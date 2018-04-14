using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : Singleton<PenController>
{
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
    }

    public Vector3 GetTipPosition()
    {
        return Tip.transform.position;
    }

    public void Update()
    {
        var input = InputController.Instance.GetXBoxInput();
        float perlinNoise = Mathf.PerlinNoise(perlinNoiseCoordinate.x, perlinNoiseCoordinate.y);
        float perlinNoiseRange = perlinNoise * 2 - 1;
        var movement =
            transform.forward * input.RightStick.y * MovementSpeed * Time.deltaTime +
            transform.right * input.LeftStick.x * MovementSpeed * Time.deltaTime +
            transform.up * input.LeftStick.y * MovementSpeed * Time.deltaTime +
            transform.forward * BaseSpeed * Time.deltaTime +
            ((transform.up * (1 - perlinNoise)) + (transform.right * perlinNoise)).normalized * perlinNoiseRange * MovmentBias * Time.deltaTime +
            transform.forward * Random.Range(-0.9f, 1) * HorizontalShakiness * Time.deltaTime +
            transform.up * Random.Range(-0.9f, 1) * VerticalShakiness * Time.deltaTime;

        DistanceMoved = movement.sqrMagnitude;
        transform.position += movement;
        perlinNoiseCoordinate.x += 0.5f * Time.deltaTime;
    }

}
