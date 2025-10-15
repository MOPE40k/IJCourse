using UnityEngine;
using Module_10_11_Homework.Controllers;
using Module_10_11_Homework.Inputs;

namespace Module_10_11_Homework.Characters
{
    public class PartnerCharacter : Character
    {
        [SerializeField] private CheckpointsController _checkpointController = null;

        protected override void InitInput()
            => input = new PartnerInput(this.transform, _checkpointController);
    }
}