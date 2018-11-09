using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcOrange.Mould.Public
{
    public abstract class IRelationship
    {
        private int _Target;

        public int Target
        {
            get { return _Target; }
            set { _Target = value; }
        }

        private int _Source;

        public int Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        public int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
