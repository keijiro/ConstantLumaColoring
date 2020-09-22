using UnityEngine;

sealed class Test : MonoBehaviour
{
    [SerializeField] GameObject _prefab = null;
    [SerializeField] int _count = 20;

    void Start()
    {
        for (var i = 0; i < _count; i++)
        {
            var pos = new Vector3(i - _count / 2 + 0.5f, 0, 0);
            var go = GameObject.Instantiate(_prefab, pos, Quaternion.identity);
            var mat = go.GetComponent<Renderer>().material;
            mat.color = Color.HSVToRGB((float)i / _count, 1, 1);
            mat.color = NormalizeLuma(mat.color);
        }
    }

    Color NormalizeLuma(Color c)
    {
        var luma = 0.299f * c.r + 0.587f * c.g + 0.114f * c.b;
        luma = Mathf.Pow(luma, 1.0f / 2.2f);
        return c * 0.37f / luma;
    }
}
