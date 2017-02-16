/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 07/03/2016
 * Time: 19:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace RESTFulDemo
{
	/// <summary>
	/// Description of Person.
	/// </summary>
	[DataContract]
	public class Person
	{
		[DataMember]
		public string ID;
		[DataMember]
		public string Name;
		[DataMember]
		public string Age;
	}
}
