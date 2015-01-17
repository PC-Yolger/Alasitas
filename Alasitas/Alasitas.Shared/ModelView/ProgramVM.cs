using Alasitas.Model;
using Alasitas.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alasitas.ModelView
{
    public class ProgramVM : NotificationService
    {
        private List<Evento> _program;
        public List<Evento> Program
        {
            get { return _program; }
            set { SetProperty(ref _program, value); }
        }

        public ProgramVM()
        {
            GetProgram();
        }

        public async void GetProgram()
        {
            Program = await DataModel.Service.GetProgram();
        }
    }
}
