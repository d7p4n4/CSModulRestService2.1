
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using CSAc4yObjectService.Class;
using CSModulRestService2._1;
using d7p4n4Namespace.Final.Class;
using d7p4n4Namespace.PersistentService.Class;
using d7p4n4NamespaceApi.Controller.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace d7p4n4NamespaceApi.Controller.Class
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class TaroltEljarasRestService : ControllerBase
    {

        private readonly MSSQLLogin _MSSQLLogin;

		private string serverName { get; set; }
        private string baseName { get; set; }
        private string userName { get; set; }
        private string password { get; set; }
		private TaroltEljarasPersistentService _TaroltEljarasPersistentService;
		
        public TaroltEljarasRestService(IOptions<MSSQLLogin> MSSQLLogin)
        {
            _MSSQLLogin = MSSQLLogin.Value;
			serverName = _MSSQLLogin.serverName;
            baseName = _MSSQLLogin.baseName;
            userName = _MSSQLLogin.userName;
            password = _MSSQLLogin.password;
			
            _TaroltEljarasPersistentService = new TaroltEljarasPersistentService(serverName, baseName, userName, password);
        }

		[HttpGet("{id}")]
        public GetObjectResponse GetFirstById(int id)
        {
            return _TaroltEljarasPersistentService.GetFirstById(id);
        }

        [HttpGet("{id}")]
        public GetObjectResponse GetFirstWithXML(int id)
        {
            return _TaroltEljarasPersistentService.GetFirstWithXML(id);
		}

        [HttpPost]
        public GetObjectResponse Save(TaroltEljaras _TaroltEljaras)
        {
            return _TaroltEljarasPersistentService.Save(_TaroltEljaras);
        }

        [HttpPost]
        public GetObjectResponse SaveWithXml(TaroltEljaras _TaroltEljaras)
        {
            return _TaroltEljarasPersistentService.SaveWithXml(_TaroltEljaras);
        }
    }
}
