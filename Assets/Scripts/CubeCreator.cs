using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(MeshRenderer)))]
public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;

    private float _devider = 2;
    private float _multiplier = 3;

    public void Create(Cube cube)
    {
        float minCountCube = 2;
        float maxCountCube = 7;

        float countCube = Random.Range(minCountCube, maxCountCube);

        for (int i = 0; i < countCube; i++)
        {
            Cube newCube = Instantiate(cube);

            float newPercent = cube.PercentForDevide / _devider;
            float newForce = cube.ExplosForce * _multiplier;
            float newRadius = cube.ExplosRadius * _multiplier;

            newCube.Init(newPercent, newForce, newRadius);

            _explosion.Explode(newCube.GetComponent<Rigidbody>());
        }
    }
}