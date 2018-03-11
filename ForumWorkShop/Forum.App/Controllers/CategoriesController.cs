﻿using System.Linq;
using Forum.App.Services;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using System;

    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class CategoriesController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public CategoriesController()
        {
            this.CurrentPage = 0;
            this.LoadCategories();
        }

        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviusPage = 11,
            NextPage = 12
        }

        private string[] AllCategoryNames { get; set; }

        private string[] CurrentPageCategories { get; set; }

        private int LastPage => this.AllCategoryNames.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => this.CurrentPage == 0;

        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public int CurrentPage { get; set; }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
        }

        private void LoadCategories()
        {
            this.AllCategoryNames = PostService.GetAllCategoryNames();

            this.CurrentPageCategories =
                this.AllCategoryNames.Skip(this.CurrentPage * PAGE_OFFSET).Take(PAGE_OFFSET).ToArray();
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index>1&&index<11)
            {
                index = 1;
            }

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                    
                case Command.ViewCategory:
                    return MenuState.OpenCategory;
                    
                case Command.PreviusPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;
                    
                case Command.NextPage:
                    this.ChangePage();
                    return MenuState.Rerender;
                    
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            LoadCategories();
            return new CategoriesView(this.CurrentPageCategories, this.IsFirstPage, this.IsLastPage);
        }
    }
}
