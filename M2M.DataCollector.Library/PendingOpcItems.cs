using System;
using System.Collections.Generic;
using System.Linq;

using OPCDA.NET;
using M2M.DataCenter.OPC;

namespace M2M.DataCollector.Library
{
    public class PendingOpcItems
    {
        private readonly Dictionary<string, List<OPCItemState>> opcItemStates = new Dictionary<string, List<OPCItemState>>();

        public PendingOpcItems(OPCItemState[] items, TagDefinitionList tagDefs)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                string machineId = tagDefs.GetByHandle(items[i].HandleClient).MachineId;

                if (!this.opcItemStates.ContainsKey(machineId))
                    this.opcItemStates.Add(machineId, new List<OPCItemState>());

                this.opcItemStates[machineId].Add(items[i]);
            }
        }

        public List<string> GetMachineIdList()
        {
            return this.opcItemStates.Keys.ToList();
        }

        public List<OPCItemState> GetOpcItems(string machineId)
        {
            if (!this.opcItemStates.ContainsKey(machineId))
                return new List<OPCItemState>();

            return this.opcItemStates[machineId];
        }
    }
}
