using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IVisitaService
	{
		uint Create(Visitum visita);
		void Edit(Visitum visita);
		void Delete(int id);
		Visitum? Get(int id);
	}
}
