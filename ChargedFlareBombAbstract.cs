using Fisobs.Core;
using System;
using UnityEngine;

namespace ChargedFlareBomb
{
    sealed class ChargedFlareBombAbstract(World world, PhysicalObject realizedObject, WorldCoordinate pos, EntityID ID, int originRoom, int placedObjectIndex, PlacedObject.ConsumableObjectData consumableObjectData) : AbstractConsumable(world, ChargedFlareBombFisob.AbstractChargedFlareBomb, realizedObject, pos, ID, originRoom, placedObjectIndex, consumableObjectData)
    {
        public override void Realize()
        {
            base.Realize();
            realizedObject ??= new ChargedFlareBomb(this, world);
        }
    }

}
