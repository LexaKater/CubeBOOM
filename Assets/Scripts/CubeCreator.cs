using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Explosion _explode;

    public void Create(Cube cube, float percent)
    {
        float minCountCube = 2;
        float maxCountCube = 7;

        float countCube = Random.Range(minCountCube, maxCountCube);

        for (int i = 0; i < countCube; i++)
        {
            Cube newCube = Instantiate(cube);
            newCube.SetPercent(percent);

            _explode.Explode(newCube.GetComponent<Rigidbody>());
        }
    }
}