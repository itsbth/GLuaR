#region Licences
//    Copyright (C) 2005  Sebastian Faltoni <sebastian@dotnetfireball.net>
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
#endregion Licences


using System;
using System.Collections;

namespace Fireball.Ssh.java.util
{
	/// <summary>
	/// Summary description for Vector.
	/// </summary>
	public class Vector : ArrayList
	{
		public int size()
		{
			return this.Count;
		}

		public void addElement(object o)
		{
			this.Add(o);
		}

		public void removeElement(object o)
		{
			this.Remove(o);
		}

		public bool remove(object o)
		{
			this.Remove(o);
			return true;
		}

		public object elementAt(int i)
		{
			return this[i];
		}
	}
}
