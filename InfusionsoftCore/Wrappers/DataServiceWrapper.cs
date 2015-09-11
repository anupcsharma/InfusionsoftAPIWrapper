﻿#region License

// Copyright (c) 2012, EventDay
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfusionsoftCoreLibrary
{
	internal partial class DataServiceWrapper : ServiceBase<IDataServiceDefinition>, IDataService
	{

		public DataServiceWrapper(IInfusionsoftConfiguration configuration, IMethodListenerProvider listenerProvider) :
			base(configuration, listenerProvider)
		{
		}

		public virtual int Add(string table, System.Collections.IDictionary values)
		{
			return Invoke(d => d.Add(ApiKey, table, values));
		}

		public virtual object Load(string table, int recordId, string[] wantedFields)
		{
			return Invoke(d => d.Load(ApiKey, table, recordId, wantedFields));
		}

		public virtual int Update(string table, int id, object values)
		{
			return Invoke(d => d.Update(ApiKey, table, id, values));
		}

		public virtual bool Delete(string table, int id)
		{
			return Invoke(d => d.Delete(ApiKey, table, id));
		}

		public virtual System.Collections.Generic.IEnumerable<object> FindByField(string table, int limit, int page, string fieldName, object fieldValue, string[] returnFields)
		{
			return Invoke(d => d.FindByField(ApiKey, table, limit, page, fieldName, fieldValue, returnFields));
		}

		public virtual System.Collections.Generic.IEnumerable<object> Query(string table, int limit, int page, System.Collections.IDictionary queryData, string[] selectedFields)
		{
			return Invoke(d => d.Query(ApiKey, table, limit, page, queryData, selectedFields));
		}

		public virtual System.Collections.Generic.IEnumerable<object> Query(string table, int limit, int page, System.Collections.IDictionary queryData, string[] selectedFields, string orderBy, bool asc)
		{
			return Invoke(d => d.Query(ApiKey, table, limit, page, queryData, selectedFields, orderBy, asc));
		}

		public virtual int AddCustomField(string customFieldType, string displayName, string dataType, int headerId)
		{
			return Invoke(d => d.AddCustomField(ApiKey, customFieldType, displayName, dataType, headerId));
		}

		public virtual int AuthenticateUser(string username, string passwordHash)
		{
			return Invoke(d => d.AuthenticateUser(ApiKey, username, passwordHash));
		}

		public virtual string GetAppSetting(string module, string setting)
		{
			return Invoke(d => d.GetAppSetting(ApiKey, module, setting));
		}

		public virtual string GetTemporaryKey(string username, string passwordHash)
		{
			return Invoke(d => d.GetTemporaryKey(ApiKey, username, passwordHash));
		}

		public virtual bool UpdateCustomField(int customFieldId, System.Collections.IDictionary values)
		{
			return Invoke(d => d.UpdateCustomField(ApiKey, customFieldId, values));
		}
	}
}