using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pom.Pom;

namespace ChargedFlareBomb
{
    internal class ChargedFlareBombData(PlacedObject owner) : ManagedData(owner, null)
    {
        [IntegerField(nameof(MinCycles), 0, 20, 0, ManagedFieldWithPanel.ControlType.slider, "Min Cycles")]
        public int MinCycles;

        [IntegerField(nameof(MaxCycles), 0, 20, 0, ManagedFieldWithPanel.ControlType.slider, "Max Cycles")]
        public int MaxCycles;
    }

    internal class ChargedFlareBombObject : UpdatableAndDeletable
    {
        public ChargedFlareBombObject(Room room, PlacedObject placedObject)
        {
            if (room.abstractRoom.firstTimeRealized)
            {
                int objIndex = room.roomSettings.placedObjects.IndexOf(placedObject);
                ChargedFlareBombData data = (ChargedFlareBombData)placedObject.data;

                if (room.game.session is not StoryGameSession session || !session.saveState.ItemConsumed(room.world, false, room.abstractRoom.index, objIndex))
                {
                    AbstractConsumable obj = new(room.world, ChargedFlareBombFisob.AbstractChargedFlareBomb, null, room.GetWorldCoordinate(placedObject.pos), room.game.GetNewID(), room.abstractRoom.index, objIndex, new PlacedObject.ConsumableObjectData(placedObject))
                    {
                        isConsumed = false,
                        minCycles = data.MinCycles,
                        maxCycles = data.MaxCycles
                    };

                    obj = new ChargedFlareBombAbstract(room.world, null, room.GetWorldCoordinate(placedObject.pos), room.game.GetNewID(), room.abstractRoom.index, objIndex, new PlacedObject.ConsumableObjectData(placedObject));

                    room.abstractRoom.entities.Add(obj);
                }
            }

            Destroy();
        }
    }
}
