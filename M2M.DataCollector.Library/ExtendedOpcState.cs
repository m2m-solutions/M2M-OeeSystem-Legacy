using OPCDA.NET;
using System;
using System.Linq;
using M2M.DataCenter.OPC;

namespace M2M.DataCollector.Library
{
    public class ExtendedOpcState
    {
        public TagDefinitionList.TagDefinition Tag { get; set; }
        public OPCItemState State { get; set; }

        public ExtendedOpcState(OPCItemState state, TagDefinitionList.TagDefinition tag)
        {
            this.State = state;
            this.Tag = tag;
        }
    }
}
