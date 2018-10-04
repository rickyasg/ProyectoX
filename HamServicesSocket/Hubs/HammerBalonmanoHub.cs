using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using HamServicesSocket.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using HamScoreboardModel;

namespace HamServicesSocket.Hubs
{
    [HubName("HammerBalonmanoHub")]
    public class HammerBalonmanoHub : Hub
    {
        private readonly static ActionUsers<string> _connections = new ActionUsers<string>();
        private readonly static ActionUsers<string> _groups = new ActionUsers<string>();

        public void ActualizarMarcador(Object value)
        {
            Clients.All.HandleActualizarMarcador(value);
        }

        public void ActualizarAccion(Object value)
        {
            Clients.All.HandleActualizarAccion(value);
        }

        public void ActualizarPeriodo(Object value)
        {
            Clients.All.HandleActualizarPeriodo(value);
        }

        public void Hello(string nameUser, string nameGroup)
        {
            string[] list = _connections.GetConnections(nameUser).ToArray();
            Clients.Group(nameGroup).SetGroups("hola");
            Clients.Client(list[0]).hello();
            //Clients.Group("nombreGrupo").porsiacaso();
        }
        #region codesur
        public void ControlCodesur(string name, string grupo)
        {
            string[] list = _connections.GetConnections(name).ToArray();
            string[] group1 = _groups.GetConnections(grupo).ToArray();
            Clients.Group(grupo).controlPantalla(group1);
        }

 
        #endregion




        #region pantalla
        public void controlPantalla(string nameUser, string group)
        {
            string[] list = _connections.GetConnections(nameUser).ToArray();
            string[] group1 = _groups.GetConnections(group).ToArray();
            Clients.Group("resultados").controlPantalla(group1);

        }
        public void disconnectedPantalla(string group)
        {
            OnDisconnected(true);
            string[] group1 = _groups.GetConnections(group).ToArray();
            Clients.Group("resultados").controlPantalla(group1);
        }
        public void send(string pantalla, object parametros)
        {
            string[] list = _connections.GetConnections(pantalla).ToArray();
            if (pantalla.Trim() != "all" && pantalla.Trim() != "")
                Clients.Client(list[0]).setAccion(parametros);
            else
                Clients.Group("resultados").setAccion(parametros);
        }

        public void sendTexto(string pantalla, string mensaje)
        {
            string[] list = _connections.GetConnections(pantalla).ToArray();
            if (pantalla.Trim() != "all" && pantalla.Trim() != "")
                Clients.Client(list[0]).setMensaje(mensaje);
            else
                Clients.Group("resultados").setMensaje(mensaje);
        }
        public object setAccion(object parametros)
        {
            return parametros;
        }
        public string setMensaje(string mensaje)
        {
            return mensaje;
        }
        public string setDesconectado(string pantalla)
        {
            return pantalla;
        }
        #endregion

        #region control de marcador
        public void bloquearIniciar(string nameUser, string group)
        {
            string[] list = _connections.GetConnections(nameUser).ToArray();
            string[] group1 = _groups.GetConnections(group).ToArray();
            Clients.Group(group).bloquearIniciar(group1);
        }

        public void playClientes(string tipo, string mensaje, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();

            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).DevolverGrupos(mensaje);
            else
                Clients.Group(group).DevolverGrupos(mensaje);
        }

        public void insertarAdicion(string tipo, int adicion, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();

            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).DevolverAdicion(adicion);
            else
                Clients.Group(group).DevolverAdicion(adicion);
        }
        public void seleccionarParametro(string tipo, Object parametros, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).DevolverParametro(parametros);
            else
                Clients.Group(group).DevolverParametro(parametros);
        }
        public void seleccionarPosesion(string tipo, string mensaje, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).DevolverPosesion(mensaje);
            else
                Clients.Group(group).DevolverPosesion(mensaje);
        }
        public void actualizarVisor(string tipo, Object mensaje, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).devuelveVisor(mensaje);
            else
                Clients.Group(group).devuelveVisor(mensaje);
        }
        public void actualizarAccion(string tipo, Object mensaje, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).devuelveVisor(mensaje);
            else
                Clients.Group(group).devuelveVisor(mensaje);
        }

   
        public void actualizarParametro(string tipo, Object mensaje, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).DevolverActParametros(mensaje);
            else
                Clients.Group(group).DevolverActParametros(mensaje);
        }
        public string DevolverGrupos(string mensaje)
        {
            return mensaje;
        }
        public int DevolverAdicion(int adicion)
        {
            return adicion;
        }
        public Object DevolverParametro(Object parametros)
        {
            return parametros;
        }
        public string DevolverPosesion(string posesion)
        {
            return posesion;
        }
        public Object devuelveVisor(Object visor)
        {
            return visor;
        }
        public Object DevolverActParametros(Object act)
        {
            return act;
        }
        #endregion

        #region golf visor

        public void controlGolfVisor(string nameUser, string group)
        {
            string[] list = _connections.GetConnections(nameUser).ToArray();
            string[] group1 = _groups.GetConnections(group).ToArray();
            Clients.Group(group).controlGolfVisor(group1);
        }

        public void mostrarDatos(string tipo, Object datos, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).devuelveDatos(datos);
            else
                Clients.Group(group).devuelveDatos(datos);
        }

        public void actualizarGridDatos(string tipo, string actualizar, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).devuelveGrid(actualizar);
            else
                Clients.Group(group).devuelveGrid(actualizar);
        }

        public void devuelveScrollDatos(string tipo, string actualizar, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).devuelveScroll(actualizar);
            else
                Clients.Group(group).devuelveScroll(actualizar);
        }

        public void devuelveHandyDatos(string tipo, string handy, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).devuelveHandy(handy);
            else
                Clients.Group(group).devuelveHandy(handy);
        }

        public Object devuelveDatos(Object datos)
        {
            return datos;
        }

        public string devuelveGrid(string datos)
        {
            return datos;
        }

        public string devuelveScroll(string datos)
        {
            return datos;
        }
        public string devuelveHandy(string datos)
        {
            return datos;
        }

        #endregion
        #region ConnectDisconnect
        public override Task OnConnected()
        {
            var name = Context.QueryString["name"];
            var grupo = Context.QueryString["group"];
            _connections.Add(name, Context.ConnectionId);
            _groups.Add(grupo, name);
            Groups.Add(Context.ConnectionId, grupo);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            var name = Context.QueryString["name"];
            var grupo = Context.QueryString["group"];
            _connections.Remove(name, Context.ConnectionId);
            _groups.RemoveFromGroup(grupo, name);

            string[] group1 = _groups.GetConnections(grupo).ToArray();

            //Clients.Group("resultados").controlPantalla(group1);
          

            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            var name = Context.QueryString["name"];
            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }
            return base.OnReconnected();
        }

        public void GetGroups(string nameUser, string group)
        {
            string[] list = _connections.GetConnections(nameUser).ToArray();
            string[] group1 = _groups.GetConnections(group).ToArray();
            Clients.Client(list[0]).SetGroups(group1);
        }
        #endregion

    }
}