﻿using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    [Alias("mkdir")]
    class MakeDirectoryCommand:Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string folderName = this.Data[1];
                this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);

            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
