namespace EstelApi.CrossCutting.Bus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;

    using MediatR;

    public static class Contract
    {
        public static void ThrowIfNullOrEmptyCollection<T>(IEnumerable<T> value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (!value.Any())
            {
                throw new ArgumentException(string.Format("[{0}] collection should contain at least one element.", parameterName));
            }
        }

        /// <summary>
        /// Checks that value is empty or null or whitespace. Throws ArgumentException in case if test passes.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <param name="parameterName">Parameter parameterName to specify in ArgumentException.</param>
        public static void ThrowIfEmptyString(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format("[{0}] parameter should be not empty.", parameterName));
            }
        }

        public static void ThrowIfNull(object value, string parameterName, IMediator bus)
        {
            if (value == null)
            {
                bus.Publish(
                    new DomainEvent(
                        parameterName,
                        "message is null")).ConfigureAwait(false);
            }
        }

        public static T As<T>(object value, string parameterName) where T : class
        {
            var castObejct = value as T;
            if (castObejct == null)
            {
                throw new ArgumentException(string.Format("{0} should be an object of {1} type", parameterName, typeof(T).Name));
            }

            return castObejct;
        }

        public static void That<T>(T obj, Func<T, bool> condition, string errorMessageOtherwise)
        {
            if (!condition.Invoke(obj))
            {
                throw new ArgumentException(errorMessageOtherwise);
            }
        }
    }
}