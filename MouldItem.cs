using ArcOrange.Mould.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcOrange.Mould
{
    public class MouldItem<T> : IMouldable<T> where T : struct, IComparable
    {
        public int Parent { get; set; }
        public MouldItem<T> NextSibling { get; set; }
        public int Level { get; set; }
        public int Index { get; set; }
        public T Value { get; set; }
        public Mould<T> Mould { get; set; }
        private List<MouldItem<T>> _PendingSiblings { get; set; }

        private int children;

        public MouldItem()
        {
            NextSibling = null;
        }

        public void AddChild(MouldItem<T> newChild, T newChildValue)
        {
            newChild.Parent = Index;
            newChild.Level = Level + 1;
            newChild.Index = Index + 1;
            newChild.Value = newChildValue;
            if (children == 0)
                Mould.Items.Add(newChild);
            else
                Mould.Items.Insert(Index + children, newChild);
            children++;
            if (children > 1)
                newChild.NextSibling = Mould.Items[Index + children];
        }
    }
}
