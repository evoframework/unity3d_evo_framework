using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Evo
{
    [System.Serializable]
    public class MapList<T> : IList<T> where T : IEObject
    {
        Dictionary<Id, T> _list = new Dictionary<Id, T>();


        //private readonly IList<T> _list = new List<T>();

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {

            var listValue = new List<T>(_list.Values);


            return listValue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<T>

        public void Add(T item)
        {


            _list.Add(item.iD, item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.ContainsKey(item.iD);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //_list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item.iD);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }//_list.IsReadOnly; }
        }


        #endregion

        #region Implementation of IList<T>

        public int IndexOf(T item)
        {
            return -1;//_list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {

            _list.Add(new Id(index.ToString()), item);
        }

        public void RemoveAt(int index)
        {
            _list.Remove(new Id(index.ToString()));
        }

        public T this[int index]
        {
            get { return _list[new Id(index.ToString())]; }
            set { _list[new Id(index.ToString())] = value; }


        }

        #endregion
    }
}

