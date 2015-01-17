using Alasitas.Model;
using Alasitas.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Alasitas.ModelView
{
    public class HistoryVM : NotificationService
    {
        private List<Parrafo> _historia;
        public List<Parrafo> Historia
        {
            get { return _historia; }
            set { SetProperty(ref _historia, value); }
        }

        public HistoryVM()
        {
            GetHistory();
        }

        public async void GetHistory()
        {
            Historia = await DataModel.Service.GetHistory();

        }
    }
}
