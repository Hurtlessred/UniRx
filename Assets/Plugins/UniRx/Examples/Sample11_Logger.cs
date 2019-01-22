﻿using System;
using System.Collections;
using exiii.Unity.Rx.Diagnostics;
using UnityEngine;

namespace exiii.Unity.Rx.Examples
{
    public class Sample11_Logger
    {
        // exiii.Unity.Rx.Diagnostics.Logger
        // logger is threadsafe, define per class with name.
		static readonly exiii.Unity.Rx.Diagnostics.Logger logger = new exiii.Unity.Rx.Diagnostics.Logger("Sample11");

        // call once at applicationinit
        public void ApplicationInitialize()
        {
            // Log as Stream, exiii.Unity.Rx.Diagnostics.ObservableLogger.Listener is IObservable<LogEntry>
            // You can subscribe and output to any place.
            ObservableLogger.Listener.LogToUnityDebug();

            // for example, filter only Exception and upload to web.
            // (make custom sink(IObserver<EventEntry>) is better to use)
            ObservableLogger.Listener
                .Where(x => x.LogType == LogType.Exception)
                .Subscribe(x =>
                {
                    // ObservableWWW.Post("", null).Subscribe();
                });
        }

        public void Run()
        {
            // Debug is write only DebugBuild.
            logger.Debug("Debug Message");

            // or other logging methods
            logger.Log("Message");
            logger.Exception(new Exception("test exception"));
        }
    }
}