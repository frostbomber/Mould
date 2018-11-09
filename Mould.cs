using ArcOrange.Mould.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcOrange.Mould
{
    public class Mould<T> where T : struct, IComparable
    {
        public List<MouldItem<T>> Items { get; set; }
        public List<List<IRelationship>> Relationships { get; set; }
        public MouldItem<T> Root { get; set; }

        public Mould()
        {
            Root = new MouldItem<T>() { Level = -1, Parent = -1, Value = default(T) };
            Items = new List<MouldItem<T>>();
            Items.Add(Root);
            Relationships = new List<List<IRelationship>>();
        }

        public Mould(List<MouldItem<T>> items)
        {
            Items = items;
            Items.Insert(0, Root);
        }

        public Mould<T> SubMould(int index)
        {
            int finalIndex = FindTargetIndex(index);

            return new Mould<T>(Items.Skip(index).Take(finalIndex - index).ToList()) { Relationships = Relationships.Skip(index).Take(finalIndex - index).ToList() };
        }

        public Mould<T> MouldFrom(MouldItem<T> element)
        {
            int index = Items.IndexOf(element);
            return SubMould(index);
        }

        public IEnumerable<MouldItem<T>> Clone(List<IMouldable<T>> source)
        {
            //cheeky way of manufacturing a new MouldItem for each MouldItem in the Items list
            return source.Join(Items, l => 1, m => 1, (l, m) => new MouldItem<T>() { Value = m.Value });
        }

        public IEnumerable<IEnumerable<T>> Match(List<IMouldable<T>> source)
        {
            return source.GroupJoin(Items, l => l.Value, m => m.Value, (l, m) => m.Select(i => i.Value));
        }

        private int FindTargetIndex(int start)
        {
            if (start == -1)
                return Items.Last().Index;

            var item = Items[start];
            var sib = item.NextSibling;
            if (sib == null)
                FindTargetIndex(item.Parent);

            return Items.IndexOf(sib);
        }
    }
}
