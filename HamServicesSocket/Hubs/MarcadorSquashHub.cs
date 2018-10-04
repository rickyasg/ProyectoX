using System;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using HamServicesSocket.Models;
using System.Threading.Tasks;
using HamScoreboardModel;

namespace HamServicesSocket.Hubs
{
    [HubName("MarcadorSquashHub")]
    public class MarcadorSquashHub : Hub
    {
        private readonly static ActionUsers<string> _connections = new ActionUsers<string>();
        private readonly static ActionUsers<string> _groups = new ActionUsers<string>();

        public void ControlCronometro(bool estado)
        {
            Clients.All.HandleControlCronometro(estado);
        }

        #region winforms ya no se usa
        public void ActualizarMarcador(SBsquash value)
        {
            Clients.All.HandleActualizarMarcador(value);
        }

        public void actualizarVisor(string tipo, Object mensaje, string group)
        {
            string[] list = _connections.GetConnections(tipo).ToArray();
            if (tipo.Trim() != "all" && tipo.Trim() != "")
                Clients.Client(list[0]).devuelveVisor(mensaje);
            else
                Clients.Group(group).devuelveVisor(mensaje);
        }
        #endregion

        public void CleanEvento(Object value)
        {
            Clients.All.HandleCleanEvento(value);
        }

        public void PeriodoEvent(Object value)
        {
            Clients.All.HandleActualizarPeriodo(value);
        }
        public void cronometroEvent(string tiempo)
        {
            Clients.All.HandleCronometro(tiempo);
        }

        public void cronometroDescuentoEvent(string tiempo)
        {
            Clients.All.HandleDescuento(tiempo);
        }
        public void TablaPeriodosEvent(object periodos)
        {
            Clients.All.HandleTablaPeriodos(periodos);
        }
        public void ChangeVisor(Object value)
        {
            Clients.All.HandleChangeVisor(value);
        }

        public void controlPantalla(string nameUser, string group)
        {
            string[] pantallas = _groups.GetConnections("squash").ToArray();
            string[] names = _groups.GetConnections("remotoSquash").ToArray();
            foreach (var item in names)
            {
                string[] ids = _connections.GetConnections(item).ToArray();
                foreach (var id in ids)
                {
                    Clients.Client(id).addPantalla(pantallas);
                }
            }
        }

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
            controlPantalla("sq", "grupoSquash");

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