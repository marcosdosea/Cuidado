using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IAtividadeExternaService
	{
		uint Create(Atividadeexterna atividadeExterna);
		void Edit(Atividadeexterna atividadeExterna);
		void Delete(int id);
		Atividadeexterna? Get(int id);
	}
}
