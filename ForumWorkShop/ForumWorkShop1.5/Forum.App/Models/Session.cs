﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.Models
{
	using Contracts;
	using DataModels;

	public class Session : ISession
	{
	    private User user;
	    private Stack<IMenu> history;

	    public Session()
	    {
	        this.history = new Stack<IMenu>();
	    }

	    public string Username => this.user?.Username;

	    public int UserId => this.user?.Id ?? 0;

	    public bool IsLoggedIn => this.user != null;

		public IMenu CurrentMenu => this.history.Peek();

		public IMenu Back()
		{
		    if (history.Count>1)
		    {
		        this.history.Pop();
		    }

		    this.CurrentMenu.Open();
		    return this.CurrentMenu;
		}

		public void LogIn(User user)
		{
		    this.user = user;
		}

		public void LogOut()
		{
		    this.user = null;
		}

		public bool PushView(IMenu view)
		{
		    if (!this.history.Any() || this.history.Peek()!=view)
		    {
		        this.history.Push(view);
		        return true;
		    }

		    return false;
		}

		public void Reset()
		{
			this.history = new Stack<IMenu>();
            this.user = null;
		}
	}
}
