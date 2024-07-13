using Fisobs.Core;
using System;
using UnityEngine;

namespace ChargedFlashbang
{
    sealed class ChargedFlashbangAbstract(World world, PhysicalObject realizedObject, WorldCoordinate pos, EntityID ID, int originRoom, int placedObjectIndex, PlacedObject.ConsumableObjectData consumableObjectData) : AbstractConsumable(world, ChargedFlashbangFisob.AbstractChargedFlashbang, realizedObject, pos, ID, originRoom, placedObjectIndex, consumableObjectData)
    {
        public override void Realize()
        {
            base.Realize();
            realizedObject ??= new ChargedFlashbang(this, world);
        }
    }

}
