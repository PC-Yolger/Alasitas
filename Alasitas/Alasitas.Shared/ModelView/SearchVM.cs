using Alasitas.Model;
using Alasitas.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alasitas.ModelView
{
    public class SearchVM : NotificationService
    {
        private List<Asociacion> _asociacion;
        public List<Asociacion> Asociacion
        {
            get { return _asociacion; }
            set { SetProperty(ref _asociacion, value); }
        }

        private List<string> _producto;
        public List<string> Producto
        {
            get
            {
                return _producto;
            }
            set { SetProperty(ref _producto, value); }
        }

        private string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                SetProperty(ref _search, value);
                GetSearch();
            }
        }

        public SearchVM()
        {
        }

        private async void GetSearch()
        {
            if (_search != null && _search.Length > 0)
            {
                Asociacion = await DataModel.Service.GetSearchAssociation(Search);
            }
            else
                Asociacion = null;
            Producto = await DataModel.Service.GetProducts(Search);
        }
    }
}
