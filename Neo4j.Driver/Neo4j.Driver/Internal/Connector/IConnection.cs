﻿// Copyright (c) 2002-2017 "Neo Technology,"
// Network Engine for Objects in Lund AB [http://neotechnology.com]
// 
// This file is part of Neo4j.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System;
using System.Collections.Generic;
using Neo4j.Driver.Internal.Result;
using Neo4j.Driver.V1;

namespace Neo4j.Driver.Internal.Connector
{
    internal interface IConnection : IDisposable
    {
        void Init();
        // send all and receive all
        void Sync();
        // send all
        void Send();
        // receive one
        void ReceiveOne();

        // Enqueue a run message, and a pull_all message if pullAll=true, otherwise a discard_all message 
        void Run(string statement, IDictionary<string, object> parameters = null, IMessageResponseCollector resultBuilder = null, bool pullAll = true);

        // Enqueue a reset message
        void Reset();
        // Enqueue a ackFailure message
        void AckFailure();

        /// <summary>
        /// Close and release related resources
        /// </summary>
        void Close();

        /// <summary>
        /// Return true if the underlying socket connection is till open, otherwise false.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// The info of the server the connection connected to.
        /// </summary>
        IServerInfo Server { get; }
    }
}