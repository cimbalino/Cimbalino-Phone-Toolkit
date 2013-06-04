// ****************************************************************************
// <copyright file="MutexLock.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>11-03-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Allows for inter-process locking and synchronization.
    /// </summary>
    public sealed class MutexLock : IDisposable
    {
        private readonly Mutex _mutex;

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MutexLock"/> class.
        /// </summary>
        /// <param name="name">The name of the Mutex.</param>
        public MutexLock(string name)
        {
            _mutex = new Mutex(false, name);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MutexLock" /> class.
        /// </summary>
        ~MutexLock()
        {
            Dispose();
        }

        /// <summary>
        /// Locks the Mutex and returns an <see cref="IDisposable"/> object that when disposed will release the Mutex.
        /// </summary>
        /// <returns>An <see cref="IDisposable"/> object that when disposed will release the Mutex.</returns>
        public IDisposable Lock()
        {
#if WP8
            try
            {
                _mutex.WaitOne();
            }
            catch //there is no pratical of of knowing if the Mutex was abandoned as WP8 does not throw the AbandonedMutexException
            {
            }
#else
            _mutex.WaitOne();
#endif

            return new Releaser(this);
        }

        /// <summary>
        /// Releases the resources allocated by this <see cref="MutexLock"/> instance.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;

                _mutex.Dispose();
            }
        }

        private class Releaser : IDisposable
        {
            private readonly MutexLock _mutexLock;

            internal Releaser(MutexLock mutexLock)
            {
                _mutexLock = mutexLock;
            }

            public void Dispose()
            {
                _mutexLock._mutex.ReleaseMutex();
            }
        }
    }
}