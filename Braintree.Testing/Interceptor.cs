using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
                    let match = t.Match(args)
                    where match > 0
                    orderby match descending
                    select t.Invoke(args)

                ).FirstOrDefault();
        }

        public void Verify() {
            var failed = (from t in _targets
                          let v = t.Verify()
                          where !v.IsSuccessful
                          select v)
                .ToArray();
            if(!failed.Any()) {
                return;
            }
            throw new InvocationVerificationException(failed);
        }
    }

    public class InvocationVerificationException : Exception {
        public readonly InvocationVerification[] Failures;

        public InvocationVerificationException(InvocationVerification[] failures) {
            Failures = failures;
        }

        public override string Message {
            get {
                var sb = new StringBuilder();
                sb.AppendLine("Gateway verification failed:");
                foreach(var failure in Failures) {
                    sb.AppendLine("  " + failure.FailureMessage);
                }
                return sb.ToString();
            }
        }
    }
}