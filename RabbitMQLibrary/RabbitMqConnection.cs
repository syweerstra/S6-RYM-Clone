﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace RabbitMQLibrary
{
    /// <summary>
    /// Singleton service keeping track of our connection with RabbitMQ.
    /// </summary>
    public class RabbitMqConnection : IDisposable
    {
        private IConnection _connection;
        public IModel CreateChannel()
        {
            var connection = GetConnection();
            return connection.CreateModel();
        }

        private IConnection GetConnection()
        {
            if (_connection == null)
            {
                var factory = new ConnectionFactory
                {
                    UserName = "guest",
                    Password = "guest",
                    Port = AmqpTcpEndpoint.UseDefaultPort,
                    AutomaticRecoveryEnabled = true
                };
                var endpoints = new List<AmqpTcpEndpoint>
                {
                          new AmqpTcpEndpoint("rabbitmq"),
                          new AmqpTcpEndpoint("rabbitmq:15672"),
                          new AmqpTcpEndpoint("rabbitmq:5672"),
                          new AmqpTcpEndpoint("localhost"),
                          new AmqpTcpEndpoint("localhost:15672"),
                          new AmqpTcpEndpoint("localhost:5672"),
                          new AmqpTcpEndpoint("rabbit@my-rabbit"),
                          new AmqpTcpEndpoint("production-rabbitmqcluster-server-0")
                };
                _connection = factory.CreateConnection(endpoints);
            }

            return _connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
