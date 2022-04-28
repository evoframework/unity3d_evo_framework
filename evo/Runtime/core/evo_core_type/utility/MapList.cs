using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class MapList<T> : IList<T> where T : IEObject
    {
        Dictionary<Id, T> _list = new Dictionary<Id, T>();


        //private readonly IList<T> _list = new List<T>();

        #region Implementation of IEnumerable

        /// <summary>
        /// 
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {

            var listValue = new List<T>(_list.Values);


            return listValue.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<T>

        /// <summary>
        /// 
        /// </summary>
        public void Add(T item)
        {


            _list.Add(item.iD, item);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Contains(T item)
        {
            return _list.ContainsKey(item.iD);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            //_list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Remove(T item)
        {
            return _list.Remove(item.iD);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }//_list.IsReadOnly; }
        }


        #endregion

        #region Implementation of IList<T>

        /// <summary>
        /// 
        /// </summary>
        public int IndexOf(T item)
        {
            return -1;//_list.IndexOf(item);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Insert(int index, T item)
        {

            _list.Add(new Id(index.ToString()), item);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveAt(int index)
        {
            _list.Remove(new Id(index.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        public T this[int index]
        {
            get { return _list[new Id(index.ToString())]; }
            set { _list[new Id(index.ToString())] = value; }
        }
        #endregion
    }
}

