using System.Collections;
using System.Collections.Generic;

namespace BJ.MongoDB.Logger
{
    public sealed class Properties
    {
        #region Fields

        private readonly Dictionary<string, string> _properties = new Dictionary<string, string>();

        #endregion


        #region Constructors

        public Properties() {}

        public Properties(string key, string value)
        {
            Add(key, value);
        }

        #endregion


        #region Properties

        public Dictionary<string, string> PropsDictionary 
        {
            get { return _properties; }
        }

        public ICollection Keys
        {
            get { return _properties.Keys; }
        }

        public string this[string key]
        {
            get 
            {
                return _properties[key];
            }

            set
            {
                _properties[key] = value;
            }
        }

        #endregion


        #region Methods

        public void Add(string key, string value)
        {
            _properties.Add(key, value);
        }

        public void Clear()
        {
            _properties.Clear();
        }

        public bool Remove(string key)
        {
            return _properties.Remove(key);
        }

        #endregion
    }
}
