using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuickTour.Models
{
    #region Transient
    public interface ITransient { 
        void WriteGuidToConsole();
    }
    public class TransientDependency : ITransient
    {
        Guid guid;
        ILogger<ITransient> logger;
        public TransientDependency(ILogger<ITransient> logger)
        {
            this.logger = logger;
            logger.LogInformation("transient constructed");
            guid = Guid.NewGuid();
        }
        public void WriteGuidToConsole()
        {
            logger.LogInformation($"Transient    : {guid}, thread={System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
    #endregion 

    #region Scoped
    public interface IScoped
    {
        void WriteGuidToConsole();
    }
    public class ScopedDependency : IScoped
    {
        Guid guid;
        ILogger<IScoped> logger;
        public ScopedDependency(ILogger<IScoped> logger)
        {
            this.logger = logger;
            logger.LogInformation("scoped constructed");
            guid = Guid.NewGuid();
        }
        public void WriteGuidToConsole()
        {
            logger.LogInformation($"Scoped    : {guid}, thread={System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
    #endregion

    #region Singleton
    public interface ISingleton
    {
        void WriteGuidToConsole();
    }
    public class SingletonDependency : ISingleton
    {
        Guid guid;
        ILogger<ISingleton> logger;
        public SingletonDependency(ILogger<ISingleton> logger)
        {
            this.logger = logger;
            logger.LogInformation("singleton constructed");
            guid = Guid.NewGuid();
        }
        public void WriteGuidToConsole()
        {
            logger.LogInformation($"Singleton : {guid}, thread={System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
    #endregion

    #region Action Injection
    public interface IActionInjection
    {
        void WriteGuidToConsole();
    }
    public class ActionInjectionDependency : IActionInjection
    {
        Guid guid;
        ILogger<IActionInjection> logger;
        public ActionInjectionDependency(ILogger<IActionInjection> logger)
        {
            this.logger = logger;
            logger.LogWarning("action injection depdendency constructed");
            guid = Guid.NewGuid();
        }
        public void WriteGuidToConsole()
        {
            logger.LogWarning($"Action Injection    : {guid}, thread={System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
    #endregion 
}
