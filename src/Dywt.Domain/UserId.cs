using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.Domain
{
    public class UserId
    {
        private readonly string _value;

        public UserId(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        public static implicit operator UserId(string value)
        {
            return new UserId(value);
        }

        public static implicit operator string(UserId value)
        {
            return (value != null) ? value.Value : null;
        }

        public override string ToString()
        {
            return _value;
        }

        public override bool Equals(object obj)
        {
            var other = obj as UserId;

            return (other != null && other.Value.Equals(Value));
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
