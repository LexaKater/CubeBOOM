using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ClickReader _click;
    [SerializeField] private CubeCreator _creator;

    private float _percentForDevide = 100;
    private int _devider = 2;
    private MeshRenderer _meshRenderer;
    private Vector3 _currentScale;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentScale = transform.localScale;
    }

    private void Start() => SetColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));

    private void OnEnable() => _click.MousePressed += OnClicked;

    private void OnDisable() => _click.MousePressed -= OnClicked;

    public void SetPercent(float percent) => _percentForDevide = percent;

    private void OnClicked()
    {
        SetScale();

        float maxPercentForDivision = 101;
        float percentForDivision = Random.Range(0, maxPercentForDivision);

        if (percentForDivision <= _percentForDevide)
        {
            _percentForDevide /= _devider;
            Debug.Log(_percentForDevide);

            _creator.Create(this.gameObject.GetComponent<Cube>(), _percentForDevide);
        }

        Destroy(gameObject);
    }

    private void SetScale() => transform.localScale = _currentScale / _devider;

    private void SetColor(Color newColor) => _meshRenderer.material.color = newColor;
}