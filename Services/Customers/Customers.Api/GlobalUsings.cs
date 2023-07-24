﻿global using _Architecture.Api.Abstractions;
global using _Architecture.Domain.ValueObjects;
global using AutoMapper;
global using Customers.Application;
global using Customers.Application.CustomerOrders._Commons.ViewModels;
global using Customers.Application.CustomerOrders.Commands.CancelCustomerOrder;
global using Customers.Application.CustomerOrders.Commands.CreateCustomerOrder;
global using Customers.Application.CustomerOrders.Commands.DelivereCustomerOrder;
global using Customers.Application.Customers._Commons;
global using Customers.Application.Customers.Commands.CreateCustomers;
global using Customers.Application.Customers.Commands.DeleteCustomers;
global using Customers.Application.Customers.Commands.UpdateCustomers;
global using Customers.Application.Customers.Queries.GetCustomerById;
global using Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;
global using Customers.Application.Customers.Queries.GetCustomers;
global using Customers.Domain;
global using Customers.Domain.CustomerOrders.Entities;
global using Customers.Domain.Customers.Entities;
global using Customers.Infrastructure;
global using Customers.Infrastructure.Customers.Queries;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using System.Net;
global using _Architecture.Infrastructure.Enums;
global using _Architecture.Application.Responses;
global using _Architecture.Api.Swaggers.Exemples;