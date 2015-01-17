using Alasitas.Model;
using Alasitas.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alasitas.ModelView
{
    public class AssociationVM : NotificationService
    {
        private List<Sector> _sectores;
        public List<Sector> Sectores
        {
            get { return _sectores; }
            set { SetProperty(ref _sectores, value); }
        }

        public AssociationVM()
        {
            GetSectores();
        }

        private async void GetSectores()
        {
            Sectores = await DataModel.Service.GetSectors();
        }
    }
}
