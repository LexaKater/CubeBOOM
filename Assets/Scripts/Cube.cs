using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(MeshRenderer)))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ClickReader _click;
    [SerializeField] private CubeCreator _creator;
    [SerializeField] private Explosion _explosion;

    public float ExplosForce { get; private set; } = 100;
    public float ExplosRadius { get; private set; } = 10;
    public float PercentForDevide { get; private set; } = 100;

    private MeshRenderer _meshRenderer;
    private Rigidbody _rbCube;
    private Vector3 _currentScale;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rbCube = GetComponent<Rigidbody>();
        _currentScale = transform.localScale;
    }

    private void Start() => SetColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));

    private void OnEnable() => _click.MousePressed += OnClicked;

    private void OnDisable() => _click.MousePressed -= OnClicked;

    public void Init(float percent, float explosForce, float explosRadius)
    {
        PercentForDevide = percent;
        ExplosForce = explosForce;
        ExplosRadius = explosRadius;
    }

    private void OnClicked()
    {
        SetScale();

        float maxPercentForDivision = 101;
        float percentForDivision = Random.Range(0, maxPercentForDivision);

        if (percentForDivision <= PercentForDevide)
            _creator.Create(this.gameObject.GetComponent<Cube>());
        else
            _explosion.Explode(_rbCube, ExplosForce, ExplosRadius);

        Destroy(gameObject);
    }

    private void SetScale()
    {
        float devider = 2;

        transform.localScale = _currentScale / devider;
    }

    private void SetColor(Color newColor) => _meshRenderer.material.color = newColor;
}