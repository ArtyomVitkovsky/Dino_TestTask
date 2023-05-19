using Modules.Game.Scripts;
using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Player
{
    public class PlayerCamera : CameraFollower
    {
        [SerializeField] private Camera camera;

        private Vector3 lookPoint;
        
        private Unit.Player.Player playerUnit;

        public Camera Camera => camera;


        [Inject]
        private void Construct(Unit.Player.Player player)
        {
            SetPlayerUnit(player);
        }

        private void SetPlayerUnit(Unit.Player.Player playerUnit)
        {
            this.playerUnit = playerUnit;
            SetFollowTarget(this.playerUnit.transform);
        }

    }
}