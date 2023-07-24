﻿global using _Architecture.Domain.Abstractions;
global using _Architecture.Domain.Interfaces;
global using _Architecture.Domain.ValueObjects;
global using _Architecture.Infrastructure.Abstractions;
global using _Architecture.Infrastructure.Connections;
global using _Architecture.Infrastructure.Enums;
global using _Architecture.Infrastructure.Evaluators;
global using _Architecture.Infrastructure.EventsLog;
global using _Architecture.Infrastructure.Extensions;
global using _Architecture.Infrastructure.Interfaces;
global using _Architecture.Infrastructure.TypeMaps;
global using Amazon;
global using Amazon.Runtime;
global using Amazon.SimpleNotificationService;
global using Amazon.SQS;
global using AwsConfiguration;
global using AwsConfiguration.Interfaces;
global using EventBus.Events;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Npgsql;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Data;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Transactions;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using _Architecture.Infrastructure.Interceptors;