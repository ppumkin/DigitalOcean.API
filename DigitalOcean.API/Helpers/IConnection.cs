﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace DigitalOcean.API.Helpers {
    public interface IConnection {
        IRestClient Client { get; }
        IRateLimit Rates { get; }

        Task<T> GetRequest<T>(string endpoint, IList<Parameter> parameters, string expectedRoot = null) where T : new();
        Task<IRestResponse> GetRequestRaw(string endpoint, IList<Parameter> parameters);
    }
}