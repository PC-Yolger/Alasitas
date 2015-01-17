using Alasitas.Model;
using Alasitas.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using System.Linq;

namespace Alasitas.DataModel
{
    public class Service
    {
        private static Service service = new Service();

        private Alasita _alasita;
        public Alasita alasita
        {
            get { return _alasita; }
        }

        // Obtiene una lista de Parrafos
        public static async Task<List<Parrafo>> GetHistory()
        {
            await service.GetServiceAsync();
            return service.alasita.Historia;
        }

        // Obtiene una lista de los Sectors, con sus respectivas asociaciones y productos de cada asociación
        public static async Task<List<Sector>> GetSectors()
        {
            await service.GetServiceAsync();
            return service.alasita.Sector;
        }

        // Obtiene una lista de Asociaciones a partir de una cadena de referencia del producto a buscar
        public static async Task<List<Asociacion>> GetSearchAssociation(string cadena)
        {
            await service.GetServiceAsync();
            List<Asociacion> association = new List<Asociacion>();
            foreach (var _sec in service.alasita.Sector)
            {
                foreach (var _assoc in _sec.Asociaciones)
                {
                    foreach (var _prod in _assoc.Productos)
                    {
                        if (_prod.ToLower().Contains(cadena.ToLower()))
                        {
                            association.Add(_assoc);
                            break;
                        }
                    }
                }
            }
            return association;
        }

        // Obtiene una lista de productos a partir de una cadena de referencia del producto a buscar
        public static async Task<List<string>> GetProducts(string cadena)
        {
            await service.GetServiceAsync();
            List<string> productos = new List<string>();
            foreach (var _sec in service.alasita.Sector)
            {
                foreach (var _assoc in _sec.Asociaciones)
                {
                    foreach (var _prod in _assoc.Productos)
                    {
                        if (!productos.Contains(_prod) && _prod.ToLower().Contains(cadena.ToLower()))
                            productos.Add(_prod);
                    }
                }
            }
            productos = productos.OrderBy(item => item).ToList();
            return productos;
        }

        // Obtiene una lista con los eventos
        public static async Task<List<Evento>> GetProgram()
        {
            await service.GetServiceAsync();
            return service.alasita.Programa;
        }

        // Metodo asincrono que se ejecuta solo al comenzar la aplicación
        private async Task GetServiceAsync()
        {
            if (this._alasita != null)
                return;
            _alasita = new Alasita();
            Uri dataUri = new Uri("ms-appx:///DataModel/Alasita.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            // Define la historia
            List<Parrafo> historia = new List<Parrafo>();
            foreach (var item in jsonObject["Historia"].GetArray())
            {
                JsonObject temp = item.GetObject();
                Parrafo _parrafo = new Parrafo();
                _parrafo.texto = temp["Texto"].GetString();
                _parrafo.imagen = temp["Imagen"].GetString();
                historia.Add(_parrafo);
            }
            _alasita.Historia = historia;
            // Define los Sectores con sus determinadas Asociaciones y sus productos
            List<Sector> sectores = new List<Sector>();
            foreach (var item in jsonObject["Sectores"].GetArray())
            {
                JsonObject temp = item.GetObject();
                Sector sector = new Sector();
                sector.Inicial = temp["Inicial"].GetString();
                sector.Asociaciones = new List<Asociacion>();
                foreach (var value in temp["Asociaciones"].GetArray())
                {
                    JsonObject asoc = value.GetObject();
                    Asociacion asociacion = new Asociacion();
                    asociacion.Nombre = asoc["Nombre"].GetString();
                    asociacion.NroExpositores = asoc["NroExpositores"].GetString();
                    asociacion.Productos = new List<string>();
                    foreach (var prod in asoc["Productos"].GetArray())
                    {
                        asociacion.Productos.Add(prod.GetString());
                    }
                    sector.Asociaciones.Add(asociacion);
                }
                sectores.Add(sector);
            }
            _alasita.Sector = sectores;
            // Define el Programa
            List<Evento> evento = new List<Evento>();
            foreach (var item in jsonObject["Programa"].GetArray())
            {
                JsonObject temp = item.GetObject();
                Evento _evento = new Evento();
                _evento.FechaInicio = temp["Inicio"].GetString();
                _evento.FechaFin = temp["Fin"].GetString();
                _evento.Actividad = temp["Actividad"].GetString();
                _evento.Lugar = temp["Lugar"].GetString();
                _evento.HoraInicio = temp["HoraInicio"].GetString();
                _evento.HoraFin = temp["HoraFin"].GetString();
                _evento.Organizador = temp["Organizador"].GetString();
                evento.Add(_evento);
            }
            _alasita.Programa = evento;
        }
    }
}
