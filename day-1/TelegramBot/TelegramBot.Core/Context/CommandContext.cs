using System;
using System.Collections.Generic;

namespace TelegramBot.Core.Context
{
    public class CommandContext : ICommandContext
    {
        private bool _isDisposed;
        private readonly Dictionary<string, object> _data;

        public CommandContext()
        {
            Offset = 0;
            _data = new Dictionary<string, object>();
            _isDisposed = false;
        }

        public int Offset { get; set; }
        public long ChatId { get; set; }

        public Guid? LastCommandId { get; set; }

        public object this[string key]
        {
            get
            {
                CheckDisposed();


                if (_data.ContainsKey(key))
                    return _data[key];

                throw new KeyNotFoundException($"Context does not contain key {key}");
            }
            set
            {
                CheckDisposed();

                if (_data.ContainsKey(key))
                    _data[key] = value;
                else
                    _data.Add(key, value);

            }
        }

        public void Dispose()
        {
            if (_isDisposed == false)
                _isDisposed = true;
        }

        private void CheckDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException("Context is disposed");
        }
    }
}
