using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    interface IFactory<T>
    {
        T Create(Transform parent);
    }
}