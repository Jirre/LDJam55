using JvLib.Services;
using UnityEngine;

namespace Project.Gameplay
{
    [ServiceInterface(Name = "Gameplay")]
    public partial class GameplayServiceManager : MonoBehaviour, IService
    {
        public bool IsServiceReady { get; private set; }

        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        private void Start()
        {
            IsServiceReady = true;
            ServiceLocator.Instance.ReportInstanceReady(this);
        }
    }
}