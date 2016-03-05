using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SECalc.Data
{
    public class BlockDefinition : GlueDefinition<Block>
    {
        public Block Block { get { return Object; } }
    }
}
