﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMSPruebasNube.reservaWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="reservaWS.IReservaEquipo")]
    public interface IReservaEquipo {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservaEquipo/RegistrarPrestamo", ReplyAction="http://tempuri.org/IReservaEquipo/RegistrarPrestamoResponse")]
        string RegistrarPrestamo(string cliente, string equipo, string usuario, string motivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservaEquipo/RegistrarPrestamo", ReplyAction="http://tempuri.org/IReservaEquipo/RegistrarPrestamoResponse")]
        System.Threading.Tasks.Task<string> RegistrarPrestamoAsync(string cliente, string equipo, string usuario, string motivo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReservaEquipoChannel : DMSPruebasNube.reservaWS.IReservaEquipo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReservaEquipoClient : System.ServiceModel.ClientBase<DMSPruebasNube.reservaWS.IReservaEquipo>, DMSPruebasNube.reservaWS.IReservaEquipo {
        
        public ReservaEquipoClient() {
        }
        
        public ReservaEquipoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReservaEquipoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReservaEquipoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReservaEquipoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RegistrarPrestamo(string cliente, string equipo, string usuario, string motivo) {
            return base.Channel.RegistrarPrestamo(cliente, equipo, usuario, motivo);
        }
        
        public System.Threading.Tasks.Task<string> RegistrarPrestamoAsync(string cliente, string equipo, string usuario, string motivo) {
            return base.Channel.RegistrarPrestamoAsync(cliente, equipo, usuario, motivo);
        }
    }
}