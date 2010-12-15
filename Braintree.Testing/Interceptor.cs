using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Braintree.Testing {
    internal class Interceptor : ICallbackProvider {
        private readonly List<InvocationTarget> _targets = new List<InvocationTarget>();

        public void AddInvocationTarget(InvocationTarget target) {
            _targets.Add(target);
        }

        T ICallbackProvider.Invoke<T>(params object[] args) {
            var value = Invoke(args);
            return value == null ? default(T) : (T)value;
        }

        void ICallbackProvider.Invoke(params object[] args) {
            Invoke(args);
        }

        private object Invoke(params object[] args) {
            var frame = new System.Diagnostics.StackFrame(2, false);
            var method = frame.GetMethod();
            return (from t in _targets
                    // Note: string signature comparison of methodinfo is cheesy
                    where t.Method.ToString() == method.ToString()
                          && t.Match(args)
                    select t.Invoke(args)
                ).FirstOrDefault();
        }
    }
}