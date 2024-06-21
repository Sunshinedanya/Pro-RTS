using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data.Configurable
{
    public class ConfigLoader : MonoBehaviour
    {
        [SerializeField] private List<ConfigurableScriptableObject> _configs;
        void Start()
        {
            Load();
        }

        private void OnDestroy()
        {
            Save();
        }

        private void Load()
        {
            foreach (var config in _configs)
            {
                config.Load();
            }
        }

        private void Save()
        {
            foreach (var config in _configs)
            {
                config.Save();
            }
        }
    }
}