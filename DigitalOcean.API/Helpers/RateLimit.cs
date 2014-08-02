﻿using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace DigitalOcean.API.Helpers {
    public class RateLimit : IRateLimit {
        /// <summary>
        /// The number of requests that can be made per hour.
        /// </summary>
        public int Limit { get; private set; }

        /// <summary>
        /// The number of requests that remain before you hit your request limit.
        /// </summary>
        public int Remaining { get; private set; }

        /// <summary>
        /// This represents the time when the oldest request will expire. The value is given in Unix epoch time.
        /// </summary>
        public int Reset { get; private set; }

        public RateLimit(IList<Parameter> headers) {
            Limit = GetHeaderValue(headers, "RateLimit-Limit");
            Remaining = GetHeaderValue(headers, "RateLimit-Remaining");
            Reset = GetHeaderValue(headers, "RateLimit-Reset");
        }

        private static int GetHeaderValue(IEnumerable<Parameter> headers, string name) {
            var header = headers.FirstOrDefault(x => x.Name == name);
            int value;
            return header != null && int.TryParse(header.Value.ToString(), out value) ? value : 0;
        }
    }
}