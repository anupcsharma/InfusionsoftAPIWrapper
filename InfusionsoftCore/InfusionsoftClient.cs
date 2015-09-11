#region License

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

namespace InfusionsoftCoreLibrary
{
	internal class InfusionsoftClient : IInfusionsoftClient, IMethodListenerProvider
	{
		private IMethodListener _methodListener;

		public InfusionsoftClient(IInfusionsoftConfiguration configuration)
		{
			Configuration = configuration;
			AccessToken = configuration.AccessToken;
			MethodListener = new NullMethodListener();

			ContactService = new ContactServiceWrapper(configuration, this);
			DataService = new CustomDataServiceWrapper(configuration, this);
			EmailService = new EmailServiceWrapper(configuration, this);
		}
		public IContactService ContactService { get; private set; }

		public IDataService DataService { get; private set; }

		public IEmailService EmailService { get; private set; }

		public string AccessToken { get; private set; }

		public IMethodListener MethodListener
		{
			get { return _methodListener; }
			set
			{
				if (value == null)
					_methodListener = new NullMethodListener();
				_methodListener = value;
			}
		}

		public IInfusionsoftConfiguration Configuration { get; private set; }
		IMethodListener IMethodListenerProvider.GetListener()
		{
			return MethodListener;
		}
	}
}
