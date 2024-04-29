using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class CubeCreator : MonoBehaviour
{
    [SerializeField] private ClickReader _click;
    [SerializeField] private Chancer _chancer;

    private int _devider = 2;
    private float _percentDivision;
    private MeshRenderer _meshRenderer;
    private Vector3 _currentScale;

    public event Action PercentChanged;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentScale = transform.localScale;
    }

    private void Start()
    {
        _percentDivision = _chancer.Percent;
        SetColor(UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
    }

    private void OnEnable() => _click.MousePressed += Start—reation;

    private void OnDisable() => _click.MousePressed -= Start—reation;

    private void Start—reation()
    {
        float maxPercentForDivision = 101;
        float percentForDivision = UnityEngine.Random.Range(0, maxPercentForDivision);

        if (percentForDivision <= _percentDivision)
        {
            PercentChanged?.Invoke();
            CreateCubes();
        }

        Destroy(gameObject);
    }

    private void CreateCubes()
    {
        int minCountCubes = 2;
        int maxCountCubes = 7;

        int countCubes = UnityEngine.Random.Range(minCountCubes, maxCountCubes);

        SetScale();

        for (int i = 0; i < countCubes; i++)
            Instantiate(this.gameObject);
    }

    private void SetScale() => transform.localScale = _currentScale / _devider;

    private void SetColor(Color newColor) => _meshRenderer.material.color = newColor;
}