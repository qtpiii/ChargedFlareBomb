using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pom.Pom;

namespace ChargedFlashbang
{
    internal class ChargedFlashbangData(PlacedObject owner) : ManagedData(owner, null)
    {
        [IntegerField(nameof(MinCycles), 0, 20, 0, ManagedFieldWithPanel.ControlType.slider, "Min Cycles")]
        public int MinCycles;

        [IntegerField(nameof(MaxCycles), 0, 20, 0, ManagedFieldWithPanel.ControlType.slider, "Max Cycles")]
        public int MaxCycles;
    }
}
