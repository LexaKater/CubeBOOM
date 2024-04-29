using UnityEngine;

public class Chancer : MonoBehaviour
{
    [SerializeField] private CubeCreator[] cubeCreator;

    private float _devider = 2;

    public float Percent = 100;

    private void OnEnable()
    {
        for (int i = 0; i < cubeCreator.Length; i++)
            cubeCreator[i].PercentChanged += ReducePercent;
    }

    private void OnDisable()
    {
        for (int i = 0; i < cubeCreator.Length; i++)
            cubeCreator[i].PercentChanged -= ReducePercent;
    }

    private void ReducePercent() => Percent /= _devider;
}