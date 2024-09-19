using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IOrganizacaoService
	{
		uint Create(Organizacao organizacao);
		void Edit(Organizacao organizacao);
		void Delete(int id);
		Organizacao? Get(int id);
	}
}
