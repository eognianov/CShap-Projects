﻿using System;
using System.Linq;
using System.Reflection;

namespace Forum.App.Factories
{
	using Contracts;

	public class CommandFactory : ICommandFactory
	{
	    private IServiceProvider serviceProvider;

	    public CommandFactory(IServiceProvider serviceProvider)
	    {
	        this.serviceProvider = serviceProvider;
	    }

		public ICommand CreateCommand(string commandName)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
		    Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

		    if (commandType==null)
		    {
		        throw new ArgumentException($"{commandName}Command not found!");
		    }

		    if (!typeof(ICommand).IsAssignableFrom(commandType))
		    {
		        throw new InvalidOperationException($"{commandName}Command is not an ICommand!");
		    }

		    ParameterInfo[] ctorParams = commandType.GetConstructors().First().GetParameters();

            object[] arguments = new object[ctorParams.Length];

		    for (int i = 0; i < arguments.Length; i++)
		    {
		        arguments[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
		    }

		    ICommand command = (ICommand) Activator.CreateInstance(commandType, arguments);

		    return command;
		}
	}
}
